
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PianoPlayer
{
    public class CircularArray : IRingBuffer
    {

        double[] buffer;

        public int Length { get; }        

        public int Front { get; private set; }     
        



        public CircularArray(int length)
        {
            buffer = new double[length];
            Front = 0;
            Length = length;
        }

        public double this[int index]
        {
            get { return buffer[index]; }
        }

        public void Fill(double[] array)
        {
            double[] temp = new double[array.Length];
            
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = temp[i];
            }

            buffer = temp;

        }

        public double Shift(double value)
        {
            double first = buffer[Front];

            buffer[Front] = value;

            //buffer[Front] = -1;

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
    }
}
