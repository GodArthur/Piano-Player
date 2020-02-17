using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PianoPlayer
{
    public class PianoWire : IMusicalInstrument
    {

        public CircularArray buffer { get; private set; }

        public PianoWire(int frequency, int samplingRate)
        {
            buffer = new CircularArray(samplingRate / frequency);
        }



        public double Sample(double decay)
        {
            //value being added to the buffer
            double value;
            
            value = ((buffer[0] + buffer[1]) / 2) * decay; 
            
            return buffer.Shift(value);
        }

        public void Strike()
        {
            Random number = new Random();
            //temporary array to store the random values
            double[] temp = new double[buffer.Length];

            for (int i = 0; i < temp.Length; i++)
            {

                temp[i] = RandomNumber(number, -0.5, 0.5);
            }

            buffer.Fill(temp);
        }

        public static double RandomNumber(Random number, double min, double max)
        {
            
            return number.NextDouble() * (max - min) + min;
        }

        /// <summary>
        /// method gets the embedded circular array
        /// </summary>
        /// <returns>a deep copy of the buffer</returns>
        public CircularArray getWires()
        {
            CircularArray temp = new CircularArray(buffer.Length);

            temp.Fill(buffer.getValues());

            return temp;
        }
    }
}
