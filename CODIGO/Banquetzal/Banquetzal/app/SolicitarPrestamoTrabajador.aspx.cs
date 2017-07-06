using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Banquetzal.app
{
    public partial class SolicitarPrestamoTrabajador : System.Web.UI.Page
    {
        ServicioWeb.ServicioWeb swjava = new ServicioWeb.ServicioWeb();
        ServicioWeb.modalidadPagoPrestamo[] listaModalidades;



        protected void Page_Load(object sender, EventArgs e)
        {
            //Verificar usuario loggeado

            int rol = Convert.ToInt32(Session["rol"]);
            if (rol < 0)
            {
                Response.Redirect("InicioCliente.aspx");
            }
            else if (rol == 0)
            {
                Response.Redirect("PaginaInicio.aspx");
            }
            else if (rol < 4)
            {
                Response.Redirect("TrabajadorSinPermisos.aspx");
            }


            if (!IsPostBack)
            {
                string[] listaTiposPrestamo = swjava.mostrarTiposPrestamo();
                listaModalidades = swjava.mostrarModalidadesPago();

                //Modalidades de pago
                ListItem item = new ListItem("--Seleccionar--", "-1");
                modalidad.Items.Add(item);
                for (int i = 0; i < listaModalidades.Length; i++)
                {
                    item = new ListItem(listaModalidades[i].nombre, listaModalidades[i].id.ToString());
                    modalidad.Items.Add(item);
                }


                //tipos de prestamo

                for (int i = 0; i < listaTiposPrestamo.Length; i++)
                {
                    tipo.Items.Add(listaTiposPrestamo[i]);
                }
            }
        }

        protected void Ingresar_Click(object sender, EventArgs e)
        {
            int modalidad = Convert.ToInt32(this.modalidad.SelectedValue);

            if (modalidad != -1)
            {
                long cui = Convert.ToInt64(this.cui.Text);
                double monto = Convert.ToInt64(this.monto.Text);
                int tipo = this.tipo.SelectedIndex + 1;


                bool solicitud = swjava.solicitarPrestamo(cui, monto, tipo, modalidad);

                if (solicitud)
                {
                    estado_Solicitud.Text = "Se ingreso la solicitud.";
                }
                else
                {
                    estado_Solicitud.Text = "Ocurrio un error al consultar la BD. " + modalidad + ", " + tipo;
                }
            }
            else
            {
                estado_Solicitud.Text = "Seleccione una modalidad de pago.";
            }


        }
    }
}