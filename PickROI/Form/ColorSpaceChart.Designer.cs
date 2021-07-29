namespace PickROI
{
    partial class ColorSpaceChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorSpaceChart));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.xLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.groupBoxChartInfo = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.plotShapeComboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lightMaxTextBox = new System.Windows.Forms.TextBox();
            this.lightMinTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.colorSpaceComboBox = new System.Windows.Forms.ComboBox();
            this.groupBoxROIInfo = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelTotalNumPixels = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxChartInfo.SuspendLayout();
            this.groupBoxROIInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.Maximum = 1D;
            chartArea1.AxisX.Minimum = -1D;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.Maximum = 1D;
            chartArea1.AxisY.Minimum = -1D;
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(12, 29);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Point";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(437, 290);
            this.chart1.TabIndex = 0;
            this.chart1.TabStop = false;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            this.chart1.MouseLeave += new System.EventHandler(this.chart1_MouseLeave);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // splitContainer1
            // 
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.xLabel);
            this.splitContainer1.Panel1.Controls.Add(this.yLabel);
            this.splitContainer1.Panel1.Controls.Add(this.chart1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxChartInfo);
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxROIInfo);
            this.splitContainer1.Size = new System.Drawing.Size(478, 781);
            this.splitContainer1.SplitterDistance = 466;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.TabStop = false;
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.xLabel.Location = new System.Drawing.Point(261, 394);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(41, 15);
            this.xLabel.TabIndex = 5;
            this.xLabel.Text = "xLabel";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.yLabel.Location = new System.Drawing.Point(261, 355);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(41, 15);
            this.yLabel.TabIndex = 4;
            this.yLabel.Text = "yLabel";
            // 
            // groupBoxChartInfo
            // 
            this.groupBoxChartInfo.Controls.Add(this.label3);
            this.groupBoxChartInfo.Controls.Add(this.plotShapeComboBox);
            this.groupBoxChartInfo.Controls.Add(this.label13);
            this.groupBoxChartInfo.Controls.Add(this.label12);
            this.groupBoxChartInfo.Controls.Add(this.lightMaxTextBox);
            this.groupBoxChartInfo.Controls.Add(this.lightMinTextBox);
            this.groupBoxChartInfo.Controls.Add(this.label10);
            this.groupBoxChartInfo.Controls.Add(this.label1);
            this.groupBoxChartInfo.Controls.Add(this.colorSpaceComboBox);
            this.groupBoxChartInfo.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBoxChartInfo.Location = new System.Drawing.Point(12, 19);
            this.groupBoxChartInfo.Name = "groupBoxChartInfo";
            this.groupBoxChartInfo.Size = new System.Drawing.Size(250, 125);
            this.groupBoxChartInfo.TabIndex = 3;
            this.groupBoxChartInfo.TabStop = false;
            this.groupBoxChartInfo.Text = "차트 정보";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(8, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "형   태:";
            // 
            // plotShapeComboBox
            // 
            this.plotShapeComboBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plotShapeComboBox.FormattingEnabled = true;
            this.plotShapeComboBox.Location = new System.Drawing.Point(60, 52);
            this.plotShapeComboBox.Name = "plotShapeComboBox";
            this.plotShapeComboBox.Size = new System.Drawing.Size(121, 23);
            this.plotShapeComboBox.TabIndex = 21;
            this.plotShapeComboBox.TabStop = false;
            this.plotShapeComboBox.SelectedIndexChanged += new System.EventHandler(this.plotShapeComboBox_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.Location = new System.Drawing.Point(174, 91);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 15);
            this.label13.TabIndex = 20;
            this.label13.Text = "%";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(112, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 15);
            this.label12.TabIndex = 19;
            this.label12.Text = "to";
            // 
            // lightMaxTextBox
            // 
            this.lightMaxTextBox.Location = new System.Drawing.Point(135, 87);
            this.lightMaxTextBox.Name = "lightMaxTextBox";
            this.lightMaxTextBox.Size = new System.Drawing.Size(34, 23);
            this.lightMaxTextBox.TabIndex = 18;
            this.lightMaxTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lightLevelTextBox_KeyPress);
            this.lightMaxTextBox.Leave += new System.EventHandler(this.lightLevelTextBox_Leave);
            // 
            // lightMinTextBox
            // 
            this.lightMinTextBox.Location = new System.Drawing.Point(73, 87);
            this.lightMinTextBox.Name = "lightMinTextBox";
            this.lightMinTextBox.Size = new System.Drawing.Size(34, 23);
            this.lightMinTextBox.TabIndex = 18;
            this.lightMinTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lightLevelTextBox_KeyPress);
            this.lightMinTextBox.Leave += new System.EventHandler(this.lightLevelTextBox_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(8, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 15);
            this.label10.TabIndex = 17;
            this.label10.Text = "Lightness:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "색공간:";
            // 
            // colorSpaceComboBox
            // 
            this.colorSpaceComboBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorSpaceComboBox.FormattingEnabled = true;
            this.colorSpaceComboBox.Location = new System.Drawing.Point(60, 16);
            this.colorSpaceComboBox.Name = "colorSpaceComboBox";
            this.colorSpaceComboBox.Size = new System.Drawing.Size(121, 23);
            this.colorSpaceComboBox.TabIndex = 2;
            this.colorSpaceComboBox.TabStop = false;
            this.colorSpaceComboBox.SelectedIndexChanged += new System.EventHandler(this.colorSpaceComboBox_SelectedIndexChanged);
            // 
            // groupBoxROIInfo
            // 
            this.groupBoxROIInfo.Controls.Add(this.label11);
            this.groupBoxROIInfo.Controls.Add(this.labelY);
            this.groupBoxROIInfo.Controls.Add(this.label9);
            this.groupBoxROIInfo.Controls.Add(this.labelX);
            this.groupBoxROIInfo.Controls.Add(this.labelHeight);
            this.groupBoxROIInfo.Controls.Add(this.label2);
            this.groupBoxROIInfo.Controls.Add(this.label8);
            this.groupBoxROIInfo.Controls.Add(this.label7);
            this.groupBoxROIInfo.Controls.Add(this.labelTotalNumPixels);
            this.groupBoxROIInfo.Controls.Add(this.labelWidth);
            this.groupBoxROIInfo.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBoxROIInfo.Location = new System.Drawing.Point(245, 139);
            this.groupBoxROIInfo.Name = "groupBoxROIInfo";
            this.groupBoxROIInfo.Size = new System.Drawing.Size(250, 125);
            this.groupBoxROIInfo.TabIndex = 4;
            this.groupBoxROIInfo.TabStop = false;
            this.groupBoxROIInfo.Text = "선택 영역 정보";
            this.groupBoxROIInfo.UseCompatibleTextRendering = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(13, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 15);
            this.label11.TabIndex = 15;
            this.label11.Text = "y:";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelY.Location = new System.Drawing.Point(35, 40);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(12, 15);
            this.labelY.TabIndex = 16;
            this.labelY.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(13, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 15);
            this.label9.TabIndex = 13;
            this.label9.Text = "x:";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX.Location = new System.Drawing.Point(35, 19);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(12, 15);
            this.labelX.TabIndex = 14;
            this.labelX.Text = "-";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelHeight.Location = new System.Drawing.Point(63, 82);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(12, 15);
            this.labelHeight.TabIndex = 12;
            this.labelHeight.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(13, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "width:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(13, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "height:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(13, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "픽셀 수:";
            // 
            // labelTotalNumPixels
            // 
            this.labelTotalNumPixels.AutoSize = true;
            this.labelTotalNumPixels.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelTotalNumPixels.Location = new System.Drawing.Point(69, 103);
            this.labelTotalNumPixels.Name = "labelTotalNumPixels";
            this.labelTotalNumPixels.Size = new System.Drawing.Size(12, 15);
            this.labelTotalNumPixels.TabIndex = 10;
            this.labelTotalNumPixels.Text = "-";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelWidth.Location = new System.Drawing.Point(63, 61);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(12, 15);
            this.labelWidth.TabIndex = 10;
            this.labelWidth.Text = "-";
            // 
            // splitContainer2
            // 
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(505, 440);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.White;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Size = new System.Drawing.Size(223, 185);
            this.splitContainer2.SplitterDistance = 92;
            this.splitContainer2.TabIndex = 5;
            this.splitContainer2.TabStop = false;
            // 
            // chart2
            // 
            chartArea2.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea2.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisX.Maximum = 100D;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Location = new System.Drawing.Point(291, 134);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series2.Name = "Point";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(437, 290);
            this.chart2.TabIndex = 6;
            this.chart2.TabStop = false;
            this.chart2.Text = "chart2";
            // 
            // ColorSpaceChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 781);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ColorSpaceChart";
            this.Text = "색분포 차트";
            this.Load += new System.EventHandler(this.ColorSpaceChart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxChartInfo.ResumeLayout(false);
            this.groupBoxChartInfo.PerformLayout();
            this.groupBoxROIInfo.ResumeLayout(false);
            this.groupBoxROIInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelTotalNumPixels;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox colorSpaceComboBox;
        private System.Windows.Forms.GroupBox groupBoxROIInfo;
        private System.Windows.Forms.GroupBox groupBoxChartInfo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox lightMaxTextBox;
        private System.Windows.Forms.TextBox lightMinTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox plotShapeComboBox;
    }
}