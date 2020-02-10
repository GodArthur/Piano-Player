using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PianoPlayer
{
    class PianoWire : IMusicalInstrument
    {

        private CircularArray buffer;

        public PianoWire(int frequency, int samplingRate)
        {
            buffer = new CircularArray(frequency / samplingRate);
        }

        public double Sample(double decay)
        {
            double value;
            if (buffer.Front != 0)
            {
                value = (buffer[buffer.Front] + buffer[buffer.Front + 1]) * decay; 
            }
            else
            {
                value = (buffer[buffer.Front] + buffer[0]) * decay;
            }
            return buffer.Shift(value);
        }

        public void Strike()
        {



            //temporary array to store the random values
            double[] temp = new double[buffer.Length];

            for (int i = 0; i < buffer.Length; i++)
            {

                temp[i] = RandomNumber(-0.5, 0.5);
            }

            buffer.Fill(temp);
        }

        private double RandomNumber(double min, double max)
        {
            Random number = new Random();
            return number.NextDouble() * (max - min) + max;
        }
    }
}
