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
using System.Reflection; // doublebuffer
using System.Windows.Forms.DataVisualization.Charting; // annotation

namespace PickROI
{
    public partial class ColorSpaceChart : Form
    {
        bool isDataExist = false;

        ColorSpaceConverter colorConvert = new ColorSpaceConverter();

        double[] _ch1;
        double[] _ch2;
        double[] _ch3;

        byte[] _r;
        byte[] _g;
        byte[] _b;

        double _lightMin, _lightMax;

        enum COLOR_SPACE { HSV, YCbCr };
        enum PLOT_SHAPE { MAIN, SPECTRUM };

        public ColorSpaceChart()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            InitailizeView();
        }

        public void DrawColorSpaceChart(int imageWidth, int imageHeight, Rectangle cropRect, byte[] imageArray)
        {
            if (imageArray == null)
            {
                isDataExist = false;
                return;
            }
            else
                isDataExist = true;

            if (_r != null) _r = null;
            if (_g != null) _g = null;
            if (_b != null) _b = null;

            if (_ch1 != null) _ch1 = null;
            if (_ch2 != null) _ch2 = null;
            if (_ch3 != null) _ch3 = null;

            byte[] cropImage = new byte[imageWidth * imageHeight * 3];

            _r = new byte[cropRect.Width * cropRect.Height];
            _g = new byte[cropRect.Width * cropRect.Height];
            _b = new byte[cropRect.Width * cropRect.Height];

            _ch1 = new double[cropRect.Width * cropRect.Height];
            _ch2 = new double[cropRect.Width * cropRect.Height];
            _ch3 = new double[cropRect.Width * cropRect.Height];

            int index, index1;
            index = 0;
            index1 = 0;

            int count = 0;
            for (int j = cropRect.Y; j < cropRect.Y + cropRect.Height; j++)
            {
                for (int i = cropRect.X; i < cropRect.X + cropRect.Width; i++)
                {
                    index = j * imageWidth * 3 + i * 3;
                    index1 = (j - cropRect.Y) * (cropRect.Width * 3) + (i - cropRect.X) * 3;
                    cropImage[index1] = imageArray[index];
                    cropImage[index1 + 1] = imageArray[index + 1];
                    cropImage[index1 + 2] = imageArray[index + 2];

                    _r[count] = imageArray[index + 2];
                    _g[count] = imageArray[index + 1];
                    _b[count] = imageArray[index + 0];
                    count++;
                }
            }

            cropImage = null;
            
         

            ChangeColorSpaceChart();

            // label            
            labelX.Text = cropRect.X.ToString("N0");
            labelY.Text = cropRect.Y.ToString("N0");
            labelWidth.Text = cropRect.Width.ToString("N0");
            labelHeight.Text = cropRect.Height.ToString("N0");
            labelTotalNumPixels.Text = (cropRect.Width * cropRect.Height).ToString("N0");
            
        }

        
        private void ChangeColorSpaceChart()
        {
            if (!isDataExist) return;

            COLOR_SPACE colorSpace = (COLOR_SPACE)colorSpaceComboBox.SelectedIndex;
            PLOT_SHAPE plotShape = (PLOT_SHAPE)plotShapeComboBox.SelectedIndex;

            ColorSpaceConverter.Point3d dstColor = new ColorSpaceConverter.Point3d();
          
            for (int i = 0; i < _r.Length; i++)
            {
                switch (colorSpace)
                {
                    case COLOR_SPACE.HSV:
                        dstColor = colorConvert.Rgb2Hsv(_r[i], _g[i], _b[i]);
                        break;

                    case COLOR_SPACE.YCbCr:
                        dstColor = colorConvert.Rgb2YCbCr(_r[i], _g[i], _b[i]);
                        break;
                }

                _ch1[i] = dstColor.Ch1;
                _ch2[i] = dstColor.Ch2;
                _ch3[i] = dstColor.Ch3;
            }


            switch (plotShape)
            {
                case PLOT_SHAPE.MAIN:

                    switch (colorSpace)
                    {
                        case COLOR_SPACE.HSV:
                            SetPolarChart(_ch1, _ch2, _ch3);
                            SetLightnessChart(_ch3, 100);
                            break;
                        case COLOR_SPACE.YCbCr:
                            SetCartesianChart(_ch2, _ch3, _ch1);
                            SetLightnessChart(_ch1, 100);
                            break;
                    }
                    break;

                case PLOT_SHAPE.SPECTRUM:
                    switch (colorSpace)
                    {
                        case COLOR_SPACE.HSV:
                            SetSpectrumChart(_ch1, _ch2, _ch3);
                            SetLightnessChart(_ch3, 255);
                            break;
                        case COLOR_SPACE.YCbCr:
                            SetSpectrumChart(_ch2, _ch3, _ch1);
                            SetLightnessChart(_ch1, 255);
                            break;
                    }
                    break;
            }
        }
                
