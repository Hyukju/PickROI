using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PickROI
{
    public class ColorSpaceConverter
    {
        const int NUM_OF_LEVEL = 256;

        double[] _RtoY1Lookup = new double[NUM_OF_LEVEL];
        double[] _GtoY1Lookup = new double[NUM_OF_LEVEL];
        double[] _BtoY1Lookup = new double[NUM_OF_LEVEL];
        double[] _RtoCbLookup = new double[NUM_OF_LEVEL];
        double[] _GtoCbLookup = new double[NUM_OF_LEVEL];
        double[] _BtoCbLookup = new double[NUM_OF_LEVEL];
        double[] _RtoCrLookup = new double[NUM_OF_LEVEL];
        double[] _GtoCrLookup = new double[NUM_OF_LEVEL];
        double[] _BtoCrLookup = new double[NUM_OF_LEVEL];

        double[] _Y1toRLookup = new double[NUM_OF_LEVEL];
        double[] _CbtoRLookup = new double[NUM_OF_LEVEL];
        double[] _CrtoRLookup = new double[NUM_OF_LEVEL];
        double[] _Y1toGLookup = new double[NUM_OF_LEVEL];
        double[] _CbtoGLookup = new double[NUM_OF_LEVEL];
        double[] _CrtoGLookup = new double[NUM_OF_LEVEL];
        double[] _Y1toBLookup = new double[NUM_OF_LEVEL];
        double[] _CbtoBLookup = new double[NUM_OF_LEVEL];
        double[] _CrtoBLookup = new double[NUM_OF_LEVEL];

        public struct Point3b
        {
            public byte Ch1;
            public byte Ch2;
            public byte Ch3;

            public Point3b(byte ch1, byte ch2, byte ch3)
            {
                this.Ch1 = ch1;
                this.Ch2 = ch2;
                this.Ch3 = ch3;
            }
        }

        public struct Point3d
        {
            public double Ch1;
            public double Ch2;
            public double Ch3;

            public Point3d(double ch1, double ch2, double ch3)
            {
                this.Ch1 = 0;
                this.Ch2 = 0;
                this.Ch3 = 0;
            }
        }

        public Point3b Rgb2Hsv255(Color rgb)
        {
            return Rgb2Hsv255(rgb.R, rgb.G, rgb.B);
        }

        public Point3b Rgb2Hsv255(byte red, byte green, byte blue)
        {
            Point3b hsv = new Point3b();
            Point3d hsv360 = new Point3d();

            hsv360 = Rgb2Hsv(red, green, blue);

            hsv.Ch1 = (byte)(hsv360.Ch1 / 360.0 * 255.0 + 0.5);
            hsv.Ch2 = (byte)(hsv360.Ch2 * 255.0 + 0.5);
            hsv.Ch3 = (byte)(hsv360.Ch3 * 255.0 + 0.5);

            if (hsv.Ch1 < 0) hsv.Ch1 = 0;
            if (hsv.Ch1 > 255) hsv.Ch1 = 255;
            if (hsv.Ch2 < 0) hsv.Ch2 = 0;
            if (hsv.Ch2 > 255) hsv.Ch2 = 255;
            if (hsv.Ch3 < 0) hsv.Ch3 = 0;
            if (hsv.Ch3 > 255) hsv.Ch3 = 255;

            return hsv;
        }

        public Point3d Rgb2Hsv(byte red, byte green, byte blue)
        {
            Point3d hsv = new Point3d();

            double rad60 = Math.PI / 3;
            double r, g, b, h, s, v;
            double min, max;
            r = (double)red / 255.0;
            g = (double)green / 255.0;
            b = (double)blue / 255.0;

            min = Math.Min(r, Math.Min(g, b));
            max = Math.Max(r, Math.Max(g, b));

            v = max;

            if (max == min)
            {
                s = 0.0;
                h = 0.0;
            }
            else
            {
                s = (max - min) / max;

                if (r == max)
                {
                    h = ((g - b) / (max - min)) * rad60;
                }
                else if (g == max)
                {
                    h = (2.0 + (b - r) / (max - min)) * rad60;
                }
                else
                {
                    h = (4.0 + (r - g) / (max - min)) * rad60;
                }

            }


            hsv.Ch1 = (h / Math.PI * 180.0);
            if (hsv.Ch1 < 0) hsv.Ch1 = hsv.Ch1 + 360.0;
            hsv.Ch2 = s;
            hsv.Ch3 = v;

            if (hsv.Ch1 < 0.0) hsv.Ch1 = 0.0;
            if (hsv.Ch1 > 360.0) hsv.Ch1 = 360.0;

            if (hsv.Ch2 < 0.0) hsv.Ch2 = 0.0;
            if (hsv.Ch2 > 1.0) hsv.Ch2 = 1.0;

            if (hsv.Ch3 < 0.0) hsv.Ch3 = 0.0;
            if (hsv.Ch3 > 1.0) hsv.Ch3 = 1.0;

            return hsv;
        }


        public Point3b Hsv2Rgb(double h, double s, double v)
        {
            //  0<= h < 360 , 0<=s <=1, 0<=v <=1
            Point3b rgb = new Point3b();

            if (h >= 360) h = 0;

            h = h / 180.0 * Math.PI;

            double rad60 = Math.PI / 3;

            double r, g, b, hi, hf;

            r = 0;
            g = 0;
            b = 0;
            hi = 0;
            hf = 0;

            if (s == 0)
            {
                r = v;
                g = v;
                b = v;
            }
            else
            {
                hi = Math.Floor(h / rad60);
                hf = h / rad60 - hi;

                if (hi == 0)
                {
                    r = v;
                    g = v * (1 - (s * (1 - hf)));
                    b = v * (1 - s);
                }
                else if (hi == 1)
                {
                    r = v * (1 - (s * hf));
                    g = v;
                    b = v * (1 - s);
                }
                else if (hi == 2)
                {
                    r = v * (1 - s);
                    g = v;
                    b = v * (1 - (s * (1 - hf)));
                }
                else if (hi == 3)
                {
                    r = v * (1 - s);
                    g = v * (1 - (s * hf));
                    b = v;
                }
                else if (hi == 4)
                {
                    r = v * (1 - (s * (1 - hf)));
                    g = v * (1 - s);
                    b = v;
                }
                else if (hi == 5)
                {
                    r = v;
                    g = v * (1 - s);
                    b = v * (1 - (s * hf));
                }
            }


            byte rr = (byte)(r * 255 + 0.5);
            byte gg = (byte)(g * 255 + 0.5);
            byte bb = (byte)(b * 255 + 0.5);

            if (rr < 0) rr = 0;
            if (rr > 255) rr = 255;

            if (gg < 0) gg = 0;
            if (gg > 255) gg = 255;

            if (bb < 0) bb = 0;
            if (bb > 255) bb = 255;


            rgb.Ch1 = rr;
            rgb.Ch2 = gg;
            rgb.Ch3 = bb;

            return rgb;
        }

        public void LookUpTableRGBtoYCbCr()
        {
            // Y = 0.299R +0.587G +0.114B
            // Cb = 0.564(B-Y) = -0.16874R -0.33126G +0.5B	
            // Cr = 0.713(R-Y) = 0.5R -0.418688G -0.081312B	

            int i;												
                                         
            for (i = 0; i < NUM_OF_LEVEL; i++)		
            {
                _RtoY1Lookup[i] = (double)i * 0.299f;
                _GtoY1Lookup[i] = (double)i * 0.587f;
                _BtoY1Lookup[i] = (double)i * 0.114f;
            }

            for (i = 0; i < NUM_OF_LEVEL; i++)
            {
                _RtoCbLookup[i] = (double)i * -0.16874f;
                _GtoCbLookup[i] = (double)i * -0.33126f;
                _BtoCbLookup[i] = (double)i * 0.5f;
            }

            for (i = 0; i < NUM_OF_LEVEL; i++)
            {
                _RtoCrLookup[i] = (double)i * 0.5f;
                _GtoCrLookup[i] = (double)i * -0.418688f;
                _BtoCrLookup[i] = (double)i * -0.081312f;
            }

        }

        public Point3d Rgb2YCbCr(byte red, byte green, byte blue)
        {
            // 0<= y <= 1, -1<= cb <= 1, -1<= cr <= 1
            Point3d ycbcr = new Point3d();

            double ftemp;
            double y, cb, cr;
            ftemp = _BtoY1Lookup[blue] + _GtoY1Lookup[green] + _RtoY1Lookup[red];
            y = ftemp / 255.0;
            if (y < 0.0) y = 0.0;
            if (y > 1.0) y = 1.0;

            ftemp = _BtoCbLookup[blue] + _GtoCbLookup[green] + _RtoCbLookup[red];		//bgr
            cb = ftemp / 128.0;
            if (cb < -1.0) cb = -1.0;
            if (cb > 1.0) cb = 1.0;

            ftemp = _BtoCrLookup[blue] + _GtoCrLookup[green] + _RtoCrLookup[red];		//bgr
            cr = ftemp / 128.0;
            if (cr < -1.0) cr = -1.0;
            if (cr > 1.0) cr = 1.0;

            ycbcr.Ch1 = y;
            ycbcr.Ch2 = cb;
            ycbcr.Ch3 = cr;

            return ycbcr;
        }

        public Point3b Rgb2YCbCr255(byte red, byte green, byte blue)
        {
            Point3d ycbcr = new Point3d();
            Point3b ycbcr255 = new Point3b();

            // 0<= y <= 1, -1<= cb <= 1, -1<= cr <= 1
            ycbcr = Rgb2YCbCr(red, green, blue);
            
            ycbcr255.Ch1 = (byte)(ycbcr.Ch1 * 255.0 + 0.5);
            ycbcr255.Ch2 = (byte)((ycbcr.Ch2 + 1.0) / 2.0 * 255.0 + 0.5);
            ycbcr255.Ch3 = (byte)((ycbcr.Ch3 + 1.0) / 2.0 * 255.0 + 0.5);

            if (ycbcr255.Ch1 < 0) ycbcr255.Ch1 = 0;
            if (ycbcr255.Ch1 > 255) ycbcr255.Ch1 = 255;
            if (ycbcr255.Ch2 < 0) ycbcr255.Ch2 = 0;
            if (ycbcr255.Ch2 > 255) ycbcr255.Ch2 = 255;
            if (ycbcr255.Ch3 < 0) ycbcr255.Ch3 = 0;
            if (ycbcr255.Ch3 > 255) ycbcr255.Ch3 = 255;

            return ycbcr255;
        }

        public void LookUpTableYCbCrtoRGB()
        {
            int i;

            for (i = 0; i < NUM_OF_LEVEL; i++)
            {
                _Y1toRLookup[i] = (double)i * 1.0f;
                _CbtoRLookup[i] = (double)0.0;
                _CrtoRLookup[i] = (double)(i - 128) * 1.402f;	
            }

            for (i = 0; i < NUM_OF_LEVEL; i++)
            {
                _Y1toGLookup[i] = (double)i * 1.0f;
                _CbtoGLookup[i] = (double)(i - 128) * -0.344136f;		
                _CrtoGLookup[i] = (double)(i - 128) * -0.714136f;		
            }

            for (i = 0; i < NUM_OF_LEVEL; i++)
            {
                _Y1toBLookup[i] = (double)i * 1.0f;
                _CbtoBLookup[i] = (double)(i - 128) * 1.77200;			
                _CrtoBLookup[i] = 0.0;
            }

        }

        public Point3b YCbCr2Rgb(double y, double cb, double cr)
        {
            // 0<= y <= 1, -1<= cb <= 1, -1<= cr <= 1
            Point3b rgb = new Point3b();

            byte y255, cb255, cr255;

            y255 = (byte)(y * 255.0 + 0.5);
            cb255 = (byte)((cb + 1.0)/2.0 * 255.0 + 0.5);
            cr255 = (byte)((cr + 1.0)/2.0 * 255.0 + 0.5);
            rgb = YCbCr2552Rgb(y255, cb255, cr255);
          
            return rgb;
        }


        public Point3b YCbCr2552Rgb(byte y, byte cb, byte cr)
        {
            Point3b rgb = new Point3b();

            double ftemp;
            byte r, g, b;

            ftemp = _Y1toRLookup[y] + _CbtoRLookup[cb] + _CrtoRLookup[cr];			//bgr
            if (ftemp > 255) ftemp = 255;
            if (ftemp < 0) ftemp = 0;
            r = (byte)(ftemp + 0.5);

            ftemp = _Y1toGLookup[y] + _CbtoGLookup[cb] + _CrtoGLookup[cr];			//bgr
            if (ftemp > 255) ftemp = 255;
            if (ftemp < 0) ftemp = 0;
            g = (byte)(ftemp + 0.5);

            ftemp = _Y1toBLookup[y] + _CbtoBLookup[cb] + _CrtoBLookup[cr];			//bgr
            if (ftemp > 255) ftemp = 255;
            if (ftemp < 0) ftemp = 0;
            b = (byte)(ftemp + 0.5);

            rgb.Ch1 = r;
            rgb.Ch2 = g;
            rgb.Ch3 = b;

            return rgb;
        }
    }
}
