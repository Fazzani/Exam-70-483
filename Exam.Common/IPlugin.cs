using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exam.Common
{
    public interface IPlugin
    {
        void Format(FileInfo file, CancellationToken token);
    }
}