        private void SetLightnessChart(double[] lightnessChannel, int lMax)
        {
            // 직교 좌표계, 데카르트 좌표계
            chart2.Series["Point"].Points.Clear();

            int[] lightnessMapp = new int[lMax + 1];

            int count = 0;
            for (int m = 0; m < lightnessChannel.Length; m++)
            {
                int lightness = (int)(Math.Round(lightnessChannel[m] * lMax));
                if (lightness < 0) lightness = 0;
                if (lightness > lMax) lightness = lMax;

                lightnessMapp[lightness]++;
                count++;
            }

            chart2.Series["Point"].Points.Clear();


            for (int m = 0; m < lMax + 1; m++)
            {
                double bin = (double)lightnessMapp[m] / (double)count * 100.0;
                chart2.Series["Point"].Points.AddXY(m, bin);
            }

            chart2.Series["Point"].Color = Color.Red;
            chart2.Series["Point"].MarkerStyle = MarkerStyle.None;
            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Maximum = lMax + 5;
            chart2.ChartAreas[0].AxisX.Interval = lMax / 10;

          
            chart2.ChartAreas[0].AxisY.Title = "frequency (%)";

            chart2.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chart2.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chart2.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart2.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;


            switch ((COLOR_SPACE)colorSpaceComboBox.SelectedIndex)
            {
                case COLOR_SPACE.HSV:
                    chart2.ChartAreas[0].AxisX.Title = "value (" + (lMax + 1).ToString() + " step)";
                    break;
                case COLOR_SPACE.YCbCr:
                    chart2.ChartAreas[0].AxisX.Title = "y (" + (lMax + 1).ToString() + " step)";
                    break;
            }


            lightnessMapp = null;
        }


