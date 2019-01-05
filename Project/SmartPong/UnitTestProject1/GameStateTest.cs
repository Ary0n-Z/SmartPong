using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartPong.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class GameStateTest
    {
        [TestMethod]
        public void TestChangeGameStates()
        {
            Game game = new Game(() => { });
            Assert.IsTrue(game.State == Game.GameState.Stopped);
            game.ChangeGameState(Game.GameCommands.Pause);
            Assert.IsTrue(game.State == Game.GameState.Paused);
            game.ChangeGameState(Game.GameCommands.Start);
            Assert.IsTrue(game.State == Game.GameState.Started);
            game.ChangeGameState(Game.GameCommands.Pause);
            Assert.IsTrue(game.State == Game.GameState.Paused);
            game.ChangeGameState(Game.GameCommands.Continue);
            Assert.IsTrue(game.State == Game.GameState.Started);
            game.ChangeGameState(Game.GameCommands.Stop);
            Assert.IsTrue(game.State == Game.GameState.Stopped);


        }
    }
}
