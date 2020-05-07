using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ActividadClase
{
    [Serializable]
    public class Persona
    {
        public string Nombre;
        public string Apellido;
        public int Edad;
        public Persona(string nombre, string apellido, int edad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Edad = edad;
        }
        public string infopersona()
        {
            return Nombre + " " + Apellido + " " + Convert.ToString(Edad);
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Stream stream = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            IFormatter formatter = new BinaryFormatter();
            Persona p1 = new Persona("Cristobal", "Neira", 21);
            List<Persona> listapersonas = new List<Persona>();
            listapersonas.Add(p1);
            int x = 2;
            while (x<=4)
            {
                Console.WriteLine("[Menu]");
                Console.WriteLine("1.Crear Persona, 2.Ver Personas, 3.Cargar Personas, 4.Guardar Personas");
                x = Convert.ToInt32(Console.ReadLine());
                if (x == 1)
                {
                    Console.WriteLine("Creando persona:");
                    Console.WriteLine("Nombre:");
                    string n = Console.ReadLine();
                    Console.WriteLine("Apellido:");
                    string a = Console.ReadLine();
                    Console.WriteLine("Edad");
                    int e = Convert.ToInt32(Console.ReadLine());
                    Persona p2 = new Persona(n, a, e);
                    listapersonas.Add(p2);
                }
                else if (x == 2)
                {
                    foreach (Persona p in listapersonas)
                    {
                        Console.WriteLine(p.infopersona());
                    }
                }
                else if (x == 3)
                {

                    foreach (Persona p in listapersonas)
                    {
                        Persona a = p;
                        a = (Persona)formatter.Deserialize(stream);
                        stream.Close();
                        Console.WriteLine(a.infopersona());

                    }

                }
                else if (x == 4)
                {
                    foreach (Persona p in listapersonas)
                    {
                        formatter.Serialize(stream, p);
                        stream.Close();

                    }
                }
                else
                {
                    Console.WriteLine("Fuera del menu. Hasta la proxima!");
                    break;
                }
            }
            

        }
        
    }
}
