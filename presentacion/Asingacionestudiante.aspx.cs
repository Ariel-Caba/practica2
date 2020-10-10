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
    public partial class Asingacionestudiante : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Actualizar_lista();
        }

        private void Actualizar_lista_asignacion()
        {
            Lista_asignacion = conexion_business.obtenerListasignacion();
            verreporte(TxtCarnetalumno.Text);

        }
        private void Actualizar_lista()
        {
            lista_general.Clear();
            lista_general = conexion_business.obtenerListpersona();
            Lista_curso = conexion_business.obtenerListcurso();
            Lista_asignacion = conexion_business.obtenerListasignacion();
            verlistacurso();
            verlistapersona();
        }
        List<persona> lista_general = new List<persona>();
        List<curso> Lista_curso = new List<curso>();
        Class_business conexion_business = new Class_business();
        List<asignacion> Lista_asignacion = new List<asignacion>();

        private void verlistapersona()
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
                        "<td>{3}</td></tr>", perso.carnet, perso.nombre1 + " " + perso.nombre2 + ", " + perso.apellido1 + " " + perso.apellido2, perso.fnac.Day + "/" + perso.fnac.Month + "/" + perso.fnac.Year, year);

                }
            }
            Content_tabla_alumno.Controls.Add(new LiteralControl(enviar.ToString()));
        }
        private void buscar_curso()
        {
            if (txtcod_curso.Text != "")
            {
                int contador = 0;
                int encontrar = -1;
                foreach (var itemcurso in Lista_curso)
                {
                    if (txtcod_curso.Text == Convert.ToString(itemcurso.cod_curso))
                    {
                        encontrar = contador;
                    }
                    contador++;
                }
                if (encontrar != -1)
                {
                    L_nombreCurso.Text = Lista_curso[encontrar].nombre;
                }
                else
                {
                    L_curso.Text = "No se pudo encontrar ningun curso con ese Codigo";
                }
            }
            else
            {
                L_curso.Text = "Ingrese el Codigo de un curso";
            }
        }
        protected void BuscarClick(object sender, EventArgs e)
        {
            if (TxtCarnetalumno.Enabled == false)
            {
                buscar_curso();
                verreporte(TxtCarnetalumno.Text);
            }
            else
            {
                int contador = 0;
                int encontrar = -1;
                foreach (var itempersona in lista_general)
                {
                    if (TxtCarnetalumno.Text == itempersona.carnet)
                    {
                        encontrar = contador;
                    }
                    contador++;
                }
                if (encontrar != -1)
                {
                    if (lista_general[encontrar].tipo == true)
                    {
                        L_profesion.Text = "Profesor";
                    }
                    else
                    {
                        L_profesion.Text = "Alumno";
                    }
                    L_nombrecompleto.Text = "Nombre Completo: " + lista_general[encontrar].nombre1 + " " + lista_general[encontrar].nombre2 + ", " + lista_general[encontrar].apellido1 + " " + lista_general[encontrar].apellido2;
                    L_fechanacimiento.Text = "Fecha de nacimiento: " + lista_general[encontrar].fnac.Day + "/" + lista_general[encontrar].fnac.Month + "/" + lista_general[encontrar].fnac.Year;
                    TxtCarnetalumno.Enabled = false;

                    verreporte(TxtCarnetalumno.Text);

                }
                else
                {
                    l_carnet.Text = "No se pudo encontrar ninguna persona con ese carnet";
                }
                buscar_curso();
            }

        }
        private void verreporte(string carnet)
        {

            content_reporte.Controls.Clear();
            StringBuilder enviar = new StringBuilder();

            foreach (var itemasignacion in Lista_asignacion)
            {
                if (carnet == itemasignacion.cod_persona)
                {
                    string nombreC = "";
                    foreach (var nombrecurso in Lista_curso)
                    {
                        if (nombrecurso.cod_curso == itemasignacion.id_curso)
                        {
                            nombreC = nombrecurso.nombre;
                        }
                    }

                    enviar.AppendFormat("<tr>" +
                            "<td>{0}</td>" +
                            "<td>{1}</td></tr>", itemasignacion.id_curso, nombreC);
                }

            }
            content_reporte.Controls.Add(new LiteralControl(enviar.ToString()));
        }
        private void verlistaprofesor()
        {

            Content_tabla_alumno.Controls.Clear();
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
                        "<td>{3}</td></tr>", perso.carnet, perso.nombre1 + " " + perso.nombre2 + ", " + perso.apellido1 + " " + perso.apellido2, perso.fnac.Day + "/" + perso.fnac.Month + "/" + perso.fnac.Year, year);

                }
            }
            Content_tabla_alumno.Controls.Add(new LiteralControl(enviar.ToString()));
        }
        private void verlistacurso()
        {
            Content_tabla_curso.Controls.Clear();
            StringBuilder enviar = new StringBuilder();

            foreach (var itemcurso in Lista_curso)
            {
                enviar.AppendFormat("<tr>" +
                    "<td>{0}</td>" +
                    "<td>{1}</td></tr>", itemcurso.cod_curso, itemcurso.nombre);

            }
            Content_tabla_curso.Controls.Add(new LiteralControl(enviar.ToString()));
        }


        protected void AsignarClick(object sender, EventArgs e)
        {
            if (TxtCarnetalumno.Enabled == false)
            {
                buscar_curso();
                verreporte(TxtCarnetalumno.Text);
                L_curso.Text = "";
                if (txtcod_curso.Text != "")
                {
                    bool curso_asignado = true;
                    foreach (var itempersona in lista_general)
                    {
                        if (itempersona.tipo == false)
                        {
                            foreach (var itemasignacion in Lista_asignacion)
                            {
                                if (itemasignacion.id_curso == Convert.ToInt32(txtcod_curso.Text) && itemasignacion.cod_persona == itempersona.carnet)
                                {
                                    curso_asignado = false;
                                }
                            }
                        }
                    }

                    if (curso_asignado == true)
                    {
                        try
                        {
                            conexion_business.insertarAsignacion(txtcod_curso.Text, TxtCarnetalumno.Text);
                            Actualizar_lista_asignacion();
                            txtcod_curso.Text = "";
                            L_curso.Text = "";
                            L_nombreCurso.Text = "";
                            l_carnet.Text = "Asignacion Exitosa";

                        }
                        catch (Exception)
                        {
                            l_carnet.Text = "Ya se ha realizado esa asignacion";

                        }
                    }
                    else
                    {
                        l_carnet.Text = "El curso ya esta asignado a un maestro";
                    }

                }
                else
                {
                    L_curso.Text = "Ingrese el nombre de un curso";
                }
            }
            else
            {
                l_carnet.Text = "Ingrse el carnet de una persona";
            }
        }

        protected void DesAsignarClick(object sender, EventArgs e)
        {
            if (TxtCarnetalumno.Enabled == false)
            {
                buscar_curso();

                L_curso.Text = "";
                if (txtcod_curso.Text != "")
                {


                    try
                    {
                        conexion_business.eliminarAsignacion(txtcod_curso.Text, TxtCarnetalumno.Text);

                        txtcod_curso.Text = "";
                        L_curso.Text = "";
                        L_nombreCurso.Text = "";
                        l_carnet.Text = "DesAsignacion Exitosa";

                    }
                    catch (Exception)
                    {
                        l_carnet.Text = "No existe esa desAsignacion";

                    }
                }
                else
                {
                    L_curso.Text = "Ingrese el codigo de un curso";
                }
                Actualizar_lista_asignacion();
            }
            else
            {
                l_carnet.Text = "Ingrse el carnet de una persona";
            }

        }

        protected void LimpiarClick(object sender, EventArgs e)
        {
            TxtCarnetalumno.Enabled = true;
            TxtCarnetalumno.Text = "";
            l_carnet.Text = "";
            L_nombreCurso.Text = "";
            L_nombrecompleto.Text = "";
            L_curso.Text = "";
            txtcod_curso.Text = "";
            L_profesion.Text = "";
            L_fechanacimiento.Text = "";
            L_nombreCurso.Text = "";
            content_reporte.Controls.Clear();

        }

        protected void Alumnos_entabla_Click(object sender, EventArgs e)
        {
            L_titulotabla.Text = "Alumnos";
            verlistapersona();
        }

        protected void Profesores_entablaClick(object sender, EventArgs e)
        {
            L_titulotabla.Text = "Profesores";
            verlistaprofesor();
        }
    }
}