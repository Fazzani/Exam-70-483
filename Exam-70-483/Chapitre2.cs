using Exam.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using Common;

namespace Exam_70_483
{
    internal class Chapitre2
    {
        #region Reflection Plugins

        internal static IEnumerable<Type> LoadPlugins()
        {
            var assemblyPlugins = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, "plugins"), "*.dll").Select(x => Assembly.LoadFile(x)).Where(x => x.GetCustomAttribute<FormaterTvListPluginAttribute>() != null);

            var plugins = from types in assemblyPlugins.SelectMany(x => x.GetTypes())
                          where typeof(IPlugin).IsAssignableFrom(types) && !types.IsInterface
                          select types;
            return plugins;
        }

        #endregion
        #region implicit explicit
        public class MoneyCollection : IEnumerable<Money>
        {
            Money[] _moneys;
            public MoneyCollection(Money[] moneyTab)
            {
                _moneys = moneyTab;
            }

            public IEnumerator<Money> GetEnumerator()
            {
                for (int i = 0; i < _moneys.Length; i++)
                {
                    yield return _moneys[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        public class Money : IComparable<Money>
        {
            public decimal Amount { get; set; }
            public Money(decimal amount)
            {
                Amount = amount;
            }

            public static implicit operator int(Money money)
            {
                return (int)money.Amount;
            }

            public static explicit operator Money(decimal amout)
            {
                return new Money(amout);
            }

            public int CompareTo(Money other)
            {
                if (other == null)
                    return 1;
                return Amount.CompareTo(other.Amount);
            }
            #endregion
        }
    }
}
