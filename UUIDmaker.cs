/*----------------------------------------------------------------------------

Copyright © 2019 <Cristiano Guarnaschelli>

Permission is hereby granted, free of charge, to any person obtaining a copy of this software 
and associated documentation files (the “Software”), to deal in the Software without restriction, 
including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, 
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies 
or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE 
OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LDTandIEStoXMLConverter
{
    class UUIDmaker
    {
        [DllImport("rpcrt4.dll", SetLastError = true)]
        static extern int UuidCreateSequential(out System.Guid guid);


        public static string UUID_Make()
        {
            //                                           12345678 9012 3456 7890 123456789012
            // Returns a 36-character string in the form XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
            // where "X" is an "upper-case" hexadecimal digit [0-9A-F].
            // Use the LCase function if you want lower-case letters.

            byte[] abData = null;
            string strHex = null;

            // 1. Generate 16 random bytes = 128 bits
            //abData = Rng.Bytes(16);
            // DEBUGGING...
            //'Console.WriteLine("RNG=" & Cnv.ToHex(abData))

            // 2. Adjust certain bits according to RFC 4122 section 4.4.
            // This just means do the following
            // (a) set the high nibble of the 7th byte equal to 4 and
            // (b) set the two most significant bits of the 9th byte to 10'B,
            //     so the high nibble will be one of {8,9,A,B}.
            abData[6] = (byte)(0x40 | ((int)abData[6] & 0xf));
            abData[8] = (byte)(0x80 | ((int)abData[8] & 0x3f));

            // 3. Convert the adjusted bytes to hex values
            //strHex = Cnv.ToHex(abData);
            // DEBUGGING...
            //'Console.WriteLine("ADJ=" & Cnv.ToHex(abData))
            //'Console.WriteLine("                ^   ^") ' point to the nibbles we've changed

            // 4. Add four hyphen '-' characters
            //'strHex = Left$(strHex, 8) & "-" & Mid$(strHex, 9, 4) & "-" & Mid$(strHex, 13, 4) _
            //'    & "-" & Mid$(strHex, 17, 4) & "-" & Right$(strHex, 12)
            strHex = strHex.Substring(0, 8) + "-" + strHex.Substring(8, 4) + "-" + strHex.Substring(12, 4) + "-" + strHex.
            Substring(16, 4) + "-" + strHex.Substring(20, 12);

            // Return the UUID string
            return strHex;
        }



        public static System.Guid NewGuid()
        {
            return CreateSequentialUuid();
        }


        public static System.Guid CreateSequentialUuid()
        {
            const int RPC_S_OK = 0;
            System.Guid g;
            int hr = UuidCreateSequential(out g);
            if (hr != RPC_S_OK)
                throw new ApplicationException("UuidCreateSequential failed: " + hr);
            return g;
        }
    }

}