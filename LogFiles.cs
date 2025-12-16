using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab6
{
        public class LogFiles : IDisposable
        {
            private StreamWriter noFile;
            private StreamWriter badData;
            private StreamWriter overflow;

            public LogFiles()
            {
                noFile = new StreamWriter("no_file.txt", false);
                badData = new StreamWriter("bad_data.txt", false);
                overflow = new StreamWriter("overflow.txt", false);
            }

            public void WriteNoFile(string fileName)
            {
                noFile.WriteLine(fileName);
            }

            public void WriteBadData(string fileName)
            {
                badData.WriteLine(fileName);
            }

            public void WriteOverflow(string fileName)
            {
                overflow.WriteLine(fileName);
            }

            public void Dispose()
            {
                noFile?.Dispose();
                badData?.Dispose();
                overflow?.Dispose();
            }


        }
}
