using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting; // annotation

namespace PickROI
{
    public partial class LineProfile : Form
    {
        bool isDataExist = false;

        int[] _x = new int[256];
        int[] _y = new int[256];
        int[] _red = new int[256];
        int[] _green = new int[256];
        int[] _blue = new int[256];
        int[] _gray = new int[256];

        double[] _smoothRed =   new double[256];
        double[] _smoothGreen = new double[256];
        double[] _smoothBlue =  new double[256];
        double[] _smoothGray =  new double[256];

        double[] _deRed = new double[256];
        double[] _deGreen = new double[256];
        double[] _deBlue = new double[256];
        double[] _deGray = new double[256];

        int _channel = 3;
        enum COLOR_CHANNEL { RGB, RED, GREEN, BLUE, GRAY };
        enum GRAPH_TYPE { LINEAR, D1ST, D2ND };

        double _oldAxisValue;

        struct AxisRange
        {
            public double yMin;
            public double yMax;
            public double xMin;
            public double xMax;

            public AxisRange(double ymin, double ymax, double xmin, double xmax)
            {
                this.yMin = ymin;
                this.yMax = ymax;
                this.xMin = xmin;
                this.xMax = xmax;
            }
        }

        AxisRange _rangeLinear, _range1st, _range2nd;

        public LineProfile()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            LineProfileGridView.DoubleBuffered(true);
            InitializeView();
        }


        public void DrawLineProfile(Point start, Point end, int imageWidth, int imageHeight, byte[] imageArray)
        {
            if (imageArray == null) return;

            if (_x != null) _x = null;
            if (_y != null) _y = null;

            if (_red != null) _red = null;
            if (_green != null) _green = null;
            if (_blue != null) _blue = null;
            if (_gray != null) _gray = null;

            if (_deRed != null) _deRed = null;
            if (_deGreen != null) _deGreen = null;
            if (_deBlue != null) _deBlue = null;
            if (_deGray != null) _deGray = null;

            if (_smoothRed != null) _smoothRed = null;
            if (_smoothGreen != null) _smoothGreen = null;
            if (_smoothBlue != null) _smoothBlue = null;
            if (_smoothGray != null) _smoothGray = null;

            indexMinTextBox.ReadOnly = false;
            indexMaxTextBox.ReadOnly = false;
            valueMinTextBox.ReadOnly = false;
            valueMaxTextBox.ReadOnly = false;


            int width = end.X - start.X;
            int height = end.Y - start.Y;
            int max = Math.Max(Math.Abs(width), Math.Abs(height));

            _x = new int[max + 1];
            _y = new int[max + 1];

            _red = new int[max + 1];
            _green = new int[max + 1];
            _blue = new int[max + 1];
            _gray = new int[max + 1];


            _smoothRed = new double[max + 1];
            _smoothGreen = new double[max + 1];
            _smoothBlue = new double[max + 1];
            _smoothGray = new double[max + 1];

            _deRed = new double[max + 1];
            _deGreen = new double[max + 1];
            _deBlue = new double[max + 1];
            _deGray = new double[max + 1];


            float divY = (float)height / max;
            float divX = (float)width / max;

            // bgr
            for (int i = 0; i <= max; i++)
            {
                int x = (int)((float)start.X + divX * i);
                int y = (int)((float)start.Y + divY * i);

                _x[i] = x;
                _y[i] = y;

                int index = y * imageWidth * _channel + x * _channel;
                _blue[i] = imageArray[index];
                _green[i] = imageArray[index + 1];
                _red[i] = imageArray[index + 2];
                _gray[i] = (int)Math.Round(0.299 * _red[i] + 0.587 * _green[i] + 0.114 * _blue[i]);
            }

            int smoothValue = trackBar1.Value * 2 - 1;

            SetSmoothLine(_red, smoothValue, ref _smoothRed);
            SetSmoothLine(_green, smoothValue, ref _smoothGreen);
            SetSmoothLine(_blue, smoothValue, ref _smoothBlue);
            SetSmoothLine(_gray, smoothValue, ref _smoothGray);

            // label            
            startLabel.Text = "(" + start.X.ToString("N0") + ", " + start.Y.ToString("N0") + ")";
            endLabel.Text = "(" + end.X.ToString("N0") + ", " + end.Y.ToString("N0") + ")";
            lineLengthLabel.Text = Math.Sqrt((double)(end.X - start.X) * (double)(end.X - start.X) + (double)(end.Y - start.Y) * (double)(end.Y - start.Y)).ToString("N1");
            numPixelLabel.Text = max.ToString("N0");

            UpdateChart();

            DisplayColorChannel();

            isDataExist = true;
        }

