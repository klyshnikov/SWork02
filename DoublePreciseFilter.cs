using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class DoublePreciseFilter : PreciseFilter
    {
        public DoublePreciseFilter(int precise) : base(precise) { }

        public override string Filter(double Number)
        {
            IntPreciseFilter tmp = new IntPreciseFilter(this.precise);

            if (tmp.Filter(Number) != String.Empty)
            {
                return tmp.Filter(Number);
            }

            string[] Halfs = Number.ToString().Split(',', '.');
            if (Halfs[1].Length >= this.precise)
            {
                int k = Halfs[1].Length - this.precise;
                return Number.ToString()[..^k];
            }
            return Number.ToString() + new string('0', this.precise - Halfs[1].Length);

        }

        public void CreateFile(string FileName, string FileWrite)
        {
            string[] FileLines = base.CreateFile(FileName, FileWrite);

            List<string> ToWriteLines = new List<string> { };

            foreach (string Line in FileLines)
            {
                if (Line.Trim(' ') != String.Empty)
                    ToWriteLines.Add(Filter(Convertor(Line)));
            }

            File.WriteAllLines(FileWrite, ToWriteLines);
        }
    }
}
