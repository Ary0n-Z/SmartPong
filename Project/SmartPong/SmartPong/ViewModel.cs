using SmartPong.Model;
using SmartPong.Model.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPong
{
    public class ViewModel : ViewModelBase
    {
        private Game model;
        private RelayCommand arrowDownCommand;
        private RelayCommand arrowUpCommand;

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
    }
}
