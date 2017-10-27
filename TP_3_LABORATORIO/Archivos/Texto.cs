using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Texto:IArchivo<string>
    {
        public bool guardar(string archivo, string dato)
        {
            bool flag = false;

            if (archivo != null && dato != null)
            {
                try
                {
                    using (StreamWriter escritor = new StreamWriter(archivo, false))
                    {
                        escritor.Write(dato);
                        flag = true;
                    }
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }

            return flag;
        }

        
        public bool leer(string archivo, out string dato)
        {
            bool flag = false;
            dato = null;

            if (archivo != null)
            {
                try
                {
                    using (StreamReader lector = new StreamReader(archivo))
                    {
                        dato = lector.ReadToEnd();
                        flag = true;
                    }
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }

            return flag;
        }
    }
}
