using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PianoPlayer;

namespace PianoPlayerTest
{
    [TestClass]
    public class PianoTest
    {
        [TestMethod]
        public void PlayOneNoteTest()
        {
            Piano testPiano = new Piano("q2we4r5ty7u8i9op-[=zxdcfvgbnjmk,.;/' ", 44100);
            testPiano.StrikeKey(q);

        }
    }
}
