using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exam_70_483
{
    internal class Chapitre1
    {
        [ThreadStatic]
        private static int _localVariable;

        /// <summary>
        /// A higher-priority thread should be used only when it’s absolutely necessary
        ///  Only when all foreground threads end does the common language runtime (CLR) shut down your application
        /// </summary>
        /// <returns></returns>
        public static Thread CreatingThread()
        {
            Thread t = new Thread(new ThreadStart(() =>
            {
                Interlocked.Increment(ref _localVariable);
                _localVariable++;
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("ThreadProc:{0}", i);
                    Thread.Sleep(0);
                }

            }))
            {
                IsBackground = true
            };
            return t;
        }
        public static Thread CreatingParametrizedThread()
        {
            var t = new Thread(x =>
            {
                Console.WriteLine($"{x} as param");
                Thread.Sleep(100);
            });
            return t;
        }


        #region ConcurrentCollections
        static void BlockingCollection()
        {
            BlockingCollection<string> col = new BlockingCollection<string>();
            var readerTask = Task.Run(() =>
            {
                foreach (var c in col.GetConsumingEnumerable())
                {
                    Console.WriteLine($"{c} taked..");
                }
            });

            string val = string.Empty;
            var writerTask = Task.Run(delegate
            {
                do
                {
                    Console.WriteLine("Faites entrer une chaine");
                    val = Console.ReadLine();
                    col.Add(val);
                    Thread.Sleep(500);
                } while (val != "xxx");
                col.CompleteAdding();
                col.Add(val);
            });
            //readerTask.Wait();
            writerTask.Wait();
        }
        #endregion
    }
}
