using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bookStruct
{
    //TODO :  Barrier
    //
    class Program
    {
        private static PerformanceCounter totalImages, imagesPerSecond;
        enum Months
        {
            Jan = 1, Feb, Mar, Apr, May, Jun, Jul, Aug, Sept,
            Oct, Nov, Dec
        };
        public static double ReadDataFromIO()
        {
            // We are simulating an I/O by putting the current thread to sleep.
            Thread.Sleep(2000);
            return 10d;
        }
        public static Task<double> ReadDataFromIOAsync()
        {
            return Task.Run(() => ReadDataFromIO());
        }
        static void Main(string[] args)
        {
            totalImages = new PerformanceCounter("test", "cpt1", false);
            totalImages.MachineName = ".";
            imagesPerSecond= new PerformanceCounter("test", "cpt2", false);
            imagesPerSecond.MachineName = ".";
            for (int i = 0; i < 10; i++)
            {
                totalImages.Increment();
                imagesPerSecond.Increment();
                Thread.Sleep(1000);
            }
            Array arrayTest = new int[2, 3];
            int[] myArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var evenNumbers = from i in myArray
                              where i % 2 == 0
                              select i;
            foreach (int i in evenNumbers)
            {
                Debug.WriteLine(i);
            }
            myArray[1] = 12;
            foreach (int i in evenNumbers)
            {
                Debug.WriteLine(i);
            }

            ArrayList myList = new ArrayList
            {
                new MyObject() { ID = 4 },
                new MyObject() { ID = 1 },
                new MyObject() { ID = 5 },
                new MyObject() { ID = 3 },
                new MyObject() { ID = 2 }
            };
            myList.Sort();
            foreach (var i in myList)
            {
                Debug.WriteLine((i as MyObject).ID);
            }

            var result = myList.BinarySearch(new MyObject { ID = 5 });
            Debug.WriteLine($"{result}");

        }

        class MyObject : IComparable
        {
            public int ID { get; set; }

            public int CompareTo(object obj)
            {
                if (obj is MyObject)
                {
                    return ID.CompareTo((obj as MyObject).ID);
                }
                return -1;
            }
        }
    }
}
