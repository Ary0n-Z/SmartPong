using SmartPong.Model.GameObjects;
using System;
using System.Timers;

namespace SmartPong.Model
{

    public class Game : INotifyObject
    {
        private bool init = false;
        private Timer gameTimer = new Timer();
        public enum GameCommands { Start, Pause,Stop,Continue};
        public enum GameState { Started,Paused,Stopped};
        public GameState State { get; private set; }
        public string StateString { get {
                string state = "";
                switch (State)
                {
                    case GameState.Started:
                        state = "Started";
                        break;
                    case GameState.Paused:
                        state = "Paused";
                        break;
                    case GameState.Stopped:
                        state = "Stopped";
                        break;
                }
                return state;
            } }

        public GameAttributes GameAttributes { get; set; }
        public event Action Game_Tick;
        private GameEngine gameEngine;
            //Newral Network
        public Game(Action action)
        {
            Game_Tick += action;
            gameEngine = new GameEngine();
            GameAttributes = new GameAttributes();
            //Timer setup
            gameTimer.Interval = 50;
            gameTimer.Elapsed += GameTimerElapsed;
            gameTimer.Enabled = false;
            State = GameState.Stopped;
        }
        public void FieldResize(double x, double y){
            var paddleW = x * 0.03;
            var paddleH = y * 0.3;
            if (!init)
            {
                InitGame(x,y);
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
                    GameAttributes.ScorePlayer += 1;
                    InitGame(GameAttributes.PongField.Width,GameAttributes.PongField.Height);
                    GameAttributes.PongBall.Angle = 0;
                    break;
                case GameEngine.Winner.P2:
                    GameAttributes.ScoreNewralNetwork += 1;
                    InitGame(GameAttributes.PongField.Width, GameAttributes.PongField.Height);
                    GameAttributes.PongBall.Angle = 180;
                    break;
                case GameEngine.Winner.NONE:
                    break;
            }
            Game_Tick?.Invoke();

        }

        private void InitGame(double x, double y)
        {
            var paddleW = x * 0.03;

            GameAttributes.PongBall.X = x / 2.0;
            GameAttributes.PongBall.Y = y / 2.0;

            GameAttributes.PlayerPaddle.X = x * 0.01;
            GameAttributes.PlayerPaddle.Y = y / 3.0;

            GameAttributes.NewralNetworkPaddle.X = (x * 0.99) - paddleW;
            GameAttributes.NewralNetworkPaddle.Y = y / 3.0;

            GameAttributes.PongField.Width = x;
            GameAttributes.PongField.Height = y;
        }

        public void ChangeGameState(GameCommands cmd)
        {
            switch (cmd)
            {
                case GameCommands.Start:
                    InitGame(GameAttributes.PongField.Width, GameAttributes.PongField.Height);
                    GameAttributes.ScorePlayer = 0;
                    GameAttributes.ScoreNewralNetwork = 0;
                    State = GameState.Started;
                    gameTimer.Enabled = true;
                    break;
                case GameCommands.Pause:
                    State = GameState.Paused;
                    gameTimer.Enabled = false;
                    break;
                case GameCommands.Stop:
                    State = GameState.Stopped;
                    gameTimer.Enabled = false;
                    InitGame(GameAttributes.PongField.Width, GameAttributes.PongField.Height);
                    break;
                case GameCommands.Continue:
                    State = GameState.Started;
                    gameTimer.Enabled = true;
                    break;
                default:
                    break;
            }
        }
    }
}
