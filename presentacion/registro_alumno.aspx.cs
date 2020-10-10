using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using business;
using clasesgenerales;
using System.Text;
namespace presentacion
{
    public partial class registro_alumno : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Actualizar_listas();
        }

        private void Actualizar_listas()
        {
            lista_general.Clear();
            lista_general = conexionbusiness.obtenerListpersona();

            verlistaestudiante();
            verlistaprofesor();
        }
       
        List<persona> lista_general = new List<persona>();
        Class_business conexionbusiness = new Class_business();


        private void claseRB(int encontrado)
        {
           
        }
        protected void Buscar(object sender, EventArgs e)
        {

            if (TxtCarnet.Text != "")
            {
                int contador = 0;
                int encontrado = -1;

                foreach (var persona in lista_general)
                {
                    if (TxtCarnet.Text == persona.carnet)
                    {
                        encontrado = contador;
                    }
                    contador++;
                }
                if (encontrado != -1)
                {
                    l_carnet.Text = "";

                    TxtNombre1.Text = lista_general[encontrado].nombre1;
                    TxtNombre2.Text = lista_general[encontrado].nombre2;
                    TxtApellido1.Text = lista_general[encontrado].apellido1;
                    TxtApellido2.Text = lista_general[encontrado].apellido2;
                    TxtAño.Text = Convert.ToString(lista_general[encontrado].fnac.Year);
                    Txtmes.Text = Convert.ToString(lista_general[encontrado].fnac.Month);
                    Txtdia.Text = Convert.ToString(lista_general[encontrado].fnac.Day);
                    claseRB(encontrado);

                    if (lista_general[encontrado].tipo ==true)
                    {
                        RB_alumno.Checked = false;
                        RB_maestro.Checked = true;
                    }
                    else
                    {
                        RB_alumno.Checked = true;
                        RB_maestro.Checked = false;
                    }
                   
                    TxtCarnet.Enabled = false;
                    Btn_registro.Visible = false;
                }
                else
                {
                    l_carnet.Text = "no existe ninguna persona con ese carnet";
                }
            }
            else
            {
                l_carnet.Text = "Ingrese un carnet";
            }



        }

        protected void btnlimpiar(object sender, EventArgs e)
        {
            limpiar();
            RB_alumno.Checked = true;
            RB_maestro.Checked = true;
            TxtCarnet.Enabled = true;
            Btn_registro.Visible = true;
        }
        protected void registro(object sender, EventArgs e)
        {
            if (comprobar() == true)
            {
                try
                {
                    string enviartipo = "0";
                    if (RB_maestro.Checked == true)
                    {
                        enviartipo = "1";
                    }
                    conexionbusiness.insertarpersona(TxtCarnet.Text, TxtNombre1.Text, TxtNombre2.Text, TxtApellido1.Text, TxtApellido2.Text, TxtAño.Text + "-" + Txtmes.Text + "-" + Txtdia.Text, enviartipo);
                    l_fecha.Text = "Registro exitoso";
                    Actualizar_listas();
                    limpiar();
                }
                catch (Exception)
                {
                    l_carnet.Text = "Este dato ya esta registrado, no se puede repetir";
                }

            }
        }
        protected void btn_actualizarClick(object sender, EventArgs e)
        {
            if (TxtCarnet.Enabled == false)
            {
                if (comprobar() == true) { 
                    string enviartipo = "0";
                    if (RB_maestro.Checked == true)
                    {
                        enviartipo = "1";
                    }
                    conexionbusiness.actualizarpersona(TxtCarnet.Text, TxtNombre1.Text, TxtNombre2.Text, TxtApellido1.Text, TxtApellido2.Text, TxtAño.Text + "-" + Txtmes.Text + "-" + Txtdia.Text, enviartipo);
                    l_fecha.Text = "Actualizacion Exitosa";
                    Actualizar_listas();
                    limpiar();
                    TxtCarnet.Enabled = true;
                    Btn_registro.Visible = true;
                }
            }
            else
            {
                l_carnet.Text = "no se ha buscado ningun dato";
            }
        }
        protected void eliminarClick(object sender, EventArgs e)
        {
            if (TxtCarnet.Enabled == false)
            {
                conexionbusiness.eliminarpersona(TxtCarnet.Text);
                l_fecha.Text = "Eliminacion Exitosa";
                    Actualizar_listas();
                    limpiar();
                    TxtCarnet.Enabled = true;
                    Btn_registro.Visible = true;
            }
            else
            {
                l_carnet.Text = "no se ha buscado ningun dato";
            }

        }

        private void verlistaestudiante()
        {

            Content_tabla_alumno.Controls.Clear();
            StringBuilder enviar = new StringBuilder();
            DateTime zeroTime = new DateTime(1, 1, 1);
            foreach (var perso in lista_general)
            {
                if (perso.tipo == false)
                {
                    TimeSpan edad = DateTime.Now - perso.fnac;
                    int year = -1;
                    try
                    {
                        year = (zeroTime + edad).Year - 1;

                    }
                    catch (Exception)
                    {

                        year = 0;
                    }
                    
                    enviar.AppendFormat("<tr>" +
                        "<td>{0}</td>" +
                        "<td>{1}</td>" +
                        "<td>{2}</td>" +
                        "<td>{3}</td>" +
                        "<td>{4}</td>" +
                        "<td>{5}</td>" +
                        "<td>{6}</td></tr>", perso.carnet, perso.nombre1, perso.nombre2, perso.apellido1, perso.apellido2, perso.fnac.Day + "/" + perso.fnac.Month + "/" + perso.fnac.Year, year);
                }
            }
            Content_tabla_alumno.Controls.Add(new LiteralControl(enviar.ToString()));
        }
        private void verlistaprofesor()
        {

            Content_tabla_profesor.Controls.Clear();
            StringBuilder enviar = new StringBuilder();
            DateTime zeroTime = new DateTime(1, 1, 1);
            foreach (var perso in lista_general)
            {
                if (perso.tipo == true)
                {
                    TimeSpan edad = DateTime.Now - perso.fnac;
                    int year = -1;
                    try
                    {
                        year = (zeroTime + edad).Year - 1;

                    }
                    catch (Exception)
                    {
                        year = 0;
                    }
                    enviar.AppendFormat("<tr>" +
                        "<td>{0}</td>" +
                        "<td>{1}</td>" +
                        "<td>{2}</td>" +
                        "<td>{3}</td>" +
                        "<td>{4}</td>" +
                        "<td>{5}</td>" +
                        "<td>{6}</td></tr>", perso.carnet, perso.nombre1, perso.nombre2, perso.apellido1, perso.apellido2, perso.fnac.Day + "/" + perso.fnac.Month + "/" + perso.fnac.Year, year);
                }
            }
            Content_tabla_profesor.Controls.Add(new LiteralControl(enviar.ToString()));
        }




        
        private void limpiar()
        {
            TxtCarnet.Text = "";
            TxtNombre1.Text = "";
            TxtNombre2.Text = "";
            TxtApellido1.Text = "";
            TxtApellido2.Text = "";
            TxtAño.Text = "";
            Txtmes.Text = "";
            Txtdia.Text = "";
            l_carnet.Text = "";
            l_nombre1.Text = "";
            l_nombre2.Text = "";
            l_apellido1.Text = "";
            l_apellido2.Text = "";
            l_fecha.Text = "";
        }
        private void limpiarlabel()
        {
            
            l_carnet.Text = "";
            l_nombre1.Text = "";
            l_nombre2.Text = "";
            l_apellido1.Text = "";
            l_apellido2.Text = "";
            l_fecha.Text = "";
        }

        private bool comprobar() {
            limpiarlabel();
            bool resultado = true;
            if (TxtCarnet.Text == "")
            {
                resultado = false;
                l_carnet.Text = "Este campo es obligatorio";
            }

            if (TxtNombre1.Text == "")
            {
                resultado = false;
                l_nombre1.Text = "Este campo es obligatorio";
            }

            if (TxtNombre2.Text == "")
            {
                resultado = false;
                l_nombre2.Text = "Este campo es obligatorio";
            }

            if (TxtApellido1.Text == "")
            {
                resultado = false;
                l_apellido1.Text = "Este campo es obligatorio";
            }

            if (TxtApellido2.Text == "")
            {
                resultado = false;
                l_apellido2.Text = "Este campo es obligatorio";
            }

            if (TxtAño.Text == "" || Txtmes.Text == "" || Txtdia.Text == "")
            {
                resultado = false;
                l_fecha.Text = "Todos los campos son obligatorios";
            }
            
                try
                {
                    DateTime fecha_comprobante = new DateTime(Convert.ToInt32(TxtAño.Text), Convert.ToInt32(Txtmes.Text), Convert.ToInt32(Txtdia.Text));
                }
                catch (Exception)
                {
                    resultado = false;
                    l_fecha.Text = "La fecha no se configuro correctamente";
                }
            return resultado;
        }

        

        
    }
}