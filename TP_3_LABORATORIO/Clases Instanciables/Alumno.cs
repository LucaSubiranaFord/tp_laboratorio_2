using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using Excepciones;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }

        #region ATRIBUTOS
        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;
        #endregion

        #region CONSTRUCTORES
        public Alumno()
            :base()
        {

        }

         
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            :this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion

        #region METODOS


        /// <summary>
        /// retorna una cadena con los datos del alumno
        /// </summary>
        /// <returns>string datos del alumno</returns>
        protected override string MostrarDatos()
        {
            string valorAcumulado = base.MostrarDatos();
            valorAcumulado += "\n\nEstado Cuenta: " + this._estadoCuenta.ToString() + this.ParticiparEnClase();
            return valorAcumulado;
        }


        /// <summary>
        /// muestra las clases que toma el alumno
        /// </summary>
        /// <returns>string clases que toma</returns>
        protected override string ParticiparEnClase()
        {
            return "\nTOMA CLASES DE: "+this._claseQueToma;
        }


        /// <summary>
        /// Muestra los datos del alumno publicamente
        /// </summary>
        /// <returns>retorna el metodo MostrarDatos()</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }


        /// <summary>
        /// Verifica si dos alumnos son iguales segun la clase que toma y si el estado de cuenta es no deudor
        /// </summary>
        /// <param name="a">Alumno a</param>
        /// <param name="clase">Enum.EClases clase</param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if(a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Dos alumnos no son iguales si no toman la misma clase
        /// </summary>
        /// <param name="a">Alumno a</param>
        /// <param name="clase">Enum.EClases clase</param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if (a._claseQueToma == clase)
            {
                return false;
            }
            return true;
            //return !(a == clase);

        }

        #endregion


    }
}
