using OOP_Lab6;
using System;
using System.Drawing;      
using System.Windows.Forms;

namespace OOP_Lab6
{

    class Program
    {
        [STAThread]
        static void Main()
        {
            LogFiles logs;

            try
            {
                logs = new LogFiles();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Не вдалося створити службові файли: " + ex.Message);
                return;
            }

            long sum = 0;
            int count = 0;

            for (int i = 10; i <= 29; i++)
            {
                string fileName = $"{i}.txt";

                try
                {
                    int product = FileProcessor.Process(fileName);
                    sum += product;
                    count++;
                }
                catch (System.IO.FileNotFoundException)
                {
                    logs.WriteNoFile(fileName);
                }
                catch (FormatException)
                {
                    logs.WriteBadData(fileName);
                }
                catch (ArgumentNullException)
                {
                    logs.WriteBadData(fileName);
                }
                catch (OverflowException)
                {
                    logs.WriteOverflow(fileName);
                }
            }

            logs.Dispose();

            Console.WriteLine($"Результат: {(double)sum / count}");
          
            Console.WriteLine("\nПочинаємо обробку зображень...");
            ImageMirror.Run();
            Console.WriteLine("Роботу завершено.");
            Console.ReadKey();

        }
    }
}