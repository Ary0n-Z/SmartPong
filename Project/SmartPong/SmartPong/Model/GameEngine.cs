using SmartPong.Model.GameObjects;
using System;
using System.Diagnostics;

namespace SmartPong.Model
{
    class GameEngine
    {
        public enum Winner { P1, P2,NONE }
        public enum Direction { Up,Down}
        public void MovePaddle(Paddle paddle,Field field, Direction direction)
        {
            double hop = field.Height * 0.05;
            switch (direction)
            {
                case Direction.Up:
                    if (0 < paddle.Y - hop)
                        paddle.Y -= hop;
                    break;
                case Direction.Down:
                    if (field.Height > paddle.Y + hop + paddle.Height)
                        paddle.Y += hop;
                    break;
                default:
                    break;
            }
        }
        public Winner NextFrame(Ball ball, Field field, Paddle playerPaddle,Paddle nnPadle)
        {
            double angleRag = (ball.Angle * Math.PI) / 180;
            double dx = Math.Cos(angleRag) * (field.Width * 0.008);
            double dy = Math.Sin(angleRag) * (field.Height * 0.008);
            ball.X += dx;
            ball.Y += dy;

            //Field physics
            if (field.Height < ball.RightBottom.Y || 0 > ball.Y)
                ball.Angle *= -1;
            //Win conditions
            if (field.Width < ball.RightBottom.X)
                return Winner.P1;
            if (0 > ball.X)
                return Winner.P2;
            //Player paddle
            if (playerPaddle.RightBottom.X > ball.X
                && playerPaddle.LeftTop.Y < ball.RightBottom.Y
                && playerPaddle.RightBottom.Y > ball.Y)
            {
                double k = (playerPaddle.Height - (ball.Y-playerPaddle.Y))/ playerPaddle.Height;
                ball.Angle = 90 - 180*k;
                ball.X = playerPaddle.X + playerPaddle.Width;
            }
            //NN paddle
            if (nnPadle.X < ball.RightBottom.X
                && nnPadle.Y < ball.RightBottom.Y
                && nnPadle.RightBottom.Y > ball.Y)
            {
                double k = (nnPadle.Height - (ball.Y - nnPadle.Y)) / nnPadle.Height;
                ball.Angle = -270 + 180 * k;
                ball.X = nnPadle.X - ball.Width;
            }

            return Winner.NONE;
        }
        static int i = 0;
        private void PaddleCollision(Ball ball, Paddle paddle)
        {
            if (IsIntoPaddle(ball, paddle))
            {
                ball.Angle = -ball.Angle;
                ball.X = paddle.RightBottom.X+0.1;
                Debug.WriteLine(i + ": Angle = " + ball.Angle + "\n Ball Coord: " + ball.X + "\n Paddle Coord: " +( paddle.X + paddle.Width));
                i++;

            }
        }
        private bool IsIntoPaddle(Ball ball, Paddle paddle) {

            var blt = ball.LeftTop;
            var brb = ball.RightBottom;
            var plt = paddle.LeftTop;
            var prb = paddle.RightBottom;

            return blt.X < prb.X && blt.X > plt.X ;
        }
    }
}
