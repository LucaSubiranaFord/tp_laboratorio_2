using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor:Universitario
    {
        #region ATRIBUTOS
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;
        #endregion

        #region CONSTRUCTORES
        public Profesor()
        {
        }

        static Profesor()
        {
            _random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            _clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        #endregion

        #region METODOS


        /// <summary>
        /// Devuelve los datos del profesor
        /// </summary>
        /// <returns>string datos profesor</returns>
        protected override string MostrarDatos()
        {
            string valorAcumulado = base.MostrarDatos();
            valorAcumulado += this.ParticiparEnClase();

            return valorAcumulado;
        }


        /// <summary>
        /// Devuelve las clases del dia
        /// </summary>
        /// <returns>string clases del dia</returns>
        protected override string ParticiparEnClase()
        {
            string valorAcumulado = "\nCLASES DEL DIA: \n";

            foreach (Universidad.EClases i in _clasesDelDia)
            {
                valorAcumulado += i.ToString()+"\n";
            }

            return valorAcumulado;
        }


        /// <summary>
        /// Hace publico los datos del profesor
        /// </summary>
        /// <returns>string datos del profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }


        /// <summary>
        /// Asigna dos clases random
        /// </summary>
        private void _randomClases()
        {
            int i = 0;

            while(i<2)
            {
                int nr = _random.Next(0, 3);
                switch (nr)
                {
                    case 0:
                        this._clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                        break;
                    case 1:
                        this._clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                        break;
                    case 2:
                        this._clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                        break;
                    case 3:
                        this._clasesDelDia.Enqueue(Universidad.EClases.SPD);
                        break;
                    default:
                        break;
                }
                i++;
            }
            
        }


        /// <summary>
        /// Verifica si un profesor es igual a una clase si este mismo da la clase
        /// </summary>
        /// <param name="p">Profesor p</param>
        /// <param name="clase">Enum.EClases clase</param>
        /// <returns>true si da la clase, false de lo contrario</returns>
        public static bool operator ==(Profesor p, Universidad.EClases clase)
        {
            foreach (Universidad.EClases i in p._clasesDelDia)
            {
                if( i == clase)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica si un profesor es igual a una clase si este mismo da la clase
        /// </summary>
        /// <param name="p">Profesor p</param>
        /// <param name="clase">Enum.EClases clase</param>
        /// <returns>false si da la clase, true de lo contrario</returns>
        public static bool operator !=(Profesor p, Universidad.EClases clase)
        {
            return !(p == clase);
        }

        #endregion
    }
}
