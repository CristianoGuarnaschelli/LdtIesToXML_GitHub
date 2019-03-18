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



        public static Create_UNI11733_Xml Instance
        {
            get
            {
                return instance;
            }
        }

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

        //emission areas varibles
        public Int32 NBtmFace;
        public Int32 NTopFace;
        public Int32 NC0Face;
        public Int32 NC90Face;
        public Int32 NC180Face;
        public Int32 NC270Face;
        public String CircularShape;
        public bool CircularShapeBtm;
        public bool CircularShapeTop;
        public bool CircularShapeC0;
        public bool CircularShapeC90;
        public bool CircularShapeC180;
        public bool CircularShapeC270;

        // emitter center variables
        public Decimal LDClengthoff;
        public Decimal LDCwidthoff;
        public Decimal LDCheightoff;

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
            Ldtlines.Clear();

            //Header variables
            Manufacture = null;
            Model_Description = null;
            CatalogNumber = null;
            MaesureLaboratory = null;
            ReportNumber = null;
            ReportDate = null;
            DocCreator = null;
            //DocCreateDate = null;
            Comments = null;
            //Reference = null;
            url = null;

            //Dimensions variables
            Length = 0;
            Width = 0;
            Height = 0;
            NumberHorizontal = 0;
            NumberVertical = 0;
            LumLength = 0;
            LumWidth = 0;
            hC0 = 0;
            hC90 = 0;
            hC180 = 0;
            hC270 = 0;

            //emission areas varibles
            NBtmFace = 0;
            NTopFace = 0;
            NC0Face = 0;
            NC90Face = 0;
            NC180Face = 0;
            NC270Face = 0;
            CircularShape ="null";
            CircularShapeBtm = false;
            CircularShapeTop = false;
            CircularShapeC0 = false;
            CircularShapeC90 = false;
            CircularShapeC180 = false;
            CircularShapeC270 = false;

            //Equipment variables
            Gonio = 0;

            // Emitter variables
            NumberLightSource = 0;
            Quantity = 0;
            LampDescription = null;
            LampCatalogNumber = null;
            RatedLumen = 0;
            InputWattage = null;
            RaCRI = null;
            FixedCCT = null;
            LORL = 0;
            ABSPhotom = false;
            symm = 0;
            NameInFile = null;

            DFF = 0;
            DistanceCPlanes = 0;
            distcpset = null;
            cplaneset = null;
            candelaidx = 0;
            IESintensitydata = null;

            // Create list
            //CommentList.Clear();
            //CommentList = null;
            //iesReferenceList.Clear();
            //iesReferenceList = null;

        }

        private Create_UNI11733_Xml()
        {
            Init();
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
                Comment = ldtCommentArray,
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

            dimensiondata.Length = Convert.ToDecimal(EmitterBoxLength.EmBoxLength);
            dimensiondata.Width = Convert.ToDecimal(EmitterBoxWidth.EmBoxWidth);
            dimensiondata.Height = Convert.ToDecimal(EmitterBoxHeight.EmBoxHeight);

            var luminairedata = new UNI11733Luminaire();
            //if (CircularShape == "Align_Z") // is cylindrical
            if (EmitterBoxShapeCirc.EmBoxShapeCirc == "Align_Z") // is cylindrical
            {                
                luminairedata.Shape = UNI11733LuminaireShape.Align_Z;
                luminairedata.ShapeSpecified = true;
            }
            else if (EmitterBoxShapeCirc.EmBoxShapeCirc == "Align_X") // is cylindrical
            {
                luminairedata.Shape = UNI11733LuminaireShape.Align_X;
                luminairedata.ShapeSpecified = true;
            }

            else if (EmitterBoxShapeCirc.EmBoxShapeCirc == "Align_Y") // is cylindrical
            {
                luminairedata.Shape = UNI11733LuminaireShape.Align_Y;
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

            //--------------CREATE LIGHTSOURCE BLOCK FROM LDT--------------------------

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


            //--------------CREATE EMISSIONAREAS BLOCK FROM LDT --------------------------

            lsourcedata.EmissionAreas = new UNI11733EmitterEmissionAreas();

            //------------ CREATE BOTTOM FACE FROM LDT-----------------------------

            if (DFF > 10)
            {
                lsourcedata.EmissionAreas.BottomFace = new UNI11733EmitterEmissionAreasBottomFace() { BottomArea = new UNI11733EmitterEmissionAreasBottomFaceBottomArea() };

                lsourcedata.EmissionAreas.BottomFace.NumberBottom = Convert.ToInt32(NumEmitterBottomFace.NumEmBtmFace);

                lsourcedata.EmissionAreas.BottomFace.BottomArea.Length = Convert.ToDecimal(EmitterBottomLength.EmBtmLength);
                lsourcedata.EmissionAreas.BottomFace.BottomArea.LengthOffset = Convert.ToDecimal(EmitterBottomLengthOffset.EmBtmLengthOff);

                if (Convert.ToDecimal(EmitterBottomWidth.EmBtmWidth) == 0)
                {
                    lsourcedata.EmissionAreas.BottomFace.BottomArea.Width = Convert.ToDecimal(EmitterBottomLength.EmBtmLength);
                    lsourcedata.EmissionAreas.BottomFace.BottomArea.WidthOffset = Convert.ToDecimal(EmitterBottomLengthOffset.EmBtmLengthOff);
                    lsourcedata.EmissionAreas.BottomFace.BottomArea.Circular = true;
                    lsourcedata.EmissionAreas.BottomFace.BottomArea.CircularSpecified = true;
                }
                else
                {
                    lsourcedata.EmissionAreas.BottomFace.BottomArea.Width = Convert.ToDecimal(EmitterBottomWidth.EmBtmWidth);
                    lsourcedata.EmissionAreas.BottomFace.BottomArea.WidthOffset = Convert.ToDecimal(EmitterBottomWidthOffset.EmBtmWidthoff);
                    lsourcedata.EmissionAreas.BottomFace.BottomArea.Circular = false;
                    lsourcedata.EmissionAreas.BottomFace.BottomArea.CircularSpecified = false;
                }
            }

            //------------ CREATE TOP FACE FROM LDT -----------------------------


            if (DFF < 60)
            {
                lsourcedata.EmissionAreas.TopFace = new UNI11733EmitterEmissionAreasTopFace();
                lsourcedata.EmissionAreas.TopFace.NumberTop = Convert.ToInt32(NumEmitterTopFace.NumEmTopFace);
                lsourcedata.EmissionAreas.TopFace.TopArea = new UNI11733EmitterEmissionAreasTopFaceTopArea();
                lsourcedata.EmissionAreas.TopFace.TopArea.Length = Convert.ToDecimal(EmitterTopLength.EmTopLength);
                lsourcedata.EmissionAreas.TopFace.TopArea.Width = Convert.ToDecimal(EmitterTopWidth.EmTopWidth);
                lsourcedata.EmissionAreas.TopFace.TopArea.LengthOffset = Convert.ToDecimal(EmitterTopLengthOffset.EmTopLengthOff);
                lsourcedata.EmissionAreas.TopFace.TopArea.WidthOffset = Convert.ToDecimal(EmitterTopWidthOffset.EmTopWidthoff);
                if (Convert.ToDecimal(EmitterTopWidth.EmTopWidth) == 0)
                {
                    lsourcedata.EmissionAreas.TopFace.TopArea.Circular = true;
                    lsourcedata.EmissionAreas.TopFace.TopArea.CircularSpecified = true;
                }
                else
                {
                    lsourcedata.EmissionAreas.TopFace.TopArea.Circular = false;
                    lsourcedata.EmissionAreas.TopFace.TopArea.CircularSpecified = false;
                }
            }

            //------------ CREATE C-0 FACE FROM LDT -----------------------------


            if (Convert.ToDecimal(EmitterC0Height.EmC0Height) != 0)
            {
                lsourcedata.EmissionAreas.C0Face = new UNI11733EmitterEmissionAreasC0Face();
                lsourcedata.EmissionAreas.C0Face.NumberC0 = Convert.ToInt32(NumEmitterC0Face.NumEmC0Face);
                lsourcedata.EmissionAreas.C0Face.C0Area = new UNI11733EmitterEmissionAreasC0FaceC0Area();
                lsourcedata.EmissionAreas.C0Face.C0Area.Length = Convert.ToDecimal(EmitterC0Width.EmC0Width);
                lsourcedata.EmissionAreas.C0Face.C0Area.Height = Convert.ToDecimal(EmitterC0Height.EmC0Height);
                lsourcedata.EmissionAreas.C0Face.C0Area.LengthOffset = Convert.ToDecimal(EmitterC0WidthOffset.EmC0Widthoff);
                lsourcedata.EmissionAreas.C0Face.C0Area.HeightOffset = Convert.ToDecimal(EmitterC0HeightOffset.EmC0HeightOff);
                if (Convert.ToDecimal(EmitterC0Width.EmC0Width) == 0)
                {
                    lsourcedata.EmissionAreas.C0Face.C0Area.Circular = true;
                    lsourcedata.EmissionAreas.C0Face.C0Area.CircularSpecified = true;
                }
                else
                {
                    lsourcedata.EmissionAreas.C0Face.C0Area.Circular = false;
                    lsourcedata.EmissionAreas.C0Face.C0Area.CircularSpecified = false;
                }
            }

            //------------ CREATE C-90 FACE FROM LDT -----------------------------


            if (Convert.ToDecimal(EmitterC90Height.EmC90Height) != 0)
            {
                lsourcedata.EmissionAreas.C90Face = new UNI11733EmitterEmissionAreasC90Face();
                lsourcedata.EmissionAreas.C90Face.NumberC90 = Convert.ToInt32(NumEmitterC90Face.NumEmC90Face);
                lsourcedata.EmissionAreas.C90Face.C90Area = new UNI11733EmitterEmissionAreasC90FaceC90Area();
                lsourcedata.EmissionAreas.C90Face.C90Area.Width = Convert.ToDecimal(EmitterC90Length.EmC90Length);
                lsourcedata.EmissionAreas.C90Face.C90Area.Height = Convert.ToDecimal(EmitterC0Height.EmC0Height);
                lsourcedata.EmissionAreas.C90Face.C90Area.WidthOffset = Convert.ToDecimal(EmitterC90LengthOffset.EmC90LengthOff);
                lsourcedata.EmissionAreas.C90Face.C90Area.HeightOffset = Convert.ToDecimal(EmitterC90HeightOffset.EmC90HeightOff);
                if (Convert.ToDecimal(EmitterC90Length.EmC90Length) == 0)
                {
                    lsourcedata.EmissionAreas.C90Face.C90Area.Circular = true;
                    lsourcedata.EmissionAreas.C90Face.C90Area.CircularSpecified = true;
                }
                else
                {
                    lsourcedata.EmissionAreas.C90Face.C90Area.Circular = false;
                    lsourcedata.EmissionAreas.C90Face.C90Area.CircularSpecified = false;
                }
            }

            //------------ CREATE C-180 FACE FROM LDT -----------------------------


            if (Convert.ToDecimal(EmitterC180Height.EmC180Height) != 0)
            {
                lsourcedata.EmissionAreas.C180Face = new UNI11733EmitterEmissionAreasC180Face();
                lsourcedata.EmissionAreas.C180Face.NumberC180 = Convert.ToInt32(NumEmitterC180Face.NumEmC180Face);
                lsourcedata.EmissionAreas.C180Face.C180Area = new UNI11733EmitterEmissionAreasC180FaceC180Area();
                lsourcedata.EmissionAreas.C180Face.C180Area.Length = Convert.ToDecimal(EmitterC180Width.EmC180Width);
                lsourcedata.EmissionAreas.C180Face.C180Area.Height = Convert.ToDecimal(EmitterC180Height.EmC180Height);
                lsourcedata.EmissionAreas.C180Face.C180Area.LengthOffset = Convert.ToDecimal(EmitterC180WidthOffset.EmC180WidthOff);
                lsourcedata.EmissionAreas.C180Face.C180Area.HeightOffset = Convert.ToDecimal(EmitterC180HeightOffset.EmC180HeightOff);
                if (Convert.ToDecimal(EmitterC180Width.EmC180Width) == 0)
                {
                    lsourcedata.EmissionAreas.C180Face.C180Area.Circular = true;
                    lsourcedata.EmissionAreas.C180Face.C180Area.CircularSpecified = true;
                }
                else
                {
                    lsourcedata.EmissionAreas.C180Face.C180Area.Circular = false;
                    lsourcedata.EmissionAreas.C180Face.C180Area.CircularSpecified = false;
                }
            }

            //------------ CREATE C-270 FACE FROM LDT -----------------------------


            if (Convert.ToDecimal(EmitterC270Height.EmC270Height) != 0)
            {
                lsourcedata.EmissionAreas.C270Face = new UNI11733EmitterEmissionAreasC270Face();
                lsourcedata.EmissionAreas.C270Face.NumberC270 = Convert.ToInt32(NumEmitterC270Face.NumEmC270Face);
                lsourcedata.EmissionAreas.C270Face.C270Area = new UNI11733EmitterEmissionAreasC270FaceC270Area();
                lsourcedata.EmissionAreas.C270Face.C270Area.Width = Convert.ToDecimal(EmitterC270Length.EmC270Length);
                lsourcedata.EmissionAreas.C270Face.C270Area.Height = Convert.ToDecimal(EmitterC270Height.EmC270Height);
                lsourcedata.EmissionAreas.C270Face.C270Area.WidthOffset = Convert.ToDecimal(EmitterC270LengthOffset.EmC270LengthOff);
                lsourcedata.EmissionAreas.C270Face.C270Area.HeightOffset = Convert.ToDecimal(EmitterC270HeightOffset.EmC270HeightOff);
                if (Convert.ToDecimal(EmitterC270Length.EmC270Length) == 0)
                {
                    lsourcedata.EmissionAreas.C270Face.C270Area.Circular = true;
                    lsourcedata.EmissionAreas.C270Face.C270Area.CircularSpecified = true;
                }
                else
                {
                    lsourcedata.EmissionAreas.C270Face.C270Area.Circular = false;
                    lsourcedata.EmissionAreas.C270Face.C270Area.CircularSpecified = false;
                }
            }

            //Decimal LDClengthoff = 0;
            //Decimal LDCwidthoff = 0;
            //Decimal LDCheightoff;
            //MessageBox.Show(DFF.ToString);

            LDClengthoff = Convert.ToDecimal(ECLengthOffset.ECLengthOff);
            LDCwidthoff = Convert.ToDecimal(ECWidthOffset.ECWidthOff);

            if (DFF >= 40m && DFF < 60m)
            {
                LDCheightoff = 0;
            }
            else
            {
                LDCheightoff = -(Convert.ToDecimal(ECHeightOffset.ECHeightOff) / 2m );
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

            var dimensiondata = new UNI11733LuminaireDimensions();
            
            dimensiondata.Length = Math.Abs(Convert.ToDecimal(EmitterBoxLength.EmBoxLength));
            dimensiondata.Width = Math.Abs(Convert.ToDecimal(EmitterBoxWidth.EmBoxWidth));
            dimensiondata.Height = Math.Abs(Convert.ToDecimal(EmitterBoxHeight.EmBoxHeight));

            var luminairedata = new UNI11733Luminaire();

            //if(String.IsNullOrEmpty(CircularShape)==false)
            if (EmitterBoxShapeCirc.EmBoxShapeCirc == "Align_Z")
            {
                luminairedata.Shape = UNI11733LuminaireShape.Align_Z;
                luminairedata.ShapeSpecified = true;    
            }
            else if (EmitterBoxShapeCirc.EmBoxShapeCirc == "Align_X")
            {
                luminairedata.Shape = UNI11733LuminaireShape.Align_X;
                luminairedata.ShapeSpecified = true;
            }
            else if (EmitterBoxShapeCirc.EmBoxShapeCirc == "Align_Y")
            {
                luminairedata.Shape = UNI11733LuminaireShape.Align_Y;
                luminairedata.ShapeSpecified = true;
            }

            if (CircularShapeBtm == true) // is cylindrical
            {
                //CircularShape = "Align_Z";
                luminairedata.Shape = UNI11733LuminaireShape.Align_Z;
                luminairedata.ShapeSpecified = true;
            }

            else if (CircularShapeC0 == true) // is cylindrical
            {
                //CircularShape = "Align_X";
                luminairedata.Shape = UNI11733LuminaireShape.Align_X;
                luminairedata.ShapeSpecified = true;
            }

            else if (CircularShapeC90 == true) // is cylindrical
            {
                //CircularShape = "Align_Y";
                luminairedata.Shape = UNI11733LuminaireShape.Align_Y;
                luminairedata.ShapeSpecified = true;
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

            //--------------CREATE EMISSIONAREAS BLOCK FROM IES--------------------------

            lsourcedata.EmissionAreas = new UNI11733EmitterEmissionAreas();

            //------------ CREATE BOTTOM FACE FROM IES-----------------------------

            lsourcedata.EmissionAreas.BottomFace = new UNI11733EmitterEmissionAreasBottomFace() { BottomArea = new UNI11733EmitterEmissionAreasBottomFaceBottomArea() };

            if (NumEmitterBottomFace.NumEmBtmFace != "0")
            {
                lsourcedata.EmissionAreas.BottomFace.NumberBottom = Convert.ToInt32(NumEmitterBottomFace.NumEmBtmFace);

                lsourcedata.EmissionAreas.BottomFace.BottomArea.Length = Math.Abs(Convert.ToDecimal(EmitterBottomLength.EmBtmLength));
                lsourcedata.EmissionAreas.BottomFace.BottomArea.Width = Math.Abs(Convert.ToDecimal(EmitterBottomWidth.EmBtmWidth));

                lsourcedata.EmissionAreas.BottomFace.BottomArea.LengthOffset = Convert.ToDecimal(EmitterBottomLengthOffset.EmBtmLengthOff);
                lsourcedata.EmissionAreas.BottomFace.BottomArea.WidthOffset = Convert.ToDecimal(EmitterBottomWidthOffset.EmBtmWidthoff);

                if (CircularShapeBtm == true)
                {
                    lsourcedata.EmissionAreas.BottomFace.BottomArea.Circular = true;
                    lsourcedata.EmissionAreas.BottomFace.BottomArea.CircularSpecified = true;
                }
                else
                {
                    lsourcedata.EmissionAreas.BottomFace.BottomArea.Circular = false;
                    lsourcedata.EmissionAreas.BottomFace.BottomArea.CircularSpecified = false;
                }
            }
            else if (NumEmitterBottomFace.NumEmBtmFace == "0")
            {
                lsourcedata.EmissionAreas.BottomFace.NumberBottom = Convert.ToInt32(NumEmitterBottomFace.NumEmBtmFace);

                lsourcedata.EmissionAreas.BottomFace.BottomArea.Length = Math.Abs(Convert.ToDecimal(EmitterBottomLength.EmBtmLength));
                lsourcedata.EmissionAreas.BottomFace.BottomArea.Width = Math.Abs(Convert.ToDecimal(EmitterBottomWidth.EmBtmWidth));

                lsourcedata.EmissionAreas.BottomFace.BottomArea.LengthOffset = Convert.ToDecimal(EmitterBottomLengthOffset.EmBtmLengthOff);
                lsourcedata.EmissionAreas.BottomFace.BottomArea.WidthOffset = Convert.ToDecimal(EmitterBottomWidthOffset.EmBtmWidthoff);

                lsourcedata.EmissionAreas.BottomFace.BottomArea.Circular = false;
                lsourcedata.EmissionAreas.BottomFace.BottomArea.CircularSpecified = false;

            }

            if (NumEmitterTopFace.NumEmTopFace != "0")
            {
                lsourcedata.EmissionAreas.TopFace = new UNI11733EmitterEmissionAreasTopFace();
                
                lsourcedata.EmissionAreas.TopFace.NumberTop = Convert.ToInt32(NumEmitterTopFace.NumEmTopFace);

                lsourcedata.EmissionAreas.TopFace.TopArea = new UNI11733EmitterEmissionAreasTopFaceTopArea();

                lsourcedata.EmissionAreas.TopFace.TopArea.Length = Math.Abs(Convert.ToDecimal(EmitterTopLength.EmTopLength));
                lsourcedata.EmissionAreas.TopFace.TopArea.Width = Math.Abs(Convert.ToDecimal(EmitterTopWidth.EmTopWidth));
                lsourcedata.EmissionAreas.TopFace.TopArea.LengthOffset = Convert.ToDecimal(EmitterTopLengthOffset.EmTopLengthOff);
                lsourcedata.EmissionAreas.TopFace.TopArea.WidthOffset = Convert.ToDecimal(EmitterTopWidthOffset.EmTopWidthoff);
                if (CircularShapeTop == true)
                {
                    lsourcedata.EmissionAreas.TopFace.TopArea.Circular = true;
                    lsourcedata.EmissionAreas.TopFace.TopArea.CircularSpecified = true;
                }
                else
                {
                    lsourcedata.EmissionAreas.TopFace.TopArea.Circular = false;
                    lsourcedata.EmissionAreas.TopFace.TopArea.CircularSpecified = false;
                }

            }

            
            if (NumEmitterC0Face.NumEmC0Face != "0")
            {
                lsourcedata.EmissionAreas.C0Face = new UNI11733EmitterEmissionAreasC0Face();

                lsourcedata.EmissionAreas.C0Face.NumberC0 = Convert.ToInt32(NumEmitterC0Face.NumEmC0Face);
                lsourcedata.EmissionAreas.C0Face.C0Area = new UNI11733EmitterEmissionAreasC0FaceC0Area();
                lsourcedata.EmissionAreas.C0Face.C0Area.Length = Math.Abs(Convert.ToDecimal(EmitterC0Width.EmC0Width));
                lsourcedata.EmissionAreas.C0Face.C0Area.Height = Math.Abs(Convert.ToDecimal(EmitterC0Height.EmC0Height));
                lsourcedata.EmissionAreas.C0Face.C0Area.LengthOffset = Convert.ToDecimal(EmitterC0WidthOffset.EmC0Widthoff);
                lsourcedata.EmissionAreas.C0Face.C0Area.HeightOffset = Convert.ToDecimal(EmitterC0HeightOffset.EmC0HeightOff);
                if (CircularShapeC0 == true)
                {
                    lsourcedata.EmissionAreas.C0Face.C0Area.Circular = true;
                    lsourcedata.EmissionAreas.C0Face.C0Area.CircularSpecified = true;
                }
                else
                {
                    lsourcedata.EmissionAreas.C0Face.C0Area.Circular = false;
                    lsourcedata.EmissionAreas.C0Face.C0Area.CircularSpecified = false;
                }
            }

            
            if (NumEmitterC90Face.NumEmC90Face != "0")
            {
                lsourcedata.EmissionAreas.C90Face = new UNI11733EmitterEmissionAreasC90Face();

                lsourcedata.EmissionAreas.C90Face.NumberC90 = Convert.ToInt32(NumEmitterC90Face.NumEmC90Face);
                lsourcedata.EmissionAreas.C90Face.C90Area = new UNI11733EmitterEmissionAreasC90FaceC90Area();
                lsourcedata.EmissionAreas.C90Face.C90Area.Width = Math.Abs(Convert.ToDecimal(EmitterC90Length.EmC90Length));
                lsourcedata.EmissionAreas.C90Face.C90Area.Height = Math.Abs(Convert.ToDecimal(EmitterC0Height.EmC0Height));
                lsourcedata.EmissionAreas.C90Face.C90Area.WidthOffset = Convert.ToDecimal(EmitterC90LengthOffset.EmC90LengthOff);
                lsourcedata.EmissionAreas.C90Face.C90Area.HeightOffset = Convert.ToDecimal(EmitterC90HeightOffset.EmC90HeightOff);
                if (CircularShapeC90 == true) 
                {
                    lsourcedata.EmissionAreas.C90Face.C90Area.Circular = true;
                    lsourcedata.EmissionAreas.C90Face.C90Area.CircularSpecified = true;
                }
                else
                {
                    lsourcedata.EmissionAreas.C90Face.C90Area.Circular = false;
                    lsourcedata.EmissionAreas.C90Face.C90Area.CircularSpecified = false;
                }
            }

            
            if (NumEmitterC180Face.NumEmC180Face != "0")
            {
                lsourcedata.EmissionAreas.C180Face = new UNI11733EmitterEmissionAreasC180Face();
                lsourcedata.EmissionAreas.C180Face.NumberC180 = Convert.ToInt32(NumEmitterC180Face.NumEmC180Face);
                lsourcedata.EmissionAreas.C180Face.C180Area = new UNI11733EmitterEmissionAreasC180FaceC180Area();
                lsourcedata.EmissionAreas.C180Face.C180Area.Length = Math.Abs(Convert.ToDecimal(EmitterC180Width.EmC180Width));
                lsourcedata.EmissionAreas.C180Face.C180Area.Height = Math.Abs(Convert.ToDecimal(EmitterC180Height.EmC180Height));
                lsourcedata.EmissionAreas.C180Face.C180Area.LengthOffset = Convert.ToDecimal(EmitterC180WidthOffset.EmC180WidthOff);
                lsourcedata.EmissionAreas.C180Face.C180Area.HeightOffset = Convert.ToDecimal(EmitterC180HeightOffset.EmC180HeightOff);
                if (CircularShapeC180 == true)
                {
                    lsourcedata.EmissionAreas.C180Face.C180Area.Circular = true;
                    lsourcedata.EmissionAreas.C180Face.C180Area.CircularSpecified = true;
                }
                else
                {
                    lsourcedata.EmissionAreas.C180Face.C180Area.Circular = false;
                    lsourcedata.EmissionAreas.C180Face.C180Area.CircularSpecified = false;
                }
            }

            
            if (NumEmitterC270Face.NumEmC270Face != "0")
            {
                lsourcedata.EmissionAreas.C270Face = new UNI11733EmitterEmissionAreasC270Face();
                lsourcedata.EmissionAreas.C270Face.NumberC270 = Convert.ToInt32(NumEmitterC270Face.NumEmC270Face);
                lsourcedata.EmissionAreas.C270Face.C270Area = new UNI11733EmitterEmissionAreasC270FaceC270Area();
                lsourcedata.EmissionAreas.C270Face.C270Area.Width = Math.Abs(Convert.ToDecimal(EmitterC270Length.EmC270Length));
                lsourcedata.EmissionAreas.C270Face.C270Area.Height = Math.Abs(Convert.ToDecimal(EmitterC270Height.EmC270Height));
                lsourcedata.EmissionAreas.C270Face.C270Area.WidthOffset = Convert.ToDecimal(EmitterC270LengthOffset.EmC270LengthOff);
                lsourcedata.EmissionAreas.C270Face.C270Area.HeightOffset = Convert.ToDecimal(EmitterC270HeightOffset.EmC270HeightOff);
                if (CircularShapeC270 == true)
                {
                    lsourcedata.EmissionAreas.C270Face.C270Area.Circular = true;
                    lsourcedata.EmissionAreas.C270Face.C270Area.CircularSpecified = true;
                }
                else
                {
                    lsourcedata.EmissionAreas.C270Face.C270Area.Circular = false;
                    lsourcedata.EmissionAreas.C270Face.C270Area.CircularSpecified = false;
                }
            }

                       
            lsourcedata.EmitterCenter = new UNI11733EmitterEmitterCenter();
            lsourcedata.EmitterCenter.LengthOffset =Convert.ToDecimal(ECLengthOffset.ECLengthOff);
            lsourcedata.EmitterCenter.WidthOffset = Convert.ToDecimal(ECWidthOffset.ECWidthOff);
            lsourcedata.EmitterCenter.HeightOffset = Convert.ToDecimal(ECHeightOffset.ECHeightOff);


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
