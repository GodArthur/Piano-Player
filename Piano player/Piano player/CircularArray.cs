
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
        //internal circular array
        double[] buffer;

        //The length of the circular array
        public int Length { get; }        

        //variable that acts as a pointer to the first index of
        //the circular array
        public int Front { get; private set; }



        /// <summary>
        /// Constructor initializes the length of the array
        /// </summary>
        /// <param name="length"></param>
        public CircularArray(int length)
        {
            //checking if the length is out of range
            if (length < 1)
            {
                throw new NotSupportedException("The value " + Length + "is not supported. Choose a number greater than zero");
            }
            
            //Setting the fields
            buffer = new double[length];
            Front = 0;
            Length = length;
        }

        //Index points to the indexed position related to the
        //Front property
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


        /// <summary>
        /// Performs a deep copy of the array into the buffer
        /// </summary>
        /// <param name="array">array of doubles to be copied</param>
        public void Fill(double[] array)
        {
            double[] temp = new double[array.Length];
            
            for (int i = 0; i < array.Length; i++)
            {
                temp[i] = array[i];
            }

            buffer = temp;

        }

        /// <summary>
        /// Returns and removes the first element in the buffer. Adds value to the end of the buffer
        /// </summary>
        /// <param name="value">Value to be added at the end of the buffer</param>
        /// <returns>First element in the buffer</returns>
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