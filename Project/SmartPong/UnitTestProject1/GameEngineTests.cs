using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartPong.Model.GameObjects;
using SmartPong.Model;
namespace UnitTestProject1
{
    [TestClass]
    public class GameEngineTests
    {
        GameEngine game = new GameEngine();

        [TestMethod]
        public void movePaddleTest()
        {
            //Center Up Test
            Field field = new Field() { Width = 6, Height = 6 };
            Paddle p = new Paddle();
            init(p);
            Paddle answerPaddle = new Paddle();
            answerPaddle.X = 2;
            answerPaddle.Y = 1.7;
            answerPaddle.Width = 2;
            answerPaddle.Height = 3;

            game.MovePaddle(p,field,GameEngine.Direction.Up);
            Assert.AreEqual(answerPaddle.X, p.X);
            Assert.AreEqual(answerPaddle.Y, p.Y);
            //Center Down Test
            init(p);
            answerPaddle.X = 2;
            answerPaddle.Y = 2.3;
            answerPaddle.Width = 2;
            answerPaddle.Height = 3;
            game.MovePaddle(p, field, GameEngine.Direction.Down);
            Assert.AreEqual(answerPaddle.X, p.X);
            Assert.AreEqual(answerPaddle.Y, p.Y);
            //Bot Down Test
            init(p);
            p.Y = 6;
            answerPaddle.X = 2;
            answerPaddle.Y = 6;
            answerPaddle.Width = 2;
            answerPaddle.Height = 3;

            
            game.MovePaddle(p, field, GameEngine.Direction.Down);
            Assert.AreEqual(answerPaddle.X, p.X);
            Assert.AreEqual(answerPaddle.Y, p.Y);
            //Bot Down Test
            init(p);
            p.Y = 0;
            answerPaddle.X = 2;
            answerPaddle.Y = 0;
            answerPaddle.Width = 2;
            answerPaddle.Height = 3;
            game.MovePaddle(p, field, GameEngine.Direction.Up);
            Assert.AreEqual(answerPaddle.X, p.X);
            Assert.AreEqual(answerPaddle.Y, p.Y);
        }
        void init(Paddle p)
        {
            p.X = 2;
            p.Y = 2;
            p.Width = 2;
            p.Height = 3;
        }
    }
}