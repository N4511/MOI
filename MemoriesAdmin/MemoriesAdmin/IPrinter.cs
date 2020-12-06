using System;
using System.Collections.Generic;
using System.Text;

namespace MemoriesAdmin
{
    public interface IPrinter
    {
        void Print(string ipAddress, int port, IList<string> linesToPrint);
        void PrintQRCODE(string ipAddress, int port, string code);
        void PrintDevider(string ipAddress, int port, string code);
    }
}
