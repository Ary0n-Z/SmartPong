using SmartPong.Model.GameObjects;
using System;
using System.Timers;

namespace SmartPong.Model
{

    public class Game : INotifyObject
    {
        private bool init = false;
        private Timer gameTimer = new Timer();
        public enum GameStats { Running = 0, Paused = 1, Stoped = 2, Finished = 3 }
        private GameStats gameState = GameStats.Stoped;
        private byte scoreNewralNetwork = 0;
        private byte scorePlayer = 0;


        public string GameState { get
            {
                switch (gameState)
                {
                    case GameStats.Running:
                        return "Running";
                    case GameStats.Paused:
                        return "Paused";
                    case GameStats.Stoped:
                        return "Stoped";
                    case GameStats.Finished:
                        return "Finished";
                    default:
                        return "Unkown";
                }
            } }
        public GameAttributes GameAttributes { get; set; }
        public string Score{
            get => string.Format("{0} : {1}", scorePlayer, scoreNewralNetwork);
        }

        //Game engine
        //Newral Network
        public Game()
        {
            GameAttributes = new GameAttributes();
            //Timer setup
            gameTimer.Interval = 500;// 0.5 seconds
            gameTimer.Elapsed += GameTimerElapsed;
            gameTimer.Enabled = true;
        }
        public void ResizeGameObjects(double x, double y)//param = Field new size
        {
            var paddleW = x * 0.03;
            var paddleH = y * 0.5;
            if (!init)
            {
                GameAttributes.ObjectsPos.Ball.X = x / 2.0;
                GameAttributes.ObjectsPos.Ball.Y = y / 2.0;

                GameAttributes.ObjectsPos.PlayerPaddle.X = x * 0.01;
                GameAttributes.ObjectsPos.PlayerPaddle.Y = y / 3.0;

                GameAttributes.ObjectsPos.NNPadle.X = (x * 0.99) - paddleW;
                GameAttributes.ObjectsPos.NNPadle.Y = y / 3.0;

                GameAttributes.PongField.Width = x;
                GameAttributes.PongField.Height = y;
                init = true;
            }

            var koefX = (x/GameAttributes.PongField.Width);
            var koefY = (y/GameAttributes.PongField.Height);
            //Ball configuration
            GameAttributes.PongBall.Side = x * 0.02;
            GameAttributes.ObjectsPos.Ball.X *= koefX; 
            GameAttributes.ObjectsPos.Ball.Y *= koefY;
            //Player paddle configuration
            GameAttributes.PlayerPaddle.Width = paddleW;
            GameAttributes.PlayerPaddle.Height = paddleH;
            GameAttributes.ObjectsPos.PlayerPaddle.X *= koefX;
            GameAttributes.ObjectsPos.PlayerPaddle.Y *= koefY;
            //NN paddle configuration
            GameAttributes.NewralNetworkPaddle.Width = paddleW;
            GameAttributes.NewralNetworkPaddle.Height = paddleH;
            GameAttributes.ObjectsPos.NNPadle.X *= koefX;
            GameAttributes.ObjectsPos.NNPadle.Y *= koefY;
            //Field 
            GameAttributes.PongField.Height = y;
            GameAttributes.PongField.Width = x;
        }
        private void GameTimerElapsed(object sender, ElapsedEventArgs e)
        {
            //TODO::
        }
        public void ChangeGameState(GameStats state)
        {
            //TODO::
        }
    }
}
