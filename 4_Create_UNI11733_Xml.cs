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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace LDTandIEStoXMLConverter
{
    class Create_UNI11733_Xml
    {
        private static readonly Create_UNI11733_Xml instance = new Create_UNI11733_Xml();

        private Create_UNI11733_Xml()
        {
        }

        public static Create_UNI11733_Xml Instance
        {
            get
            {
                return instance;
            }
        }

        //public string MoreInfoURL;
        //private String manuf;
        //public String Manufacture { get { return manuf; } }

        private List<String> LdtLines = new List<String>();
        public List<String> Ldtlines { get { return LdtLines; } }

        //Header variables
        public String Manufacture;
        public String Model_Description;
        public String CatalogNumber;
        public String MaesureLaboratory;
        public String ReportNumber;
        public String ReportDate;
        public String DocCreator;
        public DateTime DocCreateDate;
        public String Comments;
        //public String Reference;
        public String url;

        //Dimensions variables
        public Decimal Length;
        public Decimal Width;
        public Decimal Height;
        public int NumberHorizontal;
        public int NumberVertical;
        public Decimal LumLength;
        public Decimal LumWidth;
        public Decimal hC0;
        public Decimal hC90;
        public Decimal hC180;
        public Decimal hC270;

        //Equipment variables
        public int Gonio;

        // Emitter variables
        public int NumberLightSource;
        public int Quantity;
        public String LampDescription;
        public String LampCatalogNumber;
        public Decimal RatedLumen;
        public String InputWattage;
        public String RaCRI;
        public String FixedCCT;
        public int LORL;
        public bool ABSPhotom;
        public int symm;
        public String NameInFile;
        
        public Decimal DFF;
        public Decimal DistanceCPlanes;
        public Decimal[] distcpset;
        public Decimal[] cplaneset;
        public int candelaidx;
        public Decimal[] IESintensitydata;

        UNI11733 xml = new UNI11733();

        // Create list
        List<string> CommentList = new List<string>();
        List<string> iesReferenceList = new List<string>();

        //constuctor for initializing fields    
        public void Init()
        {
            //return fullMdbFileName;
        }

        public void LDTtoXML()
        {
            CreateLDTXmlHeader();
            CreateLDTXmlDimensions();
            CreateLDTXmlEquipment();
            CreateLDTXmlLightSource();
            MessageBox.Show("FINISH");
        }

        public void IEStoXML()
        {
            CreateIESXmlHeader();
            CreateIESXmlDimensions();
            CreateIESXmlEquipment();
            CreateIESXmlLightSource();
            MessageBox.Show("FINISH");
        }

        // CREATE HEADER BLOCK FROM LDT

        public void CreateLDTXmlHeader()
        {
            //MessageBox.Show(Moreinfouri.MoreInfoURL);
            //MessageBox.Show(DocumentCreator.DocCreator);
            //MessageBox.Show(DocumentComments.DocComments);
            //MessageBox.Show(LampCode.LampCatNumber);

            Parse_LDT ldtparser = new Parse_LDT();

            //--------------CREATE HEADER BLOCK FROM LDT --------------------------

            CommentList.Clear();
            CommentList.Add(DocumentComments.DocComments);
            // Convert to array
            var ldtCommentArray = CommentList.ToArray();

            iesReferenceList.Clear();
            iesReferenceList.Add(Photometric_management.Instance.ldtiesname);
            // Convert to array
            var IESLDTReferenceArray = iesReferenceList.ToArray();

            //ldtparser.ParseLDT();
            
            var headerdata = new UNI11733Header
            {
                Manufacturer = Manufacture,
                CatalogNumber = CatalogNumber,
                GTIN = GTINnumber.GTINnum,
                Description = Model_Description,
                Laboratory = Laboratory.Lab,
                ReportNumber = ReportNumber,
                ReportDate = ReportDate,
               
                DocumentCreator = DocumentCreator.DocCreator,
                DocumentCreationDate = DateTime.Now,
                //DocumentCreationDate = DateTime.Today,
                DocumentCreationDateSpecified = true,
                UniqueIdentifier = UUIDContainer.UUIDvalue,
                Comment= ldtCommentArray,
                Reference = IESLDTReferenceArray,
                MoreInfoURI = Moreinfouri.MoreInfoURL //"www.relux.com"
            };
            xml.Header = new[] { headerdata };

        }

        // CREATE DOMENSION BLOCK FROM LDT

        public void CreateLDTXmlDimensions()
        {
            Parse_LDT ldtparser = new Parse_LDT();
            //ldtparser.ParseLDT();

            var dimensiondata = new UNI11733LuminaireDimensions();

            dimensiondata.Length = Length;
            dimensiondata.Width = Width;
            dimensiondata.Height = Height;

            var luminairedata = new UNI11733Luminaire();
            if (Width == 0) // is cylindrical
            {
                luminairedata.Shape = UNI11733LuminaireShape.Align_Z;
                luminairedata.ShapeSpecified = true;
            }
            luminairedata.NumEmitter = NumberLightSource; //Int32.Parse(Eulumdatdata[25]);
            luminairedata.Dimensions = new[] { dimensiondata };

            xml.Luminaire = new[] { luminairedata };

        }

        // CREATE EQUIPMENT BLOCK FROM LDT

        public void CreateLDTXmlEquipment()
        {
            Parse_LDT ldtparser = new Parse_LDT();
            //ldtparser.ParseLDT();

            var equipdata = new UNI11733Equipment() { Gonioradiometer = new UNI11733EquipmentGonioradiometer() { Type = UNI11733EquipmentGonioradiometerType.CIE_A } };
            xml.Equipment = new[] { equipdata };
        }

        // CREATE LIGHTSOURCE BLOCK FROM LDT

        public void CreateLDTXmlLightSource()
        {
            Parse_LDT ldtparser = new Parse_LDT();
            //ldtparser.ParseLDT();

            var coltempdata = new UNI11733EmitterColorTemperature();
            int fixedCCT;
            if (Int32.TryParse(FixedCCT, out fixedCCT))
                coltempdata.FixedCCT = fixedCCT;
            else
                coltempdata.FixedCCT = 0;
            coltempdata.FixedCCTSpecified = true;

            //--------------CREATE LIGHTSOURCE BLOCK --------------------------

            var lsourcedata = new UNI11733Emitter();
            lsourcedata.Quantity = Quantity;
            lsourcedata.Description = LampDescription;
            lsourcedata.CatalogNumber = "Not applicable";
            lsourcedata.RatedLumens = RatedLumen;
            lsourcedata.InputWattage = Decimal.Parse(InputWattage);
            lsourcedata.ColorTemperature = new[] { coltempdata };

            lsourcedata.ColorRendering = new UNI11733EmitterColorRendering() { CIE_CRI = new UNI11733EmitterColorRenderingCIE_CRI() };
            int ra;
            if (Int32.TryParse(RaCRI, out ra))
                lsourcedata.ColorRendering.CIE_CRI.Ra = ra;
            else
                lsourcedata.ColorRendering.CIE_CRI.Ra = 0;

            lsourcedata.LuminousData = new UNI11733EmitterLuminousData() { LuminousIntensity = new UNI11733EmitterLuminousDataLuminousIntensity() };
           
            lsourcedata.LuminousData.LuminousIntensity.AbsolutePhotometry = ABSPhotom;

            lsourcedata.LuminousData.LuminousIntensity.NumberMeasured = 1;


            Decimal[] cplaneset = new Decimal[NumberHorizontal];

            for (int nhh = 0; nhh < NumberHorizontal; nhh++)
            {
                int cpindex = 42 + nhh;
                cplaneset[nhh] = Decimal.Parse(Ldtlines[cpindex]);
                //MessageBox.Show(cplaneset[nh].ToString());
            };

            Decimal[] distcpset = new Decimal[NumberVertical];

            for (int nvv = 0; nvv < NumberVertical; nvv++)
            {
                int distcpindex = 42 + NumberHorizontal + nvv;
                distcpset[nvv] = Decimal.Parse(Ldtlines[distcpindex]);

            };


            int xmlNHoriz = NumberHorizontal;

            if (symm == 1)
            {
                xmlNHoriz = 1;
            };

            if (symm == 2)
            {
                xmlNHoriz = 180 / (360 / NumberHorizontal) + 1;
            };

            if (symm == 3)
            {
                xmlNHoriz = 180 / (360 / NumberHorizontal) + 1;
            };

            if (symm == 4)
            {
                xmlNHoriz = 90 / (360 / NumberHorizontal) + 1;
            };

            int candelaidx = xmlNHoriz * NumberVertical;

            Decimal[] intensitydata = new decimal[candelaidx];

            for (int ni = 0; ni < candelaidx; ni++)
            {
                int idataindex = 42 + NumberHorizontal + NumberVertical + ni;
                intensitydata[ni] = Decimal.Parse(Ldtlines[idataindex]);

            };



            lsourcedata.LuminousData.LuminousIntensity.IntData = new IntDataType2[candelaidx];

            for (int nh = 0; nh < xmlNHoriz; nh++)
            {
                //lsourcedata.LuminousData.LuminousIntensity.IntData = new  IntDataType2() ;

                for (int nv = 0; nv < NumberVertical; nv++)
                {
                    lsourcedata.LuminousData.LuminousIntensity.IntData[nv + nh * NumberVertical] = new IntDataType2();
                    if (symm == 3)
                        lsourcedata.LuminousData.LuminousIntensity.IntData[nv + nh * NumberVertical].h = cplaneset[nh + 90 / (360 / NumberHorizontal)];
                    else
                        lsourcedata.LuminousData.LuminousIntensity.IntData[nv + nh * NumberVertical].h = cplaneset[nh];
                    lsourcedata.LuminousData.LuminousIntensity.IntData[nv + nh * NumberVertical].hSpecified = true;

                    lsourcedata.LuminousData.LuminousIntensity.IntData[nv + nh * NumberVertical].v = distcpset[nv];
                    lsourcedata.LuminousData.LuminousIntensity.IntData[nv + nh * NumberVertical].vSpecified = true;

                    lsourcedata.LuminousData.LuminousIntensity.IntData[nv + nh * NumberVertical].Value = intensitydata[nv];
                };
            };


            //--------------CREATE EMISSIONAREAS BLOCK --------------------------

            lsourcedata.EmissionAreas = new UNI11733EmitterEmissionAreas();

            lsourcedata.EmissionAreas.BottomFace = new UNI11733EmitterEmissionAreasBottomFace() { BottomArea = new UNI11733EmitterEmissionAreasBottomFaceBottomArea() };

            lsourcedata.EmissionAreas.BottomFace.NumberBottom = 1;
            
            lsourcedata.EmissionAreas.BottomFace.BottomArea.Length = LumLength;                      

            lsourcedata.EmissionAreas.BottomFace.BottomArea.Width = LumWidth;

            lsourcedata.EmissionAreas.BottomFace.BottomArea.LengthOffset = 0;
            lsourcedata.EmissionAreas.BottomFace.BottomArea.WidthOffset = 0;

            if (LumWidth == 0)
            {
                lsourcedata.EmissionAreas.BottomFace.BottomArea.Circular = true;
                lsourcedata.EmissionAreas.BottomFace.BottomArea.CircularSpecified = true;
            }
            else
            {
                lsourcedata.EmissionAreas.BottomFace.BottomArea.Circular = false;
                lsourcedata.EmissionAreas.BottomFace.BottomArea.CircularSpecified = true;
            }
                        
            lsourcedata.EmissionAreas.TopFace = new UNI11733EmitterEmissionAreasTopFace();

            
            if (DFF >= 40 && DFF < 60)
            //if (hC0 == housingheight)
            {
                lsourcedata.EmissionAreas.TopFace.NumberTop = 1;
                lsourcedata.EmissionAreas.TopFace.TopArea = new UNI11733EmitterEmissionAreasTopFaceTopArea();
                lsourcedata.EmissionAreas.TopFace.TopArea.Length = LumLength;
                lsourcedata.EmissionAreas.TopFace.TopArea.Width = LumWidth;
                lsourcedata.EmissionAreas.TopFace.TopArea.LengthOffset = 0;
                lsourcedata.EmissionAreas.TopFace.TopArea.WidthOffset = 0;
                if (LumWidth == 0)
                {
                    lsourcedata.EmissionAreas.TopFace.TopArea.Circular = true;
                    lsourcedata.EmissionAreas.TopFace.TopArea.CircularSpecified = true;
                }
                else
                {
                    lsourcedata.EmissionAreas.TopFace.TopArea.Circular = false;
                    lsourcedata.EmissionAreas.TopFace.TopArea.CircularSpecified = true;
                }
            }

            lsourcedata.EmissionAreas.C0Face = new UNI11733EmitterEmissionAreasC0Face();
            if (hC0 != 0)
            {
                lsourcedata.EmissionAreas.C0Face.NumberC0 = 1;
                lsourcedata.EmissionAreas.C0Face.C0Area = new UNI11733EmitterEmissionAreasC0FaceC0Area();
                lsourcedata.EmissionAreas.C0Face.C0Area.Length = LumLength;
                lsourcedata.EmissionAreas.C0Face.C0Area.Height = hC0;
                lsourcedata.EmissionAreas.C0Face.C0Area.LengthOffset = 0;
                lsourcedata.EmissionAreas.C0Face.C0Area.HeightOffset = 0;
                if (LumLength == 0)
                {
                    lsourcedata.EmissionAreas.C0Face.C0Area.Circular = true;
                    lsourcedata.EmissionAreas.C0Face.C0Area.CircularSpecified = true;
                }
                else
                {
                    lsourcedata.EmissionAreas.C0Face.C0Area.Circular = false;
                    lsourcedata.EmissionAreas.C0Face.C0Area.CircularSpecified = true;
                }
            }

            lsourcedata.EmissionAreas.C90Face = new UNI11733EmitterEmissionAreasC90Face();
            if (hC90 != 0)
            {
                lsourcedata.EmissionAreas.C90Face.NumberC90 = 1;
                lsourcedata.EmissionAreas.C90Face.C90Area = new UNI11733EmitterEmissionAreasC90FaceC90Area();
                lsourcedata.EmissionAreas.C90Face.C90Area.Width = LumWidth;
                lsourcedata.EmissionAreas.C90Face.C90Area.Height = hC90;
                lsourcedata.EmissionAreas.C90Face.C90Area.WidthOffset = 0;
                lsourcedata.EmissionAreas.C90Face.C90Area.HeightOffset = 0;
                if (LumWidth == 0)
                {
                    lsourcedata.EmissionAreas.C90Face.C90Area.Circular = true;
                    lsourcedata.EmissionAreas.C90Face.C90Area.CircularSpecified = true;
                }
                else
                {
                    lsourcedata.EmissionAreas.C90Face.C90Area.Circular = false;
                    lsourcedata.EmissionAreas.C90Face.C90Area.CircularSpecified = true;
                }
            }

            lsourcedata.EmissionAreas.C180Face = new UNI11733EmitterEmissionAreasC180Face();
            if (hC180 != 0)
            {
                lsourcedata.EmissionAreas.C180Face.NumberC180 = 1;
                lsourcedata.EmissionAreas.C180Face.C180Area = new UNI11733EmitterEmissionAreasC180FaceC180Area();
                lsourcedata.EmissionAreas.C180Face.C180Area.Length = LumLength;
                lsourcedata.EmissionAreas.C180Face.C180Area.Height = hC180;
                lsourcedata.EmissionAreas.C180Face.C180Area.LengthOffset = 0;
                lsourcedata.EmissionAreas.C180Face.C180Area.HeightOffset = 0;
                if (LumLength == 0)
                {
                    lsourcedata.EmissionAreas.C180Face.C180Area.Circular = true;
                    lsourcedata.EmissionAreas.C180Face.C180Area.CircularSpecified = true;
                }
                else
                {
                    lsourcedata.EmissionAreas.C180Face.C180Area.Circular = false;
                    lsourcedata.EmissionAreas.C180Face.C180Area.CircularSpecified = true;
                }
            }

            lsourcedata.EmissionAreas.C270Face = new UNI11733EmitterEmissionAreasC270Face();
            if (hC270 != 0)
            {
                lsourcedata.EmissionAreas.C270Face.NumberC270 = 1;
                lsourcedata.EmissionAreas.C270Face.C270Area = new UNI11733EmitterEmissionAreasC270FaceC270Area();
                lsourcedata.EmissionAreas.C270Face.C270Area.Width = LumWidth;
                lsourcedata.EmissionAreas.C270Face.C270Area.Height = hC270;
                lsourcedata.EmissionAreas.C270Face.C270Area.WidthOffset = 0;
                lsourcedata.EmissionAreas.C270Face.C270Area.HeightOffset = 0;
                if (LumWidth == 0)
                {
                    lsourcedata.EmissionAreas.C270Face.C270Area.Circular = true;
                    lsourcedata.EmissionAreas.C270Face.C270Area.CircularSpecified = true;
                }
                else
                {
                    lsourcedata.EmissionAreas.C270Face.C270Area.Circular = false;
                    lsourcedata.EmissionAreas.C270Face.C270Area.CircularSpecified = true;
                }
            }

            Decimal LDClengthoff = 0;
            Decimal LDCwidthoff = 0;
            Decimal LDCheightoff;
            //MessageBox.Show(DFF.ToString);
            if (DFF >= 40m && DFF < 60m)
            {
                LDCheightoff = 0;
            }
            else
            {
                LDCheightoff = -(Height / 2m / 1000m);
                //MessageBox.Show(LDCheightoff.ToString());
            }

            lsourcedata.EmitterCenter = new UNI11733EmitterEmitterCenter();
            lsourcedata.EmitterCenter.LengthOffset = LDClengthoff;
            lsourcedata.EmitterCenter.WidthOffset = LDCwidthoff;
            lsourcedata.EmitterCenter.HeightOffset = LDCheightoff;

            xml.Emitter = new[] { lsourcedata };
        }
        

        // CREATE HEADER BLOCK FROM IES

        public void CreateIESXmlHeader()
        {
        
            IES_Parse iesparser = new IES_Parse();

            //--------------CREATE HEADER BLOCK FROM IES --------------------------

            CommentList.Clear();
            CommentList.Add(DocumentComments.DocComments);
            // Convert to array
            var ldtCommentArray = CommentList.ToArray();

            iesReferenceList.Clear();
            iesReferenceList.Add(Photometric_management.Instance.ldtiesname);
            // Convert to array
            var IESLDTReferenceArray = iesReferenceList.ToArray();

            iesparser.ParseIES();
           
            var headerdata = new UNI11733Header
            {

                Manufacturer = Manufacture,
                CatalogNumber = CatalogNumber,
                GTIN = GTINnumber.GTINnum,
                Description = Model_Description,
                Laboratory = Laboratory.Lab,
                ReportNumber = ReportNumber,

                ReportDate = ReportDate,
                
                DocumentCreator = DocumentCreator.DocCreator,
                DocumentCreationDate = DateTime.Now,
                //DocumentCreationDate = DateTime.Today,
                DocumentCreationDateSpecified = true,
                UniqueIdentifier = UUIDContainer.UUIDvalue,
                Comment = ldtCommentArray,
                Reference = IESLDTReferenceArray,
                MoreInfoURI = Moreinfouri.MoreInfoURL //"www.relux.com"
            };
            xml.Header = new[] { headerdata };

        }

        // CREATE DIMENSIONS BLOCK FROM IES

        public void CreateIESXmlDimensions()
        {
            IES_Parse iesparser = new IES_Parse();

            //iesparser.ParseIES();

            var dimensiondata = new UNI11733LuminaireDimensions();

            dimensiondata.Length = Length;
            dimensiondata.Width = Width;
            dimensiondata.Height = Height;

            var luminairedata = new UNI11733Luminaire();
            if (Width < 0) // is cylindrical
            {
                if (Height >= 0) // is cylindrical
                {
                    if (Math.Abs(Width) != Height) // is cylindrical
                    {
                        luminairedata.Shape = UNI11733LuminaireShape.Align_Z;
                        luminairedata.ShapeSpecified = true;
                    }
                }
                else if (Height < 0) // is cylindrical
                {
                    if (Width == Height) // is cylindrical
                    {
                        luminairedata.Shape = UNI11733LuminaireShape.Align_X;
                        luminairedata.ShapeSpecified = true;
                    }
                }
            }

            luminairedata.NumEmitter = NumberLightSource; //Int32.Parse(Eulumdatdata[25]);
            luminairedata.Dimensions = new[] { dimensiondata };

            xml.Luminaire = new[] { luminairedata };

        }

        // CREATE EQUIPMENT BLOCK FROM IES

        public void CreateIESXmlEquipment()
        {
            IES_Parse iesparser = new IES_Parse();
            //iesparser.ParseIES();

            var equipdata = new UNI11733Equipment();
            equipdata.Gonioradiometer = new UNI11733EquipmentGonioradiometer();
            if (Gonio == 1)
                equipdata.Gonioradiometer.Type = UNI11733EquipmentGonioradiometerType.CIE_A;
            else if (Gonio == 2)
                equipdata.Gonioradiometer.Type = UNI11733EquipmentGonioradiometerType.CIE_B;
            else if (Gonio == 3)
                equipdata.Gonioradiometer.Type = UNI11733EquipmentGonioradiometerType.CIE_C;
            xml.Equipment = new[] { equipdata };
        }

        // CREATE LIGHTSOURCE BLOCK FROM IES

        public void CreateIESXmlLightSource()
        {
            IES_Parse iesparser = new IES_Parse();
            //iesparser.ParseIES();


            var lsourcedata = new UNI11733Emitter();
            lsourcedata.Quantity = Quantity;//Int32.Parse(firstlinearray[0]);
            lsourcedata.Description = LampDescription;
            lsourcedata.CatalogNumber = LampCatalogNumber;
            lsourcedata.InputWattage = Convert.ToDecimal(InputWattage);

            lsourcedata.LuminousData = new UNI11733EmitterLuminousData() { LuminousIntensity = new UNI11733EmitterLuminousDataLuminousIntensity() };

            lsourcedata.LuminousData.LuminousIntensity.AbsolutePhotometry = ABSPhotom;
        

            lsourcedata.RatedLumens = RatedLumen;
            lsourcedata.LuminousData.LuminousIntensity.NumberMeasured = 1;
                        
            lsourcedata.LuminousData.LuminousIntensity.NumberHorz = NumberHorizontal;
            
            lsourcedata.LuminousData.LuminousIntensity.NumberVert = NumberVertical;
           
            lsourcedata.LuminousData.LuminousIntensity.IntData = new IntDataType2[candelaidx];

            for (int nh = 0; nh < NumberHorizontal; nh++)
            {
                //lsourcedata.LuminousData.LuminousIntensity.IntData = new  IntDataType2() ;

                for (int nv = 0; nv < NumberVertical; nv++)
                {
                    lsourcedata.LuminousData.LuminousIntensity.IntData[nv + nh * NumberVertical] = new IntDataType2();
                    lsourcedata.LuminousData.LuminousIntensity.IntData[nv + nh * NumberVertical].h = cplaneset[nh];
                    lsourcedata.LuminousData.LuminousIntensity.IntData[nv + nh * NumberVertical].hSpecified = true;

                    lsourcedata.LuminousData.LuminousIntensity.IntData[nv + nh * NumberVertical].v = distcpset[nv];
                    lsourcedata.LuminousData.LuminousIntensity.IntData[nv + nh * NumberVertical].vSpecified = true;

                    lsourcedata.LuminousData.LuminousIntensity.IntData[nv + nh * NumberVertical].Value = IESintensitydata[nv];
                };
            };

            xml.Emitter = new[] { lsourcedata };
        }

    

        // WRITE XML

        public void SerializeXml()
        {
            var serializer = new XmlSerializer(typeof(UNI11733));
            var writer = new StreamWriter(Photometric_management.Instance.FullFileName.Replace(".ldt", "") + ".xml");
            serializer.Serialize(writer, xml);
            writer.Close();
        }


    }
}
