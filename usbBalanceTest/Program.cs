using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;



namespace usbBalanceTest
{
    class Program
    {
       private const int VendorId = 0x0EB8;
        private const int ProductId = 0xF000;

        private static HidDevice _device;

        static void Main()
        {
            _device = HidDevices.Enumerate(VendorId, ProductId).FirstOrDefault();

            if (_device != null)
            {
                _device.OpenDevice();

                _device.Inserted += DeviceAttachedHandler;
                _device.Removed += DeviceRemovedHandler;

                _device.MonitorDeviceEvents = true;

                _device.ReadReport(OnReport);

                Console.WriteLine("Dispositivo encontrado.");
                System.Threading.Thread.Sleep(2000);
                //Console.ReadKey();

                _device.CloseDevice();
            }
            else
            {
                Console.WriteLine("Dispositivo no encontrado");
                //Console.ReadKey();
            }
        }

        private static void OnReport(HidReport report)
        {
            if (!_device.IsConnected) { return; }
            int iOverFlow = 0;
            decimal weight = 0;

           // MagtekCardReader.Data carData = new MagtekCardReader.Data(report.Data);

           //var cardData = new MagtekCardReader.Data(report.Data);

            //decimal weight = Convert.ToDecimal(report.Data[3]) + 256;

            if (report.Data ==null)
            {
                Console.WriteLine("ERROR" );
                return;
            }

            iOverFlow = Convert.ToInt32(report.Data[4]);
            if (iOverFlow > 0)
                weight = (Convert.ToDecimal(iOverFlow * 256) + Convert.ToDecimal(report.Data[3]))  / 100;
            else
                weight = (Convert.ToDecimal(report.Data[3]) + 256) / 100;


            
            Console.WriteLine("PESO:" + weight.ToString());
         

            //_device.ReadReport(OnReport);
        }

        private static void DeviceAttachedHandler()
        {
            Console.WriteLine("Device attached.");
            //_device.ReadReport(OnReport);
        }

        private static void DeviceRemovedHandler()
        {
            Console.WriteLine("Device removed.");
        }
    }

    }

