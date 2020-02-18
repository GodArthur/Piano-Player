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

    //Author: Andrzej Fedorowicz and Korjon Chang-Jones
    //1842644, 1837302
    //2020-02-17
    //The PlayerPiano class contains the main method which runs the program to play the piano
    class PlayerPiano
    {
        //The main method will read input from a file, create a piano object and play the notes from the file
        public static void Main(string[] args)
        {
            //Audio object is created to actually play the notes
            Audio player = new Audio();

            //File is read and a new Piano object is created using the key mapping
            string[] allData = File.ReadAllLines("chopsticks.txt");
            string keys = allData[0];
            Piano piano = new Piano(keys, 44100);
            int count;
            
            //For goes through all lines after key mapping
            for (int i = 1; i < allData.Length; i++)
            {
                //For goes through each character in the line
                string line = allData[i];
                int j = 0;
                
                    //StrikeKey is called
                    piano.StrikeKey(line[j]);
                    if (line.Length > 1)
                    {
                        if (line.Length > 1)
                        {
                            piano.StrikeKey(line[j + 1]);
                        }
                    }

                    count = 1;
                    //While loop makes sure there are enough samples to play the note
                    while(count != 0)
                    {
                        player.Play(piano.Play());
                        count++; //count number of samples
                        if (count > 44100 * 1)
                        {
                            count = 0;

                        }
                    }
                    //Console.Read();
                
                Thread.Sleep(400); //delay

                
            }

        }
    }
}