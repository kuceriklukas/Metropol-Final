using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MetropolFinal2.Common;
using MetropolFinal2.Model;
using MetropolFinal2.ViewModel;
using MetropolFinal2.Singleton;

namespace MetropolTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DateTimePeriod date = DateTimePeriodConverter.ToDate("1/9/2012");
            Assert.AreEqual("1/9/2012 0:0", DateTimePeriodConverter.ToString(date));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(5, DateTimePeriodConverter.MakeMonth("05"));
        }

        private int CalculatorStartTime(bool[] CheckBoxes)    //because of problems with connecting to TimePageVM I took a part of code from
        {                                                     //that class and tested it here as standalone method
            int StartTime;
            for (int i = 0; i < CheckBoxes.Length; i++)
            {
                if (CheckBoxes[i] == true)
                {
                    StartTime = i + 8;
                    return StartTime;
                }
            }
            return 0;
        }

        private int CalculatorEndTime(bool[] CheckBoxes)     //the same here
        {
            int EndTime = 0;
            for (int i = 0; i < CheckBoxes.Length; i++)
            {
                if (CheckBoxes[i] == true)
                {
                    EndTime = i + 9;
                }
            }
            return EndTime;
        }

        [TestMethod]
        public void TestMethod3()
        {
            bool[] myCheckBoxes = new bool[12] { false, false, true, true, false, false, false,
                                        false, false, false, false, false};
            Assert.AreEqual(10, CalculatorStartTime(myCheckBoxes));
        }

        [TestMethod]
        public void TestMethod4()
        {
            bool[] myCheckBoxes = new bool[12] { false, false, false, false, false, true, true,
                                        true, true, false, false, false};
            Assert.AreEqual(17, CalculatorEndTime(myCheckBoxes));
        }
        
        //private void FillValues() //filling values for TimePageVM, so it won't throw an exception when start
        //{
        //    BookingSingleton bs = BookingSingleton.Instance;
        //    bs.SelectedDate = DateTimePeriodConverter.ToDate("15/12/2015 8:20");
        //    bs.SelectedRoom = new Room() { RommID = 1, NumOfSeats = 3, OtherFacilities = "", Projector = 1, WhiteBoard = 1};
        //}

        //[TestMethod]
        //public void TestMethod3()
        //{
        //    //FillValues();
        //    TimePageVM vm = new TimePageVM();
        //    Assert.AreEqual(10, vm.AssignHourValues(11));
        //}

        //[TestMethod]
        //public void TestMethod4()
        //{
        //    TimePageVM vm = new TimePageVM();
        //    Assert.AreEqual(50, vm.AssignMinuteValues(15));
        //}
    }
}
