using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSet
{
    public enum Offsets
    {
        FrameLimiter = 0x00000000000005CE,
        Resolution = 0x00000000000005CF
    }

    public enum Resolution
    {
        X640x480x32 = 0x06,
        X800x600x32 = 0x07,
        X1024x768x32 = 0x08,
        X1280x600x32 = 0x09,
        X1280x760x32 = 0x0D,
        X1280x768x32 = 0x0B,
        X1360x768x32 = 0x0C,
        X1366x768x32 = 0x0D
    }

    public class VCSet
    {
        public string path = "";

        public VCSet()
        {
            path = Environment.ExpandEnvironmentVariables("%userprofile%\\Documents\\GTA Vice City User Files\\gta_vc.set");
        }

        public Resolution resolution
        {
            set
            {
                byte[] file = System.IO.File.ReadAllBytes(path);
                file[(int)Offsets.Resolution] = (byte)value;
                System.IO.File.WriteAllBytes(path, file);
            }
        }

        public bool framelimiter
        {
            get
            {
                byte[] file = System.IO.File.ReadAllBytes(path);
                return file[(int)Offsets.FrameLimiter] == 0x01 ? true : false;
            }
            set
            {
                byte[] file = System.IO.File.ReadAllBytes(path);
                file[(int)Offsets.FrameLimiter] = (byte)(value == true ? 0x01 : 0x00);
                System.IO.File.WriteAllBytes(path, file);
            }
        }
    }
}
