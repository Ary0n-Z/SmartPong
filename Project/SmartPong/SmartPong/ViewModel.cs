using SmartPong.Model;
using SmartPong.Model.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SmartPong
{
    public class ViewModel : ViewModelBase
    {
        private Game model;
        private RelayCommand arrowDownCommand;
        private RelayCommand arrowUpCommand;
        private RelayCommand startContinueCommand;
        private RelayCommand nnEnableDisableCommand;

        private RelayCommand pauseCommand;
        private RelayCommand stopCommand;
        private RelayCommand quitCommand;

        public string GameState
        {
            get {
                return model.StateString;
            }
        }
        public string NNState
        {
            get
            {
                return model.NNStateString;
            }
        }
        public GameAttributes GameAttr
        {
            get
            {
                return model.GameAttributes;
            }
        }
       
        public ViewModel()
        {
            model = new Game(
                ()=>
                OnPropertyChanged("GameAttr")
                );
        }
        public void ResizeEvent(double x, double y)
        {
            model.FieldResize(x,y);
            OnPropertyChanged("GameAttr");
        }
        public RelayCommand ArrowUpCommand
        { get
            {
                if (arrowUpCommand == null) {
                    arrowUpCommand = new RelayCommand(
                        () => {
                            model.MovePlayerPaddle(0);
                            OnPropertyChanged("GameAttr");
                        }
                        );
                }
                return arrowUpCommand;
            } }

        public RelayCommand ArrowDownCommand
        {
            get
            {
                if (arrowDownCommand == null)
                {
                    arrowDownCommand = new RelayCommand(
                        () => {
                            model.MovePlayerPaddle(1);
                            OnPropertyChanged("GameAttr");
                        }
                        );
                }
                return arrowDownCommand;
            }
        }
        public RelayCommand StartContinueCommand
        {
            get
            {
                return startContinueCommand != null ? startContinueCommand : startContinueCommand = new RelayCommand(
                    () =>
                    {
                        if(model.State == Game.GameState.Paused)
                            model.ChangeGameState(Game.GameCommands.Continue);
                        else
                            model.ChangeGameState(Game.GameCommands.Start);
                        OnPropertyChanged("GameState");
                    }
                    );
            }
        }

        public RelayCommand NNEnableDisableCommand
        {
            get
            {
                return nnEnableDisableCommand != null ? nnEnableDisableCommand : nnEnableDisableCommand = new RelayCommand(
                    () =>
                    {
                        if (model.NNState == Game.NeuralNetworkState.Disabled)
                            model.ChangeNNState(Game.NeuralNetworkState.Enabled);
                        else
                            model.ChangeNNState(Game.NeuralNetworkState.Disabled);
                        OnPropertyChanged("NNState");
                    }
                    );
            }
        }

        public RelayCommand PauseCommand { get {
                return pauseCommand != null ? pauseCommand : pauseCommand = new RelayCommand(
                    () =>
                    {
                        model.ChangeGameState(Game.GameCommands.Pause);
                        OnPropertyChanged("GameState");
                    }
                    );
            }
        }
        public RelayCommand StopCommand
        {
            get
            {
                return stopCommand != null ? stopCommand : stopCommand = new RelayCommand(
                    () =>
                    {
                        model.ChangeGameState(Game.GameCommands.Stop);
                        OnPropertyChanged("GameState");
                    }
                    );
            }
        }
        public RelayCommand QuitCommand
        {
            get
            {
                return quitCommand != null ? quitCommand : quitCommand = new RelayCommand(
                    () =>
                    {
                        Application.Current.MainWindow.Close();
                    }
                    );
            }
        }
    }
}