        private void UpdateChart()
        {
            switch ((GRAPH_TYPE)graphTypeComboBox.SelectedIndex)
            {
                case GRAPH_TYPE.LINEAR:
                    SetLinePointsGrideView(_smoothRed, _smoothGreen, _smoothBlue, _smoothGray);
                    SetLineProfileGrideView(_x, _y, _smoothRed, _smoothGreen, _smoothBlue, _smoothGray);
                    _rangeLinear = SetChart(_smoothRed, _smoothGreen, _smoothBlue, _smoothGray);
                    break;
                case GRAPH_TYPE.D1ST:
                    CalCulate1st(_smoothRed, ref _deRed);
                    CalCulate1st(_smoothGreen, ref _deGreen);
                    CalCulate1st(_smoothBlue, ref _deBlue);
                    CalCulate1st(_smoothGray, ref _deGray);
                    SetLinePointsGrideView(_deRed, _deGreen, _deBlue, _deGray);
                    SetLineProfileGrideView(_x, _y, _deRed, _deGreen, _deBlue, _deGray);
                    _range1st = SetChart(_deRed, _deGreen, _deBlue, _deGray);

                    break;
                case GRAPH_TYPE.D2ND:
                    CalCulate2nd(_smoothRed, ref _deRed);
                    CalCulate2nd(_smoothGreen, ref _deGreen);
                    CalCulate2nd(_smoothBlue, ref _deBlue);
                    CalCulate2nd(_smoothGray, ref _deGray);
                    SetLinePointsGrideView(_deRed, _deGreen, _deBlue, _deGray);
                    SetLineProfileGrideView(_x, _y, _deRed, _deGreen, _deBlue, _deGray);
                    _range2nd = SetChart(_deRed, _deGreen, _deBlue, _deGray);
                    break;
            }

            this.Refresh();
        }

        private void SetSmoothLine(int[] line, int smoothValue, ref double[] smoothLine)
        {
            int i, m;                      

            if (smoothValue < 2)
            {
                for (i = 0; i < line.Length; i++)
                {
                    smoothLine[i] = (double)line[i];
                }
            }
            else
            {
                for (i = 0; i < line.Length; i++)
                {
                    double tmp = 0;
                    int half = smoothValue / 2;
                    int count = 0;
                    for (m = -half; m <= half; m++)
                    {
                        if (i + m >= 0 && i + m<= line.Length - 1)
                        {
                            tmp = tmp + (double)line[i + m];
                            count++;
                        }
                    }

                    tmp = (double)tmp / count;

                    smoothLine[i] = tmp;
                }
            }
            
        }

