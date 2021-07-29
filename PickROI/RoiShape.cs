using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace PickROI
{
    public class RoiShape
    {
        public enum ROI_TYPE { RECT, CIRCLE, LINE, NONE };
        public enum MOUSE_STATE { MOVE, LEFT, RIGHT, TOP, BOTTOM, LT, RT, LB, RB, NONE };

        protected ROI_TYPE _type;
        protected Rectangle _pos;
        protected int _rectSize = 11;

        public struct LinePoint
        {
            public Point Start;
            public Point End;

            public LinePoint(Point start, Point end)
            {
                Start = start;
                End = end;
            }

            public LinePoint(int x1, int y1, int x2, int y2)
            {
                Start = new Point(x1, y1);
                End = new Point(x2, y2);
            }
        }

        public RoiShape()
        {
            _type = ROI_TYPE.NONE;
            _pos = new Rectangle();
        }
               
        public ROI_TYPE Type
        {
            get { return _type; }
        }

        public Rectangle Pos
        {
            get { return _pos; }
            set { _pos = value; }
        }

        public virtual void ResizeRoi(int x, int y, Rectangle oldRoi, MOUSE_STATE state)
        {
            int left = oldRoi.Left;
            int right = oldRoi.Right;
            int top = oldRoi.Top;
            int bottom = oldRoi.Bottom;

            switch (state)
            {
                case MOUSE_STATE.LEFT:
                    left = x;
                    break;
                case MOUSE_STATE.RIGHT:
                    right = x;
                    break;
                case MOUSE_STATE.TOP:
                    top = y;
                    break;
                case MOUSE_STATE.BOTTOM:
                    bottom = y;
                    break;
                case MOUSE_STATE.LT:
                    left = x;
                    top = y;
                    break;
                case MOUSE_STATE.LB:
                    left = x;
                    bottom = y;
                    break;
                case MOUSE_STATE.RT:
                    right = x;
                    top = y;
                    break;
                case MOUSE_STATE.RB:
                    right = x;
                    bottom = y;
                    break;
            }

            _pos = ArrangeRectangle(left, top, right, bottom);
        }

        private Rectangle ArrangeRectangle(int left, int top, int right, int bottom)
        {
            int temp = 0;
            Rectangle rect;

            if (left > right)
            {
                temp = left;
                left = right;
                right = temp;
            }

            if (top > bottom)
            {
                temp = top;
                top = bottom;
                bottom = temp;
            }

            int width = right - left;
            int height = bottom - top;

            rect = new Rectangle(left, top, width, height);
            return rect;
        }

        public virtual void UpdateRoi(int x, int y, int width, int height)
        {
            Pos = new Rectangle(x, y, width, height);
        }
        
        public void MoveRoi(int dx, int dy, Rectangle oldRoi)
        {
            _pos.X = oldRoi.X + dx;
            _pos.Y = oldRoi.Y + dy;            
        }

        public virtual void DrawSelectedRoi(PointF imageOrigin, Color color, int thickness, float zoomRatio, PaintEventArgs e)
        {
            Rectangle scalePos = new Rectangle()
            {
                X = (int)Math.Round((_pos.X - imageOrigin.X - 0.5) * zoomRatio),
                Y = (int)Math.Round((_pos.Y - imageOrigin.Y - 0.5) * zoomRatio),
                Width = (int)Math.Round(_pos.Width * zoomRatio),
                Height = (int)Math.Round(_pos.Height * zoomRatio)
            };

            using (Pen red = new Pen(Color.Red))
            {
                using (SolidBrush whiteBrush = new SolidBrush(Color.White))
                {
                    float left = (float)scalePos.Left;
                    float top = (float)scalePos.Top;
                    float right = (float)scalePos.Right;
                    float bottom = (float)scalePos.Bottom;                    
                    float size = (float)_rectSize;

                    e.Graphics.FillRectangle(whiteBrush, left - size, top - size, size, size);
                    e.Graphics.FillRectangle(whiteBrush, left - size, bottom, size, size);
                    e.Graphics.FillRectangle(whiteBrush, right, top - size, size, size);
                    e.Graphics.FillRectangle(whiteBrush, right, bottom, size, size);
                    e.Graphics.FillRectangle(whiteBrush, (left + right - size) / 2.0F, top - size, size, size);
                    e.Graphics.FillRectangle(whiteBrush, (left + right - size) / 2.0F, bottom, size, size);
                    e.Graphics.FillRectangle(whiteBrush, left - size, (top + bottom - size) / 2.0F, size, size);
                    e.Graphics.FillRectangle(whiteBrush, right, (top + bottom - size) / 2.0F, size, size);
                    
                    e.Graphics.DrawRectangle(red, left - size, top - size, size, size);
                    e.Graphics.DrawRectangle(red, left - size, bottom, size, size);
                    e.Graphics.DrawRectangle(red, right, top - size, size, size);
                    e.Graphics.DrawRectangle(red, right, bottom, size, size);
                    e.Graphics.DrawRectangle(red, (left + right - size) / 2.0F, top - size, size, size);
                    e.Graphics.DrawRectangle(red, (left + right - size) / 2.0F, bottom, size, size);
                    e.Graphics.DrawRectangle(red, left - size, (top + bottom - size) / 2.0F, size, size);
                    e.Graphics.DrawRectangle(red, right, (top + bottom - size) / 2.0F, size, size);

                }

                DrawRoi(imageOrigin, color, thickness, zoomRatio, e);
            }
        }

        public virtual void DrawRoi(PointF imageOrigin, Color color, int thickness, float zoomRatio, PaintEventArgs e)
        {
            Pen p = new Pen(Color.White, thickness);
            Pen p2 = new Pen(color, thickness + 2);
            Rectangle scalePos = new Rectangle()
            {
                X = (int)Math.Round((_pos.X  - imageOrigin.X - 0.5) * zoomRatio),
                Y = (int)Math.Round((_pos.Y  - imageOrigin.Y - 0.5) * zoomRatio),
                Width = (int)Math.Round(_pos.Width * zoomRatio),
                Height = (int)Math.Round(_pos.Height * zoomRatio)
            };
                      

            switch(_type)
            {
                case ROI_TYPE.RECT:
                    e.Graphics.DrawRectangle(p2, scalePos);
                    e.Graphics.DrawRectangle(p, scalePos);
                    
                    break;
                case ROI_TYPE.CIRCLE:
                    e.Graphics.DrawRectangle(p2, scalePos);
                    e.Graphics.DrawEllipse(p, scalePos);
                    break;
            }

            p.Dispose();
            p2.Dispose();
        }

        
        public virtual MOUSE_STATE CheckMousePointState(Point mousePt, PointF imageOrigin, float zoomRatio)
        {
            int left = (int)(_pos.Left * zoomRatio - imageOrigin.X * zoomRatio - 0.5 * zoomRatio);
            int right = (int)(_pos.Right * zoomRatio - imageOrigin.X * zoomRatio - 0.5 * zoomRatio);
            int top = (int)(_pos.Top * zoomRatio - imageOrigin.Y * zoomRatio - 0.5 * zoomRatio);
            int bottom = (int)(_pos.Bottom * zoomRatio - imageOrigin.Y * zoomRatio - 0.5 * zoomRatio);
            int x = mousePt.X;
            int y = mousePt.Y;

            int size = _rectSize;
           
            bool lt = CheckMousePointInRectangle(mousePt, left - size, top - size, size);
            if (lt) return MOUSE_STATE.LT;
            bool lb = CheckMousePointInRectangle(mousePt, left - size, bottom, size);
            if (lb) return MOUSE_STATE.LB;
            bool rt = CheckMousePointInRectangle(mousePt, right, top - size, size);
            if (rt) return MOUSE_STATE.RT;
            bool rb = CheckMousePointInRectangle(mousePt, right, bottom, size);
            if (rb) return MOUSE_STATE.RB;
            bool t = CheckMousePointInRectangle(mousePt, (left + right - size) / 2, top - size, size);
            if (t) return MOUSE_STATE.TOP;
            bool b = CheckMousePointInRectangle(mousePt, (left + right - size) / 2, bottom, size);
            if (b) return MOUSE_STATE.BOTTOM;
            bool l = CheckMousePointInRectangle(mousePt, left - size, (top + bottom - size) / 2, size);
            if (l) return MOUSE_STATE.LEFT;
            bool r = CheckMousePointInRectangle(mousePt, right, (top + bottom - size) / 2, size);
            if (r) return MOUSE_STATE.RIGHT;

            bool d0 = CalculateDistancePointToline(left, top, right, top, x, y, size);
            if (d0) return MOUSE_STATE.MOVE;
            bool d1 = CalculateDistancePointToline(left, top, left, bottom, x, y, size);
            if (d1) return MOUSE_STATE.MOVE;
            bool d2 = CalculateDistancePointToline(right, top, right, bottom, x, y, size);
            if (d2) return MOUSE_STATE.MOVE;
            bool d3 = CalculateDistancePointToline(left, bottom, right, bottom, x, y, size);
            if (d3) return MOUSE_STATE.MOVE;

            return MOUSE_STATE.NONE;
        }

        protected bool CalculateDistancePointToline(int x1, int y1, int x2, int y2, int x0, int y0, int minDist)
        {
            bool result = false;

            int minX, maxX, minY, maxY;

            if (x1 < x2)
            {
                minX = x1;
                maxX = x2;
            }
            else
            {
                minX = x2;
                maxX = x1;
            }

            if (y1 < y2)
            {
                minY = y1;
                maxY = y2;
            }
            else
            {
                minY = y2;
                maxY = y1;
            }

            if (x0 >= minX - minDist && x0 <= maxX + minDist && y0 >= minY - minDist && y0 <= maxY + minDist)
            {
                int a = y2 - y1;
                int b = -(x2 - x1);
                int c = -a * x1 - b * y1;

                double ab = Math.Sqrt(a * a + b * b);
                double axbyc = (double)(a * x0 + b * y0 + c);
                int dist = (int)Math.Abs(axbyc / ab);

                if (dist < minDist)
                    result = true;
            }

            return result;
        }


        protected bool CheckMousePointInRectangle(Point imagePt, int left, int top, int size)
        {
            int x = imagePt.X;
            int y = imagePt.Y;
            int right = left + size;
            int bottom = top + size;
            if (x >= left && x <= right && y >= top && y <= bottom)
                return true;
            else
                return false;
        }

    }

    public class RectRoi : RoiShape
    {
        public RectRoi()
        {
            _type = ROI_TYPE.RECT;            
        }

        public RectRoi(Rectangle pos)
        {
            _type = ROI_TYPE.RECT;
            Pos = pos;
        }

        public RectRoi(int x, int y, int width, int height)
        {
            _type = ROI_TYPE.RECT;
            Pos = new Rectangle(x, y, width, height);
        }

    }

    public class CircleRoi : RoiShape
    {
        public CircleRoi()
        {
            _type = ROI_TYPE.CIRCLE;
        }
    }

    public class LineRoi : RoiShape
    {
        

        new LinePoint _pos;

        public new LinePoint Pos
        {
            get { return _pos; }
            set { _pos = value; }
        }

        public LineRoi()
        {
            _type = ROI_TYPE.LINE;            
        }

        public LineRoi(LinePoint pts)
        {
            _type = ROI_TYPE.LINE;
            Pos = pts;
        }

        public LineRoi(Point start, Point end)
        {
            _type = ROI_TYPE.LINE;
            Pos = new LinePoint(start, end);
        }

        public LineRoi(int x1, int y1, int x2, int y2)
        {
            _type = ROI_TYPE.LINE;
            Pos = new LinePoint(x1, y1, x2, y2);
        }

        public double CalculateLineLength(Point start, Point end)
        {
            return CalculateLineLength(start.X, start.Y, end.X, end.Y);
        }

        public double CalculateLineLength(int x1, int y1, int x2, int y2)
        {
            int dx = x2 - x1;
            int dy = y2 - y1;
            int mag2 = dx * dx + dy * dy;
            return Math.Sqrt((double)mag2);
        }

        public override void UpdateRoi(int x1, int y1, int x2, int y2)
        {
            Point start = new Point(x1, y1);
            Point end = new Point(x2, y2);
            Pos = new LinePoint(x1, y1, x2, y2);
        }

        public override void DrawRoi(PointF imageOrigin, Color color, int thickness, float zoomRatio, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen p = new Pen(Color.White, thickness);
            Pen p2 = new Pen(color, thickness + 2);

            LinePoint originPos = Pos;
            PointF start= new Point();
            PointF end = new Point();
            
            start.X = (float)((originPos.Start.X - imageOrigin.X) * zoomRatio);
            start.Y = (float)((originPos.Start.Y - imageOrigin.Y) * zoomRatio);
            end.X = (float)((originPos.End.X - imageOrigin.X) * zoomRatio);
            end.Y = (float)((originPos.End.Y - imageOrigin.Y) * zoomRatio);


            e.Graphics.DrawLine(p2, start, end);
            e.Graphics.DrawLine(p, start, end);
          

            p.Dispose();
            p2.Dispose();
        }
        
        public override void DrawSelectedRoi(PointF imageOrigin, Color color, int thickness, float zoomRatio, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen p = new Pen(Color.White, thickness);
            Pen p2 = new Pen(color, thickness + 2);

            LinePoint originPos = Pos;
            PointF start = new Point();
            PointF end = new Point();

            start.X = (float)((originPos.Start.X - imageOrigin.X ) * zoomRatio);
            start.Y = (float)((originPos.Start.Y - imageOrigin.Y ) * zoomRatio);
            end.X = (float)((originPos.End.X - imageOrigin.X ) * zoomRatio);
            end.Y = (float)((originPos.End.Y - imageOrigin.Y ) * zoomRatio);

            e.Graphics.DrawLine(p2, start, end);
            e.Graphics.DrawLine(p, start, end);

            // 직선 시작 끝 표시
            double originRad = CalculateLineAnlge(start, end);
            int length = 11;
            PointF crossStart1 = CalculateCrossLinePoint(start, length, originRad + Math.PI / 2);
            PointF crossEnd1 = CalculateCrossLinePoint(start, length, originRad - Math.PI / 2);

            double arrowAngle = 0;

            float dx = end.X - start.X;
            float dy = end.Y - start.Y;

            if (dx > 0 && dy > 0)
                arrowAngle = Math.PI * 3 / 4;
            else if (dx < 0 && dy > 0)
                arrowAngle = Math.PI / 4;
            else if (dx < 0 && dy <= 0)
                arrowAngle = Math.PI / 4;
            else
                arrowAngle = Math.PI * 3 / 4;

            PointF crossStart2 = CalculateCrossLinePoint(end, length, originRad + arrowAngle);
            PointF crossEnd2 = CalculateCrossLinePoint(end, length, originRad - arrowAngle);

            e.Graphics.DrawLine(p2, crossStart1, crossEnd1);
            e.Graphics.DrawLine(p2, end, crossStart2);
            e.Graphics.DrawLine(p2, end, crossEnd2);

            e.Graphics.DrawLine(p, crossStart1, crossEnd1);
            e.Graphics.DrawLine(p, end, crossStart2);
            e.Graphics.DrawLine(p, end, crossEnd2);

            p.Dispose();
            p2.Dispose();
        }

        public void MoveRoi(int dx, int dy, LinePoint oldPos)
        {            
            Point start = new Point();
            Point end = new Point();

            start.X = oldPos.Start.X + dx;
            start.Y = oldPos.Start.Y + dy;
            end.X = oldPos.End.X + dx;
            end.Y = oldPos.End.Y + dy;

            Pos = new LinePoint(start, end);
        }
        
        public void ResizeRoi(int x, int y, MOUSE_STATE state)
        {
            LinePoint originPos = Pos;

            switch (state)
            {
                case MOUSE_STATE.LB:

                    originPos.Start.X = x;
                    originPos.Start.Y = y;
                    break;
                case MOUSE_STATE.RB:
                    originPos.End.X = x;
                    originPos.End.Y = y;
                    break;
            }

            Pos = originPos;
        }


        public override MOUSE_STATE CheckMousePointState(Point mousePt, PointF imageOrigin, float zoomRatio)
        {
            LinePoint originPos = Pos;

            int x1 = (int)(originPos.Start.X * zoomRatio - imageOrigin.X * zoomRatio);
            int y1 = (int)(originPos.Start.Y * zoomRatio - imageOrigin.Y * zoomRatio);
            int x2 = (int)(originPos.End.X * zoomRatio - imageOrigin.X * zoomRatio);
            int y2 = (int)(originPos.End.Y * zoomRatio - imageOrigin.Y * zoomRatio);
            int x = mousePt.X;
            int y = mousePt.Y;

            int size = _rectSize;

            bool startPt = CheckMousePointInRectangle(mousePt, x1 - size / 2, y1 - size / 2, size);
            if (startPt) return MOUSE_STATE.LB;
            bool endPt = CheckMousePointInRectangle(mousePt, x2 - size / 2, y2 - size / 2, size);
            if (endPt) return MOUSE_STATE.RB;

            bool d0 = CalculateDistancePointToline(x1, y1, x2, y2, x, y, 3);
            if (d0) return MOUSE_STATE.MOVE;

            return MOUSE_STATE.NONE;
        }
        
        private double CalculateLineAnlge(PointF start, PointF end)
        {
            double v1 = (double)(end.X - start.X);
            double v2 = (double)(end.Y - start.Y);

            return Math.Atan(v2 / v1);
        }

        private PointF CalculateCrossLinePoint(PointF origin, int length, double rotatedRad)
        {
            if (length == 0)
                return PointF.Empty;

            PointF cross = new PointF();

            double x = Math.Cos(rotatedRad) * length;
            double y = Math.Sin(rotatedRad) * length;

            cross.X = (float)Math.Round(x + origin.X);
            cross.Y = (float)Math.Round(y + origin.Y);

            return cross;
        }

    }

}
