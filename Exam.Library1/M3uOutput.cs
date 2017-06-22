using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Exam.Library1
{
    public class M3uOutput : Common.IPlugin
    {
        public void Format(FileInfo file, CancellationToken token)
        {
            Console.WriteLine($"Treating file {file.Name} by {this.GetType().Assembly.GetName()}");
        }
    }
}
