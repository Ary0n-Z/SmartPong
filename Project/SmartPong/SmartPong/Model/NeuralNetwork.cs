using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPong.Model
{
    class NeuralNetwork
    {

        public void Run(double input1, double input2, Action output1, Action output2)
        {
            if (input2 > input1)
                output1();
            else
                output2();
        }
    }
}
