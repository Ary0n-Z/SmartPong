
namespace SmartPong.Model.GameObjects
{
    public class Ball : GameRect
    {
        public double Side { get => Width; set { Width = value; Height = value; } }
        public double Angle { get; set; }

    }
}
