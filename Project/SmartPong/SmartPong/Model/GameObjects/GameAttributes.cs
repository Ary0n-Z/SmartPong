
namespace SmartPong.Model.GameObjects
{
    public class GameAttributes
    {
        public GameAttributes()
        {
            PongField = new Field();
            PongBall = new Ball();
            PlayerPaddle = new Paddle();
            NewralNetworkPaddle = new Paddle();
            ObjectsPos = new ObjPositions();
        }
        public ObjPositions ObjectsPos { get; set; }
        public Ball PongBall { get; set; }
        public Field PongField { get; }
        public Paddle PlayerPaddle { get; set; }
        public Paddle NewralNetworkPaddle { get; set; }
    }
}
