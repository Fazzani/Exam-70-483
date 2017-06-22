using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using static Exam_70_483.Chapitre2;
using Exam.Common;
using System.Reflection;
using System.Globalization;

namespace Exam_70_483
{
    class Program
    {
        //TODO: Indexer example
        class Base
        {
            public void Execute() { Console.WriteLine("Base.Execute"); }
        }
        class Derived : Base
        {
            public new void Execute() { Console.WriteLine("Derived.Execute"); }
        }
        static void Main(string[] args)
        {

            #region Reflection plugins
            var plugins = Chapitre2.LoadPlugins();
            List<IPlugin> pluginsInstances = new List<IPlugin>();
            var culture = new CultureInfo("fr-FR");
            foreach (var plugin in plugins)
            {
                pluginsInstances.Add(Activator.CreateInstance(plugin) as IPlugin);
            }

            foreach (var pluginInstance in pluginsInstances)
            {
                Console.WriteLine($"Fullname : {pluginInstance:f}{Environment.NewLine}");
                Console.WriteLine($"Name :{pluginInstance:s}{Environment.NewLine}");
                
                pluginInstance.Format(new System.IO.FileInfo(Assembly.GetExecutingAssembly().FullName), CancellationToken.None);
            }
            Console.ReadKey();
            #endregion


            //var arrayMoney = new Money[] { new Money(10), new Money(11), new Money(12), new Money(1), new Money(5) };
            //Array.Sort(arrayMoney);
            //MoneyCollection moneys = new MoneyCollection(arrayMoney);
            //foreach (var money in moneys)
            //{
            //    Console.WriteLine($"Money {money.Amount}");
            //}

            //Base b = new Base();
            //b.Execute();
            //b = new Derived();
            //b.Execute();
            //var ab = new Derived();
            //ab.Execute();
        }

        private static void ImplicitExplicitOperators()
        {
            #region Implicit && Explicit Operators
            var money = new Money(10);
            int amount = money;
            money = (Money)amount;
            #endregion
        }

        public struct Student
        {
            public string firstName;
            public string lastName;
            private string courseName;
            public Student(string first, string last, string course)
            {
                this.firstName = first;
                this.lastName = last;
                this.courseName = course;
            }
        }
    }
}
