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
            traverseControlsAndSetTextEmpty(this);
        }
        private void traverseControlsAndSetTextEmpty(Control control)
        {

            foreach (Control c in control.Controls)
            {
                if (c is TextBox) ((TextBox)c).Text = String.Empty;
                traverseControlsAndSetTextEmpty(c);
            }
        }

        private void LoadLdt_Click(object sender, EventArgs e)
        {
            CleanForm();
            Photometric_management.Instance.SelectPhotometricFile();

            if (Photometric_management.Instance.ldtiesname != "no file selected")
            {
                UuidCreateSequential(out System.Guid guid);
                UUIDContainer.UUIDvalue = guid.ToString();

                LDTtextBox.Text = Photometric_management.Instance.FullFileName;
                //MessageBox.Show(Photometric_management.Instance.FileType);

                String Lampcodestr="";
                if (Photometric_management.Instance.FileType == "ldt")
                {
                    Parse_LDT ldtparser = new Parse_LDT();

                    ldtparser.ParseLDT();
                    MessageBox.Show("PARSE LDT Done: ");
                    LabTextBox.Text = "Unknown";
                    Lampcodestr = "Not applicable";
                }

                if (Photometric_management.Instance.FileType == "ies")
                {
                    IES_Parse iesparser = new IES_Parse();

                    iesparser.ParseIES();
                    MessageBox.Show("PARSE IES Done: ");
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

                //LUMINAIRE start
                //Dimensions start

                if (Create_UNI11733_Xml.Instance.Width != 0) // is rectangular
                {
                    LengthTextBox.Text = Create_UNI11733_Xml.Instance.Length.ToString();
                    WidthTextBox.Text = Create_UNI11733_Xml.Instance.Width.ToString();
                    HeightTextBox.Text = Create_UNI11733_Xml.Instance.Height.ToString();
                }
                else if (Create_UNI11733_Xml.Instance.Width == 0) // is circular
                {
                    ShapeTextBox.Text = "Align_Z ";
                    LengthTextBox.Text = Create_UNI11733_Xml.Instance.Length.ToString();
                    WidthTextBox.Text = Create_UNI11733_Xml.Instance.Width.ToString();
                    HeightTextBox.Text = Create_UNI11733_Xml.Instance.Height.ToString();
                }

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
                GTINnumber.GTINnum =GTINtextBox.Text;

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

}
