using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagtekCardReader
{
    public class Data
    {
        private string _errorMessage = string.Empty;
        private readonly byte[] _data;

        public Data(byte[] data)
        {
            _data = GetCardData(data);
        }

        public string ErrorMessage { get { return _errorMessage; } }
        public bool Error { get; private set; }
        public byte[] CardData { get { return _data; } }

        private byte[] GetCardData(byte[] data)
        {
            var cardData = new byte[data.Length];

            if (data != null)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    Console.WriteLine("i" + i.ToString() +"->" + data[i].ToString());
                    
                }

                Array.Copy(data, cardData, data.Length-3);
                return cardData;
            }
            else
            {
                Error = true;
                _errorMessage = "Data length is invalid";
            }
            return null;
           
               /* if (data != null && data.Length == 337)
                {
                    if (data[0] == 1 || data[1] == 1 || data[2] == 1)
                    {
                        Error = true;
                        _errorMessage = "Error reading data";
                        return null;
                    }
                    var cardData = new byte[data[3] + data[4] + data[5]];
                    //Array.Copy(data, 7, cardData, 0, data[3]);
                    //Array.Copy(data, 117, cardData, data[3], data[4]);
                    //Array.Copy(data, 227, cardData, data[3] + data[4], data[5]);
                    return data;
                }*/
           // Error = true;
           // _errorMessage = "Data length is invalid";
           // return null;
        }
    }
}
