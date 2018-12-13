
namespace SmartPong.Model.GameObjects
{
    public class GameAttributes
    {
        public byte ScoreNewralNetwork = 0;
        public byte ScorePlayer = 0;
        public GameAttributes()
        {
            PongField = new Field();
            PongBall = new Ball();
            PongBall.Angle = 0;
            PlayerPaddle = new Paddle();
            NewralNetworkPaddle = new Paddle();
        }
        public Ball PongBall { get; set; }
        public Field PongField { get; }
        public Paddle PlayerPaddle { get; set; }
        public Paddle NewralNetworkPaddle { get; set; }
        public string Score
        {
            get => string.Format("{0} : {1}", ScorePlayer, ScoreNewralNetwork);
        }

    }
}
