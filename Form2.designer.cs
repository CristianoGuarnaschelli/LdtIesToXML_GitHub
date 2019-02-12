namespace LDTandIEStoXMLConverter
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoadLdt = new System.Windows.Forms.Button();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.LDTtextBox = new System.Windows.Forms.TextBox();
            this.LDTlabel = new System.Windows.Forms.Label();
            this.Manuflabel = new System.Windows.Forms.Label();
            this.ManuftextBox = new System.Windows.Forms.TextBox();
            this.Modellabel = new System.Windows.Forms.Label();
            this.CatalogNumberlabel = new System.Windows.Forms.Label();
            this.CatalogNumbertextBox = new System.Windows.Forms.TextBox();
            this.ModeltextBox = new System.Windows.Forms.TextBox();
            this.HeaderGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GTINtextBox = new System.Windows.Forms.TextBox();
            this.MoreInfoURITextBox = new System.Windows.Forms.TextBox();
            this.MoreInfoURILabel = new System.Windows.Forms.Label();
            this.ReferenceTextBox = new System.Windows.Forms.TextBox();
            this.ReferenceLabel = new System.Windows.Forms.Label();
            this.CommentTextBox = new System.Windows.Forms.TextBox();
            this.CommentLabel = new System.Windows.Forms.Label();
            this.UniqueIdentifierTextBox = new System.Windows.Forms.TextBox();
            this.UniqueIdentifierLabel = new System.Windows.Forms.Label();
            this.DocCreateDateTextBox = new System.Windows.Forms.TextBox();
            this.DocCreateDateLabel = new System.Windows.Forms.Label();
            this.DocCreatorTextBox = new System.Windows.Forms.TextBox();
            this.DocCreatorLabel = new System.Windows.Forms.Label();
            this.RepDateTextBox = new System.Windows.Forms.TextBox();
            this.RepDateLabel = new System.Windows.Forms.Label();
            this.RepNumTextBox = new System.Windows.Forms.TextBox();
            this.ReportNumLbel = new System.Windows.Forms.Label();
            this.LabTextBox = new System.Windows.Forms.TextBox();
            this.LabLabel = new System.Windows.Forms.Label();
            this.LuminaireGroupBox = new System.Windows.Forms.GroupBox();
            this.ShapeTextBox = new System.Windows.Forms.TextBox();
            this.ShapeLabel = new System.Windows.Forms.Label();
            this.NLightSourceTextBox = new System.Windows.Forms.TextBox();
            this.DimGroupBox = new System.Windows.Forms.GroupBox();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.LengthTextBox = new System.Windows.Forms.TextBox();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.LengthLabel = new System.Windows.Forms.Label();
            this.NLightSourceLabel = new System.Windows.Forms.Label();
            this.LightEmitterGroupBox = new System.Windows.Forms.GroupBox();
            this.RatedLmTextBox = new System.Windows.Forms.TextBox();
            this.RatedLmLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NumberVertTextBox = new System.Windows.Forms.TextBox();
            this.NumberVertLabel = new System.Windows.Forms.Label();
            this.NumberHorzTextBox = new System.Windows.Forms.TextBox();
            this.NumberHorzLabel = new System.Windows.Forms.Label();
            this.NumMeasuredTextBox = new System.Windows.Forms.TextBox();
            this.NumMeasuredLabel = new System.Windows.Forms.Label();
            this.ASymmTextBox = new System.Windows.Forms.TextBox();
            this.ASymmLabel = new System.Windows.Forms.Label();
            this.ABSPhotomTextBox = new System.Windows.Forms.TextBox();
            this.AbsolutePhotometryLabel = new System.Windows.Forms.Label();
            this.CRIGroupBox = new System.Windows.Forms.GroupBox();
            this.RaTextBox = new System.Windows.Forms.TextBox();
            this.RaLabel = new System.Windows.Forms.Label();
            this.ColorTempGroupBox = new System.Windows.Forms.GroupBox();
            this.FixedCCTTextBox = new System.Windows.Forms.TextBox();
            this.FixedCCTLabel = new System.Windows.Forms.Label();
            this.InputWattageTextBox = new System.Windows.Forms.TextBox();
            this.InputWattageLabel = new System.Windows.Forms.Label();
            this.LampCodeTextBox = new System.Windows.Forms.TextBox();
            this.LampCodeLabel = new System.Windows.Forms.Label();
            this.DescTextBox = new System.Windows.Forms.TextBox();
            this.DescLabel = new System.Windows.Forms.Label();
            this.QuantityTextBox = new System.Windows.Forms.TextBox();
            this.QuantityLabel = new System.Windows.Forms.Label();
            this.ConvertButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.HeaderGroupBox.SuspendLayout();
            this.LuminaireGroupBox.SuspendLayout();
            this.DimGroupBox.SuspendLayout();
            this.LightEmitterGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.CRIGroupBox.SuspendLayout();
            this.ColorTempGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoadLdt
            // 
            this.LoadLdt.Location = new System.Drawing.Point(23, 24);
            this.LoadLdt.Name = "LoadLdt";
            this.LoadLdt.Size = new System.Drawing.Size(107, 23);
            this.LoadLdt.TabIndex = 0;
            this.LoadLdt.Text = "Load Ldt/Ies file";
            this.LoadLdt.UseVisualStyleBackColor = true;
            this.LoadLdt.Click += new System.EventHandler(this.LoadLdt_Click);
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            this.eventLog1.EntryWritten += new System.Diagnostics.EntryWrittenEventHandler(this.EventLog1_EntryWritten);
            // 
            // LDTtextBox
            // 
            this.LDTtextBox.Location = new System.Drawing.Point(276, 26);
            this.LDTtextBox.Name = "LDTtextBox";
            this.LDTtextBox.Size = new System.Drawing.Size(331, 20);
            this.LDTtextBox.TabIndex = 1;
            this.LDTtextBox.Text = "Photometric File";
            // 
            // LDTlabel
            // 
            this.LDTlabel.AutoSize = true;
            this.LDTlabel.Location = new System.Drawing.Point(159, 29);
            this.LDTlabel.Name = "LDTlabel";
            this.LDTlabel.Size = new System.Drawing.Size(111, 13);
            this.LDTlabel.TabIndex = 2;
            this.LDTlabel.Text = "Photometric Filename:";
            this.LDTlabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Manuflabel
            // 
            this.Manuflabel.AutoSize = true;
            this.Manuflabel.Location = new System.Drawing.Point(11, 33);
            this.Manuflabel.Name = "Manuflabel";
            this.Manuflabel.Size = new System.Drawing.Size(73, 13);
            this.Manuflabel.TabIndex = 3;
            this.Manuflabel.Text = "Manufacturer:";
            // 
            // ManuftextBox
            // 
            this.ManuftextBox.Location = new System.Drawing.Point(121, 30);
            this.ManuftextBox.Name = "ManuftextBox";
            this.ManuftextBox.Size = new System.Drawing.Size(211, 20);
            this.ManuftextBox.TabIndex = 4;
            // 
            // Modellabel
            // 
            this.Modellabel.AutoSize = true;
            this.Modellabel.Location = new System.Drawing.Point(11, 133);
            this.Modellabel.Name = "Modellabel";
            this.Modellabel.Size = new System.Drawing.Size(92, 13);
            this.Modellabel.TabIndex = 5;
            this.Modellabel.Text = "Model/Decription:";
            // 
            // CatalogNumberlabel
            // 
            this.CatalogNumberlabel.AutoSize = true;
            this.CatalogNumberlabel.Location = new System.Drawing.Point(11, 67);
            this.CatalogNumberlabel.Name = "CatalogNumberlabel";
            this.CatalogNumberlabel.Size = new System.Drawing.Size(86, 13);
            this.CatalogNumberlabel.TabIndex = 6;
            this.CatalogNumberlabel.Text = "Catalog Number:";
            // 
            // CatalogNumbertextBox
            // 
            this.CatalogNumbertextBox.Location = new System.Drawing.Point(121, 64);
            this.CatalogNumbertextBox.Name = "CatalogNumbertextBox";
            this.CatalogNumbertextBox.Size = new System.Drawing.Size(211, 20);
            this.CatalogNumbertextBox.TabIndex = 7;
            // 
            // ModeltextBox
            // 
            this.ModeltextBox.Location = new System.Drawing.Point(121, 130);
            this.ModeltextBox.Name = "ModeltextBox";
            this.ModeltextBox.Size = new System.Drawing.Size(211, 20);
            this.ModeltextBox.TabIndex = 8;
            // 
            // HeaderGroupBox
            // 
            this.HeaderGroupBox.Controls.Add(this.label1);
            this.HeaderGroupBox.Controls.Add(this.GTINtextBox);
            this.HeaderGroupBox.Controls.Add(this.MoreInfoURITextBox);
            this.HeaderGroupBox.Controls.Add(this.MoreInfoURILabel);
            this.HeaderGroupBox.Controls.Add(this.ReferenceTextBox);
            this.HeaderGroupBox.Controls.Add(this.ReferenceLabel);
            this.HeaderGroupBox.Controls.Add(this.CommentTextBox);
            this.HeaderGroupBox.Controls.Add(this.CommentLabel);
            this.HeaderGroupBox.Controls.Add(this.UniqueIdentifierTextBox);
            this.HeaderGroupBox.Controls.Add(this.UniqueIdentifierLabel);
            this.HeaderGroupBox.Controls.Add(this.DocCreateDateTextBox);
            this.HeaderGroupBox.Controls.Add(this.DocCreateDateLabel);
            this.HeaderGroupBox.Controls.Add(this.DocCreatorTextBox);
            this.HeaderGroupBox.Controls.Add(this.DocCreatorLabel);
            this.HeaderGroupBox.Controls.Add(this.RepDateTextBox);
            this.HeaderGroupBox.Controls.Add(this.RepDateLabel);
            this.HeaderGroupBox.Controls.Add(this.RepNumTextBox);
            this.HeaderGroupBox.Controls.Add(this.ReportNumLbel);
            this.HeaderGroupBox.Controls.Add(this.LabTextBox);
            this.HeaderGroupBox.Controls.Add(this.LabLabel);
            this.HeaderGroupBox.Controls.Add(this.ManuftextBox);
            this.HeaderGroupBox.Controls.Add(this.ModeltextBox);
            this.HeaderGroupBox.Controls.Add(this.Manuflabel);
            this.HeaderGroupBox.Controls.Add(this.Modellabel);
            this.HeaderGroupBox.Controls.Add(this.CatalogNumberlabel);
            this.HeaderGroupBox.Controls.Add(this.CatalogNumbertextBox);
            this.HeaderGroupBox.Location = new System.Drawing.Point(23, 77);
            this.HeaderGroupBox.Name = "HeaderGroupBox";
            this.HeaderGroupBox.Size = new System.Drawing.Size(345, 495);
            this.HeaderGroupBox.TabIndex = 9;
            this.HeaderGroupBox.TabStop = false;
            this.HeaderGroupBox.Text = "Header";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "GTIN Number:";
            // 
            // GTINtextBox
            // 
            this.GTINtextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.GTINtextBox.Location = new System.Drawing.Point(121, 97);
            this.GTINtextBox.Name = "GTINtextBox";
            this.GTINtextBox.Size = new System.Drawing.Size(211, 20);
            this.GTINtextBox.TabIndex = 30;
            this.GTINtextBox.Text = "Not Assigned";
            // 
            // MoreInfoURITextBox
            // 
            this.MoreInfoURITextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.MoreInfoURITextBox.Location = new System.Drawing.Point(121, 456);
            this.MoreInfoURITextBox.Name = "MoreInfoURITextBox";
            this.MoreInfoURITextBox.Size = new System.Drawing.Size(211, 20);
            this.MoreInfoURITextBox.TabIndex = 28;
            // 
            // MoreInfoURILabel
            // 
            this.MoreInfoURILabel.AutoSize = true;
            this.MoreInfoURILabel.Location = new System.Drawing.Point(11, 459);
            this.MoreInfoURILabel.Name = "MoreInfoURILabel";
            this.MoreInfoURILabel.Size = new System.Drawing.Size(77, 13);
            this.MoreInfoURILabel.TabIndex = 27;
            this.MoreInfoURILabel.Text = "More Info URI:";
            // 
            // ReferenceTextBox
            // 
            this.ReferenceTextBox.Location = new System.Drawing.Point(121, 422);
            this.ReferenceTextBox.Name = "ReferenceTextBox";
            this.ReferenceTextBox.Size = new System.Drawing.Size(211, 20);
            this.ReferenceTextBox.TabIndex = 26;
            // 
            // ReferenceLabel
            // 
            this.ReferenceLabel.AutoSize = true;
            this.ReferenceLabel.Location = new System.Drawing.Point(11, 425);
            this.ReferenceLabel.Name = "ReferenceLabel";
            this.ReferenceLabel.Size = new System.Drawing.Size(60, 13);
            this.ReferenceLabel.TabIndex = 25;
            this.ReferenceLabel.Text = "Reference:";
            // 
            // CommentTextBox
            // 
            this.CommentTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CommentTextBox.Location = new System.Drawing.Point(90, 368);
            this.CommentTextBox.Multiline = true;
            this.CommentTextBox.Name = "CommentTextBox";
            this.CommentTextBox.Size = new System.Drawing.Size(242, 40);
            this.CommentTextBox.TabIndex = 24;
            this.CommentTextBox.Text = "lorem ipsum";
            // 
            // CommentLabel
            // 
            this.CommentLabel.AutoSize = true;
            this.CommentLabel.Location = new System.Drawing.Point(11, 371);
            this.CommentLabel.Name = "CommentLabel";
            this.CommentLabel.Size = new System.Drawing.Size(54, 13);
            this.CommentLabel.TabIndex = 23;
            this.CommentLabel.Text = "Comment:";
            // 
            // UniqueIdentifierTextBox
            // 
            this.UniqueIdentifierTextBox.Location = new System.Drawing.Point(121, 334);
            this.UniqueIdentifierTextBox.Name = "UniqueIdentifierTextBox";
            this.UniqueIdentifierTextBox.Size = new System.Drawing.Size(211, 20);
            this.UniqueIdentifierTextBox.TabIndex = 22;
            // 
            // UniqueIdentifierLabel
            // 
            this.UniqueIdentifierLabel.AutoSize = true;
            this.UniqueIdentifierLabel.Location = new System.Drawing.Point(11, 337);
            this.UniqueIdentifierLabel.Name = "UniqueIdentifierLabel";
            this.UniqueIdentifierLabel.Size = new System.Drawing.Size(87, 13);
            this.UniqueIdentifierLabel.TabIndex = 21;
            this.UniqueIdentifierLabel.Text = "Unique Identifier:";
            // 
            // DocCreateDateTextBox
            // 
            this.DocCreateDateTextBox.Location = new System.Drawing.Point(139, 300);
            this.DocCreateDateTextBox.Name = "DocCreateDateTextBox";
            this.DocCreateDateTextBox.Size = new System.Drawing.Size(193, 20);
            this.DocCreateDateTextBox.TabIndex = 18;
            // 
            // DocCreateDateLabel
            // 
            this.DocCreateDateLabel.AutoSize = true;
            this.DocCreateDateLabel.Location = new System.Drawing.Point(11, 303);
            this.DocCreateDateLabel.Name = "DocCreateDateLabel";
            this.DocCreateDateLabel.Size = new System.Drawing.Size(127, 13);
            this.DocCreateDateLabel.TabIndex = 17;
            this.DocCreateDateLabel.Text = "Document Creation Date:";
            // 
            // DocCreatorTextBox
            // 
            this.DocCreatorTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DocCreatorTextBox.Location = new System.Drawing.Point(121, 266);
            this.DocCreatorTextBox.Name = "DocCreatorTextBox";
            this.DocCreatorTextBox.Size = new System.Drawing.Size(211, 20);
            this.DocCreatorTextBox.TabIndex = 16;
            this.DocCreatorTextBox.Text = "Unknown";
            // 
            // DocCreatorLabel
            // 
            this.DocCreatorLabel.AutoSize = true;
            this.DocCreatorLabel.Location = new System.Drawing.Point(11, 269);
            this.DocCreatorLabel.Name = "DocCreatorLabel";
            this.DocCreatorLabel.Size = new System.Drawing.Size(96, 13);
            this.DocCreatorLabel.TabIndex = 15;
            this.DocCreatorLabel.Text = "Document Creator:";
            // 
            // RepDateTextBox
            // 
            this.RepDateTextBox.Location = new System.Drawing.Point(121, 232);
            this.RepDateTextBox.Name = "RepDateTextBox";
            this.RepDateTextBox.Size = new System.Drawing.Size(211, 20);
            this.RepDateTextBox.TabIndex = 14;
            // 
            // RepDateLabel
            // 
            this.RepDateLabel.AutoSize = true;
            this.RepDateLabel.Location = new System.Drawing.Point(11, 235);
            this.RepDateLabel.Name = "RepDateLabel";
            this.RepDateLabel.Size = new System.Drawing.Size(68, 13);
            this.RepDateLabel.TabIndex = 13;
            this.RepDateLabel.Text = "Report Date:";
            // 
            // RepNumTextBox
            // 
            this.RepNumTextBox.Location = new System.Drawing.Point(121, 198);
            this.RepNumTextBox.Name = "RepNumTextBox";
            this.RepNumTextBox.Size = new System.Drawing.Size(211, 20);
            this.RepNumTextBox.TabIndex = 12;
            // 
            // ReportNumLbel
            // 
            this.ReportNumLbel.AutoSize = true;
            this.ReportNumLbel.Location = new System.Drawing.Point(11, 201);
            this.ReportNumLbel.Name = "ReportNumLbel";
            this.ReportNumLbel.Size = new System.Drawing.Size(82, 13);
            this.ReportNumLbel.TabIndex = 11;
            this.ReportNumLbel.Text = "Report Number:";
            // 
            // LabTextBox
            // 
            this.LabTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.LabTextBox.Location = new System.Drawing.Point(121, 164);
            this.LabTextBox.Name = "LabTextBox";
            this.LabTextBox.Size = new System.Drawing.Size(211, 20);
            this.LabTextBox.TabIndex = 10;
            this.LabTextBox.Text = "Unknown";
            // 
            // LabLabel
            // 
            this.LabLabel.AutoSize = true;
            this.LabLabel.Location = new System.Drawing.Point(11, 167);
            this.LabLabel.Name = "LabLabel";
            this.LabLabel.Size = new System.Drawing.Size(60, 13);
            this.LabLabel.TabIndex = 9;
            this.LabLabel.Text = "Laboratory:";
            // 
            // LuminaireGroupBox
            // 
            this.LuminaireGroupBox.Controls.Add(this.ShapeTextBox);
            this.LuminaireGroupBox.Controls.Add(this.ShapeLabel);
            this.LuminaireGroupBox.Controls.Add(this.NLightSourceTextBox);
            this.LuminaireGroupBox.Controls.Add(this.DimGroupBox);
            this.LuminaireGroupBox.Controls.Add(this.NLightSourceLabel);
            this.LuminaireGroupBox.Location = new System.Drawing.Point(385, 77);
            this.LuminaireGroupBox.Name = "LuminaireGroupBox";
            this.LuminaireGroupBox.Size = new System.Drawing.Size(222, 205);
            this.LuminaireGroupBox.TabIndex = 10;
            this.LuminaireGroupBox.TabStop = false;
            this.LuminaireGroupBox.Text = "Luminaire";
            // 
            // ShapeTextBox
            // 
            this.ShapeTextBox.Location = new System.Drawing.Point(136, 143);
            this.ShapeTextBox.Name = "ShapeTextBox";
            this.ShapeTextBox.Size = new System.Drawing.Size(70, 20);
            this.ShapeTextBox.TabIndex = 7;
            // 
            // ShapeLabel
            // 
            this.ShapeLabel.AutoSize = true;
            this.ShapeLabel.Location = new System.Drawing.Point(25, 146);
            this.ShapeLabel.Name = "ShapeLabel";
            this.ShapeLabel.Size = new System.Drawing.Size(105, 13);
            this.ShapeLabel.TabIndex = 6;
            this.ShapeLabel.Text = "Shape (if Cylindrical):";
            // 
            // NLightSourceTextBox
            // 
            this.NLightSourceTextBox.Location = new System.Drawing.Point(153, 175);
            this.NLightSourceTextBox.Name = "NLightSourceTextBox";
            this.NLightSourceTextBox.Size = new System.Drawing.Size(53, 20);
            this.NLightSourceTextBox.TabIndex = 2;
            // 
            // DimGroupBox
            // 
            this.DimGroupBox.Controls.Add(this.HeightTextBox);
            this.DimGroupBox.Controls.Add(this.WidthTextBox);
            this.DimGroupBox.Controls.Add(this.LengthTextBox);
            this.DimGroupBox.Controls.Add(this.HeightLabel);
            this.DimGroupBox.Controls.Add(this.WidthLabel);
            this.DimGroupBox.Controls.Add(this.LengthLabel);
            this.DimGroupBox.Location = new System.Drawing.Point(17, 27);
            this.DimGroupBox.Name = "DimGroupBox";
            this.DimGroupBox.Size = new System.Drawing.Size(189, 106);
            this.DimGroupBox.TabIndex = 1;
            this.DimGroupBox.TabStop = false;
            this.DimGroupBox.Text = "Dimensions";
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new System.Drawing.Point(93, 77);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(79, 20);
            this.HeightTextBox.TabIndex = 5;
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Location = new System.Drawing.Point(93, 50);
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(79, 20);
            this.WidthTextBox.TabIndex = 4;
            // 
            // LengthTextBox
            // 
            this.LengthTextBox.Location = new System.Drawing.Point(93, 24);
            this.LengthTextBox.Name = "LengthTextBox";
            this.LengthTextBox.Size = new System.Drawing.Size(79, 20);
            this.LengthTextBox.TabIndex = 3;
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(16, 80);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(41, 13);
            this.HeightLabel.TabIndex = 2;
            this.HeightLabel.Text = "Height:";
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(16, 53);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(38, 13);
            this.WidthLabel.TabIndex = 1;
            this.WidthLabel.Text = "Width:";
            // 
            // LengthLabel
            // 
            this.LengthLabel.AutoSize = true;
            this.LengthLabel.Location = new System.Drawing.Point(16, 27);
            this.LengthLabel.Name = "LengthLabel";
            this.LengthLabel.Size = new System.Drawing.Size(43, 13);
            this.LengthLabel.TabIndex = 0;
            this.LengthLabel.Text = "Length:";
            // 
            // NLightSourceLabel
            // 
            this.NLightSourceLabel.AutoSize = true;
            this.NLightSourceLabel.Location = new System.Drawing.Point(25, 178);
            this.NLightSourceLabel.Name = "NLightSourceLabel";
            this.NLightSourceLabel.Size = new System.Drawing.Size(122, 13);
            this.NLightSourceLabel.TabIndex = 0;
            this.NLightSourceLabel.Text = "Number of Light Source:";
            // 
            // LightEmitterGroupBox
            // 
            this.LightEmitterGroupBox.Controls.Add(this.RatedLmTextBox);
            this.LightEmitterGroupBox.Controls.Add(this.RatedLmLabel);
            this.LightEmitterGroupBox.Controls.Add(this.groupBox1);
            this.LightEmitterGroupBox.Controls.Add(this.CRIGroupBox);
            this.LightEmitterGroupBox.Controls.Add(this.ColorTempGroupBox);
            this.LightEmitterGroupBox.Controls.Add(this.InputWattageTextBox);
            this.LightEmitterGroupBox.Controls.Add(this.InputWattageLabel);
            this.LightEmitterGroupBox.Controls.Add(this.LampCodeTextBox);
            this.LightEmitterGroupBox.Controls.Add(this.LampCodeLabel);
            this.LightEmitterGroupBox.Controls.Add(this.DescTextBox);
            this.LightEmitterGroupBox.Controls.Add(this.DescLabel);
            this.LightEmitterGroupBox.Controls.Add(this.QuantityTextBox);
            this.LightEmitterGroupBox.Controls.Add(this.QuantityLabel);
            this.LightEmitterGroupBox.Location = new System.Drawing.Point(624, 76);
            this.LightEmitterGroupBox.Name = "LightEmitterGroupBox";
            this.LightEmitterGroupBox.Size = new System.Drawing.Size(270, 496);
            this.LightEmitterGroupBox.TabIndex = 11;
            this.LightEmitterGroupBox.TabStop = false;
            this.LightEmitterGroupBox.Text = "Light Emitter";
            // 
            // RatedLmTextBox
            // 
            this.RatedLmTextBox.Location = new System.Drawing.Point(104, 107);
            this.RatedLmTextBox.Name = "RatedLmTextBox";
            this.RatedLmTextBox.Size = new System.Drawing.Size(145, 20);
            this.RatedLmTextBox.TabIndex = 12;
            // 
            // RatedLmLabel
            // 
            this.RatedLmLabel.AutoSize = true;
            this.RatedLmLabel.Location = new System.Drawing.Point(12, 109);
            this.RatedLmLabel.Name = "RatedLmLabel";
            this.RatedLmLabel.Size = new System.Drawing.Size(79, 13);
            this.RatedLmLabel.TabIndex = 11;
            this.RatedLmLabel.Text = "Rated Lumens:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NumberVertTextBox);
            this.groupBox1.Controls.Add(this.NumberVertLabel);
            this.groupBox1.Controls.Add(this.NumberHorzTextBox);
            this.groupBox1.Controls.Add(this.NumberHorzLabel);
            this.groupBox1.Controls.Add(this.NumMeasuredTextBox);
            this.groupBox1.Controls.Add(this.NumMeasuredLabel);
            this.groupBox1.Controls.Add(this.ASymmTextBox);
            this.groupBox1.Controls.Add(this.ASymmLabel);
            this.groupBox1.Controls.Add(this.ABSPhotomTextBox);
            this.groupBox1.Controls.Add(this.AbsolutePhotometryLabel);
            this.groupBox1.Location = new System.Drawing.Point(15, 303);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 176);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Luminous Data/Luminous Intensity";
            // 
            // NumberVertTextBox
            // 
            this.NumberVertTextBox.Location = new System.Drawing.Point(127, 142);
            this.NumberVertTextBox.Name = "NumberVertTextBox";
            this.NumberVertTextBox.Size = new System.Drawing.Size(91, 20);
            this.NumberVertTextBox.TabIndex = 15;
            // 
            // NumberVertLabel
            // 
            this.NumberVertLabel.AutoSize = true;
            this.NumberVertLabel.Location = new System.Drawing.Point(14, 145);
            this.NumberVertLabel.Name = "NumberVertLabel";
            this.NumberVertLabel.Size = new System.Drawing.Size(69, 13);
            this.NumberVertLabel.TabIndex = 14;
            this.NumberVertLabel.Text = "Number Vert:";
            // 
            // NumberHorzTextBox
            // 
            this.NumberHorzTextBox.Location = new System.Drawing.Point(127, 114);
            this.NumberHorzTextBox.Name = "NumberHorzTextBox";
            this.NumberHorzTextBox.Size = new System.Drawing.Size(91, 20);
            this.NumberHorzTextBox.TabIndex = 13;
            // 
            // NumberHorzLabel
            // 
            this.NumberHorzLabel.AutoSize = true;
            this.NumberHorzLabel.Location = new System.Drawing.Point(14, 117);
            this.NumberHorzLabel.Name = "NumberHorzLabel";
            this.NumberHorzLabel.Size = new System.Drawing.Size(72, 13);
            this.NumberHorzLabel.TabIndex = 12;
            this.NumberHorzLabel.Text = "Number Horz:";
            // 
            // NumMeasuredTextBox
            // 
            this.NumMeasuredTextBox.Location = new System.Drawing.Point(127, 88);
            this.NumMeasuredTextBox.Name = "NumMeasuredTextBox";
            this.NumMeasuredTextBox.Size = new System.Drawing.Size(91, 20);
            this.NumMeasuredTextBox.TabIndex = 11;
            // 
            // NumMeasuredLabel
            // 
            this.NumMeasuredLabel.AutoSize = true;
            this.NumMeasuredLabel.Location = new System.Drawing.Point(14, 91);
            this.NumMeasuredLabel.Name = "NumMeasuredLabel";
            this.NumMeasuredLabel.Size = new System.Drawing.Size(97, 13);
            this.NumMeasuredLabel.TabIndex = 10;
            this.NumMeasuredLabel.Text = "Number Measured:";
            // 
            // ASymmTextBox
            // 
            this.ASymmTextBox.Location = new System.Drawing.Point(127, 60);
            this.ASymmTextBox.Name = "ASymmTextBox";
            this.ASymmTextBox.Size = new System.Drawing.Size(91, 20);
            this.ASymmTextBox.TabIndex = 9;
            // 
            // ASymmLabel
            // 
            this.ASymmLabel.AutoSize = true;
            this.ASymmLabel.Location = new System.Drawing.Point(14, 63);
            this.ASymmLabel.Name = "ASymmLabel";
            this.ASymmLabel.Size = new System.Drawing.Size(94, 13);
            this.ASymmLabel.TabIndex = 8;
            this.ASymmLabel.Text = "Angular Symmetry:";
            // 
            // ABSPhotomTextBox
            // 
            this.ABSPhotomTextBox.Location = new System.Drawing.Point(127, 31);
            this.ABSPhotomTextBox.Name = "ABSPhotomTextBox";
            this.ABSPhotomTextBox.Size = new System.Drawing.Size(91, 20);
            this.ABSPhotomTextBox.TabIndex = 7;
            // 
            // AbsolutePhotometryLabel
            // 
            this.AbsolutePhotometryLabel.AutoSize = true;
            this.AbsolutePhotometryLabel.Location = new System.Drawing.Point(14, 34);
            this.AbsolutePhotometryLabel.Name = "AbsolutePhotometryLabel";
            this.AbsolutePhotometryLabel.Size = new System.Drawing.Size(107, 13);
            this.AbsolutePhotometryLabel.TabIndex = 6;
            this.AbsolutePhotometryLabel.Text = "Absolute Photometry:";
            // 
            // CRIGroupBox
            // 
            this.CRIGroupBox.Controls.Add(this.RaTextBox);
            this.CRIGroupBox.Controls.Add(this.RaLabel);
            this.CRIGroupBox.Location = new System.Drawing.Point(15, 237);
            this.CRIGroupBox.Name = "CRIGroupBox";
            this.CRIGroupBox.Size = new System.Drawing.Size(234, 53);
            this.CRIGroupBox.TabIndex = 9;
            this.CRIGroupBox.TabStop = false;
            this.CRIGroupBox.Text = "Color Rendering / CIE_CRI";
            // 
            // RaTextBox
            // 
            this.RaTextBox.Location = new System.Drawing.Point(91, 24);
            this.RaTextBox.Name = "RaTextBox";
            this.RaTextBox.Size = new System.Drawing.Size(127, 20);
            this.RaTextBox.TabIndex = 7;
            // 
            // RaLabel
            // 
            this.RaLabel.AutoSize = true;
            this.RaLabel.Location = new System.Drawing.Point(14, 27);
            this.RaLabel.Name = "RaLabel";
            this.RaLabel.Size = new System.Drawing.Size(24, 13);
            this.RaLabel.TabIndex = 6;
            this.RaLabel.Text = "Ra:";
            // 
            // ColorTempGroupBox
            // 
            this.ColorTempGroupBox.Controls.Add(this.FixedCCTTextBox);
            this.ColorTempGroupBox.Controls.Add(this.FixedCCTLabel);
            this.ColorTempGroupBox.Location = new System.Drawing.Point(15, 171);
            this.ColorTempGroupBox.Name = "ColorTempGroupBox";
            this.ColorTempGroupBox.Size = new System.Drawing.Size(234, 54);
            this.ColorTempGroupBox.TabIndex = 8;
            this.ColorTempGroupBox.TabStop = false;
            this.ColorTempGroupBox.Text = "ColorTemperature";
            // 
            // FixedCCTTextBox
            // 
            this.FixedCCTTextBox.Location = new System.Drawing.Point(91, 24);
            this.FixedCCTTextBox.Name = "FixedCCTTextBox";
            this.FixedCCTTextBox.Size = new System.Drawing.Size(127, 20);
            this.FixedCCTTextBox.TabIndex = 7;
            // 
            // FixedCCTLabel
            // 
            this.FixedCCTLabel.AutoSize = true;
            this.FixedCCTLabel.Location = new System.Drawing.Point(14, 27);
            this.FixedCCTLabel.Name = "FixedCCTLabel";
            this.FixedCCTLabel.Size = new System.Drawing.Size(59, 13);
            this.FixedCCTLabel.TabIndex = 6;
            this.FixedCCTLabel.Text = "Fixed CCT:";
            // 
            // InputWattageTextBox
            // 
            this.InputWattageTextBox.Location = new System.Drawing.Point(104, 135);
            this.InputWattageTextBox.Name = "InputWattageTextBox";
            this.InputWattageTextBox.Size = new System.Drawing.Size(145, 20);
            this.InputWattageTextBox.TabIndex = 7;
            // 
            // InputWattageLabel
            // 
            this.InputWattageLabel.AutoSize = true;
            this.InputWattageLabel.Location = new System.Drawing.Point(12, 137);
            this.InputWattageLabel.Name = "InputWattageLabel";
            this.InputWattageLabel.Size = new System.Drawing.Size(78, 13);
            this.InputWattageLabel.TabIndex = 6;
            this.InputWattageLabel.Text = "Input Wattage:";
            // 
            // LampCodeTextBox
            // 
            this.LampCodeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.LampCodeTextBox.Location = new System.Drawing.Point(104, 80);
            this.LampCodeTextBox.Name = "LampCodeTextBox";
            this.LampCodeTextBox.Size = new System.Drawing.Size(145, 20);
            this.LampCodeTextBox.TabIndex = 5;
            this.LampCodeTextBox.Text = "Unknown";
            // 
            // LampCodeLabel
            // 
            this.LampCodeLabel.AutoSize = true;
            this.LampCodeLabel.Location = new System.Drawing.Point(12, 82);
            this.LampCodeLabel.Name = "LampCodeLabel";
            this.LampCodeLabel.Size = new System.Drawing.Size(86, 13);
            this.LampCodeLabel.TabIndex = 4;
            this.LampCodeLabel.Text = "Catalog Number:";
            // 
            // DescTextBox
            // 
            this.DescTextBox.Location = new System.Drawing.Point(104, 51);
            this.DescTextBox.Name = "DescTextBox";
            this.DescTextBox.Size = new System.Drawing.Size(145, 20);
            this.DescTextBox.TabIndex = 3;
            // 
            // DescLabel
            // 
            this.DescLabel.AutoSize = true;
            this.DescLabel.Location = new System.Drawing.Point(12, 53);
            this.DescLabel.Name = "DescLabel";
            this.DescLabel.Size = new System.Drawing.Size(63, 13);
            this.DescLabel.TabIndex = 2;
            this.DescLabel.Text = "Descritpion:";
            // 
            // QuantityTextBox
            // 
            this.QuantityTextBox.Location = new System.Drawing.Point(104, 22);
            this.QuantityTextBox.Name = "QuantityTextBox";
            this.QuantityTextBox.Size = new System.Drawing.Size(145, 20);
            this.QuantityTextBox.TabIndex = 1;
            // 
            // QuantityLabel
            // 
            this.QuantityLabel.AutoSize = true;
            this.QuantityLabel.Location = new System.Drawing.Point(12, 24);
            this.QuantityLabel.Name = "QuantityLabel";
            this.QuantityLabel.Size = new System.Drawing.Size(49, 13);
            this.QuantityLabel.TabIndex = 0;
            this.QuantityLabel.Text = "Quantity:";
            // 
            // ConvertButton
            // 
            this.ConvertButton.Location = new System.Drawing.Point(624, 26);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(270, 22);
            this.ConvertButton.TabIndex = 12;
            this.ConvertButton.Text = "Convert File";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 587);
            this.Controls.Add(this.ConvertButton);
            this.Controls.Add(this.LightEmitterGroupBox);
            this.Controls.Add(this.LuminaireGroupBox);
            this.Controls.Add(this.HeaderGroupBox);
            this.Controls.Add(this.LDTlabel);
            this.Controls.Add(this.LDTtextBox);
            this.Controls.Add(this.LoadLdt);
            this.Name = "Form2";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.HeaderGroupBox.ResumeLayout(false);
            this.HeaderGroupBox.PerformLayout();
            this.LuminaireGroupBox.ResumeLayout(false);
            this.LuminaireGroupBox.PerformLayout();
            this.DimGroupBox.ResumeLayout(false);
            this.DimGroupBox.PerformLayout();
            this.LightEmitterGroupBox.ResumeLayout(false);
            this.LightEmitterGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.CRIGroupBox.ResumeLayout(false);
            this.CRIGroupBox.PerformLayout();
            this.ColorTempGroupBox.ResumeLayout(false);
            this.ColorTempGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadLdt;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.TextBox LDTtextBox;
        private System.Windows.Forms.Label LDTlabel;
        private System.Windows.Forms.TextBox ManuftextBox;
        private System.Windows.Forms.Label Manuflabel;
        private System.Windows.Forms.Label Modellabel;
        private System.Windows.Forms.TextBox ModeltextBox;
        private System.Windows.Forms.TextBox CatalogNumbertextBox;
        private System.Windows.Forms.Label CatalogNumberlabel;
        private System.Windows.Forms.GroupBox HeaderGroupBox;
        private System.Windows.Forms.GroupBox LuminaireGroupBox;
        private System.Windows.Forms.Label NLightSourceLabel;
        private System.Windows.Forms.GroupBox DimGroupBox;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.TextBox WidthTextBox;
        private System.Windows.Forms.TextBox LengthTextBox;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.Label LengthLabel;
        private System.Windows.Forms.TextBox NLightSourceTextBox;
        private System.Windows.Forms.Label LabLabel;
        private System.Windows.Forms.TextBox LabTextBox;
        private System.Windows.Forms.TextBox RepNumTextBox;
        private System.Windows.Forms.Label ReportNumLbel;
        private System.Windows.Forms.TextBox RepDateTextBox;
        private System.Windows.Forms.Label RepDateLabel;
        private System.Windows.Forms.TextBox DocCreatorTextBox;
        private System.Windows.Forms.Label DocCreatorLabel;
        private System.Windows.Forms.TextBox DocCreateDateTextBox;
        private System.Windows.Forms.Label DocCreateDateLabel;
        private System.Windows.Forms.TextBox UniqueIdentifierTextBox;
        private System.Windows.Forms.Label UniqueIdentifierLabel;
        private System.Windows.Forms.TextBox CommentTextBox;
        private System.Windows.Forms.Label CommentLabel;
        private System.Windows.Forms.TextBox ReferenceTextBox;
        private System.Windows.Forms.Label ReferenceLabel;
        private System.Windows.Forms.TextBox MoreInfoURITextBox;
        private System.Windows.Forms.Label MoreInfoURILabel;
        private System.Windows.Forms.GroupBox LightEmitterGroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox NumberVertTextBox;
        private System.Windows.Forms.Label NumberVertLabel;
        private System.Windows.Forms.TextBox NumberHorzTextBox;
        private System.Windows.Forms.Label NumberHorzLabel;
        private System.Windows.Forms.TextBox NumMeasuredTextBox;
        private System.Windows.Forms.Label NumMeasuredLabel;
        private System.Windows.Forms.TextBox ASymmTextBox;
        private System.Windows.Forms.Label ASymmLabel;
        private System.Windows.Forms.TextBox ABSPhotomTextBox;
        private System.Windows.Forms.Label AbsolutePhotometryLabel;
        private System.Windows.Forms.GroupBox CRIGroupBox;
        private System.Windows.Forms.TextBox RaTextBox;
        private System.Windows.Forms.Label RaLabel;
        private System.Windows.Forms.GroupBox ColorTempGroupBox;
        private System.Windows.Forms.TextBox FixedCCTTextBox;
        private System.Windows.Forms.Label FixedCCTLabel;
        private System.Windows.Forms.TextBox InputWattageTextBox;
        private System.Windows.Forms.Label InputWattageLabel;
        private System.Windows.Forms.TextBox LampCodeTextBox;
        private System.Windows.Forms.Label LampCodeLabel;
        private System.Windows.Forms.TextBox DescTextBox;
        private System.Windows.Forms.Label DescLabel;
        private System.Windows.Forms.TextBox QuantityTextBox;
        private System.Windows.Forms.Label QuantityLabel;
        private System.Windows.Forms.TextBox RatedLmTextBox;
        private System.Windows.Forms.Label RatedLmLabel;
        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.TextBox ShapeTextBox;
        private System.Windows.Forms.Label ShapeLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox GTINtextBox;
    }
}