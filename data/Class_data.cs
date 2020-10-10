using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using clasesgenerales;

namespace data
{
    public class Class_data
    {
        
        public static SqlConnection conect()
        {
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=webpr2;Integrated Security=True");
            

            try
            {
                connection.Open();
                
            }
            catch (Exception)
            {
               
            }
            return connection;
        }
        public List<persona> lista_persona()
        {
            List<persona> retornar_lista = new List<persona>();
            retornar_lista.Clear();
            SqlCommand comando = new SqlCommand(string.Format("select * from persona"), Class_data.conect());
            comando.ExecuteNonQuery();
            SqlDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {

                persona add_dato = new persona();
                add_dato.carnet = leer.GetString(0);
                add_dato.nombre1 = leer.GetString(1);
                add_dato.nombre2 = leer.GetString(2);
                add_dato.apellido1 = leer.GetString(3);
                add_dato.apellido2 = leer.GetString(4);
                add_dato.fnac = leer.GetDateTime(5);
                add_dato.tipo = leer.GetBoolean(6);              
                retornar_lista.Add(add_dato);
            }
            return retornar_lista;
        }
        public void insertStudent(string carnet,string nombre1,string nombre2,string apellido1,string apellido2,string fecha_n,string tipo)
        {           
            SqlCommand insert = new SqlCommand(string.Format(
                "insert into persona values ('"+carnet+"','"+nombre1+"','"+nombre2+"','"+apellido1+"','"+apellido2+"','"+fecha_n+"',"+tipo+")"), Class_data.conect());
            insert.ExecuteNonQuery();
        }
        public void updateStudent(string carnet, string nombre1, string nombre2, string apellido1, string apellido2, string fecha_n, string tipo)
        {
            SqlCommand update = new SqlCommand(string.Format(
                "update persona set nombre1='"+nombre1+"',nombre2='"+nombre2+"', apellido1 = '"+apellido1+"'," +
                "apellido2='"+apellido2+"',fechan='"+fecha_n+"',tipo='"+tipo+"' where cod_persona ='"+carnet+"';"
                ), Class_data.conect());
            update.ExecuteNonQuery();
        }
        public void deleteStudent(string carnet)
        {
            SqlCommand delete = new SqlCommand(string.Format(
                "DELETE FROM persona where cod_persona = '"+carnet+"';"
                ), Class_data.conect());
            delete.ExecuteNonQuery();            
        }

        public List<curso> lista_curso()
        {
            List<curso> retornar_lista = new List<curso>();
            retornar_lista.Clear();
            SqlCommand comando = new SqlCommand(string.Format("select * from curso"), Class_data.conect());
            comando.ExecuteNonQuery();
            SqlDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {

                curso add_dato = new curso();
                add_dato.cod_curso = leer.GetInt32(0);
                add_dato.nombre = leer.GetString(1);
                add_dato.descripcion = leer.GetString(2);                
                retornar_lista.Add(add_dato);
            }
            return retornar_lista;
        }
        public void insertCurso(string nombre, string descripcion)
        {
            SqlCommand insert = new SqlCommand(string.Format(
                "insert into curso(nombre,descripcion) values ('"+nombre+"','"+descripcion+ "');"
                ), Class_data.conect());
            insert.ExecuteNonQuery();
        }
        public void updateCurso(string id, string nombre, string descripcion)
        {
            SqlCommand updatec = new SqlCommand(string.Format(
               "update curso set nombre='"+nombre+"',descripcion='"+descripcion+"' where id_curso ="+id+";"
                ), Class_data.conect());
            updatec.ExecuteNonQuery();
        }
        public void deletecurso(string id)
        {
            SqlCommand delete = new SqlCommand(string.Format(
                "DELETE FROM curso where id_curso = "+id+";"
                ), Class_data.conect());
            delete.ExecuteNonQuery();
        }

        public List<asignacion> lista_asignacion()
        {
            List<asignacion> retornar_lista = new List<asignacion>();
            retornar_lista.Clear();
            SqlCommand comando = new SqlCommand(string.Format("select * from asignacion"), Class_data.conect());
            comando.ExecuteNonQuery();
            SqlDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {
                asignacion add_dato = new asignacion();
                add_dato.id_curso = leer.GetInt32(0);
                add_dato.cod_persona = leer.GetString(1);
                retornar_lista.Add(add_dato);
            }
            return retornar_lista;
        }
        public void insertAsignacion(string id_curso, string cod_curso)
        {
            SqlCommand insert = new SqlCommand(string.Format(
                "insert into asignacion(id_curso, cod_persona) values("+id_curso+", '"+cod_curso+"')"
                ), Class_data.conect());
            insert.ExecuteNonQuery();
        }
        public void deleteAsignacion(string id_curso,string cod_persona)
        {
            SqlCommand delete = new SqlCommand(string.Format(
                "DELETE FROM asignacion where id_curso="+id_curso+" and cod_persona = '"+cod_persona+"';"
                ), Class_data.conect());
            delete.ExecuteNonQuery();
        }
        public string cantidad_cursos(string cod_persona)
        {
            int valor = 0;
            SqlCommand comando = new SqlCommand(string.Format(
                "SELECT count(*) FROM asignacion WHERE id_curso=" + cod_persona), Class_data.conect());
            comando.ExecuteNonQuery();
            SqlDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {

                valor = leer.GetInt32(0);
              
            }
            return Convert.ToString(valor);
        }
        


    }
}
