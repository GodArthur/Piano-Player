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
            throw new NotImplementedException();
        }
    }
}
