using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class PreciseFilter
    {
        public int precise;

        public PreciseFilter(int precise)
        {
            this.precise = precise;
        }

        public virtual string Filter(double Number)
        {
            return $"{Number:F3}";
        }

        public virtual string[] CreateFile(string FileName, string FileWrite)
        {
            try
            {
                string[] FileLines = File.ReadAllLines(FileName);
                return FileLines;
            }
            catch (Exception e)
            {
                throw new Exception("Некорректный файл! Попробуйте еще раз");
            }
        }

        public static double Convertor(string number)
        {
            try
            {
                return double.Parse(number.Replace('.', ','));
            }
            catch (Exception e)
            {
                throw new Exception("Не все числа можно преобразовать в рационатьное!");
            }
        }
    }
}
