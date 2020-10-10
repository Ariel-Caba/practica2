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
    public partial class Vista_Reporte : System.Web.UI.Page
    {
        Class_business conesxion_business = new Class_business();
        List<persona> List_general = new List<persona>();
        List<curso> List_curso = new List<curso>();
        List<asignacion> List_asignacion = new List<asignacion>();
        protected void Page_Load(object sender, EventArgs e)
        {
            List_general = conesxion_business.obtenerListpersona();
            List_curso = conesxion_business.obtenerListcurso();
            List_asignacion = conesxion_business.obtenerListasignacion();
            reporte_todos_estudiantes();
            reporte_curso_profesor_alumno();
        }
        private void reporte_todos_estudiantes()
        {
            tabla_CeroAsignados.Controls.Clear();
            tabla_UnoAsignados.Controls.Clear();
            StringBuilder enviar = new StringBuilder();
            StringBuilder enviar2 = new StringBuilder();

            foreach (var perso in List_general)
            {
                if (perso.tipo == false)
                {
                    int contar_asignacion = Convert.ToInt32(conesxion_business.repeticiones(perso.carnet));
                    if (contar_asignacion == 0)
                    {
                        enviar.AppendFormat("<tr>" +
                            "<td>{0}</td>" +
                            "<td>{1}</td></tr>", perso.carnet, perso.nombre1 + " " + perso.nombre2 + ", " + perso.apellido1 + " " + perso.apellido2);

                    }
                    if (contar_asignacion >= 1)
                    {
                        enviar2.AppendFormat("<tr>" +
                            "<td>{0}</td>" +
                            "<td>{1}</td>" +
                            "<td>{2}</td></tr>", perso.carnet, perso.nombre1 + " " + perso.nombre2 + ", " + perso.apellido1 + " " + perso.apellido2, contar_asignacion);
                    }
                }
            }
            tabla_CeroAsignados.Controls.Add(new LiteralControl(enviar.ToString()));
            tabla_UnoAsignados.Controls.Add(new LiteralControl(enviar2.ToString()));
        }
        private void reporte_curso_profesor_alumno()
        {
            Content_curso_maestro_alumno.Controls.Clear();
            StringBuilder enviar = new StringBuilder();

            foreach (var cursoss in List_curso)
            {
                String profesor = "No Asignado";
                foreach (var perso in List_general)
                {
                    if(perso.tipo == true)
                    {
                        foreach (var itemasig in List_asignacion)
                        {
                            if(itemasig.id_curso == cursoss.cod_curso && itemasig.cod_persona == perso.carnet)
                            {
                                profesor = perso.nombre1 + " " + perso.apellido1;
                            }
                        }
                    }
                }
                int quitar = 0;
                if(profesor != "No Asignado")
                {
                    quitar = 1;
                }

               int cantidad_alumnos = Convert.ToInt32(conesxion_business.repeticiones(Convert.ToString(cursoss.cod_curso)));

                    enviar.AppendFormat("<tr>" +
                        "<td>{0}</td>" +
                        "<td>{1}</td>" +
                        "<td>{2}</td>" +
                        "<td>{3}</td></tr>", cursoss.cod_curso, cursoss.nombre, profesor,cantidad_alumnos-quitar);
            }
            Content_curso_maestro_alumno.Controls.Add(new LiteralControl(enviar.ToString()));
            
        }


    }
}