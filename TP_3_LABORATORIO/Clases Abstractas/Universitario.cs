using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario:Persona
    {
        private int _legajo;
        public Universitario()
        {}

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }

        protected virtual string MostrarDatos()
        {
            string valorAcumulado = base.ToString();
            valorAcumulado += "\nLegajo: " + this._legajo;
            return valorAcumulado;
        }

        protected abstract string ParticiparEnClase();

        public static bool operator ==(Universitario u1, Universitario u2)
        {
            if( (u1 is Universitario && u2 is Universitario) && (u1.DNI == u2.DNI || u1._legajo == u2._legajo) )
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Universitario u1, Universitario u2)
        {
            return !(u1 == u2);
        }

        public override bool Equals(object obj)
        {

            if(obj is Universitario)
            {
                return true;
            }
            return false;
        }
    }
}
