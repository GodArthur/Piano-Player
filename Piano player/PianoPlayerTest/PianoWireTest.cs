using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PianoPlayer;

namespace PianoPlayerTest
{
    [TestClass]
    public class PianoWireTest
    {

        /// <summary>
        /// Testing the Strike() method
        /// </summary>
        /// <remarks>
        /// Testing the highest value to see if it greater than 0.5
        /// </remarks>
        [TestMethod]
        public void StrikeHighestTest()
        {
            //creating a new PianoWire
            PianoWire pw = new PianoWire(5, 25);
            pw.Strike();

            //Stering a copy of the circular array into a new buffer
            CircularArray buffer = pw.getWires();

            //storing the buffer values into a new array
            double[] temp = buffer.getValues();

            //sorting the values of the array
            Array.Sort(temp);

            Assert.IsTrue(temp[temp.Length - 1] <= 0.5);
        }

        /// <summary>
        /// Testing the Strike() method
        /// <remarks>
        /// Testing the lowest value to see if it greater than -0.5
        /// </remarks>
        /// </summary>
        [TestMethod]
        public void StrikeLowestTest()
        {
            //creating a new PianoWire
            PianoWire pw = new PianoWire(5, 25);
            pw.Strike();

            //Stering a copy of the circular array into a new buffer
            CircularArray buffer = pw.getWires();

            //storing the buffer values into a new array
            double[] temp = buffer.getValues();

            //sorting the values of the array
            Array.Sort(temp);

            Assert.IsTrue(temp[0] <= 0.5);
        }



        [TestMethod]
        public void SampleTest()
        {
            //creating a PianoWire
            PianoWire pw = new PianoWire(5, 25);

            //calling strike() method
            pw.Strike();

            //storing the initial values of the array
            CircularArray buffer = pw.getWires();

            double[] beforeSample = buffer.getValues();

            double decay = 3;
            
            //adding new value to queue
            pw.Sample(decay);

            //Storing the new value of the array
            CircularArray buffer2 = pw.getWires();

            double[] afterSample = buffer2.getValues();

            double value = ((beforeSample[0] + beforeSample[1]) / 2) * decay;
            Assert.AreEqual(value, afterSample[0]);

        }
    }
}
