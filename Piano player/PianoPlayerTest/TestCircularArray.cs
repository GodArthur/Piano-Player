using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PianoPlayer;

namespace PianoPlayerTest
{
    [TestClass]
    public class TestCircularArray
    {
        [TestMethod]
        public void TestFill()
        {
            //initial array
            double[] array = new double[] { 1, 2, 3, 4 };

            //new ring buffer being created
            CircularArray buffer = new CircularArray(4);

            //filling up the buffer
            buffer.Fill(array);

            //creating a second array to store the values of the buffer
            double[] temp = new double[buffer.Length];

            for (int i = 0; i < buffer.Length; i++)
            {
                temp[i] = buffer[i];
            }
            CollectionsAssert.AreEqual(array, temp);
            //Assert.equals(1, buffer[0]);
            
        }
    }
}
