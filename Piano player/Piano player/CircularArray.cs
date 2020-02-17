
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
    public class CircularArray : IRingBuffer
    {

        double[] buffer;

        public int Length { get; }        

        public int Front { get; private set; }




        public CircularArray(int length)
        {
            
            if (length < 1)
            {
                throw new NotSupportedException("The value " + Length + "is not supported. Choose a number greater than zero");
            }
             
            buffer = new double[length];
            Front = 0;
            Length = length;
        }

        public double this[int index]
        {
            get
            {
                if (index + Front > Length - 1)
                {
                    return buffer[(index + Front) - Length];
                }
                else
                {
                    return buffer[(index + Front)];
                }

            }
        }

        public void Fill(double[] array)
        {
            double[] temp = new double[array.Length];
            
            for (int i = 0; i < array.Length; i++)
            {
                temp[i] = array[i];
            }

            buffer = temp;

        }

        public double Shift(double value)
        {
            double first = buffer[Front];

            buffer[Front] = value;

            

            if (Front == Length - 1)
            {
                Front = 0;
            }
            else
            {
                Front++;
            }
           

            return first;
        }

        /// <summary>
        /// Method gets values of the internal buffer array
        /// </summary>
        /// <remarks>
        /// creates a deep copy before sending the values
        /// </remarks>
        /// <returns>
        /// a Copy of the buffer array
        /// </returns>
        public double[] getValues()
        {
            double[] temp = new double[buffer.Length];

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = buffer[i];
            }
            return temp;
        }
    }
}