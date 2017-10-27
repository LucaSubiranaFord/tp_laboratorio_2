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
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

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

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this.Clase = clase;
            this.Instructor = instructor;

        }

        public override string ToString()
        {
            string valorAcumulado = "Alumnos: \n";

            foreach (Alumno i in this.Alumnos)
            {
                valorAcumulado += i.ToString()+"\n";
            }

            valorAcumulado += "Profesor: " + this.Instructor+"\nClase: "+this.Clase;
            return valorAcumulado;
        }

        public static bool operator ==(Jornada jornada, Alumno alu)
        {
            foreach(Alumno i in jornada.Alumnos)
            {
                if (i == alu)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Jornada jornada, Alumno alu)
        {
            return !(jornada == alu);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j == a)
            {
                return j;
            }
            j.Alumnos.Add(a);
            return j;
        }

        public static bool Guardar(Jornada jornada)
        {
            Texto text = new Texto();

            return text.guardar("Jornada.txt", jornada.ToString());
        }

        /*public static string Leer()
        {
            Texto text = new Texto();
            //return text.leer("Jornada.txt");
        }*/
    }
}
