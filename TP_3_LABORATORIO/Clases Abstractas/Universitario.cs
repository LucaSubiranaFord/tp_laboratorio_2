using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario:Persona
    {
        #region PROPIEDADES
        private int _legajo;
        #endregion

        #region CONSTRUCTORES
        public Universitario()
        {}

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }

        #endregion

        #region METODOS


        /// <summary>
        /// Devuelve los datos del universitario
        /// </summary>
        /// <returns>String datos del universitario</returns>
        protected virtual string MostrarDatos()
        {
            string valorAcumulado = base.ToString();
            valorAcumulado += "\nLegajo: " + this._legajo;
            return valorAcumulado;
        }

        protected abstract string ParticiparEnClase();


        /// <summary>
        /// Verifica si un universitario es igual al otro
        /// </summary>
        /// <param name="u1">Universitario u1</param>
        /// <param name="u2">Universitario u2</param>
        /// <returns>True si son del mismo tipo, y ademas si el dni o el legajo son iguales. False de lo contario</returns>
        public static bool operator ==(Universitario u1, Universitario u2)
        {
            if( (u1 is Universitario && u2 is Universitario) && (u1.DNI == u2.DNI || u1._legajo == u2._legajo) )
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica si un universitario es igual al otro
        /// </summary>
        /// <param name="u1">Universitario u1</param>
        /// <param name="u2">Universitario u2</param>
        /// <returns>False si son del mismo tipo, y ademas si el dni o el legajo son iguales. True de lo contario</returns>
        public static bool operator !=(Universitario u1, Universitario u2)
        {
            return !(u1 == u2);
        }


        /// <summary>
        /// Verifica si un objeto es del tipo Universitario
        /// </summary>
        /// <param name="obj">Object obj</param>
        /// <returns>True si el objeto es universitario, false de caso contrario</returns>
        public override bool Equals(object obj)
        {

            if(obj is Universitario)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
