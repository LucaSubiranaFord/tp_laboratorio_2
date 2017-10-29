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
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;
         
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

        protected override string MostrarDatos()
        {
            string valorAcumulado = base.MostrarDatos();
            valorAcumulado += this.ParticiparEnClase();

            return valorAcumulado;
        }

        protected override string ParticiparEnClase()
        {
            string valorAcumulado = "\nCLASES DEL DIA: \n";

            foreach (Universidad.EClases i in _clasesDelDia)
            {
                valorAcumulado += i.ToString()+"\n";
            }

            return valorAcumulado;
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

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

        public static bool operator !=(Profesor p, Universidad.EClases clase)
        {
            return !(p == clase);
        }

        
    }
}