        private void SetChartAxisRange(double yMin, double yMax, double xMin, double xMax)
        {            
            chart1.ChartAreas[0].AxisY.Minimum = yMin;
            chart1.ChartAreas[0].AxisY.Maximum = yMax;
            
            chart1.ChartAreas[0].AxisY.Interval = (yMax - yMin) / 10;
            //
            chart1.ChartAreas[0].AxisX.Minimum = xMin;
            chart1.ChartAreas[0].AxisX.Maximum = xMax;
            

            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "N1";
            chart1.ChartAreas[0].AxisY.Crossing = 0;

            indexMinTextBox.Text = xMin.ToString("N1");
            indexMaxTextBox.Text = xMax.ToString("N1");
            valueMinTextBox.Text = yMin.ToString("N1");
            valueMaxTextBox.Text = yMax.ToString("N1");

            chart1.ChartAreas[0].AxisY.Crossing = 0;
            chart1.Update();
        }

       
        private AxisRange SetChart(double[] red, double[] green, double[] blue, double[] gray)
        {
            chart1.Series["Red"].Points.Clear();
            chart1.Series["Green"].Points.Clear();
            chart1.Series["Blue"].Points.Clear();
            chart1.Series["Gray"].Points.Clear();


            for (int m = 0; m < red.Length; m++)
            {
                chart1.Series["Red"].Points.AddXY(m, red[m]);
                chart1.Series["Green"].Points.AddXY(m, green[m]);
                chart1.Series["Blue"].Points.AddXY(m, blue[m]);
                chart1.Series["Gray"].Points.AddXY(m, gray[m]);
            }


            double maxCount0 = Math.Max(red.Max(), green.Max());
            double maxCount1 = Math.Max(blue.Max(), gray.Max());
            double maxCount = Math.Max(maxCount0, maxCount1);

            double minCount0 = Math.Min(red.Min(), green.Min());
            double minCount1 = Math.Min(blue.Min(), gray.Min());
            double minCount = Math.Min(minCount0, minCount1);

            if (maxCount < 0)
                maxCount = maxCount * 0.85;
            else
                maxCount = maxCount * 1.15;
            if (minCount < 0)
                minCount = minCount * 1.15;
            else
                minCount = minCount * 0.85;
                      
            if (maxCount == minCount)
            {
                maxCount += 1;
                minCount -= 1;
            }

            double xMin, xMax, yMin, yMax;

            if (!string.IsNullOrEmpty(indexMinTextBox.Text))
                xMin = Convert.ToDouble(indexMinTextBox.Text);
            else
                xMin = 0;

            if (!string.IsNullOrEmpty(indexMaxTextBox.Text))
                xMax = Convert.ToDouble(indexMaxTextBox.Text);
            else
                xMax = red.Length - 1;

            if (!string.IsNullOrEmpty(valueMinTextBox.Text))
                yMin = Convert.ToDouble(valueMinTextBox.Text);
            else
                yMin = minCount;

            if (!string.IsNullOrEmpty(valueMaxTextBox.Text))
                yMax = Convert.ToDouble(valueMaxTextBox.Text);
            else
                yMax = maxCount;
                       

            if ( !(indexRangeCheckBox.Checked) && !(valueRangeCheckBox.Checked))            
            {
                SetChartAxisRange(minCount, maxCount, 0, red.Length - 1);
            }
            else if ((indexRangeCheckBox.Checked) && !(valueRangeCheckBox.Checked))
            {
                
                SetChartAxisRange(minCount, maxCount, xMin, xMax);                
            }
            else if (!(indexRangeCheckBox.Checked) && (valueRangeCheckBox.Checked))
            {
                SetChartAxisRange(yMin, yMax, 0, red.Length - 1);
            }
            else
            {
                SetChartAxisRange(yMin, yMax, xMin, xMax);
            }
            
            AxisRange axisRange = new AxisRange(minCount, maxCount, 0, red.Length - 1);

            return axisRange;
        }

