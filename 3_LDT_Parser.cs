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
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LDTandIEStoXMLConverter
{
    class Parse_LDT
    {
        //private List<String> LdtLines = new List<String>();
        //public List<String> Ldtlines { get { return LdtLines; } }

        //private String ManuFacture;
        //public String Manufacture { get { return ManuFacture; } }

        //Create_UNI11733_Xml xmlvariables = new Create_UNI11733_Xml();
                    
        public void ParseLDT()
        {
            int lineCount = File.ReadLines(Photometric_management.Instance.FullFileName).Count();
            string[] lines = (System.IO.File.ReadAllLines(Photometric_management.Instance.FullFileName));// the file.
           
            for (int i=0; i< lineCount; i++ )
            {
                Create_UNI11733_Xml.Instance.Ldtlines.Add(lines[i]);
            }

            
            Create_UNI11733_Xml.Instance.Manufacture = Create_UNI11733_Xml.Instance.Ldtlines[0];

            Create_UNI11733_Xml.Instance.NumberHorizontal = Convert.ToInt32(Create_UNI11733_Xml.Instance.Ldtlines[3]);
            Create_UNI11733_Xml.Instance.NumberVertical = Convert.ToInt32(Create_UNI11733_Xml.Instance.Ldtlines[5]);

            if (Decimal.TryParse(Create_UNI11733_Xml.Instance.Ldtlines[4], out Create_UNI11733_Xml.Instance.DistanceCPlanes))
            {
                ;
            }
            else Create_UNI11733_Xml.Instance.DistanceCPlanes = 0;

            Create_UNI11733_Xml.Instance.ReportNumber = Create_UNI11733_Xml.Instance.Ldtlines[7];
            Create_UNI11733_Xml.Instance.Model_Description = Create_UNI11733_Xml.Instance.Ldtlines[8];
            Create_UNI11733_Xml.Instance.CatalogNumber = Create_UNI11733_Xml.Instance.Ldtlines[9];
            Create_UNI11733_Xml.Instance.NameInFile = Create_UNI11733_Xml.Instance.Ldtlines[10];
            if (String.IsNullOrEmpty(Create_UNI11733_Xml.Instance.Ldtlines[11]) == false)
            {
                Create_UNI11733_Xml.Instance.ReportDate = Create_UNI11733_Xml.Instance.Ldtlines[11].ToString();
            }
            else
            {
                Create_UNI11733_Xml.Instance.ReportDate = DateTime.Now.ToString();
            }
            Create_UNI11733_Xml.Instance.DocCreateDate = DateTime.Now;

            Create_UNI11733_Xml.Instance.Length = Convert.ToDecimal(Create_UNI11733_Xml.Instance.Ldtlines[12]);
            Create_UNI11733_Xml.Instance.Width = Convert.ToDecimal(Create_UNI11733_Xml.Instance.Ldtlines[13]);
            Create_UNI11733_Xml.Instance.Height = Convert.ToDecimal(Create_UNI11733_Xml.Instance.Ldtlines[14]);

            if (Decimal.TryParse(Create_UNI11733_Xml.Instance.Ldtlines[15], out Create_UNI11733_Xml.Instance.LumLength))
            {
                ;
            }
            else Create_UNI11733_Xml.Instance.LumLength = 0;

            if (Decimal.TryParse(Create_UNI11733_Xml.Instance.Ldtlines[16], out Create_UNI11733_Xml.Instance.LumWidth))
            {
                ;
            }
            else Create_UNI11733_Xml.Instance.LumWidth = 0;

            if (Decimal.TryParse(Create_UNI11733_Xml.Instance.Ldtlines[17], out Create_UNI11733_Xml.Instance.hC0))
            {
                ;
            }
            else Create_UNI11733_Xml.Instance.hC0 = 0;

            if (Decimal.TryParse(Create_UNI11733_Xml.Instance.Ldtlines[18], out Create_UNI11733_Xml.Instance.hC90))
            {
                ;
            }
            else Create_UNI11733_Xml.Instance.hC90 = 0;

            if (Decimal.TryParse(Create_UNI11733_Xml.Instance.Ldtlines[19], out Create_UNI11733_Xml.Instance.hC180))
            {
                ;
            }
            else Create_UNI11733_Xml.Instance.hC180 = 0;

            if (Decimal.TryParse(Create_UNI11733_Xml.Instance.Ldtlines[20], out Create_UNI11733_Xml.Instance.hC270))
            {
                ;
            }
            else Create_UNI11733_Xml.Instance.hC270 = 0;

            Create_UNI11733_Xml.Instance.DFF = Convert.ToDecimal(Create_UNI11733_Xml.Instance.Ldtlines[21]);

            Create_UNI11733_Xml.Instance.NumberLightSource = Convert.ToInt32(Create_UNI11733_Xml.Instance.Ldtlines[25]);

            Create_UNI11733_Xml.Instance.Quantity = Convert.ToInt32(Create_UNI11733_Xml.Instance.Ldtlines[26]);
            Create_UNI11733_Xml.Instance.LampDescription = Create_UNI11733_Xml.Instance.Ldtlines[27];

            Create_UNI11733_Xml.Instance.RatedLumen = Convert.ToDecimal(Create_UNI11733_Xml.Instance.Ldtlines[28]);
            Create_UNI11733_Xml.Instance.InputWattage = Create_UNI11733_Xml.Instance.Ldtlines[31];
            Create_UNI11733_Xml.Instance.RaCRI = Create_UNI11733_Xml.Instance.Ldtlines[30];
            Create_UNI11733_Xml.Instance.FixedCCT = Create_UNI11733_Xml.Instance.Ldtlines[29];

            
            if (Int32.TryParse(Create_UNI11733_Xml.Instance.Ldtlines[22], out Create_UNI11733_Xml.Instance.LORL))
            {
                ;
            }
            else Create_UNI11733_Xml.Instance.LORL = 0;
            if (Create_UNI11733_Xml.Instance.LORL == 100)
                Create_UNI11733_Xml.Instance.ABSPhotom =true;
            else Create_UNI11733_Xml.Instance.ABSPhotom =false;

            
            if (Int32.TryParse(Create_UNI11733_Xml.Instance.Ldtlines[2], out Create_UNI11733_Xml.Instance.symm))
            {
                ;
            }
            else Create_UNI11733_Xml.Instance.symm = 0;
            

        }
        
        
    }
}
