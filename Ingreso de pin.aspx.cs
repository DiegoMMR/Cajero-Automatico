﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Specialized;

using System.Data.SqlClient;

public partial class _Default : Page
{

   

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Response.Write(Request.QueryString["numero"]);
        }
       
    }

    public SqlCommand cmd;
    public DataTable dt;
    public SqlDataAdapter da;
    public SqlConnection cn;



    public void Conectar()
    {
        cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConeccion"].ConnectionString);
    }

    public void Abrir_cn()
    {
        try
        {
            if (cn.State == ConnectionState.Broken || cn.State == ConnectionState.Closed)
                cn.Open();
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    public void Cerrar_cn()
    {
        try
        {
            if (cn.State == ConnectionState.Open)
                cn.Close();
        }
        catch (Exception e)
        {
            throw (e);
        }
    }
    

    protected void Entrar_Click(object sender, System.EventArgs e)
    {

        string numero;
        int pin = 0;

        pinInvalido.Text = "";
        pin = Convert.ToInt32(pintext.Text);
        numero = Request.QueryString["numero"];

        Tarjeta _Tarjeta = new Tarjeta();
        Conectar();

        string codigo = "SELECT notarjeta, codcliente, estado, limite, pin FROM tarjetas  where notarjeta=" + numero + ";";
        //escribe el codigo para poder biscar los datos de la tarjeta

        cmd = new SqlCommand(String.Format(codigo), cn);

        Abrir_cn();
        //ejecuta un lector de datos
        SqlDataReader _reader = cmd.ExecuteReader();



        //ingresa lo leido en variables internas
        while (_reader.Read())
        {


            _Tarjeta.numero = _reader.GetString(0);
            _Tarjeta.CodCliente = _reader.GetInt32(1);
            _Tarjeta.estado = _reader.GetString(2);
            _Tarjeta.limite = _reader.GetInt32(3);
            _Tarjeta.pin = _reader.GetInt32(4);

        }



        Cerrar_cn();

        Response.Write("=" + _Tarjeta.numero + ", " + _Tarjeta.CodCliente + ", " + _Tarjeta.estado + ", " + _Tarjeta.limite + ", " + _Tarjeta.pin + ", " + pin + ", " + numero);

        int codigocliente = _Tarjeta.CodCliente;

        //analiza el pin ingresado con el pin real de la tarjeta
        if (pin == _Tarjeta.pin)
         {
             int conteo = 0;

             Response.Redirect("Menu.aspx?numero=" + numero + "&conteo=" + conteo + "&codCliente=" + codigocliente);             
             Server.Transfer("Menu.aspx", true);
         }
         else
         {
           
             pinInvalido.Text = "Pin Invalido";
         }


    }

    protected void Cancelar_Click(object sender, System.EventArgs e)
    {
        Server.Transfer("Ingreso de tarjeta.aspx", true);
    }


    
}