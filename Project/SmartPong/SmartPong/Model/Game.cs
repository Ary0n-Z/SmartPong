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
        public event Action Game_Tick;
        private GameEngine gameEngine;
            //Newral Network
        public Game(Action action)
        {
            Game_Tick += action;
            gameEngine = new GameEngine();
            GameAttributes = new GameAttributes();
            //Timer setup
            gameTimer.Interval = 100;
            gameTimer.Elapsed += GameTimerElapsed;
            gameTimer.Enabled = true;
        }
        public void FieldResize(double x, double y){
            var paddleW = x * 0.03;
            var paddleH = y * 0.5;
            if (!init)
            {
                GameAttributes.PongBall.X = x / 2.0;
                GameAttributes.PongBall.Y = y / 2.0;

                GameAttributes.PlayerPaddle.X = x * 0.01;
                GameAttributes.PlayerPaddle.Y = y / 3.0;

                GameAttributes.NewralNetworkPaddle.X = (x * 0.99) - paddleW;
                GameAttributes.NewralNetworkPaddle.Y = y / 3.0;

                GameAttributes.PongField.Width = x;
                GameAttributes.PongField.Height = y;
                init = true;
            }

            var koefX = (x/GameAttributes.PongField.Width);
            var koefY = (y/GameAttributes.PongField.Height);
            //Ball configuration
            GameAttributes.PongBall.Side = x * 0.02;
            GameAttributes.PongBall.X *= koefX; 
            GameAttributes.PongBall.Y *= koefY;
            //Player paddle configuration
            GameAttributes.PlayerPaddle.Width = paddleW;
            GameAttributes.PlayerPaddle.Height = paddleH;
            GameAttributes.PlayerPaddle.X *= koefX;
            GameAttributes.PlayerPaddle.Y *= koefY;
            //NN paddle configuration
            GameAttributes.NewralNetworkPaddle.Width = paddleW;
            GameAttributes.NewralNetworkPaddle.Height = paddleH;
            GameAttributes.NewralNetworkPaddle.X *= koefX;
            GameAttributes.NewralNetworkPaddle.Y *= koefY;
            //Field 
            GameAttributes.PongField.Height = y;
            GameAttributes.PongField.Width = x;
        }
        public void MovePlayerPaddle(int i)
        {
            if (i == 0)
                gameEngine.MovePaddle(GameAttributes.PlayerPaddle, GameAttributes.PongField, GameEngine.Direction.Up);
            else
                gameEngine.MovePaddle(GameAttributes.PlayerPaddle, GameAttributes.PongField, GameEngine.Direction.Down);

         }
        private void GameTimerElapsed(object sender, ElapsedEventArgs e)
        {
            var winner = gameEngine.NextFrame(
                GameAttributes.PongBall, 
                GameAttributes.PongField,
                GameAttributes.PlayerPaddle,
                GameAttributes.NewralNetworkPaddle );
            switch (winner)
            {
                case GameEngine.Winner.P1:
                    scorePlayer += 1;
                    gameTimer.Stop();
                    break;
                case GameEngine.Winner.P2:
                    scoreNewralNetwork +=1;
                    gameTimer.Stop();
                    break;
                case GameEngine.Winner.NONE:
                    break;
                default:
                    break;
            }
            Game_Tick?.Invoke();

        }
        public void ChangeGameState(GameStats state)
        {
            //TODO::
        }
    }
}
