namespace PickROI
{
    partial class HistogramChart
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
            System.Windows.Forms.DataVisualization.Charting.VerticalLineAnnotation verticalLineAnnotation1 = new System.Windows.Forms.DataVisualization.Charting.VerticalLineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ArrowAnnotation arrowAnnotation1 = new System.Windows.Forms.DataVisualization.Charting.ArrowAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ArrowAnnotation arrowAnnotation2 = new System.Windows.Forms.DataVisualization.Charting.ArrowAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ArrowAnnotation arrowAnnotation3 = new System.Windows.Forms.DataVisualization.Charting.ArrowAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ArrowAnnotation arrowAnnotation4 = new System.Windows.Forms.DataVisualization.Charting.ArrowAnnotation();
            System.Windows.Forms.DataVisualization.Charting.TextAnnotation textAnnotation1 = new System.Windows.Forms.DataVisualization.Charting.TextAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistogramChart));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.HistogramGridView = new System.Windows.Forms.DataGridView();
            this.IntensityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GreenColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BlueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxChartInfo = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.graphTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.colorChComboBox = new System.Windows.Forms.ComboBox();
            this.groupBoxPixels = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelMaxGrayPixels = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelMaxBluePixels = new System.Windows.Forms.Label();
            this.labelMaxRedPixels = new System.Windows.Forms.Label();
            this.labelMaxGreenPixels = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HistogramGridView)).BeginInit();
            this.groupBoxChartInfo.SuspendLayout();
            this.groupBoxPixels.SuspendLayout();
            this.groupBoxROIInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            verticalLineAnnotation1.ClipToChartArea = "ChartArea1";
            verticalLineAnnotation1.IsInfinitive = true;
            verticalLineAnnotation1.LineColor = System.Drawing.Color.OrangeRed;
            verticalLineAnnotation1.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            verticalLineAnnotation1.Name = "VA";
            arrowAnnotation1.ArrowSize = 3;
            arrowAnnotation1.BackColor = System.Drawing.Color.Transparent;
            arrowAnnotation1.ForeColor = System.Drawing.Color.Transparent;
            arrowAnnotation1.LineColor = System.Drawing.Color.Red;
            arrowAnnotation1.Name = "ArrowRed";
            arrowAnnotation2.ArrowSize = 3;
            arrowAnnotation2.BackColor = System.Drawing.Color.Transparent;
            arrowAnnotation2.ForeColor = System.Drawing.Color.Transparent;
            arrowAnnotation2.LineColor = System.Drawing.Color.Green;
            arrowAnnotation2.Name = "ArrowGreen";
            arrowAnnotation3.ArrowSize = 3;
            arrowAnnotation3.BackColor = System.Drawing.Color.Transparent;
            arrowAnnotation3.ForeColor = System.Drawing.Color.Transparent;
            arrowAnnotation3.LineColor = System.Drawing.Color.Blue;
            arrowAnnotation3.Name = "ArrowBlue";
            arrowAnnotation4.ArrowSize = 3;
            arrowAnnotation4.BackColor = System.Drawing.Color.Transparent;
            arrowAnnotation4.ForeColor = System.Drawing.Color.Transparent;
            arrowAnnotation4.Name = "ArrowGray";
            textAnnotation1.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            textAnnotation1.AnchorAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            textAnnotation1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textAnnotation1.Name = "Text";
            textAnnotation1.Text = "TextAnnotation1";
            this.chart1.Annotations.Add(verticalLineAnnotation1);
            this.chart1.Annotations.Add(arrowAnnotation1);
            this.chart1.Annotations.Add(arrowAnnotation2);
            this.chart1.Annotations.Add(arrowAnnotation3);
            this.chart1.Annotations.Add(arrowAnnotation4);
            this.chart1.Annotations.Add(textAnnotation1);
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.Maximum = 255D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 29);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series1.Legend = "Legend1";
            series1.Name = "Red";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series2.Legend = "Legend1";
            series2.Name = "Green";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series3.Legend = "Legend1";
            series3.Name = "Blue";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series4.Legend = "Legend1";
            series4.Name = "Gray";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(437, 290);
            this.chart1.TabIndex = 0;
            this.chart1.TabStop = false;
            this.chart1.Text = "chart1";
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
            this.splitContainer1.Panel1.Controls.Add(this.HistogramGridView);
            this.splitContainer1.Panel1.Controls.Add(this.chart1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxChartInfo);
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxPixels);
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxROIInfo);
            this.splitContainer1.Size = new System.Drawing.Size(684, 647);
            this.splitContainer1.SplitterDistance = 498;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.TabStop = false;
            // 
            // HistogramGridView
            // 
            this.HistogramGridView.AllowUserToAddRows = false;
            this.HistogramGridView.AllowUserToDeleteRows = false;
            this.HistogramGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.HistogramGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.HistogramGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.HistogramGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HistogramGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IntensityColumn,
            this.RedColumn,
            this.GreenColumn,
            this.BlueColumn,
            this.GrayColumn});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.HistogramGridView.DefaultCellStyle = dataGridViewCellStyle7;
            this.HistogramGridView.Location = new System.Drawing.Point(397, 237);
            this.HistogramGridView.Name = "HistogramGridView";
            this.HistogramGridView.ReadOnly = true;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.HistogramGridView.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.HistogramGridView.RowTemplate.Height = 23;
            this.HistogramGridView.Size = new System.Drawing.Size(240, 150);
            this.HistogramGridView.TabIndex = 3;
            // 
            // IntensityColumn
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IntensityColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.IntensityColumn.HeaderText = "밝기";
            this.IntensityColumn.Name = "IntensityColumn";
            this.IntensityColumn.ReadOnly = true;
            // 
            // RedColumn
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RedColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.RedColumn.HeaderText = "Red";
            this.RedColumn.Name = "RedColumn";
            this.RedColumn.ReadOnly = true;
            this.RedColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // GreenColumn
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GreenColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.GreenColumn.HeaderText = "Green";
            this.GreenColumn.Name = "GreenColumn";
            this.GreenColumn.ReadOnly = true;
            this.GreenColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BlueColumn
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlueColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.BlueColumn.HeaderText = "Blue";
            this.BlueColumn.Name = "BlueColumn";
            this.BlueColumn.ReadOnly = true;
            this.BlueColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // GrayColumn
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrayColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.GrayColumn.HeaderText = "Gray";
            this.GrayColumn.Name = "GrayColumn";
            this.GrayColumn.ReadOnly = true;
            this.GrayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // groupBoxChartInfo
            // 
            this.groupBoxChartInfo.Controls.Add(this.label10);
            this.groupBoxChartInfo.Controls.Add(this.graphTypeComboBox);
            this.groupBoxChartInfo.Controls.Add(this.label1);
            this.groupBoxChartInfo.Controls.Add(this.colorChComboBox);
            this.groupBoxChartInfo.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBoxChartInfo.Location = new System.Drawing.Point(12, 16);
            this.groupBoxChartInfo.Name = "groupBoxChartInfo";
            this.groupBoxChartInfo.Size = new System.Drawing.Size(200, 125);
            this.groupBoxChartInfo.TabIndex = 3;
            this.groupBoxChartInfo.TabStop = false;
            this.groupBoxChartInfo.Text = "차트 정보";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(6, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 15);
            this.label10.TabIndex = 6;
            this.label10.Text = "형태:";
            // 
            // graphTypeComboBox
            // 
            this.graphTypeComboBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphTypeComboBox.FormattingEnabled = true;
            this.graphTypeComboBox.Location = new System.Drawing.Point(46, 58);
            this.graphTypeComboBox.Name = "graphTypeComboBox";
            this.graphTypeComboBox.Size = new System.Drawing.Size(121, 23);
            this.graphTypeComboBox.TabIndex = 5;
            this.graphTypeComboBox.TabStop = false;
            this.graphTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.graphTypeComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "채널:";
            // 
            // colorChComboBox
            // 
            this.colorChComboBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorChComboBox.FormattingEnabled = true;
            this.colorChComboBox.Location = new System.Drawing.Point(46, 23);
            this.colorChComboBox.Name = "colorChComboBox";
            this.colorChComboBox.Size = new System.Drawing.Size(121, 23);
            this.colorChComboBox.TabIndex = 2;
            this.colorChComboBox.TabStop = false;
            this.colorChComboBox.SelectedIndexChanged += new System.EventHandler(this.colorChComboBox_SelectedIndexChanged);
            // 
            // groupBoxPixels
            // 
            this.groupBoxPixels.Controls.Add(this.label3);
            this.groupBoxPixels.Controls.Add(this.label4);
            this.groupBoxPixels.Controls.Add(this.label5);
            this.groupBoxPixels.Controls.Add(this.labelMaxGrayPixels);
            this.groupBoxPixels.Controls.Add(this.label6);
            this.groupBoxPixels.Controls.Add(this.labelMaxBluePixels);
            this.groupBoxPixels.Controls.Add(this.labelMaxRedPixels);
            this.groupBoxPixels.Controls.Add(this.labelMaxGreenPixels);
            this.groupBoxPixels.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBoxPixels.Location = new System.Drawing.Point(475, 16);
            this.groupBoxPixels.Name = "groupBoxPixels";
            this.groupBoxPixels.Size = new System.Drawing.Size(200, 125);
            this.groupBoxPixels.TabIndex = 3;
            this.groupBoxPixels.TabStop = false;
            this.groupBoxPixels.Text = "최대 픽셀 수(PDF)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(14, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Red:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(14, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Green:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(14, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Blue:";
            // 
            // labelMaxGrayPixels
            // 
            this.labelMaxGrayPixels.AutoSize = true;
            this.labelMaxGrayPixels.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelMaxGrayPixels.Location = new System.Drawing.Point(59, 97);
            this.labelMaxGrayPixels.Name = "labelMaxGrayPixels";
            this.labelMaxGrayPixels.Size = new System.Drawing.Size(12, 15);
            this.labelMaxGrayPixels.TabIndex = 10;
            this.labelMaxGrayPixels.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(14, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Gray:";
            // 
            // labelMaxBluePixels
            // 
            this.labelMaxBluePixels.AutoSize = true;
            this.labelMaxBluePixels.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelMaxBluePixels.Location = new System.Drawing.Point(59, 72);
            this.labelMaxBluePixels.Name = "labelMaxBluePixels";
            this.labelMaxBluePixels.Size = new System.Drawing.Size(12, 15);
            this.labelMaxBluePixels.TabIndex = 10;
            this.labelMaxBluePixels.Text = "-";
            // 
            // labelMaxRedPixels
            // 
            this.labelMaxRedPixels.AutoSize = true;
            this.labelMaxRedPixels.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelMaxRedPixels.Location = new System.Drawing.Point(59, 22);
            this.labelMaxRedPixels.Name = "labelMaxRedPixels";
            this.labelMaxRedPixels.Size = new System.Drawing.Size(12, 15);
            this.labelMaxRedPixels.TabIndex = 10;
            this.labelMaxRedPixels.Text = "-";
            // 
            // labelMaxGreenPixels
            // 
            this.labelMaxGreenPixels.AutoSize = true;
            this.labelMaxGreenPixels.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelMaxGreenPixels.Location = new System.Drawing.Point(59, 47);
            this.labelMaxGreenPixels.Name = "labelMaxGreenPixels";
            this.labelMaxGreenPixels.Size = new System.Drawing.Size(12, 15);
            this.labelMaxGreenPixels.TabIndex = 10;
            this.labelMaxGreenPixels.Text = "-";
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
            this.groupBoxROIInfo.Location = new System.Drawing.Point(225, 16);
            this.groupBoxROIInfo.Name = "groupBoxROIInfo";
            this.groupBoxROIInfo.Size = new System.Drawing.Size(200, 125);
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
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(757, 121);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Size = new System.Drawing.Size(150, 100);
            this.splitContainer2.SplitterDistance = 76;
            this.splitContainer2.TabIndex = 2;
            // 
            // HistogramChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 687);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HistogramChart";
            this.Text = "히스토그램 차트";
            this.Load += new System.EventHandler(this.HistogramChart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HistogramGridView)).EndInit();
            this.groupBoxChartInfo.ResumeLayout(false);
            this.groupBoxChartInfo.PerformLayout();
            this.groupBoxPixels.ResumeLayout(false);
            this.groupBoxPixels.PerformLayout();
            this.groupBoxROIInfo.ResumeLayout(false);
            this.groupBoxROIInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView HistogramGridView;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelTotalNumPixels;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox colorChComboBox;
        private System.Windows.Forms.GroupBox groupBoxPixels;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelMaxGrayPixels;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelMaxBluePixels;
        private System.Windows.Forms.Label labelMaxRedPixels;
        private System.Windows.Forms.Label labelMaxGreenPixels;
        private System.Windows.Forms.GroupBox groupBoxROIInfo;
        private System.Windows.Forms.GroupBox groupBoxChartInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntensityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GreenColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrayColumn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox graphTypeComboBox;
    }
}