        public void InitializeView()
        {
            //chart
            isDataExist = false;

            if (_x != null) _x = null;
            if (_y != null) _y = null;

            if (_red != null) _red = null;
            if (_green != null) _green = null;
            if (_blue != null) _blue = null;
            if (_gray != null) _gray = null;

            if (_deRed != null) _deRed = null;
            if (_deGreen != null) _deGreen = null;
            if (_deBlue != null) _deBlue = null;
            if (_deGray != null) _deGray = null;

            if (_smoothRed != null) _smoothRed = null;
            if (_smoothGreen != null) _smoothGreen = null;
            if (_smoothBlue != null) _smoothBlue = null;
            if (_smoothGray != null) _smoothGray = null;


            indexRangeCheckBox.Checked = false;
            valueRangeCheckBox.Checked = false;

            chart1.Series["Red"].Points.Clear();
            chart1.Series["Green"].Points.Clear();
            chart1.Series["Blue"].Points.Clear();
            chart1.Series["Gray"].Points.Clear();

            chart1.Series["Red"].Color = Color.Red;
            chart1.Series["Green"].Color = Color.Green;
            chart1.Series["Blue"].Color = Color.Blue;
            chart1.Series["Gray"].Color = Color.DimGray;

            chart1.Series["Red"].BorderWidth = 1;
            chart1.Series["Green"].BorderWidth = 1;
            chart1.Series["Blue"].BorderWidth = 1;
            chart1.Series["Gray"].BorderWidth = 1;

          
            chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

            chart1.ChartAreas[0].AxisX.Title = "인덱스";
            chart1.ChartAreas[0].AxisY.Title = "픽셀 값";

            // label
            startLabel.Text = "-";
            endLabel.Text = "-";
            numPixelLabel.Text = "-";
            lineLengthLabel.Text = "-";

            // gridview

            LineProfileGridView.RowHeadersVisible = false; // 왼쪽 화살표 안보이게
            LineProfileGridView.Rows.Clear();

            int index = 0;
            for (index = 0; index < 100; index++)
            {
                object[] rectData = { index, "-", "-", "-", "-", "-", "-" };
                LineProfileGridView.Rows.Add(rectData);
            }

            LinePointsGridView.Rows.Clear();
            object[] r = { "Red", "-", "-", "-", "-", };
            object[] g = { "Green", "-", "-", "-", "-" };
            object[] b = { "Blue", "-", "-", "-", "-" };
            object[] g0 = { "Gray", "-", "-", "-", "-" };
            LinePointsGridView.Rows.Add(r);
            LinePointsGridView.Rows.Add(g);
            LinePointsGridView.Rows.Add(b);
            LinePointsGridView.Rows.Add(g0);

            LinePointsGridView.RowHeadersVisible = false; // 왼쪽 화살표 안보이게

            this.Refresh();

            indexMinTextBox.ReadOnly = true;
            indexMaxTextBox.ReadOnly = true;
            valueMinTextBox.ReadOnly = true;
            valueMaxTextBox.ReadOnly = true;

            indexMinTextBox.Text = ""; 
            indexMaxTextBox.Text = "";
            valueMinTextBox.Text = "";
            valueMaxTextBox.Text = "";


            _rangeLinear = new AxisRange(0,0,0,0);
            _range1st= new AxisRange(0,0,0,0);
            _range2nd = new AxisRange(0, 0, 0, 0);


                      
        }

        private void SetLinePointsGrideView(double[] red, double[] green, double[] blue, double[] gray)
        {
            LinePointsGridView.Rows.Clear();
            
            double rMax, rMin, rMean, rStd;
            CalculateLinePointsData(red, out rMax, out rMin, out rMean, out rStd);
            double gMax, gMin, gMean, gStd;
            CalculateLinePointsData(green, out gMax, out gMin, out gMean, out gStd);
            double bMax, bMin, bMean, bStd;
            CalculateLinePointsData(blue, out bMax, out bMin, out bMean, out bStd);
            double g0Max, g0Min, g0Mean, g0Std;
            CalculateLinePointsData(gray, out g0Max, out g0Min, out g0Mean, out g0Std);

            object[] r = { "Red", rMax, rMin, rMean, rStd };
            object[] g = { "Green", gMax, gMin, gMean, gStd };
            object[] b = { "Blue", bMax, bMin, bMean, bStd };
            object[] g0 = { "Gray", g0Max, g0Min, g0Mean, g0Std };
            LinePointsGridView.Rows.Add(r);
            LinePointsGridView.Rows.Add(g);
            LinePointsGridView.Rows.Add(b);
            LinePointsGridView.Rows.Add(g0);

            LinePointsGridView.Columns[1].DefaultCellStyle.Format = "N1";
            LinePointsGridView.Columns[2].DefaultCellStyle.Format = "N1";
            LinePointsGridView.Columns[3].DefaultCellStyle.Format = "N1";
            LinePointsGridView.Columns[4].DefaultCellStyle.Format = "N1";
            LinePointsGridView.Update();
        }

        private void CalculateLinePointsData(double[] line, out double max, out double min, out double mean, out double std)
        {
            max = line.Max();
            min = line.Min();
            mean = line.Average();

            if (line.Length == 1)
                std = 0;
            else
            {
                double r = 0;
                for (int index = 0; index < line.Length; index++)
                {
                    r = r + (line[index] - mean) * (line[index] - mean);
                }

                std = Math.Sqrt(r / line.Length);
            }
        }

        private void CalCulate1st(double[] line, ref double[] line1st)
        {            
            line1st[0] = 0;
            line1st[line.Length - 1] = 0;

            for (int index = 1; index < line.Length - 1; index++)
            {
                line1st[index] = -line[index - 1] + line[index + 1];
            }
        }

        private void CalCulate2nd(double[] line, ref double[] line1st)
        {
            line1st[0] = 0;
            line1st[line.Length - 1] = 0;

            for (int index = 1; index < line.Length - 1; index++)
            {
                line1st[index] = line[index - 1] - line[index] * 2 + line[index + 1];
            }
        }


