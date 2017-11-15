using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _archivo;

        public Texto(string archivo)
        {
            this._archivo = archivo;
        }

        public bool guardar(string datos)
        {
            if (this._archivo != null && datos != null)
            {
                try
                {
                    StreamWriter escritor = new StreamWriter(this._archivo,true);
                    escritor.WriteLine(datos);
                    escritor.Close();
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
            return true;
        }

        public bool leer(out List<string> datos)
        {
            string datosUx;
            List<string> lista = new List<string>();

            try
            {
                StreamReader lector = new StreamReader(this._archivo);
                while ((datosUx = lector.ReadLine()) != null)
                {
                    lista.Add(datosUx);
                }
                datos = lista;
                lector.Close();

            }
            catch (Exception e)
            {
                throw e;
            }

            return true;
        }

    }
}
