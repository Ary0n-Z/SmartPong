
namespace SmartPong.Model.GameObjects
{
    public class GameAttributes
    {
        public GameAttributes()
        {
            PongField = new Field();
            PongBall = new Ball();
            PongBall.Angle = 180;
            PlayerPaddle = new Paddle();
            NewralNetworkPaddle = new Paddle();
        }
        public Ball PongBall { get; set; }
        public Field PongField { get; }
        public Paddle PlayerPaddle { get; set; }
        public Paddle NewralNetworkPaddle { get; set; }
    }
}
