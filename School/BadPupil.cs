using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class BadPupil : IPupil
    {
        public void Read()
        {
            Console.WriteLine("Read-Bad");
        }

        public void Relax()
        {
            Console.WriteLine("Relax-Excelent");
        }

        public void Study()
        {
            Console.WriteLine("Study-Bad");
        }

        public void Write()
        {
            Console.WriteLine("Write-Bad");
        }
    }
}