        private void SetCartesianChart(double[] ch1, double[] ch2, double[] lightnessChannel)
        {
            // 직교 좌표계, 데카르트 좌표계
            chart1.Series["Point"].Points.Clear();

            chart1.ChartAreas[0].AxisX.Minimum = -1;
            chart1.ChartAreas[0].AxisX.Maximum = 1;
            chart1.ChartAreas[0].AxisX.Interval = 0.2;

            chart1.ChartAreas[0].AxisY.Minimum = -1;
            chart1.ChartAreas[0].AxisY.Maximum = 1;
            chart1.ChartAreas[0].AxisY.Interval = 0.2;


            int[] xyMap = new int[201 * 201];
            for (int m = 0; m < ch1.Length; m++)
            {
                double x = ch1[m];
                double y = ch2[m];

                int xx = (int)(x * 100) + 100;
                int yy = (int)(y * 100) + 100;

                if (xx > 200) xx = 200;
                if (xx < 0) xx = 0;
                if (yy > 200) yy = 200;
                if (yy < 0) yy = 0;

                double lightness = Math.Round(lightnessChannel[m] * 100.0);
                if (lightness < 0) lightness = 0;
                if (lightness > 100) lightness = 100;
                
                if (lightness >= _lightMin && lightness <= _lightMax)
                {
                    int index = yy * 201 + xx;
                    xyMap[index]++;
                }
                              
            }

            int count = 0;

            ColorSpaceConverter.Point3b dstRgb = new ColorSpaceConverter.Point3b();
            COLOR_SPACE colorSpace = (COLOR_SPACE)colorSpaceComboBox.SelectedIndex;

            for (int y = -100; y <= 100; y++)
            {
                for (int x = -100; x <= 100; x++)
                {
                    int index = (y + 100) * 201 + (x + 100);
                    if (xyMap[index] != 0)
                    {

                        switch (colorSpace)
                        {
                            case COLOR_SPACE.YCbCr:
                                double cb = (double)x / 100.0;
                                double cr = (double)y / 100.0;
                                dstRgb = colorConvert.YCbCr2Rgb(_lightMax / 100.0, cb, cr);
                                break;
                        }

                        chart1.Series["Point"].Points.AddXY((double)x / 100.0, (double)y / 100.0);
                        chart1.Series["Point"].Points[count].Color = Color.FromArgb(255, dstRgb.Ch1, dstRgb.Ch2, dstRgb.Ch3);
                        count++;
                    }
                }
            }

            chart1.Series["Point"].ChartType = SeriesChartType.Point;
            chart1.ChartAreas[0].AxisX.Crossing = 0;
            chart1.ChartAreas[0].AxisY.Crossing = 0;
            chart1.ChartAreas[0].AxisX.MajorTickMark.TickMarkStyle = TickMarkStyle.AcrossAxis;
            chart1.ChartAreas[0].AxisY.MajorTickMark.TickMarkStyle = TickMarkStyle.AcrossAxis;
            xLabel.Hide();
            yLabel.Hide();

            xyMap = null;

            SetChartSquare();

            switch (colorSpace)
            {
                case COLOR_SPACE.YCbCr:
                    chart1.ChartAreas[0].AxisX.Title = "cb";
                    chart1.ChartAreas[0].AxisY.Title = "cr";
                    break;
            }

        }

        private void SetSpectrumChart(double[] ch1, double[] ch2, double[] lightnessChannel)
        {           
            chart1.Series["Point"].Points.Clear();

            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 260;
            chart1.ChartAreas[0].AxisX.Interval = 20;

            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 260;
            chart1.ChartAreas[0].AxisY.Interval = 20;

            int xLength = 256;
            int yLength = 256;

            int[] xyMap = new int[xLength * yLength];

            COLOR_SPACE colorSpace = (COLOR_SPACE)colorSpaceComboBox.SelectedIndex;

            int xx, yy;

            xx = 0;
            yy = 0;

            for (int m = 0; m < ch1.Length; m++)
            {
                switch(colorSpace)
                {
                    case COLOR_SPACE.HSV:
                        xx = (int)(Math.Round(ch1[m])/360.0 * 255.0);
                        yy = (int)(Math.Round(ch2[m] * 255.0));
                        break;
                    case COLOR_SPACE.YCbCr:
                        xx = (int)(Math.Round((ch1[m] + 1.0) / 2 * 255.0));
                        yy = (int)(Math.Round((ch2[m] + 1.0) / 2 * 255.0));
                        break;
                }

                if (xx < 0) xx = 0;
                if (xx > 255) xx = 255;
                if (yy < 0) yy = 0;
                if (yy > 255) yy = 255;

                double lightness = Math.Round(lightnessChannel[m] * 100.0);
                if (lightness < 0) lightness = 0;
                if (lightness > 100) lightness = 100;

                if (lightness >= _lightMin && lightness <= _lightMax)
                {
                    int index = (int)(yy * xLength + xx);
                    xyMap[index]++;
                }
            }

            int count = 0;

            ColorSpaceConverter.Point3b dstRgb = new ColorSpaceConverter.Point3b();

            for (int y = 0; y < yLength; y++)
            {
                for (int x = 0; x < xLength; x++)
                {
                    int index = y * xLength + x;

                    if (xyMap[index] != 0)
                    {                       
                        switch (colorSpace)
                        {
                            case COLOR_SPACE.HSV:
                                double h = (double)x / 255.0 * 360.0;                      
                                double s = (double)y / 255.0;                                             
                                double v = _lightMax / 100.0;
                                dstRgb = colorConvert.Hsv2Rgb(h, s, v);                                 
                                break;
                            case COLOR_SPACE.YCbCr:

                                double y1 = _lightMax / 100.0;
                                double cb = ((double)x / 255.0 - 0.5) * 2.0;
                                double cr = ((double)y / 255.0 - 0.5) * 2.0;                                                               
                                dstRgb = colorConvert.YCbCr2Rgb(y1, cb,cr);   
                               
                                break;
                        }
                        chart1.Series["Point"].Points.AddXY(x, y);
                        chart1.Series["Point"].Points[count].Color = Color.FromArgb(255, dstRgb.Ch1, dstRgb.Ch2, dstRgb.Ch3);
                        count++;
                    }
                }
            }
                        
            chart1.Series["Point"].ChartType = SeriesChartType.Point;
            chart1.ChartAreas[0].AxisX.Crossing = 0;
            chart1.ChartAreas[0].AxisY.Crossing = 0;            
            xLabel.Hide();
            yLabel.Hide();
            chart1.ChartAreas[0].AxisX.MajorTickMark.TickMarkStyle = TickMarkStyle.OutsideArea;
            chart1.ChartAreas[0].AxisY.MajorTickMark.TickMarkStyle = TickMarkStyle.OutsideArea;


            switch (colorSpace)
            {
                case COLOR_SPACE.HSV:
                    chart1.ChartAreas[0].AxisX.Title = "hue";
                    chart1.ChartAreas[0].AxisY.Title = "saturation";
                    break;
                case COLOR_SPACE.YCbCr:
                    chart1.ChartAreas[0].AxisX.Title = "cb";
                    chart1.ChartAreas[0].AxisY.Title = "cr";
                    break;
            }
            xyMap = null;
        }


