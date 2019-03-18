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
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using CryptoSysPKI;
using System.Security.Cryptography;
using System.Runtime.InteropServices;



//using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;

namespace LDTandIEStoXMLConverter
{


    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();

        }

        private void EventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {

        }

        [DllImport("rpcrt4.dll", SetLastError = true)]
        static extern int UuidCreateSequential(out System.Guid guid);


        private void CleanForm()
        {
            TraverseControlsAndSetTextEmpty(this);
        }

        private void TraverseControlsAndSetTextEmpty(Control control)
        {

            foreach (Control c in control.Controls)
            {
                if (c is TextBox) ((TextBox)c).Text = String.Empty;
                TraverseControlsAndSetTextEmpty(c);
            }
        }

        private void LoadLdt_Click(object sender, EventArgs e)
        {
            CleanForm();
            Create_UNI11733_Xml.Instance.Init();

            Photometric_management.Instance.SelectPhotometricFile();

            if (Photometric_management.Instance.ldtiesname != "no file selected")
            {
                UuidCreateSequential(out System.Guid guid);
                UUIDContainer.UUIDvalue = guid.ToString();

                LDTtextBox.Text = Photometric_management.Instance.FullFileName;
                //MessageBox.Show(Photometric_management.Instance.FileType);

                String Lampcodestr = "";
                if (Photometric_management.Instance.FileType == "ldt")
                {
                    Parse_LDT ldtparser = new Parse_LDT();

                    ldtparser.ParseLDT();
                    //MessageBox.Show("PARSE LDT Done: ");
                    LabTextBox.Text = "Unknown";
                    Lampcodestr = "Not applicable";
                }

                if (Photometric_management.Instance.FileType == "ies")
                {
                    IES_Parse iesparser = new IES_Parse();

                    iesparser.ParseIES();
                    //MessageBox.Show("PARSE IES Done: ");
                    LabTextBox.Text = Create_UNI11733_Xml.Instance.MaesureLaboratory;
                    Lampcodestr = Create_UNI11733_Xml.Instance.LampCatalogNumber; //modified by AW
                }

                // HEADER START
                // MessageBox.Show(Photometric_management.Instance.ldtiesname);

                ManuftextBox.Text = Create_UNI11733_Xml.Instance.Manufacture;
                CatalogNumbertextBox.Text = Create_UNI11733_Xml.Instance.CatalogNumber;
                GTINtextBox.Text = "Not assigned";
                ModeltextBox.Text = Create_UNI11733_Xml.Instance.Model_Description;

                RepNumTextBox.Text = Create_UNI11733_Xml.Instance.ReportNumber;
                RepDateTextBox.Text = Create_UNI11733_Xml.Instance.ReportDate;
                DocCreatorTextBox.Text = "Unknown";
                DocCreateDateTextBox.Text = Create_UNI11733_Xml.Instance.DocCreateDate.ToString(); //DateTime.Now.ToString();
                UniqueIdentifierTextBox.Text = UUIDContainer.UUIDvalue.ToString(); // guid.ToString();
                CommentTextBox.Text = "lorem ipsum";
                ReferenceTextBox.Text = Create_UNI11733_Xml.Instance.NameInFile;
                MoreInfoURITextBox.Text = "Unknown";

                // HEADER end

                //Dimensions start
                LengthTextBox.Text = Create_UNI11733_Xml.Instance.Length.ToString();
                WidthTextBox.Text = Create_UNI11733_Xml.Instance.Width.ToString();
                HeightTextBox.Text = Create_UNI11733_Xml.Instance.Height.ToString();

                ShapeComboBox.Text = Create_UNI11733_Xml.Instance.CircularShape;

                //Dimensions end

                //Emission Areas
                //Bottom Face 

                NumBottomTextBox.Text = Create_UNI11733_Xml.Instance.NBtmFace.ToString();
                if (Create_UNI11733_Xml.Instance.NBtmFace == 0)
                {
                    BtmLengthTextBox.Text = "0";
                    BtmWidthTextBox.Text = "0";
                }
                else
                {
                    BtmLengthTextBox.Text = Create_UNI11733_Xml.Instance.LumLength.ToString();
                    BtmWidthTextBox.Text = Create_UNI11733_Xml.Instance.LumWidth.ToString();
                }
                BtmLengthOffTextBox.Text = "0";
                BtmWidthOffTextBox.Text = "0";

                if (Create_UNI11733_Xml.Instance.CircularShapeBtm == true)
                {
                    CircularBtmTextBox.Text = "true";
                }
                else
                {
                    CircularBtmTextBox.Text = "false";
                }

                //Top Face 

                NumTopTextBox.Text = Create_UNI11733_Xml.Instance.NTopFace.ToString();
                if (Create_UNI11733_Xml.Instance.NTopFace == 0)
                {
                    TopLengthTextBox.Text = "0";
                    TopWidthTextBox.Text = "0";
                }
                else
                {
                    TopLengthTextBox.Text = Create_UNI11733_Xml.Instance.LumLength.ToString();
                    TopWidthTextBox.Text = Create_UNI11733_Xml.Instance.LumWidth.ToString();
                }
                TopLengthOffTextBox.Text = "0";
                TopWidthOffTextBox.Text = "0";

                if (Create_UNI11733_Xml.Instance.CircularShapeTop == true)
                {
                    CircularTopTextBox.Text = "true";
                }
                else
                {
                    CircularTopTextBox.Text = "false";
                }


                //C-0 Face
                //NumC0TextBox.Text = "1";
                NumC0TextBox.Text = Create_UNI11733_Xml.Instance.NC0Face.ToString();
                if (Create_UNI11733_Xml.Instance.NC0Face == 0)
                {
                    C0HeightTextBox.Text = "0";
                    C0WidthTextBox.Text = "0";
                }
                else
                {
                    C0HeightTextBox.Text = Create_UNI11733_Xml.Instance.hC0.ToString();
                    C0WidthTextBox.Text = Create_UNI11733_Xml.Instance.LumLength.ToString();
                }
                C0WidthOffTextBox.Text = "0";
                C0HeightOffTextBox.Text = "0";

                if (Create_UNI11733_Xml.Instance.CircularShapeC0 == true)
                {
                    CircularC0TextBox.Text = "true";
                }
                else
                {
                    CircularC0TextBox.Text = "false";
                }

                //C-90 Face
                //NumC90TextBox.Text = "1";
                NumC90TextBox.Text = Create_UNI11733_Xml.Instance.NC90Face.ToString();
                if (Create_UNI11733_Xml.Instance.NC90Face == 0)
                {
                    C90HeightTextBox.Text = "0";
                    C90LengthTextBox.Text = "0";
                }
                else
                {
                    C90HeightTextBox.Text = Create_UNI11733_Xml.Instance.hC90.ToString();
                    C90LengthTextBox.Text = Create_UNI11733_Xml.Instance.LumWidth.ToString();
                }
                C90LengthOffTextBox.Text = "0";
                C90HeightOffTextBox.Text = "0";

                if (Create_UNI11733_Xml.Instance.CircularShapeC90 == true)
                {
                    CircularC90TextBox.Text = "true";
                }
                else
                {
                    CircularC90TextBox.Text = "false";
                }

                //C-180 Face
                //NumC180TextBox.Text = "1";
                NumC180TextBox.Text = Create_UNI11733_Xml.Instance.NC180Face.ToString();
                if (Create_UNI11733_Xml.Instance.NC90Face == 0)
                {
                    C180HeightTextBox.Text = "0";
                    C180WidthTextBox.Text = "0";
                }
                else
                {
                    C180HeightTextBox.Text = Create_UNI11733_Xml.Instance.hC180.ToString();
                    C180WidthTextBox.Text = Create_UNI11733_Xml.Instance.LumLength.ToString();
                }
                C180WidthOffTextBox.Text = "0";
                C180HeightOffTextBox.Text = "0";

                if (Create_UNI11733_Xml.Instance.CircularShapeC180 == true)
                {
                    CircularC180TextBox.Text = "true";
                }
                else
                {
                    CircularC180TextBox.Text = "false";
                }

                //C-270 Face
                //NumC270TextBox.Text = "1";
                NumC270TextBox.Text = Create_UNI11733_Xml.Instance.NC270Face.ToString();
                if (Create_UNI11733_Xml.Instance.NC90Face == 0)
                {
                    C270HeightTextBox.Text = "0";
                    C270LengthTextBox.Text = "0";
                }
                else
                {
                    C270HeightTextBox.Text = Create_UNI11733_Xml.Instance.hC270.ToString();
                    C270LengthTextBox.Text = Create_UNI11733_Xml.Instance.LumWidth.ToString();
                }
                C270LengthOffTextBox.Text = "0";
                C270HeightOffTextBox.Text = "0";

                if (Create_UNI11733_Xml.Instance.CircularShapeC270 == true)
                {
                    CircularC270TextBox.Text = "true";
                }
                else
                {
                    CircularC270TextBox.Text = "false";
                }

                // emission areas end

                //emitter center start
                ECLengthTtextBox.Text = "0";
                ECWidthTextBox.Text = "0";
                ECHeightTextBox.Text = (-(Create_UNI11733_Xml.Instance.Height / 2m)).ToString();

                //emitter center end


                //----------------------- Image Fields --------------------------------------

                // Luminaire dimeansoins
                HeightTextBox1.Text = HeightTextBox.Text;
                WidthTextBox2.Text = WidthTextBox.Text;
                LengthTextBox2.Text = LengthTextBox.Text;
                //Bottom Face 
                NumBottomTextBox2.Text = NumBottomTextBox.Text;
                BtmLengthTextBox2.Text = BtmLengthTextBox.Text;
                BtmWidthTextBox2.Text = BtmWidthTextBox.Text;
                //BtmLengthOffTextBox2.Text = BtmLengthOffTextBox.Text;
                //BtmWidthOffTextBox2.Text = BtmWidthOffTextBox.Text;
                //Top Face 
                NumTopTextBox2.Text = NumTopTextBox.Text;
                TopLengthTextBox2.Text = TopLengthTextBox.Text;
                TopWidthTextBox2.Text = TopWidthTextBox.Text;
                TopLengthOffTextBox2.Text = TopLengthOffTextBox.Text;
                TopWidthOffTextBox2.Text = TopWidthOffTextBox.Text;
                //C-0 Face
                NumC0TextBox2.Text = NumC0TextBox.Text;
                C0HeightTextBox3.Text = C0HeightTextBox.Text;
                C0WidthTextBox2.Text = C0WidthTextBox.Text;
                //C0WidthOffTextBox2.Text = C0WidthOffTextBox.Text;
                //C0HeightOffTextBox2.Text = C0HeightOffTextBox.Text;
                //C-90 Face
                NumC90TextBox2.Text = NumC90TextBox.Text;
                C90HeightTextBox2.Text = C90HeightTextBox.Text;
                C90LengthTextBox2.Text = C90LengthTextBox.Text;
                //C90LengthOffTextBox2.Text = C90LengthOffTextBox.Text;
                //C90HeightOffTextBox2.Text = C90HeightOffTextBox.Text;

                //C-180 Face
                NumC180TextBox2.Text = NumC180TextBox.Text;
                C180HeightTextBox2.Text = C180HeightTextBox.Text;
                C180WidthTextBox2.Text = C180WidthTextBox.Text;
                //C180HeightOffTextBox2.Text = C180HeightOffTextBox.Text;
                //C180HeightOffTextBox2.Text = C180HeightOffTextBox.Text;
                //C-270 Face
                NumC270TextBox2.Text = NumC270TextBox.Text;
                C270HeightTextBox2.Text = C270HeightTextBox.Text;
                C270LengthTextBox2.Text = C270LengthTextBox.Text;
                //C270LengthOffTextBox2.Text = C270LengthOffTextBox.Text;
                //C270HeightOffTextBox2.Text = C270HeightOffTextBox.Text;
                // emission areas end
                // -------------------- END IMAGE FIELDS ------------------------------------------------


                //Dimensions end

                NLightSourceTextBox.Text = Create_UNI11733_Xml.Instance.NumberLightSource.ToString();
                //LUMINAIRE end

                //LuminousData start
                //LuminousIntensity start
                QuantityTextBox.Text = Create_UNI11733_Xml.Instance.Quantity.ToString();
                DescTextBox.Text = Create_UNI11733_Xml.Instance.LampDescription;
                //LampCodeTextBox.Text = "Not applicable";
                LampCodeTextBox.Text = Lampcodestr; //modified by AW
                RatedLmTextBox.Text = Create_UNI11733_Xml.Instance.RatedLumen.ToString();
                InputWattageTextBox.Text = Create_UNI11733_Xml.Instance.InputWattage;
                RaTextBox.Text = Create_UNI11733_Xml.Instance.RaCRI;
                FixedCCTTextBox.Text = Create_UNI11733_Xml.Instance.FixedCCT;

                ABSPhotomTextBox.Text = Create_UNI11733_Xml.Instance.ABSPhotom.ToString();

                if (Create_UNI11733_Xml.Instance.symm == 0)
                    ASymmTextBox.Text = Create_UNI11733_Xml.Instance.symm.ToString() + " - None";
                else if (Create_UNI11733_Xml.Instance.symm == 1)
                    ASymmTextBox.Text = Create_UNI11733_Xml.Instance.symm.ToString() + " - Symmetric";
                else if (Create_UNI11733_Xml.Instance.symm == 2)
                    ASymmTextBox.Text = Create_UNI11733_Xml.Instance.symm.ToString() + " - Bilateral_X";
                else if (Create_UNI11733_Xml.Instance.symm == 3)
                    ASymmTextBox.Text = Create_UNI11733_Xml.Instance.symm.ToString() + " - Bilateral_Y";
                else if (Create_UNI11733_Xml.Instance.symm == 4)
                    ASymmTextBox.Text = Create_UNI11733_Xml.Instance.symm.ToString() + " - Quadrilateral";
                else
                    ASymmTextBox.Text = Create_UNI11733_Xml.Instance.symm.ToString() + " - None";

                NumMeasuredTextBox.Text = "1";
                NumberHorzTextBox.Text = Create_UNI11733_Xml.Instance.NumberHorizontal.ToString();
                NumberVertTextBox.Text = Create_UNI11733_Xml.Instance.NumberVertical.ToString();


                Moreinfouri.MoreInfoURL = MoreInfoURITextBox.Text;
                DocumentCreator.DocCreator = DocCreatorTextBox.Text;
                DocumentComments.DocComments = CommentTextBox.Text;
                LampCode.LampCatNumber = LampCodeTextBox.Text;
                Laboratory.Lab = LabTextBox.Text;
                GTINnumber.GTINnum = GTINtextBox.Text;

                EmitterBoxLength.EmBoxLength = LengthTextBox.Text;
                EmitterBoxWidth.EmBoxWidth = WidthTextBox.Text;
                EmitterBoxHeight.EmBoxHeight = HeightTextBox.Text;
                EmitterBoxShapeCirc.EmBoxShapeCirc = ShapeComboBox.Text;

                NumEmitterBottomFace.NumEmBtmFace = NumBottomTextBox.Text;
                EmitterBottomLength.EmBtmLength = BtmLengthTextBox.Text;
                EmitterBottomWidth.EmBtmWidth = BtmWidthTextBox.Text;
                EmitterBottomLengthOffset.EmBtmLengthOff = BtmLengthOffTextBox.Text;
                EmitterBottomWidthOffset.EmBtmWidthoff = BtmWidthOffTextBox.Text;
                EmBtmCirc.EmBtmCircular = CircularBtmTextBox.Text;

                NumEmitterTopFace.NumEmTopFace = NumTopTextBox.Text;
                EmitterTopLength.EmTopLength = TopLengthTextBox.Text;
                EmitterTopWidth.EmTopWidth = TopWidthTextBox.Text;
                EmitterTopLengthOffset.EmTopLengthOff = TopLengthOffTextBox.Text;
                EmitterTopWidthOffset.EmTopWidthoff = TopWidthOffTextBox.Text;
                EmTopCirc.EmTopCircular = CircularTopTextBox.Text;

                NumEmitterC0Face.NumEmC0Face = NumC0TextBox.Text;
                EmitterC0Height.EmC0Height = C0HeightTextBox.Text;
                EmitterC0Width.EmC0Width = C0WidthTextBox.Text;
                EmitterC0HeightOffset.EmC0HeightOff = C0HeightOffTextBox.Text;
                EmitterC0WidthOffset.EmC0Widthoff = C0WidthOffTextBox.Text;
                EmC0Circ.EmC0Circular = CircularC0TextBox.Text;

                NumEmitterC180Face.NumEmC180Face = NumC180TextBox.Text;
                EmitterC180Height.EmC180Height = C180HeightTextBox.Text;
                EmitterC180Width.EmC180Width = C180WidthTextBox.Text;
                EmitterC180HeightOffset.EmC180HeightOff = C180HeightOffTextBox.Text;
                EmitterC180WidthOffset.EmC180WidthOff = C180WidthOffTextBox.Text;
                EmC180Circ.EmC180Circular = CircularC180TextBox.Text;

                NumEmitterC90Face.NumEmC90Face = NumC90TextBox.Text;
                EmitterC90Height.EmC90Height = C90HeightTextBox.Text;
                EmitterC90Length.EmC90Length = C90LengthTextBox.Text;
                EmitterC90HeightOffset.EmC90HeightOff = C90HeightOffTextBox.Text;
                EmitterC90LengthOffset.EmC90LengthOff = C90LengthOffTextBox.Text;
                EmC90Circ.EmC90Circular = CircularC90TextBox.Text;

                NumEmitterC270Face.NumEmC270Face = NumC270TextBox.Text;
                EmitterC270Height.EmC270Height = C270HeightTextBox.Text;
                EmitterC270Length.EmC270Length = C270LengthTextBox.Text;
                EmitterC270HeightOffset.EmC270HeightOff = C270HeightOffTextBox.Text;
                EmitterC270LengthOffset.EmC270LengthOff = C270LengthOffTextBox.Text;
                EmC270Circ.EmC270Circular = CircularC270TextBox.Text;

                ECLengthOffset.ECLengthOff = ECLengthTtextBox.Text;
                ECWidthOffset.ECWidthOff = ECWidthTextBox.Text;
                ECHeightOffset.ECHeightOff = ECHeightTextBox.Text;

            }
            else
            {
                CleanForm();
            }

        }



        private void ConvertButton_Click(object sender, EventArgs e)
        {
            if (Photometric_management.Instance.FileType == "ldt")
            {
                Create_UNI11733_Xml.Instance.LDTtoXML();
                MessageBox.Show("ldt converted");
            }

            if (Photometric_management.Instance.FileType == "ies")
            {
                Create_UNI11733_Xml.Instance.IEStoXML();
                MessageBox.Show("ies converted");
            }

            Create_UNI11733_Xml.Instance.SerializeXml();

            //CleanXmlVariables();
        }


        public void CleanXmlVariables()
        {
            //Header variables
            UNI11733 myxml = new UNI11733();

            Create_UNI11733_Xml.Instance.Manufacture = null;
            Create_UNI11733_Xml.Instance.Model_Description = null;
            Create_UNI11733_Xml.Instance.CatalogNumber = null;

            Create_UNI11733_Xml.Instance.MaesureLaboratory = null;
            Create_UNI11733_Xml.Instance.ReportNumber = null;
            Create_UNI11733_Xml.Instance.ReportDate = null;
            Create_UNI11733_Xml.Instance.DocCreator = null;
            //public DateTime DocCreateDate;
            Create_UNI11733_Xml.Instance.Comments = null;
            Create_UNI11733_Xml.Instance.url = null;

            //Dimensions variables
            Create_UNI11733_Xml.Instance.Length = 0;
            Create_UNI11733_Xml.Instance.Width = 0;
            Create_UNI11733_Xml.Instance.Height = 0;
            Create_UNI11733_Xml.Instance.NumberHorizontal = 0;
            Create_UNI11733_Xml.Instance.NumberVertical = 0;
            Create_UNI11733_Xml.Instance.LumLength = 0;
            Create_UNI11733_Xml.Instance.LumWidth = 0;
            Create_UNI11733_Xml.Instance.hC0 = 0;
            Create_UNI11733_Xml.Instance.hC90 = 0;
            Create_UNI11733_Xml.Instance.hC180 = 0;

            // Emitter variables
            Create_UNI11733_Xml.Instance.NumberLightSource = 0;
            Create_UNI11733_Xml.Instance.Quantity = 0;
            Create_UNI11733_Xml.Instance.LampDescription = null;
            Create_UNI11733_Xml.Instance.LampCatalogNumber = null;
            Create_UNI11733_Xml.Instance.RatedLumen = 0;
            Create_UNI11733_Xml.Instance.InputWattage = null;
            Create_UNI11733_Xml.Instance.RaCRI = null;
            Create_UNI11733_Xml.Instance.FixedCCT = null;
            Create_UNI11733_Xml.Instance.LORL = 0;
            Create_UNI11733_Xml.Instance.ABSPhotom = false;
            Create_UNI11733_Xml.Instance.symm = 0;
            Create_UNI11733_Xml.Instance.NameInFile = null;

            Create_UNI11733_Xml.Instance.DFF = 0;
            Create_UNI11733_Xml.Instance.DistanceCPlanes = 0;

        }

        private void ShapeLabel_Click(object sender, EventArgs e)
        {

        }
    }
    /*
    internal static class NativeMethods
    {
        [DllImport("rpcrt4.dll", SetLastError = true)]
        internal static extern int UuidCreateSequential(out System.Guid guid);
    }
    */
    public static class UUIDContainer
    {
        public static String UUIDvalue;
    }

    public static class Moreinfouri
    {
        public static String MoreInfoURL;
    }

    public static class DocumentCreator
    {
        public static String DocCreator;
    }

    public static class DocumentComments
    {
        public static String DocComments;
    }

    public static class LampCode
    {
        public static String LampCatNumber;
    }

    public static class Laboratory
    {
        public static String Lab;
    }

    public static class GTINnumber
    {
        public static String GTINnum;
    }

    public static class EmitterBoxLength
    {
        public static String EmBoxLength;
    }

    public static class EmitterBoxWidth
    {
        public static String EmBoxWidth;
    }

    public static class EmitterBoxHeight
    {
        public static String EmBoxHeight;
    }

    public static class EmitterBoxShapeCirc
        {
        //public static List<String> EmBoxShapeCirc = new List<string>() { "Align_Z", "Align_X", "Align_Y" };
        public static String EmBoxShapeCirc;
    }
    public static class NumEmitterBottomFace
    {
        public static String NumEmBtmFace;
    }
        public static class EmitterBottomLength
    {
        public static String EmBtmLength;
    }
        public static class EmitterBottomWidth
    {
        public static String EmBtmWidth;
    }
        public static class EmitterBottomLengthOffset
    {
        public static String EmBtmLengthOff;
    }
        public static class EmitterBottomWidthOffset
    {
        public static String EmBtmWidthoff;
    }
    public static class EmBtmCirc
    {
        public static String EmBtmCircular;
    }

    public static class NumEmitterTopFace
    {
        public static String NumEmTopFace;
    }
    public static class EmitterTopLength
    {
        public static String EmTopLength;
    }
    public static class EmitterTopWidth
    {
        public static String EmTopWidth;
    }
    public static class EmitterTopLengthOffset
    {
        public static String EmTopLengthOff;
    }
    public static class EmitterTopWidthOffset
    {
        public static String EmTopWidthoff;
    }
    public static class EmTopCirc
    {
        public static String EmTopCircular;
    }

    public static class NumEmitterC0Face
    {
        public static String NumEmC0Face;
    }
    public static class EmitterC0Height
    {
        public static String EmC0Height;
    }
    public static class EmitterC0Width
    {
        public static String EmC0Width;
    }
    public static class EmitterC0HeightOffset
    {
        public static String EmC0HeightOff;
    }
    public static class EmitterC0WidthOffset
    {
        public static String EmC0Widthoff;
    }
    public static class EmC0Circ
    {
        public static String EmC0Circular;
    }

    public static class NumEmitterC90Face
    {
        public static String NumEmC90Face;
    }
    public static class EmitterC90Length
    {
        public static String EmC90Length;
    }
    public static class EmitterC90Height
    {
        public static String EmC90Height;
    }
    public static class EmitterC90LengthOffset
    {
        public static String EmC90LengthOff;
    }
    public static class EmitterC90HeightOffset
    {
        public static String EmC90HeightOff;
    }
    public static class EmC90Circ
    {
        public static String EmC90Circular;
    }


    public static class NumEmitterC180Face
    {
        public static String NumEmC180Face;
    }
    public static class EmitterC180Height
    {
        public static String EmC180Height;
    }
    public static class EmitterC180Width
    {
        public static String EmC180Width;
    }
    public static class EmitterC180HeightOffset
    {
        public static String EmC180HeightOff;
    }
    public static class EmitterC180WidthOffset
    {
        public static String EmC180WidthOff;
    }
    public static class EmC180Circ
    {
        public static String EmC180Circular;
    }

    public static class NumEmitterC270Face
    {
        public static String NumEmC270Face;
    }
    public static class EmitterC270Length
    {
        public static String EmC270Length;
    }
    public static class EmitterC270Height
    {
        public static String EmC270Height;
    }
    public static class EmitterC270LengthOffset
    {
        public static String EmC270LengthOff;
    }
    public static class EmitterC270HeightOffset
    {
        public static String EmC270HeightOff;
    }
    public static class EmC270Circ
    {
        public static String EmC270Circular;
    }


    public static class ECLengthOffset
    {
        public static String ECLengthOff;
    }
    public static class ECWidthOffset
    {
        public static String ECWidthOff;
    }
    public static class ECHeightOffset
    {
        public static String ECHeightOff;
    }
}
