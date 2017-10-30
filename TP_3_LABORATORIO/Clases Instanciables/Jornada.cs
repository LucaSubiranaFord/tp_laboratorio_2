using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region ATRIBUTOS
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;
        #endregion

        #region PROPIEDADES
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }

        public Profesor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value; }
        }
        #endregion

        #region CONSTRUCTORES
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this._clase = clase;
            this._instructor = instructor;

        }

        #endregion

        #region METODOS


        /// <summary>
        /// Hace publico los datos de la jornada
        /// </summary>
        /// <returns>string datos jornada</returns>
        public override string ToString()
        {
            string valorAcumulado = "CLASE DE "+this._clase.ToString()+" POR "+this._instructor.ToString();

            valorAcumulado += "\nAlumnos: \n";
            foreach (Alumno i in this.Alumnos)
            {
                valorAcumulado += i.ToString()+"\n";
            }
            valorAcumulado += "\n----------------------------------------\n";

            
            return valorAcumulado;
        }


        /// <summary>
        /// Verifica si un alumno se encuentra en una jornada
        /// </summary>
        /// <param name="jornada">Jornada jornada</param>
        /// <param name="alu">Alumno alu</param>
        /// <returns>true si se encuentra, de lo contrario false</returns>
        public static bool operator ==(Jornada jornada, Alumno alu)
        {
            foreach(Alumno i in jornada._alumnos)
            {
                if (i == alu)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica si un alumno se encuentra en una jornada
        /// </summary>
        /// <param name="jornada">Jornada jornada</param>
        /// <param name="alu">Alumno alu</param>
        /// <returns>false si se encuentra, de lo contrario true</returns>
        public static bool operator !=(Jornada jornada, Alumno alu)
        {
            return !(jornada == alu);
        }


        /// <summary>
        /// Añade un alumno a una jornada
        /// </summary>
        /// <param name="j">Jornada j</param>
        /// <param name="a">Alumno a</param>
        /// <returns>returna la jornada "j"</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if( !(j == a) )
            {
                j.Alumnos.Add(a);
            }
            
            return j;
        }


        /// <summary>
        /// Guarda en un txt los datos de la jornada
        /// </summary>
        /// <param name="jornada">Jornada jornada</param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto text = new Texto();

            return text.guardar("Jornada.txt", jornada.ToString());
        }


        /// <summary>
        /// Lee los datos del Jornada.txt
        /// </summary>
        /// <returns>string con los datos</returns>
        public static string Leer()
        {
            string dato = "";
            Texto text = new Texto();
            text.leer("Jornada.txt",out dato);
            return dato;
        }

        #endregion
    }
}