        private void SetPolarChart(double[] ch1, double[] ch2, double[] lightnessChannel)
        {
            // 극 좌표계
            chart1.Series["Point"].Points.Clear();

            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 360;
            chart1.ChartAreas[0].AxisX.Interval = 20;

            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 100;
            chart1.ChartAreas[0].AxisY.Interval = 20;


            int length = 201;
            int lMax = length - 1;
            int lMin = 0;
            int half = lMax / 2;
            
            int[] xyMap = new int[length * length];
            for (int m = 0; m < ch1.Length; m++)
            {
                double lightness = Math.Round(lightnessChannel[m] * 100.0);
                if (lightness < 0) lightness = 0;
                if (lightness > 100) lightness = 100;

                if (lightness >= _lightMin && lightness <= _lightMax)
                {

                    double rad = ch1[m] / 180.0 * Math.PI;
                    double x = Math.Cos(rad) * ch2[m];
                    double y = Math.Sin(rad) * ch2[m];

                    int xx = (int)(x * half) + half;
                    int yy = (int)(y * half) + half;

                    if (xx > lMax) xx = lMax;
                    if (xx < lMin) xx = lMin;
                    if (yy > lMax) yy = lMax;
                    if (yy < lMin) yy = lMin;

                    int index = yy * length + xx;
                    xyMap[index]++;
                }
            }

            int count = 0;

            ColorSpaceConverter.Point3b dstRgb = new ColorSpaceConverter.Point3b();

            for (int y = -half; y <= half; y++)
            {
                for (int x = -half; x <= half; x++)
                {
                    int index = (y + half) * length + (x + half);
                    if (xyMap[index] != 0)
                    {
                        double h = Math.Atan2(y, x) / Math.PI * 180.0;
                        if (h < 0) h = h + 360.0;
                        double s = Math.Sqrt(x * x + y * y) / half * 100.0;
                        double v = _lightMax / 100.0;


                        dstRgb = colorConvert.Hsv2Rgb(h, s / 100.0, v);

                        chart1.Series["Point"].Points.AddXY(h, s);
                        chart1.Series["Point"].Points[count].Color = Color.FromArgb(255, dstRgb.Ch1, dstRgb.Ch2, dstRgb.Ch3);
                        count++;
                    }
                }
            }

            chart1.Series["Point"].SetCustomProperty("PolarDrawingStyle", "Marker");
            chart1.Series["Point"].ChartType = SeriesChartType.Polar;

            chart1.ChartAreas[0].AxisX.Crossing = 90;
            chart1.ChartAreas[0].AxisY.Crossing = 0;

            xyMap = null;

            xLabel.Show();
            yLabel.Show();
            yLabel.Text = "saturation";
            xLabel.Text = "hue(°)";

            int height = splitContainer1.Panel1.Height;

            yLabel.Location = new Point(338, height / 2);
            xLabel.Location = new Point(485, height / 2 + 20);
            yLabel.BackColor = Color.Transparent;
            xLabel.BackColor = Color.Transparent;

            chart1.ChartAreas[0].AxisX.Title = "";
            chart1.ChartAreas[0].AxisY.Title = "";

            chart1.ChartAreas[0].AxisX.MajorTickMark.TickMarkStyle = TickMarkStyle.OutsideArea;
            chart1.ChartAreas[0].AxisY.MajorTickMark.TickMarkStyle = TickMarkStyle.OutsideArea;

            SetChartSquare();
        }

