using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PianoPlayer;

namespace PianoPlayerTest
{
    //Author: Andrzej Fedorowicz
    //1842644
    //2020-02-17
    //The only feasible method that I would be able to check is the Play() method since the StrikeKey creates completely random resultd
    //and is also checked in other test cases
    [TestClass]
    public class PianoTest
    {

        /// <summary>
        /// Testing the Play() method
        /// </summary>
        /// <remarks>
        /// Testing if the output of the method corresponds to the expected output on one note
        /// There wasn't really a definitive way to figure out what the buffer would be each time, so I basically manually
        /// found out the first value in the buffer and compared it to the output of the test case
        /// </remarks>
        [TestMethod]
        public void PlayOneNoteTest()
        {
            //There isn't really a feasible way to test whether or not the sampling returned will add up to the same thing for two different piano's
            //so I just made copied over 
            Piano testPiano = new Piano("q2we4r5ty7u8i9op-[=zxdcfvgbnjmk,.;/' ", 44100);
            testPiano.StrikeKey('q');
            PianoWire testWire = (PianoWire)testPiano.returnKeyAtIndex('q');
            double[] testArray = testWire.buffer.getValues();

            Assert.AreEqual(testArray[0], testPiano.Play());
        }

        /// <summary>
        /// Testing the Play() method with multiple notes being struck
        /// </summary>
        /// <remarks>
        /// Testing if the output of the method corresponds to the expected output on multiple notes (make sure the adding is performed correctly
        /// </remarks>
        [TestMethod]
        public void PlayMultipleNotesTest()
        {
            Piano testPiano = new Piano("q2we4r5ty7u8i9op-[=zxdcfvgbnjmk,.;/' ", 44100);
            testPiano.StrikeKey('q');
            testPiano.StrikeKey('2');
            testPiano.StrikeKey('w');
            PianoWire testWire1 = (PianoWire)testPiano.returnKeyAtIndex('q');
            PianoWire testWire2 = (PianoWire)testPiano.returnKeyAtIndex('2');
            PianoWire testWire3 = (PianoWire)testPiano.returnKeyAtIndex('w');

            double[] testArray1 = testWire1.buffer.getValues();
            double[] testArray2 = testWire2.buffer.getValues();
            double[] testArray3 = testWire3.buffer.getValues();
            double result = testArray1[0] + testArray2[0] + testArray3[0];

            Assert.AreEqual(result, testPiano.Play());
        }
    }
}
