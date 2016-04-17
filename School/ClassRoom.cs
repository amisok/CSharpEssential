using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class ClassRoom
    {
        IPupil[] pupils ;

        public ClassRoom(IPupil p1, IPupil p2)
        {
            pupils = new IPupil[2] { p1, p2 };

        }

        public ClassRoom(IPupil p1, IPupil p2, IPupil p3)
        {
            pupils = new IPupil[3] ;
            pupils[0] = p1;
            pupils[1] = p2;
            pupils[2] = p3;
        }

        public ClassRoom(IPupil p1, IPupil p2, IPupil p3, IPupil p4)
        {
            pupils = new IPupil[] { p1, p2, p3, p4};

        }

        public void PupilInfomation()
        {
            for (int i = 0; i < pupils.Length; i++)
            {
                Console.WriteLine($"{pupils[i]}");
                pupils[i].Read();
                pupils[i].Relax();
                pupils[i].Study();
                pupils[i].Write();
            }
        }
    }
}