        private void SetChartSquare()
        {
            int chartWidth = splitContainer1.Panel1.Width;
            int chartHeight = splitContainer1.Panel1.Height;

            if (chartWidth < chartHeight)
            {
                chart1.Size = new Size(chartWidth, chartWidth);
                chart1.Location = new Point(0, chartHeight / 2 - chartWidth / 2);
            }
            else
            {
                chart1.Size = new Size(chartHeight, chartHeight);
                chart1.Location = new Point(chartWidth / 2 - chartHeight / 2, 0);
            }

            chart1.Update();
        }
               

        public void InitailizeView()
        {
            isDataExist = false;

            if (_r != null) _r = null;
            if (_g != null) _g = null;
            if (_b != null) _b = null;

            if (_ch1 != null) _ch1 = null;
            if (_ch2 != null) _ch2 = null;
            if (_ch3 != null) _ch3 = null;

            chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart1.Series["Point"].ChartType = SeriesChartType.Point;

            chart1.Series["Point"].Points.Clear();
            chart2.Series["Point"].Points.Clear();
            
            // label
            labelX.Text = "-";
            labelY.Text = "-";
            labelWidth.Text = "-";
            labelHeight.Text = "-";
            labelTotalNumPixels.Text = "-";

            //
            _lightMax = 100;
            _lightMin = 0;
            lightMaxTextBox.Text = _lightMax.ToString();
            lightMinTextBox.Text = _lightMin.ToString();

            xLabel.Hide();
            yLabel.Hide();
            
        }


        private void ColorSpaceChart_Load(object sender, EventArgs e)
        {
            // Form 크기
            this.Size = new Size(550, 900);

            splitContainer1.Panel1.Controls.Add(chart1);            
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.SplitterDistance = splitContainer1.Panel1.Width;
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer2.Dock = DockStyle.Fill;            
            splitContainer2.SplitterDistance = splitContainer1.Panel2.Height/2+20;
            splitContainer2.Panel1.Controls.Add(chart2);
            splitContainer2.Panel2.Controls.Add(groupBoxChartInfo);
            splitContainer2.Panel2.Controls.Add(groupBoxROIInfo);
            
            //
            chart1.Controls.Add(yLabel);
            chart1.Controls.Add(xLabel);
                       
            xLabel.Hide();
            yLabel.Hide();

            //
            chart1.Dock = DockStyle.Fill;
            chart2.Dock = DockStyle.Fill;

            groupBoxChartInfo.Location = new Point
            {
                X = splitContainer2.Panel2.Width / 4 - groupBoxChartInfo.Width/2,
                Y = splitContainer2.Panel2.Height / 2 - groupBoxChartInfo.Height / 2
            };


            groupBoxROIInfo.Location = new Point
            {
                X = splitContainer2.Panel2.Width * 3 / 4 - groupBoxROIInfo.Width/2,
                Y = splitContainer2.Panel2.Height / 2 - groupBoxROIInfo.Height / 2,
            };

         
            string[] colorChData = { "HSV", "YCbCr" };

            colorSpaceComboBox.Items.AddRange(colorChData);
            colorSpaceComboBox.SelectedIndex = 0;

            string[] plotShape = { "대표좌표계", "스펙트럼"};

            plotShapeComboBox.Items.AddRange(plotShape);
            plotShapeComboBox.SelectedIndex = 0;

            SetChartSquare();

            colorConvert.LookUpTableRGBtoYCbCr();
            colorConvert.LookUpTableYCbCrtoRGB();

            //InitailizeView();
        }


        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            //if (_red == null) return;

