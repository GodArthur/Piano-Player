using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using NAudio.Wave;


namespace PianoPlayer
{
    class PlayerPiano
    {
        public static void Main(string[] args)
        {
            Audio player = new Audio();
            string[] allData = File.ReadAllLines("chopsticks.txt");
            string keys = allData[0];
            Piano piano = new Piano(keys, 44100);
            int count;
            
            for (int i = 1; i < allData.Length; i++)
            {
                string line = allData[i];
                for (int j = 0; j < line.Length; j++)
                {
                    //Console.WriteLine(line[j]);
                    piano.StrikeKey(line[j]);

                    count = 1;
                    //player.Play(piano.Play());
                    while(count != 0)
                    {
                        player.Play(piano.Play());
                        count++; //count number of samples
                        if (count > 44100 * 3)
                        {
                            count = 0;

                        }
                    }
                    //Console.Read();
                }
                Thread.Sleep(400); //delay

                //Console.Read();
            }

        }
    }
}