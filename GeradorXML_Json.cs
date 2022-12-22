using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DLL_To_XML_JSON
{
    public class GeradorXML_Json<T> where T: class
    {
        public static void GeradorXML(List<T> lista)
        {
            if (lista.Count <= 0)
            {
                Console.WriteLine("... Não existe dados para exportação...");
                Console.ReadKey();
            }
            else
            {
                var contasXML = new XmlSerializer(typeof(List<T>));

                try
                {
                    FileStream fs = new FileStream("contasXML_DLL.xml", FileMode.Create);
                    using (StreamWriter streamWriter = new StreamWriter(fs))
                    {
                        contasXML.Serialize(streamWriter, lista);
                    }
                    Console.WriteLine("Arquivo salvo...");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.ReadKey();
                }
            }
        }
        public static void GeradorJson(List<T> lista)
        {
            if (lista.Count <= 0)
            {
                Console.WriteLine("... Não existe dados para exportação...");
                Console.ReadKey();
            }
            else
            {
                string json = JsonConvert.SerializeObject(lista,
                    Formatting.Indented);
                try
                {
                    FileStream fs = new FileStream("contas_DLL.json", FileMode.Create);
                    using (StreamWriter streamWriter = new StreamWriter(fs))
                    {
                        streamWriter.WriteLine(json);
                    }
                    Console.WriteLine("Arquivo salvo...");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.ReadKey();
                }
            }

        }
    }
}
