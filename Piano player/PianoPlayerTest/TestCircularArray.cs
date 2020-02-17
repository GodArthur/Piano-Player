﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PianoPlayer;

namespace PianoPlayerTest
{
    /// <summary>
    /// class tests the methods of the CircularArray class
    /// </summary>
    /// <remarks>
    /// The class tests the Fill and Shift method
    /// </remarks>
    [TestClass]
    public class TestCircularArray
    {

        [TestMethod]
        public void ConstructorTest()
        {

            CircularArray circle = new CircularArray(5);
            Assert.AreEqual(5, circle.Length);
        }

        [TestMethod]
        public void IndexTest()
        {
            double[] array = new double[] { 1, 2, 3, 4 };

            //new ring buffer being created
            CircularArray circle = new CircularArray(4);

            //filling up the circle
            circle.Fill(array);
            Assert.AreEqual(3.0, circle[2]);
        }

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

            //Storing the array
            for (int i = 0; i < buffer.Length; i++)
            {
                temp[i] = buffer[i];
            }
            CollectionAssert.AreEqual(array, temp);
        }

        [TestMethod]
        public void TestShift()
        {
            double[] array = new double[] { 1, 2, 3, 4 };

            //new ring buffer being created
            CircularArray buffer = new CircularArray(array.Length);

            //filling up the buffer
            buffer.Fill(array);

            //shifting the array positions (replacing 1 and 2)
            buffer.Shift(5);
            buffer.Shift(6);

            Assert.AreEqual("56", buffer[0] + "" + buffer[1], true);
        }


        [TestMethod]
        //Testing if the queue doesn't go out of bounds when shifting
        //and circles back to the beginning
        public void TestShiftFullCircle()
        {
            double[] array = new double[] { 1, 2, 3, 4 };

            //new ring buffer being created
            CircularArray buffer = new CircularArray(4);

            //filling up the buffer
            buffer.Fill(array);

            //shifting the array positions full circle
            buffer.Shift(5);
            buffer.Shift(6);
            buffer.Shift(7);
            buffer.Shift(8);
            buffer.Shift(9);

            //Checking the new first and last position
            Assert.AreEqual("98", buffer[0] + "" + buffer[buffer.Length - 1], true);
        }

        [TestMethod]
        public void TestFront()
        {
            double[] array = new double[] { 1, 2, 3, 4 };

            //new ring buffer being created
            CircularArray buffer = new CircularArray(array.Length);

            //filling up the buffer
            buffer.Fill(array);

            //shifting the array positions (replacing 1 and 2)
            buffer.Shift(5);
            buffer.Shift(6);

            Assert.AreEqual(3, buffer[buffer.Front]);
        }

    }
}
