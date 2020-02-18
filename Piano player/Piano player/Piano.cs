using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PianoPlayer
{
    //Author: Andrzej Fedorowicz
    //1842644  
    //2020-02-17
    //This class represents the Piano object that uses the pianoWires to create a piano capable of playing different notes
    public class Piano
    {
        //Declaring the list of PianoWires (essentially) and the keys that will be used
        private List<IMusicalInstrument> allKeys;
        private string keys;

        //The constructor takes as input the string corresponding the key mapping of the piano and the sampling rate
        public Piano(string keys, int samplingRate)
        {
            //keys attribute is set to input and instantiating the List
            this.keys = keys;
            this.allKeys = new List<IMusicalInstrument>();

            //This for loop goes through each of the keys and performs a mathematical calculation to find the frequency
            //Of that note and create a PianoWire object of that note
            for(int i = 0; i < this.keys.Length; i++)
            {
                int frequency = 0;
                double power = 0;
                power = (i - 24) / 12.0;
                frequency = (int)(Math.Pow(2, power) * 440);
                PianoWire wire = new PianoWire(frequency, samplingRate);
                //Once the object is created, it is added to the List of keys
                this.allKeys.Add(wire);
            }

        }

        //The StrikeKey method calls the Strike() method of the pianoWire which corresponds to the inputted key
        public void StrikeKey(char key)
        {
            this.allKeys[this.keys.IndexOf(key)].Strike();
        }

        //The Play method returns the sum of the samples of all the PianoWires in the List
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
