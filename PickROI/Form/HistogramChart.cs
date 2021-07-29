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
    public partial class HistogramChart : Form
    {
        bool isDataExist = false;

        int[] _red = new int[256];
        int[] _green = new int[256];
        int[] _blue = new int[256];
        int[] _gray = new int[256];

        int[] _cdfRed = new int[256];
        int[] _cdfGreen = new int[256];
        int[] _cdfBlue = new int[256];
        int[] _cdfGray = new int[256];

        int _channel = 3;
        enum COLOR_CHANNEL { RGB, RED, GREEN, BLUE, GRAY };
        enum GRAPH_TYPE { PDF, CDF };

        public HistogramChart()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            HistogramGridView.DoubleBuffered(true);
            InitializeView();
        }

        public void DrawHistogram(int imageWidth, int imageHeight, Rectangle cropRect, byte[] imageArray)
        {
            if (imageArray == null) return;
            if (_red != null) _red = null;
            if (_green != null) _green = null;
            if (_blue != null) _blue = null;
            if (_gray != null) _gray = null;

            byte[] cropImage = new byte[cropRect.Width * cropRect.Height * 3];

            int index, index1;
            index = 0;
            index1 = 0;
            for (int j = cropRect.Y; j < cropRect.Y + cropRect.Height; j++)
            {
                for (int i = cropRect.X; i < cropRect.X + cropRect.Width; i++)
                {
                    index = j * imageWidth * 3 + i * 3;
                    index1 = (j - cropRect.Y) * (cropRect.Width * 3) + (i - cropRect.X) * 3;
                    cropImage[index1] = imageArray[index];
                    cropImage[index1 + 1] = imageArray[index + 1];
                    cropImage[index1 + 2] = imageArray[index + 2];
                }
            }

            int r, g, b, g0;

            _red = new int[256];
            _green = new int[256];
            _blue = new int[256];
            _gray = new int[256];

            for (int j = 0; j < cropRect.Height; j++)
            {
                for (int i = 0; i < cropRect.Width; i++)
                {
                    index = j * (cropRect.Width * _channel) + i * _channel;
                    r = cropImage[index + 2];
                    g = cropImage[index + 1];
                    b = cropImage[index];
                    g0 = (int)Math.Round(0.299 * r + 0.587 * g + 0.114 * b);
                    if (g0 < 0) g0 = 0;
                    if (g0 > 255) g0 = 255;
                    _red[r]++;
                    _green[g]++;
                    _blue[b]++;
                    _gray[g0]++;
                }
            }

            cropImage = null;

            // cdf
            CalculateCDF();


            // label            
            labelX.Text = cropRect.X.ToString("N0");
            labelY.Text = cropRect.Y.ToString("N0");
            labelWidth.Text = cropRect.Width.ToString("N0");
            labelHeight.Text = cropRect.Height.ToString("N0");
            labelTotalNumPixels.Text = (cropRect.Width * cropRect.Height).ToString("N0") + "/채널";
            labelMaxRedPixels.Text = "(" + _red.ToList().IndexOf(_red.Max()).ToString("N0") + "), " + _red.Max().ToString("N0");
            labelMaxGreenPixels.Text = "(" + _green.ToList().IndexOf(_green.Max()).ToString("N0") + "), " + _green.Max().ToString("N0");
            labelMaxBluePixels.Text = "(" + _blue.ToList().IndexOf(_blue.Max()).ToString("N0") + "), " + _blue.Max().ToString("N0");
            labelMaxGrayPixels.Text = "(" + _gray.ToList().IndexOf(_gray.Max()).ToString("N0") + "), " + _gray.Max().ToString("N0");

            switch ((GRAPH_TYPE)graphTypeComboBox.SelectedIndex)
            {
                case GRAPH_TYPE.PDF:                 
                    SetHistogramChart(_red, _green, _blue, _gray);
                    SetHistogramGrideView(_red, _green, _blue, _gray);
                    break;
                case GRAPH_TYPE.CDF:                   
                    SetHistogramChart(_cdfRed, _cdfGreen, _cdfBlue, _cdfGray);
                    SetHistogramGrideView(_cdfRed, _cdfGreen, _cdfBlue, _cdfGray);
                    break;
            }
            
            DisplayColorChannel();

            isDataExist = true;
        }


        private void CalculateCDF()
        {
            _cdfRed = new int[256];
            _cdfGreen = new int[256];
            _cdfBlue = new int[256];
            _cdfGray = new int[256];

            _cdfRed[0] = _red[0];
            _cdfGreen[0] = _green[0];
            _cdfBlue[0] = _blue[0];
            _cdfGray[0] = _gray[0];

            for (int i = 1; i < 256; i++)
            {
                _cdfRed[i] = _cdfRed[i - 1] + _red[i];
                _cdfGreen[i] = _cdfGreen[i - 1] + _green[i];
                _cdfBlue[i] = _cdfBlue[i - 1] + _blue[i];
                _cdfGray[i] = _cdfGray[i - 1] + _gray[i];
            }
        }


        private void SetHistogramChart(int[] red, int[] green, int[] blue, int[] gray)
        {
            chart1.Series["Red"].Points.Clear();
            chart1.Series["Green"].Points.Clear();
            chart1.Series["Blue"].Points.Clear();
            chart1.Series["Gray"].Points.Clear();


            for (int m = 0; m < 256; m++)
            {
                chart1.Series["Red"].Points.AddXY(m, red[m]);
                chart1.Series["Green"].Points.AddXY(m, green[m]);
                chart1.Series["Blue"].Points.AddXY(m, blue[m]);
                chart1.Series["Gray"].Points.AddXY(m, gray[m]);
            }


            int maxCount0 = Math.Max(red.Max(), green.Max());
            int maxCount1 = Math.Max(blue.Max(), gray.Max());
            int maxCount = Math.Max(maxCount0, maxCount1);
            chart1.ChartAreas[0].AxisY.Maximum = maxCount * 1.15;
        }

        public void InitializeView()
        {
            //chart
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

            //
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 260;
            chart1.ChartAreas[0].AxisX.Interval = 15;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

            // label
            labelX.Text = "-";
            labelY.Text = "-";
            labelWidth.Text = "-";
            labelHeight.Text = "-";
            labelTotalNumPixels.Text = "-";
            labelMaxRedPixels.Text = "-";
            labelMaxGreenPixels.Text = "-";
            labelMaxBluePixels.Text = "-";
            labelMaxGrayPixels.Text = "-";

            // gridview

            HistogramGridView.RowHeadersVisible = false; // 왼쪽 화살표 안보이게
            HistogramGridView.Rows.Clear();

            int index = 0;
            for (index = 0; index < 256; index++)
            {
                object[] rectData = { index, "-", "-", "-", "-" };
                HistogramGridView.Rows.Add(rectData);
            }

            HistogramGridView.Update();
        }

        private void SetHistogramGrideView(int[] red, int[] green, int[] blue, int[] gray)
        {
            int index = 0;
            for (index = 0; index < 256; index++)
            {
                HistogramGridView.Rows[index].Cells["IntensityColumn"].Value = index;
                HistogramGridView.Rows[index].Cells["RedColumn"].Value = red[index];
                HistogramGridView.Rows[index].Cells["GreenColumn"].Value = green[index];
                HistogramGridView.Rows[index].Cells["BlueColumn"].Value = blue[index];
                HistogramGridView.Rows[index].Cells["GrayColumn"].Value = gray[index];
            }

            HistogramGridView.Columns[1].DefaultCellStyle.Format = "N0";
            HistogramGridView.Columns[2].DefaultCellStyle.Format = "N0";
            HistogramGridView.Columns[3].DefaultCellStyle.Format = "N0";
            HistogramGridView.Columns[4].DefaultCellStyle.Format = "N0";


            HistogramGridView.Update();

        }

        private void HistogramChart_Load(object sender, EventArgs e)
        {
            splitContainer2.Panel1.Controls.Add(splitContainer1);
            splitContainer2.Panel2.Controls.Add(HistogramGridView);
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.SplitterDistance = this.Width - 350;
            //
            splitContainer1.Panel1.Controls.Add(chart1);
            splitContainer1.Dock = DockStyle.Fill;
            chart1.Dock = DockStyle.Fill;

            HistogramGridView.Dock = DockStyle.Fill;

            groupBoxChartInfo.Location = new Point
            {
                X = splitContainer1.Panel2.Width * 1 / 6 - groupBoxROIInfo.Width / 2,
                Y = splitContainer1.Panel2.Height / 2 - groupBoxROIInfo.Height / 2
            };


            groupBoxROIInfo.Location = new Point
            {
                X = splitContainer1.Panel2.Width / 2 - groupBoxROIInfo.Width / 2,
                Y = splitContainer1.Panel2.Height / 2 - groupBoxROIInfo.Height / 2
            };

            groupBoxPixels.Location = new Point
            {
                X = splitContainer1.Panel2.Width * 5 / 6 - groupBoxPixels.Width / 2,
                Y = splitContainer1.Panel2.Height / 2 - groupBoxPixels.Height / 2
            };


            string[] colorChData = { "RGB", "RED", "GREEN", "BLUE", "GRAY" };

            colorChComboBox.Items.AddRange(colorChData);
            colorChComboBox.SelectedIndex = 0;

            string[] graphType = { "PDF", "CDF" };
            graphTypeComboBox.Items.AddRange(graphType);
            graphTypeComboBox.SelectedIndex = 0;

            //InitializeView();
        }

        private void colorChComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (colorChComboBox.SelectedIndex >= 0)
            {
                DisplayColorChannel();
            }
        }

        private void graphTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isDataExist == false) return;

            switch ((GRAPH_TYPE)graphTypeComboBox.SelectedIndex)
            {
                case GRAPH_TYPE.PDF:
                    SetHistogramChart(_red, _green, _blue, _gray);
                    SetHistogramGrideView(_red, _green, _blue, _gray);
                    break;
                case GRAPH_TYPE.CDF:
                    SetHistogramChart(_cdfRed, _cdfGreen, _cdfBlue, _cdfGray);
                    SetHistogramGrideView(_cdfRed, _cdfGreen, _cdfBlue, _cdfGray);
                    break;
            }
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

        private void DisplayHistogramAnnotation(int xx, int[] red, int[] green, int[] blue, int[] gray)
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
                   ((TextAnnotation)chart1.Annotations["Text"]).Text = "X:" + xx + Environment.NewLine + "R:" + red[xx].ToString("N0") + Environment.NewLine + "G:" + green[xx].ToString("N0") + Environment.NewLine + "B:" + blue[xx].ToString("N0");
                    break;
                case COLOR_CHANNEL.RED:
                    chart1.Annotations["ArrowRed"].Visible = true;
                    chart1.Annotations["ArrowGreen"].Visible = false;
                    chart1.Annotations["ArrowBlue"].Visible = false;
                    chart1.Annotations["ArrowGray"].Visible = false;
                    chart1.Annotations["VA"].AnchorDataPoint = chart1.Series["Red"].Points[xx];
                    chart1.Annotations["Text"].AnchorDataPoint = chart1.Series["Red"].Points[xx];
                    ((TextAnnotation)chart1.Annotations["Text"]).Text = "X:" + xx + Environment.NewLine + "R:" + red[xx].ToString("N0");
                    break;
                case COLOR_CHANNEL.GREEN:
                    chart1.Annotations["ArrowRed"].Visible = false;
                    chart1.Annotations["ArrowGreen"].Visible = true;
                    chart1.Annotations["ArrowBlue"].Visible = false;
                    chart1.Annotations["ArrowGray"].Visible = false;
                    chart1.Annotations["VA"].AnchorDataPoint = chart1.Series["Green"].Points[xx];
                    chart1.Annotations["Text"].AnchorDataPoint = chart1.Series["Green"].Points[xx];
                    ((TextAnnotation)chart1.Annotations["Text"]).Text = "X:" + xx + Environment.NewLine + "G:" + green[xx].ToString("N0");
                    break;
                case COLOR_CHANNEL.BLUE:
                    chart1.Annotations["ArrowRed"].Visible = false;
                    chart1.Annotations["ArrowGreen"].Visible = false;
                    chart1.Annotations["ArrowBlue"].Visible = true;
                    chart1.Annotations["ArrowGray"].Visible = false;
                    chart1.Annotations["VA"].AnchorDataPoint = chart1.Series["Blue"].Points[xx];
                    chart1.Annotations["Text"].AnchorDataPoint = chart1.Series["Blue"].Points[xx];
                    ((TextAnnotation)chart1.Annotations["Text"]).Text = "X:" + xx + Environment.NewLine + "B:" + blue[xx].ToString("N0");
                    break;
                case COLOR_CHANNEL.GRAY:
                    chart1.Annotations["ArrowRed"].Visible = false;
                    chart1.Annotations["ArrowGreen"].Visible = false;
                    chart1.Annotations["ArrowBlue"].Visible = false;
                    chart1.Annotations["ArrowGray"].Visible = true;

                    chart1.Annotations["VA"].AnchorDataPoint = chart1.Series["Gray"].Points[xx];
                    chart1.Annotations["Text"].AnchorDataPoint = chart1.Series["Gray"].Points[xx];
                    ((TextAnnotation)chart1.Annotations["Text"]).Text = "X:" + xx + Environment.NewLine + "Gray:" + gray[xx].ToString("N0");
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

                if (xx >= 0 && xx <= 255 && yy >= 0 && yy <= yAxis.Maximum)
                {
                    chart1.Annotations["VA"].Visible = true;
                    chart1.Annotations["Text"].Visible = true;
                    DisplayColorChannel();

                    switch ((GRAPH_TYPE)graphTypeComboBox.SelectedIndex)
                    {
                        case GRAPH_TYPE.PDF:
                            DisplayHistogramAnnotation(xx, _red, _green, _blue, _gray);
                            break;
                        case GRAPH_TYPE.CDF:
                            DisplayHistogramAnnotation(xx, _cdfRed, _cdfGreen, _cdfBlue, _cdfGray);
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

       
    }
      
}
