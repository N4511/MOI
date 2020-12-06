using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MemoriesAdmin;
using System.Net.Sockets;

using System.Drawing;
using System.IO.Ports;
using System.Diagnostics;


[assembly: Dependency(typeof(MemoriesAdmin.UWP.Printer))]
namespace MemoriesAdmin.UWP
{
    public class Printer : IPrinter
    {


        public void Print(string ipAddress, int port, IList<string> linesToPrint)
        {

            // Create a socket object
            Socket pSocket = new Socket(SocketType.Stream, ProtocolType.IP);
            // Set a timeout for attemps to connect, here set to 1500 miliseconds
            pSocket.SendTimeout = 1500;
            // Connect to the specified ip address and port
            pSocket.Connect(ipAddress, port);

            foreach (string txt in linesToPrint)
            {
                print_NORMAL(pSocket, txt);               
            }

            // Close the connection once done
            pSocket.Close();



        }

        public void print_4SQUARE(Socket pSocket, string text)
        {
            pSocket.Send(Commands.TXT_ALIGN_CT);
            pSocket.Send(Commands.TXT_4SQUARE);
            pSocket.Send(System.Text.Encoding.UTF8.GetBytes(text));
            pSocket.Send(Commands.NEW_LINE);

        }

        public void print_NORMAL(Socket pSocket, string text)
        {

            pSocket.Send(Commands.TXT_ALIGN_LT);
            pSocket.Send(Commands.TXT_2HEIGHT);
            pSocket.Send(Commands.TXT_BOLD_OFF);
            pSocket.Send(System.Text.Encoding.UTF8.GetBytes(text));
            pSocket.Send(Commands.NEW_LINE);

        }
        public void print_QRCODE(Socket pSocket, string text)
        {
            pSocket.Send(Commands.TXT_ALIGN_CT);
            pSocket.Send(Commands.QR_CODE);
            pSocket.Send(System.Text.Encoding.UTF8.GetBytes(text));
            pSocket.Send(Commands.HW_INIT);
            pSocket.Send(Commands.HW_INIT);
            pSocket.Send(Commands.NEW_LINE);

        }

        public void LineFeed(Socket pSocket, int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                pSocket.Send(Commands.NEW_LINE);
            }

        }
        public void SetTextType(Socket pSocket, String type)
        {
            if (type.ToUpper() == "B")
            {
                pSocket.Send(Commands.TXT_BOLD_ON);
                pSocket.Send(Commands.TXT_UNDERL_OFF);
            }
            else if (type == "U")
            {
                pSocket.Send(Commands.TXT_BOLD_OFF);
                pSocket.Send(Commands.TXT_UNDERL_ON);
            }
            else if (type.Equals("U2"))
            {
                pSocket.Send(Commands.TXT_BOLD_OFF);
                pSocket.Send(Commands.TXT_UNDERL2_ON);
            }
            else if (type.Equals("BU"))
            {
                pSocket.Send(Commands.TXT_BOLD_ON);
                pSocket.Send(Commands.TXT_UNDERL_ON);
            }
            else if (type.Equals("BU2"))
            {
                pSocket.Send(Commands.TXT_BOLD_ON);
                pSocket.Send(Commands.TXT_UNDERL2_ON);
            }
            else if (type.Equals("NORMAL"))
            {
                pSocket.Send(Commands.TXT_BOLD_OFF);
                pSocket.Send(Commands.TXT_UNDERL_OFF);
            }


        }
        public void PrintDevider(string ipAddress, int port, string code)
        {
            // Create a socket object
            Socket pSocket = new Socket(SocketType.Stream, ProtocolType.IP);
            // Set a timeout for attemps to connect, here set to 1500 miliseconds
            pSocket.SendTimeout = 1500;
            // Connect to the specified ip address and port
            pSocket.Connect(ipAddress, port);

            print_4SQUARE(pSocket, code);

            // Close the connection once done
            pSocket.Close();
        }
        public void PrintQRCODE(string ipAddress, int port, string code)
        {
            // Create a socket object
            Socket pSocket = new Socket(SocketType.Stream, ProtocolType.IP);
            // Set a timeout for attemps to connect, here set to 1500 miliseconds
            pSocket.SendTimeout = 1500;
            // Connect to the specified ip address and port
            pSocket.Connect(ipAddress, port);

            print_QRCODE(pSocket, code);

            // Close the connection once done
            pSocket.Close();
        }
    }
}