        private void SetLineProfileGrideView(int[] x, int[] y, double[] red, double[] green, double[] blue, double[] gray)
        {
            LineProfileGridView.Rows.Clear();
            int index = 0;
            for (index = 0; index < red.Length; index++)
            {
                object[] rectData = { index, x[index], y[index], red[index], green[index], blue[index], gray[index] };
                LineProfileGridView.Rows.Add(rectData);
            }

            LineProfileGridView.Columns[1].DefaultCellStyle.Format = "N0";
            LineProfileGridView.Columns[2].DefaultCellStyle.Format = "N0";
            LineProfileGridView.Columns[3].DefaultCellStyle.Format = "N1";
            LineProfileGridView.Columns[4].DefaultCellStyle.Format = "N1";
            LineProfileGridView.Columns[5].DefaultCellStyle.Format = "N1";
            LineProfileGridView.Columns[6].DefaultCellStyle.Format = "N1";

            LineProfileGridView.Update();

        }


        private void LineProfile_Load(object sender, EventArgs e)
        {
            splitContainer2.Panel1.Controls.Add(splitContainer1);
            splitContainer2.Panel2.Controls.Add(LineProfileGridView);
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.SplitterDistance = this.Width - 400;
                        
            //
            splitContainer1.Panel1.Controls.Add(chart1);
            splitContainer1.Dock = DockStyle.Fill;
            chart1.Dock = DockStyle.Fill;
            splitContainer1.SplitterDistance = this.Height - 300;

            LineProfileGridView.Dock = DockStyle.Fill;

            groupBoxChartInfo.Width = splitContainer1.Panel2.Width / 2 - 10;
            groupBoxROIInfo.Width = splitContainer1.Panel2.Width / 2 - 10;

            groupBoxChartInfo.Location = new Point
            {
                X = splitContainer1.Panel2.Width * 1 / 4 - groupBoxChartInfo.Width / 2,
                Y = splitContainer1.Panel2.Height / 2 - groupBoxChartInfo.Height / 2
            };


            groupBoxROIInfo.Location = new Point
            {
                X = splitContainer1.Panel2.Width * 3 / 4 - groupBoxROIInfo.Width / 2,
                Y = splitContainer1.Panel2.Height / 2 - groupBoxROIInfo.Height / 2
            };

            LinePointsGridView.Left = groupBoxROIInfo.Width / 2 - LinePointsGridView.Width / 2;

            groupBoxROIInfo.Controls.Add(LinePointsGridView);
            //LinePointsGridView.Dock = DockStyle.Bottom;

            string[] colorChData = { "RGB", "RED", "GREEN", "BLUE", "GRAY" };

            colorChComboBox.Items.AddRange(colorChData);
            colorChComboBox.SelectedIndex = 0;

            string[] graphType = { "선형", "1차미분", "2차미분" };
            graphTypeComboBox.Items.AddRange(graphType);
            graphTypeComboBox.SelectedIndex = 0;


            //

            trackBar1.Maximum = 15;
            trackBar1.Minimum = 1;            
            tracBarTextBox.Text = trackBar1.Value.ToString();

            //InitializeView();
        }

