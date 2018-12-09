using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPong.Model.GameObjects
{
    public class Field : IRect
    {
        public double Width { get; set; }
        public double Height { get; set; }
    }
}
