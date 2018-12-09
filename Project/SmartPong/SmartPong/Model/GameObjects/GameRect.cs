using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPong.Model.GameObjects
{
    public class GameRect : GameObj, IRect
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Point Center
        {
            get
            {
                return new Point((X + Width) / 2.0, (Y + Height) / 2.0);
            }
        }
        public Point LeftTop
        {
            get
            {
                return new Point(X, Y);
            }
        }
        public Point RightBottom
        {
            get
            {
                return new Point((X + Width), (Y + Height));
            }
        }
    }
}
