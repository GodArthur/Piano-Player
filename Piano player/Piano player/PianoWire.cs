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
            double value = (buffer[buffer.Front] + buffer[buffer.Front + 1] * decay);
            return buffer.Shift(decay);
        }

        public void Strike()
        {
            throw new NotImplementedException();
        }
    }
}
