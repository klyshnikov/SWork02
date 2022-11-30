using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Program
{
    internal class IntPreciseFilter : PreciseFilter
    {
        public IntPreciseFilter(int precise) : base(precise) { }

        public override string Filter(double Number)
        {
            if (Number.ToString().Split(',', '.').Length == 1 || Number.ToString().Split(',', '.').Length == 0 ||
                Number.ToString().Split(',', '.')[1].Count(x => x=='0') == Number.ToString().Split(',', '.')[1].Length)
            {
                if (Number >= 0)
                {
                    if (this.precise < Number.ToString().Split(',', '.')[0].Length)
                        return Number.ToString().Split(',', '.')[0];
                    return new string('0', this.precise - Number.ToString().Split(',', '.')[0].Length) + Number.ToString().Split(',', '.')[0];
                }
                else
                {
                    if (this.precise < Number.ToString().Split(',', '.')[0].Length-1)
                        return Number.ToString().Split(',', '.')[0];
                    return "-" + new string('0', this.precise - Number.ToString().Split(',', '.')[0][1..].Length) + Number.ToString().Split(',', '.')[0][1..];
                }
            }
            return String.Empty;
        }

        public void CreateFile(string FileName, string FileWrite)
        {
            string[] FileLines = base.CreateFile(FileName, FileWrite);

            List<string> ToWriteLines = new List<string> { };

            foreach (string Line in FileLines)
            {
                if (Line.Trim(' ') != String.Empty)
                {
                    Console.WriteLine(Line);
                    if (Filter(Convertor(Line)) != String.Empty)
                    {
                        ToWriteLines.Add(Filter(Convertor(Line)));
                    }
                }
            }

            File.WriteAllLines(FileWrite, ToWriteLines);
        }
    }
}
