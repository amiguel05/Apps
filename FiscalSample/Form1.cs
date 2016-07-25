using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace FiscalSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        FiscalNET.EpsonDO IFiscal = new FiscalNET.EpsonDO();

           
        private void button1_Click(object sender, EventArgs e)
        {
            long nError = 0;
         

        //   IFiscal.Printer = "TMT88";

           
         
            nError = IFiscal.IF_OPEN("COM4",38400);


           // nError = IFiscal.GetDateTime();
          
          
            MessageBox.Show(IFiscal.IF_ERROR1(0).ToString());

           nError = IFiscal.IF_WRITE("@GetPrinterVersion|P");
 
            //MsgBox CStr(IFiscal.IF_ERROR1(0)) 





 







        }

        private void button3_Click(object sender, EventArgs e)
        {
            long nError = 0;

            nError = IFiscal.TicketOpen("A", 0, 1, "", "", "", "", "P", 0, 0, 0);


            //Imprime el código de estado del impresor fiscal

            MessageBox.Show(IFiscal.IF_ERROR1(0).ToString()); 



            nError = IFiscal.IF_WRITE("@TicketItem|Mouse Genius XScrol|1.0|2040.00|11.00|M|N");

            nError = IFiscal.IF_WRITE("@TicketItem|Patchcord Cat.5E Gr|5.0|2060.00|11.00|M|N");

            nError = IFiscal.IF_WRITE("@TicketItem|Microfono NG-H300 N|1.0|2060.00|11.00|M|N");

            nError = IFiscal.IF_WRITE("@TicketItem|Mouse Genius Netscr|1.0|2060.00|11.00|M|N");

            nError = IFiscal.IF_WRITE("@TicketItem|Ventilador Cyber Co|2.0|2060.00|11.00|M|N");

            nError = IFiscal.IF_WRITE("@TicketItem|Lector 3.5 MultiCar|2.0|2110.00|11.00|M|N");

            nError = IFiscal.IF_WRITE("@TicketItem|Teclado Noganet Esp|2.0|2150.00|11.00|M|N");

            nError = IFiscal.IF_WRITE("@TicketItem|Antena SMA Kozumi W|2.0|2165.00|11.00|M|N");

            nError = IFiscal.IF_WRITE("@TicketItem|Teclado Ecovision W|1.0|2195.00|11.00|M|N");

            nError = IFiscal.IF_WRITE("@TicketItem|Limpiador para Pant|1.0|2220.00|11.00|M|N");

            nError = IFiscal.IF_WRITE("@TicketItem|Auricular Genius Mo|1.0|2230.00|11.00|M|N");

            nError = IFiscal.IF_WRITE("@TicketSubtotal");

            nError = IFiscal.IF_WRITE("@TicketPayment|1|50000.00");

            nError = IFiscal.IF_WRITE("@TicketClose");


            //Imprime el código de estado del impresor fiscal

            MessageBox.Show(IFiscal.IF_ERROR1(0).ToString()); 

 

//Imprime el código de estado del impresor fiscal

MessageBox.Show(IFiscal.IF_ERROR2(0).ToString());

 

//ecuperar el campo Nro. 1 de la respuesta fiscal

 
MessageBox.Show( IFiscal.IF_READ(1) );

 

nError =IFiscal.IF_CLOSE();

 



        }

        private void button2_Click(object sender, EventArgs e)
        {
           //brir el puerto de comunicaciones

            int err= 0;
            
err = IFiscal.IF_OPEN("COM4",38400); 

 

//Efectuar un cierrez

err = IFiscal.IF_WRITE("@DailyCloseZ|P"); 

 

//Recuperar el estado del controlador fiscal

MessageBox.Show(IFiscal.IF_ERROR2(0).ToString());

 

//Cerrar el puerto de comunicaciones

err = IFiscal.IF_CLOSE(); 

 


        }

        private void button4_Click(object sender, EventArgs e)
        {
            SerialPort oPort = new SerialPort("COM4", 38400);

            oPort.DataBits = 8;

            oPort.Open();

            string s = "0210";

            byte[] oByte = System.Text.ASCIIEncoding.ASCII.GetBytes(s.ToCharArray());

            oPort.Write(oByte, 1, oByte.Length-1);
            //string message = oPort.ReadLine();
            //Console.WriteLine(message);

            oPort.Close();

        }
    }
}
