using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using clasesgenerales;
using business;
using System.Text;

namespace presentacion
{
    public partial class registrocurso : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            actualizar_tabla();
        }

        private void actualizar_tabla()
        {
            Lista_curso = conexion_business.obtenerListcurso();
            verlistacurso();
        }
        Class_business conexion_business = new Class_business();
        List<curso> Lista_curso = new List<curso>();
        private void verlistacurso()
        {

            Content_tabla_curso.Controls.Clear();
            StringBuilder enviar = new StringBuilder();

            foreach (var itemcurso in Lista_curso)
            {
                enviar.AppendFormat("<tr>" +
                    "<td>{0}</td>" +
                    "<td>{1}</td>" +
                    "<td>{2}</td></tr>", itemcurso.cod_curso, itemcurso.nombre, itemcurso.descripcion);

            }
            Content_tabla_curso.Controls.Add(new LiteralControl(enviar.ToString()));
        }
        private void limpiar()
        {
            txtCodcurso.Text = "";
            TxtNombre.Text = "";
            TxtDescripcion.Text = "";
            l_Codcurso.Text = "";
            l_nombre.Text = "";
            l_Descripcion.Text = "";

        }
        private void limpiar_label()
        {
            
            l_Codcurso.Text = "";
            l_nombre.Text = "";
            l_Descripcion.Text = "";

        }
        protected void registroClick(object sender, EventArgs e)
        {
            limpiar_label();
            if (TxtNombre.Text != "")
            {
                conexion_business.insertarCurso(TxtNombre.Text, TxtDescripcion.Text);
                limpiar();
                l_Descripcion.Text = "Registro Exitoso";               
                actualizar_tabla();
            }
            else
            {
                l_nombre.Text = "Este campo es obligatorio";
            }


        }

        protected void BuscarClick(object sender, EventArgs e)
        {
            limpiar_label();
            if (txtCodcurso.Text != "")
            {
                int contador = 0;
                int encontrado = -1;
                foreach (var itemcurso in Lista_curso)
                {
                    if (Convert.ToString(itemcurso.cod_curso) == txtCodcurso.Text)
                    {
                        encontrado = contador;
                    }
                    contador++;
                }

                if (encontrado != -1)
                {
                    txtCodcurso.Enabled = false;
                    Btn_registro.Visible = false;
                    TxtNombre.Text = Lista_curso[encontrado].nombre;
                    TxtDescripcion.Text = Lista_curso[encontrado].descripcion;
                }
                else
                {
                    limpiar();
                    l_Codcurso.Text = "No se ha encontrado ningun curso con este codigo, intente con otro";
                }
            }
            else
            {
                l_Codcurso.Text = "Ingrese el codigo del curso que desea buscar";
            }
        }

        protected void btn_actualizarClick(object sender, EventArgs e)
        {
            if(txtCodcurso.Enabled == false)
            {
                if (TxtNombre.Text != "")
                {
                    conexion_business.actualizarCurso(txtCodcurso.Text, TxtNombre.Text, TxtDescripcion.Text);
                    limpiar();
                    l_Descripcion.Text = "Actuallizacion Exitosa";
                    txtCodcurso.Enabled = true;
                    Btn_registro.Visible = true;
                    actualizar_tabla();
                }
                else
                {
                    l_nombre.Text = "Este Campo es obligatorio";
                }
            }
            else
            {
                l_Codcurso.Text = "No se ha buscado un dato";
            }
        }

        protected void eliminarClick(object sender, EventArgs e)
        {
            if (txtCodcurso.Enabled == false)
            {
                conexion_business.eliminarCurso(txtCodcurso.Text);
                limpiar();
                l_Descripcion.Text = "Eliminacion Exitosa";
                txtCodcurso.Enabled = true;
                Btn_registro.Visible = true;
                actualizar_tabla();
            }
            else
            {
                l_Codcurso.Text = "No se ha buscado un dato";
            }

        }

        protected void btnlimpiarClick(object sender, EventArgs e)
        {
            limpiar();
            txtCodcurso.Enabled = true;
            Btn_registro.Visible = true;
        }
    }
}