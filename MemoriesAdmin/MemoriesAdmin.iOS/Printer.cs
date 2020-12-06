using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using UIKit;
using MemoriesAdmin;
using Xamarin.Forms;
using System.Net.Sockets;


[assembly: Dependency(typeof(MemoriesAdmin.iOS.Printer))]
namespace MemoriesAdmin.iOS

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

            List<byte> outputList = new List<byte>();
            // Send the command to the printer
            //print_4SQUARE(pSocket, "ORDER:700");
            print_QRCODE(pSocket, "ORDER:700");

            print_4SQUARE(pSocket, "...................");
            print_NORMAL(pSocket, "1 * Chicken Shonar Bangla");

            print_NORMAL(pSocket, "1 * Chicken Tikka Masala");
            print_NORMAL(pSocket, "1 * Bombay Aloo");

            print_NORMAL(pSocket, "3 * Pilau Rice");
            print_NORMAL(pSocket, "1 * Keema Nan");
            print_4SQUARE(pSocket, "................");
            print_NORMAL(pSocket, "Bobby Chauhan");
            print_NORMAL(pSocket, "4 Robin Parade");

            print_NORMAL(pSocket, "SL2 3QL");
            print_NORMAL(pSocket, "01753 644166");
            print_4SQUARE(pSocket, "................");
            /*
            pSocket.Send(Commands.TXT_ALIGN_CT);
            pSocket.Send(Commands.BARCODE_HEIGHT);
            pSocket.Send(Commands.BARCODE_WIDTH);
            pSocket.Send(Commands.BARCODE_FONT_A);
            pSocket.Send(Commands.BARCODE_TXT_ABV);
            pSocket.Send(Commands.BARCODE_CODE39);
            pSocket.Send(System.Text.Encoding.UTF8.GetBytes("ABC123456789"));
            pSocket.Send(Commands.CTL_LF);

            */

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
            pSocket.Send(Commands.NEW_LINE);
            pSocket.Send(Commands.NEW_LINE);
            pSocket.Send(Commands.NEW_LINE);
            pSocket.Send(Commands.HW_INIT);

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

        public void PrintQRCODE(string ipAddress, int port, string code)
        {
            throw new NotImplementedException();
        }

        public void PrintDevider(string ipAddress, int port, string code)
        {
            throw new NotImplementedException();
        }
    }
}