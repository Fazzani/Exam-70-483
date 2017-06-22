using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Exam.Library2
{
    public class TvListOutput : Common.IPlugin
    {
        public void Format(FileInfo file, CancellationToken token)
        {
            Console.WriteLine($"Treating file {file.Name} by {this.GetType().Assembly.GetName()}");
        }
    }
}
