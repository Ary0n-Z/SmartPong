using SmartPong.Model.GameObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if(ball.Angle == -180)
            {
                int a = 5;
            }
            double angleRag = (ball.Angle * Math.PI) / 180;
            double dx = Math.Cos(angleRag) * (field.Width * 0.005);
            double dy = Math.Sin(angleRag) * (field.Height * 0.005);
            ball.X += dx;
            ball.Y += dy;
            ////Field top / bottom border
            //if( ball.Y < 0 || ((ball.Y + ball.Side) > field.Height) )
            //{
            //    ball.Angle = -ball.Angle;
            //}
            ////left / right border
            //if( ball.X < 0)
            //    return Winner.P1;
            //if(ball.X > field.Width)
            //    return Winner.P2;
            //// Paddle
            PaddleCollision(ball, playerPaddle);
           // PaddleCollision(ball, nnPadle);

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
