using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Exam.Library1
{
    public sealed class M3uOutput : Common.IPlugin, IFormattable
    {
        public void Format(FileInfo file, CancellationToken token)
        {
            Console.WriteLine($"Treating file {file.Name} by {this.GetType().Assembly.GetName()}");
        }

        string IFormattable.ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
                return GetType().Name;
            else
                switch (format)
                {
                    case "f":
                        return GetType().FullName;
                    case "s":
                    default:
                        return GetType().Name;
                }
        }
    }
}
