using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serialisacion
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona test = new Persona();
            int numcase = 0;
            while(numcase !=9)
            {
                Console.WriteLine("(1) ingresar persona");
                Console.WriteLine("(2) Almacenar personas");
                Console.WriteLine("(3) cargar personas");
                Console.WriteLine("(4) informacion personas");
                numcase = Convert.ToInt32(Console.ReadLine());
                switch (numcase)
                {
                    case 1:
                        {
                            Console.WriteLine("ingresa un nombre");
                            string nom = Console.ReadLine();
                            Console.WriteLine("ingresa un apellido");
                            string ape = Console.ReadLine();
                            Console.WriteLine("ingresa una edad");
                            int ed = Convert.ToInt32(Console.ReadLine());
                            Persona yo = new Persona(nom, ape, ed);
                            test.todas_las_personas.Add(yo);
                            break;
                        }
                    case 2:
                        {
                            IFormatter formatter = new BinaryFormatter();
                            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                            formatter.Serialize(stream, test.todas_las_personas.Count);
                            for (int i = 0; i < test.todas_las_personas.Count; i++)
                            {
                                formatter.Serialize(stream,test.todas_las_personas[i] );

                            }
                            stream.Close();
                            break;
                        }
                    case 3:
                        {
                            IFormatter formatter = new BinaryFormatter();
                            Stream stream = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                            int linea = (int)formatter.Deserialize(stream);
                            for (int i = 0; i < linea ; i++)
                            {
                                Persona obj = (Persona)formatter.Deserialize(stream);
                                test.todas_las_personas.Add(obj);

                            }

                            stream.Close();
                            break;
                        }
                    case 4:
                        {
                            for (int i = 0; i < test.todas_las_personas.Count; i++)
                            {
                                Console.WriteLine(test.todas_las_personas[i].Nombre +" "+ test.todas_las_personas[i].Apellido +" "+ test.todas_las_personas[i].edad);
                            }
                            break;
                        }



                    default:
                        break;
                }
            }
        }
    }
}
