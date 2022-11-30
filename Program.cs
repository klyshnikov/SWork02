using System;

namespace Program
{
    class Program
    {
        public static void Main()
        {
            string FileName;
            int precise;

            //string IntFileName = ""

            while (true)
            {
                try
                {
                    Console.WriteLine("Введите название файла: ");
                    FileName = Console.ReadLine();

                    if (File.Exists(FileName)) { }
                    else
                    {
                        throw new Exception("Файла не существует! Попробуйте еще разю");
                    }

                    Console.WriteLine("Введите N: ");

                    if (!int.TryParse(Console.ReadLine(), out precise))
                        throw new Exception("Введенное число не целое! Попробуйте еще раз");

                    IntPreciseFilter IntFilter = new IntPreciseFilter(precise);
                    DoublePreciseFilter DoubleFilter = new DoublePreciseFilter(precise);

                    IntFilter.CreateFile(FileName, "IntValues.txt");
                    DoubleFilter.CreateFile(FileName, "DoubleValues.txt");

                    Console.WriteLine("Успешно!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}