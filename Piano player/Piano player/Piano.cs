using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PianoPlayer
{
    class Piano
    {

        private List<IMusicalInstrument> allKeys;
        private string keys;

        public Piano(string keys, int samplingRate)
        {
            this.keys = keys;
            this.allKeys = new List<IMusicalInstrument>();

            for(int i = 0; i < this.keys.Length; i++)
            {
                int frequency = 0;
                double power = (i - 24) / 12;
                frequency = (int)(Math.Pow(2, power) * 440);
                PianoWire wire = new PianoWire(frequency, samplingRate);
                this.allKeys.Add(wire);
            }

        }

        public void StrikeKey(char key)
        {
            this.allKeys[this.keys.IndexOf(key)].Strike();
        }

        public double Play()
        {
            double result = 0;
            foreach(PianoWire wire in this.allKeys)
            {
                result += wire.Sample(0.996);
            }
            return result;
        }
    }
}
