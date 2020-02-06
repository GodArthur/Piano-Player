
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
        int buffPosition;
        public CircularArray(int length)
        {
            buffer = new double[length];
            buffPosition = 0;
        }

        public double this[int index] => throw new NotImplementedException();

        public int Length => throw new NotImplementedException();

        public void Fill(double[] array)
        {
            throw new NotImplementedException();
        }

        public double Shift(double value)
        {
            throw new NotImplementedException();
        }
    }
}
