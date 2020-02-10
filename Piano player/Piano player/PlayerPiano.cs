using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PianoPlayer
{
    class PlayerPiano
    {
        public static void main(String[] args)
        {
            String[] allData = File.ReadAllLines("chopsticks.txt");
            String keys = allData[0];
            Piano piano = new Piano(keys, 44100);
            for(int i = 1; i < keys.Length; i++)
            {
                String line = allData[i];
                for(int j = 0; j < line.Length; j++)
                {
                    
                }
            }
        }
    }
}