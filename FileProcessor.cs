using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab6
{
    internal class FileProcessor
    {
        public static int Process(string fileName)
        {
            using StreamReader sr = new StreamReader(fileName);

            string line1 = sr.ReadLine();
            string line2 = sr.ReadLine();

            int a = int.Parse(line1);
            int b = int.Parse(line2);

            checked
            {
                return a * b;
            }
        }



    }
}
