using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Banquetzal.app
{
    public partial class CerrarSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["cui"] = "";
            Session["nombres"] = "";
            Session["apellidos"] = "";
            Session["rol"] = "0";
            Session["usuario"] = "";
            Session["contrasena"] = "";
        }
    }
}