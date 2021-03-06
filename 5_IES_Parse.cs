﻿/*----------------------------------------------------------------------------

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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LDTandIEStoXMLConverter
{
    class IES_Parse
    {
        private List<String> IESLines = new List<String>();
        public List<String> IESlines { get { return IESLines; } }

        public int iesindex;

        public void ParseIES()
        {
            Create_UNI11733_Xml.Instance.NameInFile = Photometric_management.Instance.filename;

            int lineCount = File.ReadLines(Photometric_management.Instance.FullFileName).Count();
            string[] lines = (System.IO.File.ReadAllLines(Photometric_management.Instance.FullFileName));// the file.

            for (int i = 0; i < lineCount; i++)
            {
                IESlines.Add(lines[i]);
            }
            foreach (string test in IESlines)
            {
                if (test.Contains("[MANUFAC]"))
                    Create_UNI11733_Xml.Instance.Manufacture = test;
                else if (test.Contains("[LUMCAT]"))
                    Create_UNI11733_Xml.Instance.CatalogNumber = test;
                else if (test.Contains("[LUMINAIRE]"))
                    Create_UNI11733_Xml.Instance.Model_Description = test;
                else if (test.Contains("[TESTLAB]"))
                    Create_UNI11733_Xml.Instance.MaesureLaboratory = test;//modified by AW
                else if (test.Contains("[TEST]"))
                    Create_UNI11733_Xml.Instance.ReportNumber = test;
                else if (test.Contains("[ISSUEDATE]"))
                    Create_UNI11733_Xml.Instance.ReportDate = test;
                else if (test.Contains("[OTHER]"))
                    Create_UNI11733_Xml.Instance.Comments = test;
                else if (test.Contains("[LAMP]"))
                    Create_UNI11733_Xml.Instance.LampDescription = test;
                else if (test.Contains("[LAMPCAT]"))
                    Create_UNI11733_Xml.Instance.LampCatalogNumber = test;
                //else if (test.Contains("TILT=NONE"))

                //counter++;
            }

            iesindex = IESLines.IndexOf("TILT=NONE");
            //MessageBox.Show(iesindex.ToString());

            string firstline = IESLines[iesindex + 1];
            string[] firstlinearray = firstline.Split(' ');
            Create_UNI11733_Xml.Instance.Gonio = Int32.Parse(firstlinearray[5]);

            Create_UNI11733_Xml.Instance.NumberLightSource = Convert.ToInt32(firstlinearray[0]);

            if (firstlinearray[1] == "-1")
            {
                Create_UNI11733_Xml.Instance.ABSPhotom = true;
            }
            else
            {
                Create_UNI11733_Xml.Instance.ABSPhotom = false;
                Create_UNI11733_Xml.Instance.RatedLumen = Convert.ToDecimal(firstlinearray[1]);
            }

            int NHoriz;
            if (Int32.TryParse(firstlinearray[4], out NHoriz))
            {
                ;
            }
            else NHoriz = 0;
            Create_UNI11733_Xml.Instance.NumberHorizontal = NHoriz;
            int NVert;
            if (Int32.TryParse(firstlinearray[3], out NVert))
            {
                ;
            }
            else NVert = 0;
            Create_UNI11733_Xml.Instance.NumberVertical = NVert;

            //firstlinearray[5]; photometrict type
            //firstlinearray[6]; measure unt -> 2=meters

            Create_UNI11733_Xml.Instance.Length = Convert.ToDecimal(firstlinearray[7]);
            Create_UNI11733_Xml.Instance.Width = Convert.ToDecimal(firstlinearray[8]);
            Create_UNI11733_Xml.Instance.Height = Convert.ToDecimal(firstlinearray[9]);
            Create_UNI11733_Xml.Instance.LumLength = Convert.ToDecimal(firstlinearray[7]);
            Create_UNI11733_Xml.Instance.LumWidth = Convert.ToDecimal(firstlinearray[8]);
            Create_UNI11733_Xml.Instance.hC0 = Convert.ToDecimal(firstlinearray[9]);
            Create_UNI11733_Xml.Instance.hC90 = Convert.ToDecimal(firstlinearray[9]);
            Create_UNI11733_Xml.Instance.hC180 = Convert.ToDecimal(firstlinearray[9]);
            Create_UNI11733_Xml.Instance.hC270 = Convert.ToDecimal(firstlinearray[9]);

            if (Create_UNI11733_Xml.Instance.Length == 0)
            {
                // IESNA OPENING POINT
                Create_UNI11733_Xml.Instance.NBtmFace = 1;
                Create_UNI11733_Xml.Instance.NTopFace = 0;
                Create_UNI11733_Xml.Instance.NC0Face = 0;
                Create_UNI11733_Xml.Instance.NC90Face = 0;
                Create_UNI11733_Xml.Instance.NC180Face = 0;
                Create_UNI11733_Xml.Instance.NC270Face = 0;
                Create_UNI11733_Xml.Instance.CircularShapeBtm = false;
                Create_UNI11733_Xml.Instance.CircularShapeTop = false;
                Create_UNI11733_Xml.Instance.CircularShapeC0 = false;
                Create_UNI11733_Xml.Instance.CircularShapeC90 = false;
                Create_UNI11733_Xml.Instance.CircularShapeC180 = false;
                Create_UNI11733_Xml.Instance.CircularShapeC270 = false;
            }
            else if (Create_UNI11733_Xml.Instance.Length > 0)
            {
                if (Create_UNI11733_Xml.Instance.Width > 0)
                {
                    if (Create_UNI11733_Xml.Instance.Height == 0)
                    {
                        // IESNA OPENING RECTANGULAR
                        Create_UNI11733_Xml.Instance.NBtmFace = 1;
                        Create_UNI11733_Xml.Instance.NTopFace = 0;
                        Create_UNI11733_Xml.Instance.NC0Face = 0;
                        Create_UNI11733_Xml.Instance.NC90Face = 0;
                        Create_UNI11733_Xml.Instance.NC180Face = 0;
                        Create_UNI11733_Xml.Instance.NC270Face = 0;
                        Create_UNI11733_Xml.Instance.CircularShapeBtm = false;
                        Create_UNI11733_Xml.Instance.CircularShapeTop = false;
                        Create_UNI11733_Xml.Instance.CircularShapeC0 = false;
                        Create_UNI11733_Xml.Instance.CircularShapeC90 = false;
                        Create_UNI11733_Xml.Instance.CircularShapeC180 = false;
                        Create_UNI11733_Xml.Instance.CircularShapeC270 = false;
                    }
                    if (Create_UNI11733_Xml.Instance.Height > 0)
                    {
                        MessageBox.Show("RECTANGULAR WITH LUMINOUS SIDES");
                        // IESNA OPENING RECTANGULAR WITH LUMINOUS SIDES
                        Create_UNI11733_Xml.Instance.NBtmFace = 1;
                        Create_UNI11733_Xml.Instance.NTopFace = 0;
                        Create_UNI11733_Xml.Instance.NC0Face = 1;
                        Create_UNI11733_Xml.Instance.NC90Face = 1;
                        Create_UNI11733_Xml.Instance.NC180Face = 1;
                        Create_UNI11733_Xml.Instance.NC270Face = 1;
                        Create_UNI11733_Xml.Instance.CircularShapeBtm = false;
                        Create_UNI11733_Xml.Instance.CircularShapeTop = false;
                        Create_UNI11733_Xml.Instance.CircularShapeC0 = false;
                        Create_UNI11733_Xml.Instance.CircularShapeC90 = false;
                        Create_UNI11733_Xml.Instance.CircularShapeC180 = false;
                        Create_UNI11733_Xml.Instance.CircularShapeC270 = false;
                    }
                }
                else if (Create_UNI11733_Xml.Instance.Width < 0)
                {
                    if (Create_UNI11733_Xml.Instance.Height < 0)
                    {
                        MessageBox.Show(" HORIZ CYLINDER/ELLIPS ALONG C-0");
                        // IESNA OPENING HORIZ CYLINDER/ELLIPS ALONG C-0
                        Create_UNI11733_Xml.Instance.CircularShape = "Align_X";
                        Create_UNI11733_Xml.Instance.NBtmFace = 1;
                        Create_UNI11733_Xml.Instance.NTopFace = 1;
                        Create_UNI11733_Xml.Instance.NC0Face = 1;
                        Create_UNI11733_Xml.Instance.NC90Face = 1;
                        Create_UNI11733_Xml.Instance.NC180Face = 1;
                        Create_UNI11733_Xml.Instance.NC270Face = 1;
                        Create_UNI11733_Xml.Instance.CircularShapeBtm = false;
                        Create_UNI11733_Xml.Instance.CircularShapeTop = false;
                        Create_UNI11733_Xml.Instance.CircularShapeC0 = true;
                        Create_UNI11733_Xml.Instance.CircularShapeC90 = false;
                        Create_UNI11733_Xml.Instance.CircularShapeC180 = true;
                        Create_UNI11733_Xml.Instance.CircularShapeC270 = false;
                    }
                }

            }
            else if (Create_UNI11733_Xml.Instance.Length < 0)
            {
                if (Create_UNI11733_Xml.Instance.Width > 0)
                {
                    if (Create_UNI11733_Xml.Instance.Height < 0)
                    {
                        MessageBox.Show(" HORIZ CYLINDER/ELLIPS ALONG C-90");
                        // IESNA OPENING HORIZ CYLINDER/ELLIPS ALONG C-90
                        Create_UNI11733_Xml.Instance.CircularShape = "Align_Y";
                        Create_UNI11733_Xml.Instance.NBtmFace = 1;
                        Create_UNI11733_Xml.Instance.NTopFace = 1;
                        Create_UNI11733_Xml.Instance.NC0Face = 1;
                        Create_UNI11733_Xml.Instance.NC90Face = 1;
                        Create_UNI11733_Xml.Instance.NC180Face = 1;
                        Create_UNI11733_Xml.Instance.NC270Face = 1;
                        Create_UNI11733_Xml.Instance.CircularShapeBtm = false;
                        Create_UNI11733_Xml.Instance.CircularShapeTop = false;
                        Create_UNI11733_Xml.Instance.CircularShapeC0 = false;
                        Create_UNI11733_Xml.Instance.CircularShapeC90 = true;
                        Create_UNI11733_Xml.Instance.CircularShapeC180 = false;
                        Create_UNI11733_Xml.Instance.CircularShapeC270 = true;
                    }
                }
                else if (Create_UNI11733_Xml.Instance.Width < 0)
                {
                    if (Create_UNI11733_Xml.Instance.Height < 0)
                    {
                        // IESNA OPENING SPHERE/ELLIPS
                        Create_UNI11733_Xml.Instance.CircularShape = "Align_Z";
                        Create_UNI11733_Xml.Instance.NBtmFace = 1;
                        Create_UNI11733_Xml.Instance.NTopFace = 1;
                        Create_UNI11733_Xml.Instance.NC0Face = 1;
                        Create_UNI11733_Xml.Instance.NC90Face = 1;
                        Create_UNI11733_Xml.Instance.NC180Face = 1;
                        Create_UNI11733_Xml.Instance.NC270Face = 1;
                        Create_UNI11733_Xml.Instance.CircularShapeBtm = true;
                        Create_UNI11733_Xml.Instance.CircularShapeTop = true;
                        Create_UNI11733_Xml.Instance.CircularShapeC0 = true;
                        Create_UNI11733_Xml.Instance.CircularShapeC90 = true;
                        Create_UNI11733_Xml.Instance.CircularShapeC180 = true;
                        Create_UNI11733_Xml.Instance.CircularShapeC270 = true;
                    }
                    else if (Create_UNI11733_Xml.Instance.Height > 0)
                    {
                        // IESNA OPENING VERTICAL CYLINDER/ELLIPS
                        Create_UNI11733_Xml.Instance.CircularShape = "Align_Z";
                        Create_UNI11733_Xml.Instance.NBtmFace = 1;
                        Create_UNI11733_Xml.Instance.NTopFace = 1;
                        Create_UNI11733_Xml.Instance.NC0Face = 1;
                        Create_UNI11733_Xml.Instance.NC90Face = 1;
                        Create_UNI11733_Xml.Instance.NC180Face = 1;
                        Create_UNI11733_Xml.Instance.NC270Face = 1;
                        Create_UNI11733_Xml.Instance.CircularShapeBtm = true;
                        Create_UNI11733_Xml.Instance.CircularShapeTop = true;
                        Create_UNI11733_Xml.Instance.CircularShapeC0 = false;
                        Create_UNI11733_Xml.Instance.CircularShapeC90 = false;
                        Create_UNI11733_Xml.Instance.CircularShapeC180 = false;
                        Create_UNI11733_Xml.Instance.CircularShapeC270 = false;
                    }
                    else if (Create_UNI11733_Xml.Instance.Height == 0)
                    {
                        // IESNA OPENING CIRCLE/ELLIPS
                        Create_UNI11733_Xml.Instance.CircularShape = "Align_Z";
                        Create_UNI11733_Xml.Instance.NBtmFace = 1;
                        Create_UNI11733_Xml.Instance.NTopFace = 0;
                        Create_UNI11733_Xml.Instance.NC0Face = 0;
                        Create_UNI11733_Xml.Instance.NC90Face = 0;
                        Create_UNI11733_Xml.Instance.NC180Face = 0;
                        Create_UNI11733_Xml.Instance.NC270Face = 0;
                        Create_UNI11733_Xml.Instance.CircularShapeBtm = true;
                        Create_UNI11733_Xml.Instance.CircularShapeTop = false;
                        Create_UNI11733_Xml.Instance.CircularShapeC0 = false;
                        Create_UNI11733_Xml.Instance.CircularShapeC90 = false;
                        Create_UNI11733_Xml.Instance.CircularShapeC180 = false;
                        Create_UNI11733_Xml.Instance.CircularShapeC270 = false;
                    }
                }
                else if (Create_UNI11733_Xml.Instance.Width == 0)
                {
                    if (Create_UNI11733_Xml.Instance.Height < 0)
                    {
                        // IESNA OPENING VERTICAL CIRCLE/ELLIPS
                        Create_UNI11733_Xml.Instance.CircularShape = "Align_X";
                        Create_UNI11733_Xml.Instance.NBtmFace = 0;
                        Create_UNI11733_Xml.Instance.NTopFace = 0;
                        Create_UNI11733_Xml.Instance.NC0Face = 1;
                        Create_UNI11733_Xml.Instance.NC90Face = 0;
                        Create_UNI11733_Xml.Instance.NC180Face = 0;
                        Create_UNI11733_Xml.Instance.NC270Face = 0;
                        Create_UNI11733_Xml.Instance.CircularShapeBtm = false;
                        Create_UNI11733_Xml.Instance.CircularShapeTop = false;
                        Create_UNI11733_Xml.Instance.CircularShapeC0 = true;
                        Create_UNI11733_Xml.Instance.CircularShapeC90 = false;
                        Create_UNI11733_Xml.Instance.CircularShapeC180 = false;
                        Create_UNI11733_Xml.Instance.CircularShapeC270 = false;
                    }
                }

            }


            Create_UNI11733_Xml.Instance.NumberLightSource = 1;

            string secondline = IESLines[iesindex + 2];
            string[] secondlinearray = secondline.Split(' ');
            //MessageBox.Show(secondline);
            Create_UNI11733_Xml.Instance.InputWattage = secondlinearray[2];

            Create_UNI11733_Xml.Instance.distcpset = new Decimal[NVert];

            int anglerowidx = iesindex + 3;
            //MessageBox.Show(Eulumdatdata[anglerowidx].ToString());
            decimal value = 0;
            int firstarrayidx = 0;
            int linecount = 0;
            string line = "";
            for (int nvv = 0; nvv < NVert; nvv++)
            {
                anglerowidx = iesindex + 3 + linecount;
                line = IESLines[anglerowidx];
                string[] linearray = line.Trim().Trim().Split(' ');
                //MessageBox.Show(linearray[firstarrayidx].ToString());
                if (firstarrayidx < linearray.Length)
                {
                    //MessageBox.Show(firstarrayidx.ToString());
                    value = Convert.ToDecimal(linearray[firstarrayidx]);
                    Create_UNI11733_Xml.Instance.distcpset[nvv] = value;
                    firstarrayidx++;
                }
                else if (firstarrayidx == linearray.Length)
                {
                    linecount++;
                    firstarrayidx = 0;
                    nvv = nvv - 1;
                };
            };

            Create_UNI11733_Xml.Instance.cplaneset = new Decimal[NHoriz];
            Decimal Hvalue = 0;
            int firstHarrayidx = 0;
            int lineHcount = 0;
            string lineH = "";
            int angleHrowidx = 0;
            for (int nhh = 0; nhh < NHoriz; nhh++)
            {
                angleHrowidx = anglerowidx + 1 + lineHcount;
                lineH = IESLines[angleHrowidx];
                string[] lineHarray = lineH.Trim().Trim().Split(' ');
                //MessageBox.Show(Eulumdatdata[anglerowidx].ToString()); ;
                if (firstHarrayidx < lineHarray.Length)
                {
                    //MessageBox.Show(firstarrayidx.ToString());
                    Hvalue = Convert.ToDecimal(lineHarray[firstHarrayidx]);
                    Create_UNI11733_Xml.Instance.cplaneset[nhh] = Hvalue;
                    firstHarrayidx++;
                }
                else if (firstHarrayidx == lineHarray.Length)
                {
                    lineHcount++;
                    firstHarrayidx = 0;
                    nhh = nhh - 1;
                };

            };


            Create_UNI11733_Xml.Instance.candelaidx = NHoriz * NVert;

            Create_UNI11733_Xml.Instance.IESintensitydata = new decimal[Create_UNI11733_Xml.Instance.candelaidx];
            Decimal Ivalue = 0;
            int firstIarrayidx = 0;
            int lineIcount = 0;
            string lineI = "";
            int angleIrowidx = 0;
            for (int ni = 0; ni < Create_UNI11733_Xml.Instance.candelaidx; ni++)
            {
                angleIrowidx = angleHrowidx + 1 + lineIcount;
                lineI = IESLines[angleIrowidx];
                string[] lineIarray = lineI.Trim().Trim().Split(' ');
                //MessageBox.Show(Eulumdatdata[anglerowidx].ToString()); ;
                if (firstIarrayidx < lineIarray.Length)
                {
                    //MessageBox.Show(firstarrayidx.ToString());
                    Ivalue = Convert.ToDecimal(lineIarray[firstIarrayidx]);
                    Create_UNI11733_Xml.Instance.IESintensitydata[ni] = Ivalue;
                    firstIarrayidx++;
                }
                else if (firstIarrayidx == lineIarray.Length)
                {
                    lineIcount++;
                    firstIarrayidx = 0;
                    ni = ni - 1;
                };


            };

        }

    }
}
