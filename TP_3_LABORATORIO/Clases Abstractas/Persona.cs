using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }

        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        #region PROPIEDADES
        public string Apellido
        {
            get { return this._apellido; }
            set
            {
                if (validarNombreApellido(value) != null)
                {
                    this._apellido = value;
                }
            }
        }

        public int DNI
        {
            get { return this._dni; }
            set
            {
                this._dni = ValidarDni(this._nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }

        public string Nombre
        {
            get { return this._nombre; }
            set
            {
                if(validarNombreApellido(value) != null)
                {
                    this._nombre = value;
                }
            }
        }

        public string StringToDNI
        {
            set { this._dni = ValidarDni(this._nacionalidad, int.Parse(value)); }
        }

        #endregion

        public Persona()
        { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino && (dato > 1 && dato < 89999999))
            {
                return dato;
            }
            else if (nacionalidad == ENacionalidad.Extranjero && (dato > 89999999 && dato < 99999999))
            {
                return dato;
            }

            throw new DniInvalidoException("DNI INVALIDO");
        }

        public string validarNombreApellido(string dato)
        {
            int i = 0;
            if (string.IsNullOrEmpty(dato))
            {
               return "";
            }
               
            for (i = 0; i < dato.Length; i++)
            {
                if (!char.IsLetter(dato[i]))
                { 
                    return ""; 
                }
                    
            }

            return dato;
        }

        public override string ToString()
        {
            return "Nombre: "+this._nombre+"\nApellido: "+this._apellido+"\nDNI: "+this._dni+"\nNacionalidad: "+this._nacionalidad;
        }
    }
}
