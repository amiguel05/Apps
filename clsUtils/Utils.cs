using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace clsUtils
{
    
    public static class Utils
    {

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern bool GetVolumeInformation(string Volume, StringBuilder VolumeName,
            uint VolumeNameSize, out uint SerialNumber, out uint SerialNumberLength,
            out uint flags, StringBuilder fs, uint fs_size);

        
        public static string ObtenerSerialTerminal()
        {
            uint serialNum, serialNumLength, flags;
            var volumename = new StringBuilder(256);
            var fstype = new StringBuilder(256);
            var ok = GetVolumeInformation("c:\\", volumename,
            (uint)volumename.Capacity - 1, out serialNum, out serialNumLength,
            out flags, fstype, (uint)fstype.Capacity - 1);
            return serialNum.ToString().Encrypt();
        }
    }
}
