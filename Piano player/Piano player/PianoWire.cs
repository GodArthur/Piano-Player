using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Author: Korjon Chang-Jones
//1837302
//2020-02-17
namespace PianoPlayer
{
    /// <summary>
    /// Class simulates the implementation of a piano wire within the program
    /// </summary>
    public class PianoWire : IMusicalInstrument
    {

        public CircularArray buffer { get; private set; }

        public PianoWire(int frequency, int samplingRate)
        {
            //Setting the circular array with the sampling rate over the frequency
            buffer = new CircularArray(samplingRate / frequency);
        }



        public double Sample(double decay)
        {
            //value being added to the buffer
            double value;
            
            //setting the value to the average of the two values
            //times the decay factor
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

        /// <summary>
        /// Method generates a random double value
        /// </summary>
        /// <param name="number">the random number object</param>
        /// <param name="min">The minimum range value</param>
        /// <param name="max">The maximum range value</param>
        /// <returnsA random number within the min and max range></returns>
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
