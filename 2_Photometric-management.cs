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
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LDTandIEStoXMLConverter
{

    public class Photometric_management
    {
        private static readonly Photometric_management instance = new Photometric_management();

        private Photometric_management()
        {
        }

        public static Photometric_management Instance
        {
            get
            {
                return instance;
            }
        }

        // Member Variables
        public String libraryPath = "c:\\";

        public String FullFileName;
        public String filename;
        public String ldtiesname;
        public String filepath;
        public String FileType;

        //constuctor for initializing fields    
        public void Init()
        {
            //return fullMdbFileName;
        }


        // ------------------ SELECT PHOTOMETRIC FILE ----------------

        public void SelectPhotometricFile()
        {
            // Create an instance of the open file dialog box.
            // Allow the user to select a file.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = libraryPath;

            // Set filter options and filter index.
            openFileDialog1.Filter = "Photometric Files|*.ldt;*.ies|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Title = "Select Photometric File (ldt-ies)";
            // Call the ShowDialog method to show the dialog box.
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                FullFileName = "no path selected";
                filename = "no file selected";
            }
            else
            {
                // Open the selected file to read.
                FullFileName = openFileDialog1.FileName;
                filename = openFileDialog1.SafeFileName;
            }

            if (FullFileName == "no path selected")
            {
                ldtiesname = "no file selected";
                filepath = null;
            }
            else
            {
                ldtiesname = filename;
                filepath = FullFileName.Replace(ldtiesname, "");
                if (ldtiesname.Substring(ldtiesname.Length - 4) == ".ldt")
                {
                    FileType = "ldt";
                }
                else if (ldtiesname.Substring(ldtiesname.Length - 4) == ".ies")
                {
                    FileType = "ies";
                }

            }



        }

    }
}

