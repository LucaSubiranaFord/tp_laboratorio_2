using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion = 0, Laboratorio, Legislacion, SPD
        }

        #region ATRIBUTOS
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region PROPIEDADES
        public List<Alumno> Alumnos
        {
            get {return this.alumnos; }
            set {this.alumnos = value; }
        }

        public List<Jornada> Jornadas 
        {
            get {return this.jornada; }
            set { this.jornada = value; }
        }

        public List<Profesor> Instructores
        {
            get {return this.profesores; }
            set { this.profesores = value; }
        }

        public Jornada this[int i]
        {
            get {return this.jornada[i]; }
            set { this.jornada[i] = value; }
        }

        #endregion

        #region CONSTRUCTORES
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region METODOS


        /// <summary>
        /// Devuelve los datos de las jornadas
        /// </summary>
        /// <param name="gim">Universidad gim</param>
        /// <returns>string datos de las jornadas</returns>
        private static string MostrarDatos(Universidad gim)
        {
            string valorAcumulado = "JORNADA:\n";
            foreach (Jornada i in gim.Jornadas)
            {
                valorAcumulado += i.ToString();
            }

            return valorAcumulado;
        }


        /// <summary>
        /// Hace publico los datos de las jornadas
        /// </summary>
        /// <returns>string datos jornadas</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }


        /// <summary>
        /// Verifica si una universidad es igual a un alumno verificando si este mismo se encuentra en la universidad
        /// </summary>
        /// <param name="g">Unviersidad g</param>
        /// <param name="a">Alumno a</param>
        /// <returns>true si se encuentra, false de lo contrario</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach(Alumno i in g.Alumnos)
            {
                if(i == a)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica si una universidad es igual a un alumno verificando si este mismo se encuentra en la universidad
        /// </summary>
        /// <param name="g">Unviersidad g</param>
        /// <param name="a">Alumno a</param>
        /// <returns>false si se encuentra, true de lo contrario</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }


        /// <summary>
        /// Verifica si una universidad es igual a un profesor, viendo si este mismo se encuentra en la universidad
        /// </summary>
        /// <param name="g">Universidad g</param>
        /// <param name="i">Profesor i</param>
        /// <returns>retorna true si se encuentra, false de lo contrario</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach(Profesor p in g.profesores)
            {
                if(p == i)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica si una universidad es igual a un profesor, viendo si este mismo se encuentra en la universidad
        /// </summary>
        /// <param name="g">Universidad g</param>
        /// <param name="i">Profesor i</param>
        /// <returns>retorna false si se encuentra, true de lo contrario</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }


        /// <summary>
        /// Añade un alumno a la universidad
        /// </summary>
        /// <param name="g">Universidad g</param>
        /// <param name="a">Alumno a</param>
        /// <returns>retorna la universidad g</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if( g != a)
            {
                g.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return g;
            
        }


        /// <summary>
        /// Añade un profesor a la universidad
        /// </summary>
        /// <param name="g">Universidad g</param>
        /// <param name="i">Profesor i</param>
        /// <returns>retorna la universidad g</returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g!=i)
            {
                g.profesores.Add(i);
            }
            return g;
        }


        /// <summary>
        /// Añade una clase a una universidad, instanciando una nueva jornada
        /// </summary>
        /// <param name="g">Universidad g</param>
        /// <param name="clase">Enum.Eclases clase</param>
        /// <returns>Universidad g</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada j = new Jornada(clase, g == clase);
            foreach (Alumno i in g.Alumnos)
            {
                if (i == clase)
                {
                    j.Alumnos.Add(i);
                }
            }
            g.Jornadas.Add(j);

            return g;
        }


        /// <summary>
        /// Verifica el primer profesor que de cierta clase en la universidad
        /// </summary>
        /// <param name="g">Universidad g</param>
        /// <param name="clase">Enum.Eclases clase</param>
        /// <returns>Primer PROFESOR que de la clase, de lo contrario arroja una excepcion</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
                foreach (Profesor i in g.Instructores)
                {
                    if (i == clase)
                    {
                        return i;
                    }
                }

            throw new SinProfesorException();
        }

        /// <summary>
        /// Verifica el primer profesor que no de la clase en la universidad
        /// </summary>
        /// <param name="g">Universidad g</param>
        /// <param name="clase">Enum.Eclases clase</param>
        /// <returns>Primer PROFESOR que no de la clase, caso contrario devuelve null</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor i in g.Instructores)
            {
                if (i != clase)
                {
                    return i;
                }
            }

            return null;
        }


        /// <summary>
        /// Guarda la universidad pasada como parametro en un archivo .xml
        /// </summary>
        /// <param name="gim">Universidad gim</param>
        /// <returns>true si se pudo guardar, en caso contrario false</returns>
        public static bool Guardar(Universidad gim)
        {
            Xml<Universidad> xml = new Xml<Universidad>();

            return xml.guardar("Universidad.xml", gim);
        }

        #endregion
    }
}
