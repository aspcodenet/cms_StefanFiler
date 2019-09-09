using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilerStefan
{
    class Program
    {
        //Varför
        //Streams
        //using
        //Skriv textfil
        //Append textfil
        //Kolla om finns?
        //Ta bort fil
        //Läs textfil
        //Directory - get all files

        static void Main2()
        {
            //string path = @"C:\Users\stefan\source\repos\FilerStefan\FilerStefan";
            string path = "..\\";

            string[] files = System.IO.Directory.GetFiles(path);
            foreach (var file in files)
            {
                string extension = System.IO.Path.GetExtension(file);
                if(extension == ".txt")
                {

                }
                Console.WriteLine(file);
            }

            string pathToFile = path + "\\" + "settings.txt";
            int min, max;
            if (System.IO.File.Exists(pathToFile))
            {
                var lines = System.IO.File.ReadAllLines(pathToFile);
                foreach(var line in lines)
                {
                    if (line.StartsWith("MIN:"))
                    {
                        min = Convert.ToInt32(line.Replace("MIN:", ""));
                        //string[] parts = line.Split(':');
                        //min = Convert.ToInt32(parts[1]);
                    }
                    if (line.StartsWith("MAX:"))
                    {
                        max = Convert.ToInt32(line.Replace("MAX:", ""));
                    }


                }
            }
            else
            {
                Console.WriteLine("Enter min");
                min = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter max");
                max = Convert.ToInt32(Console.ReadLine());

                var lines = new string[2];
                lines[0] = "MIN:" + min.ToString();
                lines[1] = "MAX:" + max.ToString();

                System.IO.File.WriteAllLines(pathToFile,lines);
                System.IO.File.AppendAllLines(pathToFile, lines);
            }


        }

        static void Main(string[] args)
        {

            Main2();
            string path = @"C:\Users\stefan\source\repos\FilerStefan\FilerStefan";
            string pathToFile = path + "\\" + "settings.txt";
            int min, max;

            if (System.IO.File.Exists(pathToFile))
            {
                //Read min max from file
                using(var streamReader = System.IO.File.OpenText(pathToFile))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if(line.StartsWith("MIN:"))
                        {
                            min = Convert.ToInt32(line.Replace("MIN:", ""));
                            //string[] parts = line.Split(':');
                            //min = Convert.ToInt32(parts[1]);
                        }
                        if (line.StartsWith("MAX:"))
                        {
                            max = Convert.ToInt32(line.Replace("MAX:", ""));
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("Enter min");
                min = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter max");
                max = Convert.ToInt32(Console.ReadLine());

                using (var streamWriter = System.IO.File.CreateText(pathToFile))
                {
                    streamWriter.WriteLine("MIN:" + min);
                    streamWriter.WriteLine("MAX:" + max);
                }
            }

            //...
            //...
        }
    }
}
