using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPong.Model.GameObjects
{
    public class ObjPositions
    {
        public ObjPositions()
        {
            Ball = new Point();
            NNPadle = new Point();
            PlayerPaddle = new Point();
        }
        public Point Ball { get; set; }
        public Point NNPadle { get; set; }
        public Point PlayerPaddle { get; set; }
    }
}