        private void colorChComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isDataExist == false) return;

            if (colorChComboBox.SelectedIndex >= 0)
            {
                DisplayColorChannel();
            }
        }

        private void graphTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isDataExist == false) return;
                        
            UpdateChart();
        }
        
        private void DisplayColorChannel()
        {
            switch ((COLOR_CHANNEL)colorChComboBox.SelectedIndex)
            {
                case COLOR_CHANNEL.RGB:
                    chart1.Series["Red"].Enabled = true;
                    chart1.Series["Green"].Enabled = true;
                    chart1.Series["Blue"].Enabled = true;
                    chart1.Series["Gray"].Enabled = false;
                    break;
                case COLOR_CHANNEL.RED:
                    chart1.Series["Red"].Enabled = true;
                    chart1.Series["Green"].Enabled = false;
                    chart1.Series["Blue"].Enabled = false;
                    chart1.Series["Gray"].Enabled = false;
                    break;
                case COLOR_CHANNEL.GREEN:
                    chart1.Series["Red"].Enabled = false;
                    chart1.Series["Green"].Enabled = true;
                    chart1.Series["Blue"].Enabled = false;
                    chart1.Series["Gray"].Enabled = false;
                    break;
                case COLOR_CHANNEL.BLUE:
                    chart1.Series["Red"].Enabled = false;
                    chart1.Series["Green"].Enabled = false;
                    chart1.Series["Blue"].Enabled = true;
                    chart1.Series["Gray"].Enabled = false;
                    break;
                case COLOR_CHANNEL.GRAY:
                    chart1.Series["Red"].Enabled = false;
                    chart1.Series["Green"].Enabled = false;
                    chart1.Series["Blue"].Enabled = false;
                    chart1.Series["Gray"].Enabled = true;
                    break;
            }
        }

        private void DisplayAnnotation(int xx, double[] red, double[] green, double[] blue, double[] gray)
        {

            chart1.Annotations["ArrowRed"].AnchorDataPoint = chart1.Series["Red"].Points[xx];
            chart1.Annotations["ArrowGreen"].AnchorDataPoint = chart1.Series["Green"].Points[xx];
            chart1.Annotations["ArrowBlue"].AnchorDataPoint = chart1.Series["Blue"].Points[xx];
            chart1.Annotations["ArrowGray"].AnchorDataPoint = chart1.Series["Gray"].Points[xx];

            chart1.Annotations["ArrowRed"].Height = -3;
            chart1.Annotations["ArrowGreen"].Height = -3;
            chart1.Annotations["ArrowBlue"].Height = -3;
            chart1.Annotations["ArrowGray"].Height = -3;

            chart1.Annotations["ArrowRed"].Width = 0;
            chart1.Annotations["ArrowGreen"].Width = 0;
            chart1.Annotations["ArrowBlue"].Width = 0;
            chart1.Annotations["ArrowGray"].Width = 0;
                                    
            switch ((COLOR_CHANNEL)colorChComboBox.SelectedIndex)
            {
                case COLOR_CHANNEL.RGB:
                    chart1.Annotations["ArrowRed"].Visible = true;
                    chart1.Annotations["ArrowGreen"].Visible = true;
                    chart1.Annotations["ArrowBlue"].Visible = true;
                    chart1.Annotations["ArrowGray"].Visible = false;
                    chart1.Annotations["VA"].AnchorDataPoint = chart1.Series["Red"].Points[xx];
                   chart1.Annotations["Text"].AnchorDataPoint = chart1.Series["Red"].Points[xx];
                   ((TextAnnotation)chart1.Annotations["Text"]).Text = "No.:" + xx + Environment.NewLine + "R:" + red[xx].ToString("N1") + Environment.NewLine + "G:" + green[xx].ToString("N1") + Environment.NewLine + "B:" + blue[xx].ToString("N1");
                    break;
                case COLOR_CHANNEL.RED:
                    chart1.Annotations["ArrowRed"].Visible = true;
                    chart1.Annotations["ArrowGreen"].Visible = false;
                    chart1.Annotations["ArrowBlue"].Visible = false;
                    chart1.Annotations["ArrowGray"].Visible = false;
                    chart1.Annotations["VA"].AnchorDataPoint = chart1.Series["Red"].Points[xx];
                    chart1.Annotations["Text"].AnchorDataPoint = chart1.Series["Red"].Points[xx];
                    ((TextAnnotation)chart1.Annotations["Text"]).Text = "No.:" + xx + Environment.NewLine + "R:" + red[xx].ToString("N1");
                    break;
                case COLOR_CHANNEL.GREEN:
                    chart1.Annotations["ArrowRed"].Visible = false;
                    chart1.Annotations["ArrowGreen"].Visible = true;
                    chart1.Annotations["ArrowBlue"].Visible = false;
                    chart1.Annotations["ArrowGray"].Visible = false;
                    chart1.Annotations["VA"].AnchorDataPoint = chart1.Series["Green"].Points[xx];
                    chart1.Annotations["Text"].AnchorDataPoint = chart1.Series["Green"].Points[xx];
                    ((TextAnnotation)chart1.Annotations["Text"]).Text = "No.:" + xx + Environment.NewLine + "G:" + green[xx].ToString("N1");
                    break;
                case COLOR_CHANNEL.BLUE:
                    chart1.Annotations["ArrowRed"].Visible = false;
                    chart1.Annotations["ArrowGreen"].Visible = false;
                    chart1.Annotations["ArrowBlue"].Visible = true;
                    chart1.Annotations["ArrowGray"].Visible = false;
                    chart1.Annotations["VA"].AnchorDataPoint = chart1.Series["Blue"].Points[xx];
                    chart1.Annotations["Text"].AnchorDataPoint = chart1.Series["Blue"].Points[xx];
                    ((TextAnnotation)chart1.Annotations["Text"]).Text = "No.:" + xx + Environment.NewLine + "B:" + blue[xx].ToString("N1");
                    break;
                case COLOR_CHANNEL.GRAY:
                    chart1.Annotations["ArrowRed"].Visible = false;
                    chart1.Annotations["ArrowGreen"].Visible = false;
                    chart1.Annotations["ArrowBlue"].Visible = false;
                    chart1.Annotations["ArrowGray"].Visible = true;

                    chart1.Annotations["VA"].AnchorDataPoint = chart1.Series["Gray"].Points[xx];
                    chart1.Annotations["Text"].AnchorDataPoint = chart1.Series["Gray"].Points[xx];
                    ((TextAnnotation)chart1.Annotations["Text"]).Text = "No.:" + xx + Environment.NewLine + "Gray:" + gray[xx].ToString("N1");
                    break;
            }

            chart1.Annotations["Text"].Y = chart1.ChartAreas[0].AxisY.Maximum;

        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_red == null) return;

            try
            {
                var xAxis = chart1.ChartAreas[0].AxisX;
                var yAxis = chart1.ChartAreas[0].AxisY;
                double x = xAxis.PixelPositionToValue(e.Location.X);
                double y = yAxis.PixelPositionToValue(e.Location.Y);
                int xx = (int)x;
                int yy = (int)y;

                if (xx >= xAxis.Minimum && xx <= xAxis.Maximum && yy >= yAxis.Minimum && yy <= yAxis.Maximum)
                {
                    chart1.Annotations["VA"].Visible = true;
                    chart1.Annotations["Text"].Visible = true;
                    
                    switch ((GRAPH_TYPE)graphTypeComboBox.SelectedIndex)
                    {
                        case GRAPH_TYPE.LINEAR:
                            DisplayAnnotation(xx, _smoothRed, _smoothGreen, _smoothBlue, _smoothGray);
                            break;
                        case GRAPH_TYPE.D1ST:
                            DisplayAnnotation(xx, _deRed, _deGreen, _deBlue, _deGray);
                            break;
                        case GRAPH_TYPE.D2ND:
                            DisplayAnnotation(xx, _deRed, _deGreen, _deBlue, _deGray);
                            break;
                    }
                }
                else
                {
                    chart1.Annotations["VA"].Visible = false;
                    chart1.Annotations["Text"].Visible = false;
                    chart1.Annotations["ArrowRed"].Visible = false;
                    chart1.Annotations["ArrowGreen"].Visible = false;
                    chart1.Annotations["ArrowBlue"].Visible = false;
                    chart1.Annotations["ArrowGray"].Visible = false;
                }
                
            }
            catch
            {

            }
        }

        private void chart1_MouseLeave(object sender, EventArgs e)
        {
            chart1.Annotations["VA"].Visible = false;
            chart1.Annotations["Text"].Visible = false;
            chart1.Annotations["ArrowRed"].Visible = false;
            chart1.Annotations["ArrowGreen"].Visible = false;
            chart1.Annotations["ArrowBlue"].Visible = false;
            chart1.Annotations["ArrowGray"].Visible = false;
        }

        
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int smoothValue = trackBar1.Value * 2 - 1;


            tracBarTextBox.Text = smoothValue.ToString();
            tracBarTextBox.Update();
            if (!isDataExist) return;
                       
            SetSmoothLine(_red, smoothValue, ref _smoothRed);
            SetSmoothLine(_green, smoothValue, ref _smoothGreen);
            SetSmoothLine(_blue, smoothValue, ref _smoothBlue);
            SetSmoothLine(_gray, smoothValue, ref _smoothGray);

            UpdateChart();

            tracBarTextBox.Update();
        }

        private void AxisTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isDataExist) return;
                       
            
            // 숫자와 벡스페이스만 입력 받음
            TextBox box = (TextBox)sender;
                        
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '-' || e.KeyChar == '.'))
            {
                e.Handled = true;
            }

            int a = box.SelectionLength;
            int b = box.Text.Length;

            // 마이너스 박스 처음에만 가능 또는 편집 모드일 경우
            if (e.KeyChar == '-')
            {                
                if (!string.IsNullOrEmpty(box.Text))
                {
                    if ( a!=b)
                        e.Handled = true;
                }
            }

            // 콤마는 박스 중 하나만 가능
            if (e.KeyChar == '.')
            {
                if (box.Text.Contains('.'))
                    e.Handled = true;
            }

            // 엔터 입력 시 실행
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (!string.IsNullOrEmpty(box.Text) && !string.Equals(box.Text, "-"))
                {
                    ChangeChartAxisRange(box);
                }
                else
                {
                    box.Text = _oldAxisValue.ToString("N1");
                }
                
            }
        }

        private void AxisTextBox_Leave(object sender, EventArgs e)
        {
            if (!isDataExist) return;
            // tab 키 눌렀을 경우 처리  
            
            TextBox box = (TextBox)sender;

            if (!string.IsNullOrEmpty(box.Text) && !string.Equals(box.Text, "-"))
            {
                ChangeChartAxisRange(box);
            }
            else
            {
                box.Text = _oldAxisValue.ToString("N1");
            }
        }

        private void AxisTextBox_Enter(object sender, EventArgs e)
        {
            if (!isDataExist) return;

            TextBox box = (TextBox)sender;
            _oldAxisValue = Convert.ToDouble(box.Text);
        }


        private void ChangeChartAxisRange(TextBox box)
        {
            if (!isDataExist) return;

            double currentValue = Convert.ToDouble(box.Text);

            string boxName = box.Name;

            if (boxName == "xMinTextBox")
            {
                double maxValue = Convert.ToDouble(indexMaxTextBox.Text);
                if (currentValue >= maxValue)
                    box.Text = _oldAxisValue.ToString("N1");
            }
            else if (boxName == "xMaxTextBox")
            {
                double minValue = Convert.ToDouble(indexMinTextBox.Text);
                if (currentValue <= minValue)
                    box.Text = _oldAxisValue.ToString("N1");
            }
            else if (boxName == "yMaxTextBox")
            {
                double minValue = Convert.ToDouble(valueMinTextBox.Text);
                if (currentValue <= minValue)
                    box.Text = _oldAxisValue.ToString("N1");
            }
            else if (boxName == "yMinTextBox")
            {
                double maxValue = Convert.ToDouble(valueMaxTextBox.Text);
                if (currentValue >= maxValue)
                    box.Text = _oldAxisValue.ToString("N1");
            }
            
            if (!string.IsNullOrEmpty(valueMinTextBox.Text) && !string.IsNullOrEmpty(valueMaxTextBox.Text) 
                && !string.IsNullOrEmpty(indexMinTextBox.Text) && !string.IsNullOrEmpty(indexMaxTextBox.Text))
            {
                double yMin = Convert.ToDouble(valueMinTextBox.Text);
                double yMax = Convert.ToDouble(valueMaxTextBox.Text);
                double xMin = Convert.ToDouble(indexMinTextBox.Text);
                double xMax = Convert.ToDouble(indexMaxTextBox.Text);

                SetChartAxisRange(yMin, yMax, xMin, xMax);
            }
        }

        private void axisRestButton_Click(object sender, EventArgs e)
        {
            if (!isDataExist) return;

            switch ((GRAPH_TYPE)graphTypeComboBox.SelectedIndex)
            {
                case GRAPH_TYPE.LINEAR:
                    SetChartAxisRange(_rangeLinear.yMin, _rangeLinear.yMax, _rangeLinear.xMin, _rangeLinear.xMax);
                    break;
                case GRAPH_TYPE.D1ST:
                    SetChartAxisRange(_range1st.yMin, _range1st.yMax, _range1st.xMin, _range1st.xMax);

                    break;
                case GRAPH_TYPE.D2ND:
                    SetChartAxisRange(_range2nd.yMin, _range2nd.yMax, _range2nd.xMin, _range2nd.xMax);
                    break;
            }
        }
                     
    }
      
}
