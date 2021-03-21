using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

namespace Prueba_1
{
    public partial class _Default : Page
    {
        //Declaracion de variables y objetos
        DataTable dtable = new DataTable();
        DataColumn dc;
        DataRow dr;

        LanderServices.User_WebServiceSoapClient usuariosRequest = new LanderServices.User_WebServiceSoapClient();
        LanderServices.UsuariosAplic[] usuarios;
        PropertyInfo[] Propiedades;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            dtable = ConsultarServicio();
            if (dtable != null)
            {
                GridView1.DataSource = dtable;
                GridView1.DataBind();
            }
            else
            {
                TextBox1.Text = "No hay información que mostrar.";
            }
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtable = ConsultarServicio();
            if (dtable != null)
            {
                GridView1.DataSource = dtable;
                GridView1.PageIndex = e.NewPageIndex;
                GridView1.DataBind();
            }
            else
            {
                TextBox1.Text = "No hay información que mostrar.";
            }
        }

        private DataTable ConsultarServicio()
        {
            //Identificacion dinamica de columnas
            Propiedades = typeof(LanderServices.UsuariosAplic).GetProperties();
            foreach (PropertyInfo Propiedad in Propiedades)
            {
                if (Propiedad.Name != "ExtensionData" && Propiedad.Name != "param" && Propiedad.Name != "Codigo")
                {
                    dc = new DataColumn(Propiedad.Name, Propiedad.PropertyType);
                    dtable.Columns.Add(dc);
                }
            }

            //Consumo de Servicio ListarUsuarios
            try
            {
                usuarios = usuariosRequest.ListarUsuarios("Prueba1", "Prueba1");
                foreach (LanderServices.UsuariosAplic usuario in usuarios)
                {
                    dr = dtable.NewRow();
                    foreach (PropertyInfo Propiedad in Propiedades)
                    {
                        if (Propiedad.Name != "ExtensionData" && Propiedad.Name != "param" && Propiedad.Name != "Codigo")
                        {
                            dr[Propiedad.Name] = usuario.GetType().GetProperty(Propiedad.Name).GetValue(usuario);
                        }
                    }
                    dtable.Rows.Add(dr);
                }
                return dtable;
            }
            catch (Exception ex)
            {
                TextBox1.Text = "Ocurrió un error al acceder al servicio. Consulte al administrador.";
                return null;
            }
        }
    }
}