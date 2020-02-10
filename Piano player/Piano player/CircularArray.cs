
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

        int front;
        int end;
        int tail;



        public CircularArray(int length)
        {
            buffer = new double[length];
            front = 0;
            Length = length;
            tail = head;
        }

        public double this[int index] => throw new NotImplementedException();

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
            throw new NotImplementedException();
        }
    }
}
