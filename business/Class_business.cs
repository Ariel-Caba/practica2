using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data;
using clasesgenerales;

namespace business
{
    public class Class_business
    {
        Class_data b_conexion = new Class_data();
        public String mensajeconexion()
        {
            String mensaje = "";
            return mensaje;
        }
        public List<persona> obtenerListpersona()
        {
            return b_conexion.lista_persona();
        }
        public void insertarpersona (string carnet, string nombre1, string nombre2, string apellido1, string apellido2, string fecha_n,string tipo)
        {
            b_conexion.insertStudent(carnet,nombre1,nombre2,apellido1,apellido2,fecha_n,tipo);
        }
        public void actualizarpersona(string carnet, string nombre1, string nombre2, string apellido1, string apellido2, string fecha_n, string tipo)
        {
            b_conexion.updateStudent(carnet, nombre1, nombre2, apellido1, apellido2, fecha_n, tipo);
        }
        public void eliminarpersona(string carnet)
        {
            b_conexion.deleteStudent(carnet);
        }

        
        public List<curso> obtenerListcurso()
        {
            return b_conexion.lista_curso();
        }
        public void insertarCurso(string nombre, string descripcion)
        {
            b_conexion.insertCurso(nombre, descripcion);
        }
        public void actualizarCurso(string id, string nombre, string descripcion)
        {
            b_conexion.updateCurso(id, nombre, descripcion);
        }
        public void eliminarCurso(string id)
        {
            b_conexion.deletecurso(id);
        }

        public List<asignacion> obtenerListasignacion()
        {
            return b_conexion.lista_asignacion();
        }
        public void insertarAsignacion(string id_curso, string cod_persona)
        {
            b_conexion.insertAsignacion(id_curso,cod_persona);
        }
        public void eliminarAsignacion(string id_curso, string cod_persona)
        {
            b_conexion.deleteAsignacion(id_curso, cod_persona);
        }
        public string repeticiones(string cod_persona)
        {
            return b_conexion.cantidad_cursos(cod_persona);
        }
        

    }
}
