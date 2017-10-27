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

        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        public Alumno()
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

        protected override string MostrarDatos()
        {
            string valorAcumulado = base.MostrarDatos();
            valorAcumulado += "\nEstado Cuenta: " + this._estadoCuenta + "\n" + this.ParticiparEnClase();
            return valorAcumulado;
        }

        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE: "+this._claseQueToma;
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if(a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if (a._claseQueToma == clase)
            {
                return false;
            }
            return true;
        }


    }
}
