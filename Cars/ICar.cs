using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public interface ICar
    {
        double Mas { get; set; }
        CarBody Body { get; set; }
        double Speed { get; set; }
    }

    public interface IWheel
    {
        string Tread { get; set; }
        string Disk { get; set; }
        DiskType DType { get; set; }
    }

    public interface IEngine
    {
        bool Start();
        double Power { get; set; }
    }

    public enum CarBody
    {
        Steel,
        Titanium,
        Carbon,
        Aluminium
    }

    public enum DiskType
    {
        Stamped,
        Cast,
        Wrought
    }
}
