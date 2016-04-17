using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class GoodPupil : IPupil
    {
        public void Read()
        {
            Console.WriteLine("Read-Good");
        }

        public void Relax()
        {
            Console.WriteLine("Relax-Good");
        }

        public void Study()
        {
            Console.WriteLine("Study-Good");
        }

        public void Write()
        {
            Console.WriteLine("Write-Good");
        }
    }
}