            //try
            //{
            //    var xAxis = chart1.ChartAreas[0].AxisX;
            //    var yAxis = chart1.ChartAreas[0].AxisY;
            //    double x = xAxis.PixelPositionToValue(e.Location.X);
            //    double y = yAxis.PixelPositionToValue(e.Location.Y);
            //    int xx = (int)x;
            //    int yy = (int)y;

            //    if (xx >= 0 && xx <= 255 && yy >= 0 && yy <= yAxis.Maximum)
            //    {
            //        chart1.Annotations["VA"].Visible = true;
            //        chart1.Annotations["Text"].Visible = true;
            //        DisplayColorChannel();

            //        switch ((GRAPH_TYPE)graphTypeComboBox.SelectedIndex)
            //        {
            //            case GRAPH_TYPE.PDF:
            //                DisplayHistogramAnnotation(xx, _red, _green, _blue, _gray);
            //                break;
            //            case GRAPH_TYPE.CDF:
            //                DisplayHistogramAnnotation(xx, _cdfRed, _cdfGreen, _cdfBlue, _cdfGray);
            //                break;
            //        }

            //    }
            //    else
            //    {
            //        chart1.Annotations["VA"].Visible = false;
            //        chart1.Annotations["Text"].Visible = false;
            //        chart1.Annotations["ArrowRed"].Visible = false;
            //        chart1.Annotations["ArrowGreen"].Visible = false;
            //        chart1.Annotations["ArrowBlue"].Visible = false;
            //        chart1.Annotations["ArrowGray"].Visible = false;
            //    }
            //}
            //catch
            //{

            //}
        }

        private void chart1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void colorSpaceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isDataExist) return;
                   
            ChangeColorSpaceChart();
        }

        private void lightLevelTextBox_TextChanged(object sender, EventArgs e)
        {


        }

        private void lightLevelTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isDataExist) return;
            // 숫자와 벡스페이스만 입력 받음
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }

            // 엔터 입력 시 실행
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                ChangeLightLevelValue();
            }
        }

        private void lightLevelTextBox_Leave(object sender, EventArgs e)
        {
            if (!isDataExist) return;
            // tab 키 눌렀을 경우 처리
            ChangeLightLevelValue();
        }
              
        private void ChangeLightLevelValue()
        {
            if (!isDataExist) return;

            double oldMin, oldMax;
            double min, max;

            oldMin = _lightMin;
            oldMax = _lightMax;

            if (lightMaxTextBox.TextLength > 0)
                max = Convert.ToDouble(lightMaxTextBox.Text);
            else
                max = _lightMax;

            if (lightMinTextBox.TextLength > 0)
                min = Convert.ToDouble(lightMinTextBox.Text);
            else
                min = _lightMin;

            // 값 변경이 존재 할 때만
            if (oldMin != min || oldMax != max)
            {
                if (max < 0) max = 0;
                if (max > 100) max = 100;
                if (max < _lightMin) max = _lightMin;
                if (min < 0) min = 0;
                if (min > 100) min = 100;
                if (min > _lightMax) min = _lightMax;

                _lightMax = max;
                _lightMin = min;

                // 데이터 유무 확인
                if (_ch1 != null || _ch2 != null || _ch3 != null)
                {
                    ChangeColorSpaceChart();
                }
            }

            lightMaxTextBox.Text = _lightMax.ToString();
            lightMinTextBox.Text = _lightMin.ToString();
        }

        private void plotShapeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isDataExist) return;
                
            ChangeColorSpaceChart();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            if (!isDataExist) return;

            if (chart1.ChartAreas[0].BackColor == Color.White)
                chart1.ChartAreas[0].BackColor = Color.DarkGray;
            else
                chart1.ChartAreas[0].BackColor = Color.White;
        }

    }

}
