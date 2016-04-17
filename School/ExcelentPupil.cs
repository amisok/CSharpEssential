using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class ExcelentPupil : IPupil
    {
        public void Read()
        {
            Console.WriteLine("Read-Excelent");
        }

        public void Relax()
        {
            Console.WriteLine("Relax-Bad");
        }

        public void Study()
        {
            Console.WriteLine("Study-Excelent");
        }

        public void Write()
        {
            Console.WriteLine("Write-Excelent");
        }
    }
}
