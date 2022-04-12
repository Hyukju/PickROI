using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace PickROI
{
    public partial class ImageViewer : UserControl
    {
        int _numImage, _totalNumImage, _numSelectedRoi, _numSelectedLine;
        public Bitmap _image;
        float _zoomRatio;
        bool _isMoving, _isOutside, _isMovingObject, _isReSizingObject, _isHistChartOpend, _isColorSpaceChartOpend, _isLineProfileOpend;
        string _preText;
        Point _mouseDownPoint, _mousePoint;
        PointF _imageMovePoint, _imageOrigin;
        Point _roiStartPoint, _roiEndPoint;


        private enum CURRENT_MODE { MOVE_IMAGE, ADD_ROI, ADD_LINE, SELECT_OBJ, NONE };
        private enum COLOR_CHANNEL { RGB, HSV, YCbCr };
        private enum OBJECT_TYPE { ROI, LINE, NONE };
        public enum IMAGE_TYPE { PNG, JPG, BMP24, BMP32, TIFF }
        public enum LOADING_TYPE { NONE, FILE, CLIPBOARD }

        List<string> _imageFileList;

        List<RoiShape> _roiShapes;
        List<LineRoi> _lineShapes;

        Rectangle _oldRoi;
        RoiShape.LinePoint _oldLine;

        RoiShape.MOUSE_STATE _slectedMouseState;

        CURRENT_MODE _currentMode;
        COLOR_CHANNEL _colorCh;
        OBJECT_TYPE _objType;
        LOADING_TYPE _loadingType;

        HistogramChart histChart;
        LineProfile lineProfile;
        ColorSpaceChart colorSapceChart;
        ImageProcessing imageProcessing = new ImageProcessing();
        ColorSpaceConverter csc = new ColorSpaceConverter();

        byte[] _imageArray;

        public ImageViewer()
        {
            InitializeComponent();
            DoubleBuffered = true;
            _roiShapes = new List<RoiShape>();
            _lineShapes = new List<LineRoi>();
            InitailizeParams();
            _currentMode = CURRENT_MODE.NONE;
            ChangeModeParam(_currentMode);
            _isHistChartOpend = false;
            _isLineProfileOpend = false;
            _isColorSpaceChartOpend = false;

            csc.LookUpTableRGBtoYCbCr();
        }

        public bool IsExist()
        {
            if (_image == null)
                return false;
            else
                return true;
        }


        private void InitailizeParams()
        {
            _numImage = 0;
            _totalNumImage = 0;
            _numSelectedRoi = -1;
            _numSelectedLine = -1;
            _imageFileList = new List<string>();
            _colorCh = COLOR_CHANNEL.RGB;
            _currentMode = CURRENT_MODE.MOVE_IMAGE;
            _objType = OBJECT_TYPE.NONE;
            _loadingType = LOADING_TYPE.NONE;
            _zoomRatio = 1.0F;
            _isMoving = false;
            _isOutside = false;
            _isMovingObject = false;
            _isReSizingObject = false;

            _mouseDownPoint = new Point();
            _mousePoint = new Point();
            _imageMovePoint = new PointF();
            _imageOrigin = new PointF();

            _roiStartPoint = new Point();
            _roiEndPoint = new Point();

            dispPixelRgbButton.Checked = true;
            dispPixelHsvButton.Checked = false;
            dispPixelYCbCrButton.Checked = false;
            keepPrePosCheckBox.Checked = false;
            _slectedMouseState = RoiShape.MOUSE_STATE.NONE;

            //
            ChangeModeParam(_currentMode);

        }

        public void ImshowFilePath(string[] filePath)
        {
            InitailizeParams();

            _imageFileList = filePath.ToList();
            _totalNumImage = _imageFileList.Count;
            _numImage = 0;
            _loadingType = LOADING_TYPE.FILE;
            UpdateLabels();
            DisplayImage(_numImage);
        }

        private static Bitmap ConvertTo24bpp(Image img)
        {
            var bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (var gr = Graphics.FromImage(bmp))
                gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            return bmp;
        }

        public void SaveAs(Bitmap image, System.IO.FileStream fs, int imageType)
        {
            //
            try
            {
                switch ((IMAGE_TYPE)(imageType - 1))
                {
                    case IMAGE_TYPE.JPG:
                        image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case IMAGE_TYPE.BMP24:
                        Bitmap saveimage = ConvertTo24bpp(image);
                        saveimage.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Bmp);
                        saveimage.Dispose();
                        break;

                    case IMAGE_TYPE.BMP32:
                        image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case IMAGE_TYPE.TIFF:
                        image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    case IMAGE_TYPE.PNG:
                        image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Png);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /*
        public void SaveAs(string saveFilePath, System.IO.FileStream fs, int imageType)
        {
            //
            switch ((IMAGE_TYPE)(imageType - 1))
            {
                case IMAGE_TYPE.JPG:
                    _image.Save(fs,
                       System.Drawing.Imaging.ImageFormat.Jpeg);
                    break;

                case IMAGE_TYPE.BMP24:
                    Bitmap saveimage = ConvertTo24bpp(_image);
                    saveimage.Save(fs,
                       System.Drawing.Imaging.ImageFormat.Bmp);
                    saveimage.Dispose();
                    break;

                case IMAGE_TYPE.BMP32:
                    _image.Save(fs,
                       System.Drawing.Imaging.ImageFormat.Bmp);
                    break;

                case IMAGE_TYPE.TIFF:
                    _image.Save(fs,
                       System.Drawing.Imaging.ImageFormat.Tiff);
                    break;
                case IMAGE_TYPE.PNG:
                    _image.Save(fs,
                       System.Drawing.Imaging.ImageFormat.Png);
                    break;
            }
        }
        */


        public void DisplayImage(int num)
        {
            try
            {
                if (_imageArray != null)
                {
                    _imageArray = null;
                }

                if (_image != null)
                {
                    _image.Dispose();
                    _image = null;
                }

                using (FileStream fs = new FileStream(_imageFileList[num], FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    _image = new Bitmap(fs);
                    //using(Image source = Image.FromStream(fs))
                    //{
                    //    image = new Bitmap(source);
                    //}
                }

                                pictureBox1.Image = (Image)_image;
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;

                _imageArray = new byte[_image.Width * _image.Height * 3];

                imageProcessing.Image2Array(_image, ref _imageArray);

                if (!keepPrePosCheckBox.Checked)
                {
                    _imageOrigin = Point.Empty;
                    _zoomRatio = 1.0F;
                }

                UpdateLabels();
                if (_isHistChartOpend) DisplayHistogramChart();
                if (_isColorSpaceChartOpend) DisplayColorSpaceChart();
                if (_isLineProfileOpend) DisplayLineProfile();
                errorLabel.Hide();
            }
            catch (Exception)
            {
                UpdateLabels();
                _image = null;
                pictureBox1.Image = null;
                errorLabel.Show();
                errorLabel.Text = "오류 발생.";
                errorLabel.Location = new Point(50, 100);
            }
        }


        public void DisplayClipboardImage(Bitmap clipboardImage)
        {
            try
            {
                if (_imageArray != null)
                {
                    _imageArray = null;
                }

                if (_image != null)
                {
                    _image.Dispose();
                    _image = null;

                }

                _image = clipboardImage;

                pictureBox1.Image = (Image)_image;
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;

                _imageArray = new byte[_image.Width * _image.Height * 3];

                imageProcessing.Image2Array(_image, ref _imageArray);

                if (!keepPrePosCheckBox.Checked)
                {
                    _imageOrigin = Point.Empty;
                    _zoomRatio = 1.0F;
                }

                UpdateLabels();
                if (_isHistChartOpend) DisplayHistogramChart();
                if (_isColorSpaceChartOpend) DisplayColorSpaceChart();
                if (_isLineProfileOpend) DisplayLineProfile();
                errorLabel.Hide();
            }
            catch (Exception)
            {
                _image = null;
                pictureBox1.Image = null;
                errorLabel.Show();
                errorLabel.Text = "오류 발생.";
                errorLabel.Location = new Point(50, 100);
            }
        }


        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (_image == null) return;

            int lines = e.Delta * SystemInformation.MouseWheelScrollLines / 120;

            float oldZoomRatio = _zoomRatio;

            if (lines > 0)
            {
                if (System.Windows.Forms.Control.ModifierKeys != Keys.Control)
                    if (_zoomRatio > 1.0F)
                        _zoomRatio += 1.0F;
                    else
                        _zoomRatio += 0.1F;
                else
                    _zoomRatio += 0.1F;

                if (Math.Round(_zoomRatio * 100.0) >= 5000.0)
                {
                    _zoomRatio = 50.0F;
                }
            }
            else
            {
                if (System.Windows.Forms.Control.ModifierKeys != Keys.Control)
                    if (_zoomRatio > 1.0F)
                        _zoomRatio -= 1.0F;
                    else
                        _zoomRatio -= 0.1F;
                else
                    _zoomRatio -= 0.1F;

                if (Math.Round(_zoomRatio * 100.0) < 10.0)
                {
                    _zoomRatio = 0.1F;
                }
            }

            float x = _imageOrigin.X + e.Location.X / oldZoomRatio;
            float y = _imageOrigin.Y + e.Location.Y / oldZoomRatio;

            if (CheckMousePointInImage((int)x, (int)y))
            {
                _imageOrigin.X = x - e.Location.X / _zoomRatio;
                _imageOrigin.Y = y - e.Location.Y / _zoomRatio;
            }
            else
            {
                _zoomRatio = oldZoomRatio;
            }

            pictureBox1.Refresh();

            UpdateLabels();
        }

        private void ImageViewer_Load(object sender, EventArgs e)
        {

            splitContainer1.Panel1.Controls.Add(pictureBox1);
            splitContainer2.Panel1.Controls.Add(roiDataGridView);
            splitContainer2.Panel2.Controls.Add(lineDataGridView);

            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.SplitterDistance = this.Width - 320;
            splitContainer2.SplitterDistance = splitContainer1.Height / 2;
            splitContainer1.Panel1.BackColor = Color.White;
            splitContainer1.Panel1.AutoScroll = false;
            pictureBox1.MouseWheel += new MouseEventHandler(pictureBox1_MouseWheel);

            pictureBox1.BackColor = Color.Black;
            pictureBox1.Dock = DockStyle.Fill;

            roiDataGridView.Dock = DockStyle.Fill;
            lineDataGridView.Dock = DockStyle.Fill;

            // drage and drop
            this.AllowDrop = true;
            this.DragDrop += new DragEventHandler(this.ImageViewer_DragDrop);
            this.DragEnter += new DragEventHandler(this.ImageViewer_DragEnter);
        }


        private void ImageViewer_DragDrop(object sender, DragEventArgs e)
        {
            // Handle FileDrop data.
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Assign the file names to a string array, in 
                // case the user has selected multiple files.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                try
                {
                    ImshowFilePath(files);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            // Handle Bitmap data.
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                try
                {
                    //// Create an Image and assign it to the picture variable.
                    //this.picture = (Image)e.Data.GetData(DataFormats.Bitmap);
                    //// Set the picture location equal to the drop point.
                    //this.pictureLocation = this.PointToClient(new Point(e.X, e.Y));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            // Force the form to be redrawn with the image.
            this.Invalidate();
        }

        private void ImageViewer_DragEnter(object sender, DragEventArgs e)
        {
            // If the data is a file or a bitmap, display the copy cursor.
            if (e.Data.GetDataPresent(DataFormats.Bitmap) ||
               e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (_image == null) return;


            if (!_isMoving)
            {
                _isMoving = true;
                _mouseDownPoint = e.Location;
                //_numSelectedRoi = -1;
                //_numSelectedLine = -1;

                switch (_currentMode)
                {
                    case CURRENT_MODE.MOVE_IMAGE:
                        break;

                    case CURRENT_MODE.ADD_ROI:
                        break;

                    case CURRENT_MODE.ADD_LINE:

                        break;

                    case CURRENT_MODE.SELECT_OBJ:

                        if (!_isMovingObject && !_isReSizingObject)
                        {
                            bool isSelectedRoi, isSelectedLine;

                            isSelectedRoi = false;
                            isSelectedLine = false;

                            //// --------------- roi -------------------                          
                            if (_numSelectedRoi == -1 && _numSelectedLine == -1)
                            {
                                // 선택이 안될 경우 전체 검색
                                isSelectedRoi = SearchSelectedRoi(e.Location);
                                isSelectedLine = SearchSelectedLine(e.Location);
                            }
                            else if (_numSelectedRoi != -1 && _numSelectedLine == -1)
                            {
                                // 선택 우선 검색
                                _slectedMouseState = _roiShapes[_numSelectedRoi].CheckMousePointState(e.Location, _imageOrigin, _zoomRatio);
                                if (_slectedMouseState == RoiShape.MOUSE_STATE.NONE)
                                {
                                    // 선택이 안될 경우 전체 검색
                                    isSelectedRoi = SearchSelectedRoi(e.Location);
                                    isSelectedLine = SearchSelectedLine(e.Location);

                                    if (!isSelectedRoi) _numSelectedRoi = -1;
                                    if (!isSelectedLine) _numSelectedLine = -1;
                                }
                                else
                                {
                                    _oldRoi = _roiShapes[_numSelectedRoi].Pos;
                                    _objType = OBJECT_TYPE.ROI;
                                }
                            }
                            else
                            {
                                // 선택 우선 검색
                                _slectedMouseState = _lineShapes[_numSelectedLine].CheckMousePointState(e.Location, _imageOrigin, _zoomRatio);
                                if (_slectedMouseState == RoiShape.MOUSE_STATE.NONE)
                                {
                                    // 선택이 안될 경우 전체 검색
                                    isSelectedRoi = SearchSelectedRoi(e.Location);
                                    isSelectedLine = SearchSelectedLine(e.Location);

                                    if (!isSelectedRoi) _numSelectedRoi = -1;
                                    if (!isSelectedLine) _numSelectedLine = -1;

                                }
                                else
                                {
                                    _oldLine = _lineShapes[_numSelectedLine].Pos;
                                    _objType = OBJECT_TYPE.LINE;
                                }

                            }

                            if (_slectedMouseState != RoiShape.MOUSE_STATE.NONE && (_numSelectedRoi != -1 || _numSelectedLine != -1))
                            {
                                ChangeCursor(_slectedMouseState);
                                switch (_slectedMouseState)
                                {
                                    case RoiShape.MOUSE_STATE.MOVE:
                                        _isMovingObject = true;
                                        break;
                                    case RoiShape.MOUSE_STATE.NONE:
                                        break;
                                    default:
                                        _isReSizingObject = true;
                                        break;
                                }
                            }
                        }

                        break;
                }
            }

            pictureBox1.Refresh();
        }

        private bool SearchSelectedRoi(Point mousePt)
        {
            bool result = false;

            RoiShape.MOUSE_STATE mouseState;

            for (int roiIdx = 0; roiIdx < _roiShapes.Count; roiIdx++)
            {
                mouseState = _roiShapes[roiIdx].CheckMousePointState(mousePt, _imageOrigin, _zoomRatio);
                if (mouseState != RoiShape.MOUSE_STATE.NONE)
                {
                    _oldRoi = _roiShapes[roiIdx].Pos;
                    _numSelectedRoi = roiIdx;
                    _numSelectedLine = -1;
                    _slectedMouseState = mouseState;
                    _objType = OBJECT_TYPE.ROI;
                    result = true;
                    break;
                }
            }

            return result;
        }

        private bool SearchSelectedLine(Point mousePt)
        {
            bool result = false;

            RoiShape.MOUSE_STATE mouseState;

            for (int lineIdx = 0; lineIdx < _lineShapes.Count; lineIdx++)
            {
                mouseState = _lineShapes[lineIdx].CheckMousePointState(mousePt, _imageOrigin, _zoomRatio);
                if (mouseState != RoiShape.MOUSE_STATE.NONE)
                {
                    _oldLine = _lineShapes[lineIdx].Pos;
                    _numSelectedRoi = -1;
                    _numSelectedLine = lineIdx;
                    _slectedMouseState = mouseState;
                    _objType = OBJECT_TYPE.LINE;
                    result = true;
                    break;
                }
            }

            return result;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_image == null) return;

            int dx, dy;

            _mousePoint = e.Location;

            if (_isMoving)
            {
                switch (_currentMode)
                {
                    case CURRENT_MODE.MOVE_IMAGE:

                        dx = e.Location.X - _mouseDownPoint.X;
                        dy = e.Location.Y - _mouseDownPoint.Y;
                        _imageMovePoint.X = dx / _zoomRatio;
                        _imageMovePoint.Y = dy / _zoomRatio;

                        break;

                    case CURRENT_MODE.SELECT_OBJ:
                        if (_isMovingObject)
                        {
                            dx = e.Location.X - _mouseDownPoint.X;
                            dy = e.Location.Y - _mouseDownPoint.Y;
                            dx = (int)Math.Round(dx / _zoomRatio);
                            dy = (int)Math.Round(dy / _zoomRatio);

                            switch (_objType)
                            {
                                case OBJECT_TYPE.ROI:
                                    _roiShapes[_numSelectedRoi].MoveRoi(dx, dy, _oldRoi);
                                    UpdateGrideView(_numSelectedRoi, _objType);
                                    break;
                                case OBJECT_TYPE.LINE:
                                    _lineShapes[_numSelectedLine].MoveRoi(dx, dy, _oldLine);
                                    UpdateGrideView(_numSelectedLine, _objType);
                                    break;
                            }
                        }
                        else if (_isReSizingObject)
                        {
                            Point imagePt = MousePoint2ImagePoint(e.Location, _imageOrigin, _zoomRatio);
                            switch (_objType)
                            {
                                case OBJECT_TYPE.ROI:
                                    _roiShapes[_numSelectedRoi].ResizeRoi(imagePt.X, imagePt.Y, _oldRoi, _slectedMouseState);
                                    UpdateGrideView(_numSelectedRoi, _objType);
                                    break;
                                case OBJECT_TYPE.LINE:
                                    _lineShapes[_numSelectedLine].ResizeRoi(imagePt.X, imagePt.Y, _slectedMouseState);
                                    UpdateGrideView(_numSelectedLine, _objType);
                                    break;
                            }
                        }
                        break;
                }
            }

            if (_currentMode == CURRENT_MODE.SELECT_OBJ && !_isMovingObject && !_isReSizingObject)
            {
                OBJECT_TYPE type = OBJECT_TYPE.NONE;

                RoiShape.MOUSE_STATE stateRoi = RoiShape.MOUSE_STATE.NONE;
                RoiShape.MOUSE_STATE stateLine = RoiShape.MOUSE_STATE.NONE;
                int roiIdx, lineIdx;

                for (roiIdx = 0; roiIdx < _roiShapes.Count; roiIdx++)
                {
                    stateRoi = _roiShapes[roiIdx].CheckMousePointState(e.Location, _imageOrigin, _zoomRatio);
                    if (stateRoi != RoiShape.MOUSE_STATE.NONE)
                    {
                        type = OBJECT_TYPE.ROI;
                        break;
                    }
                }

                for (lineIdx = 0; lineIdx < _lineShapes.Count; lineIdx++)
                {
                    stateLine = _lineShapes[lineIdx].CheckMousePointState(e.Location, _imageOrigin, _zoomRatio);
                    if (stateLine != RoiShape.MOUSE_STATE.NONE)
                    {
                        type = OBJECT_TYPE.LINE;
                        break;
                    }
                }

                switch (type)
                {
                    case OBJECT_TYPE.ROI:
                        if (roiIdx == _numSelectedRoi)
                            ChangeCursor(stateRoi);
                        else
                            Cursor = Cursors.NoMove2D;
                        break;
                    case OBJECT_TYPE.LINE:
                        if (lineIdx == _numSelectedLine)
                            ChangeCursor(stateLine);
                        else
                            Cursor = Cursors.NoMove2D;
                        break;
                    default:
                        Cursor = Cursors.Arrow;
                        break;
                }
            }

            UpdateLabels();
            pictureBox1.Refresh();
        }

        private void ChangeCursor(RoiShape.MOUSE_STATE state)
        {
            switch (state)
            {
                case RoiShape.MOUSE_STATE.MOVE:
                    Cursor = Cursors.NoMove2D;
                    break;
                case RoiShape.MOUSE_STATE.LEFT:
                    Cursor = Cursors.SizeWE;
                    break;
                case RoiShape.MOUSE_STATE.RIGHT:
                    Cursor = Cursors.SizeWE;
                    break;
                case RoiShape.MOUSE_STATE.TOP:
                    Cursor = Cursors.SizeNS;
                    break;
                case RoiShape.MOUSE_STATE.BOTTOM:
                    Cursor = Cursors.SizeNS;
                    break;
                case RoiShape.MOUSE_STATE.LT:
                    Cursor = Cursors.SizeNWSE;
                    break;
                case RoiShape.MOUSE_STATE.LB:
                    Cursor = Cursors.SizeNESW;
                    break;
                case RoiShape.MOUSE_STATE.RT:
                    Cursor = Cursors.SizeNESW;
                    break;
                case RoiShape.MOUSE_STATE.RB:
                    Cursor = Cursors.SizeNWSE;
                    break;
            }
        }

        private void UpdateGrideView(int index, OBJECT_TYPE objType)
        {
            if (index < 0) return;

            switch (objType)
            {
                case OBJECT_TYPE.ROI:
                    Rectangle roiPos = _roiShapes[index].Pos;
                    int x = roiPos.X;
                    int y = roiPos.Y;
                    int width = roiPos.Width;
                    int height = roiPos.Height;
                    roiDataGridView.Rows[index].Cells["x"].Value = x;
                    roiDataGridView.Rows[index].Cells["y"].Value = y;
                    roiDataGridView.Rows[index].Cells["width"].Value = width;
                    roiDataGridView.Rows[index].Cells["height"].Value = height;
                    break;
                case OBJECT_TYPE.LINE:
                    RoiShape.LinePoint linePos = _lineShapes[index].Pos;
                    int x1 = linePos.Start.X;
                    int y1 = linePos.Start.Y;
                    int x2 = linePos.End.X;
                    int y2 = linePos.End.Y;
                    double length = _lineShapes[index].CalculateLineLength(x1, y1, x2, y2);
                    lineDataGridView.Rows[index].Cells["x1"].Value = x1;
                    lineDataGridView.Rows[index].Cells["y1"].Value = y1;
                    lineDataGridView.Rows[index].Cells["x2"].Value = x2;
                    lineDataGridView.Rows[index].Cells["y2"].Value = y2;
                    lineDataGridView.Rows[index].Cells["length"].Value = length;
                    break;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (_currentMode)
            {
                case CURRENT_MODE.MOVE_IMAGE:
                    if (_isMoving)
                    {
                        _imageOrigin.X -= _imageMovePoint.X;
                        _imageOrigin.Y -= _imageMovePoint.Y;
                        _imageMovePoint = Point.Empty;
                    }

                    break;
                case CURRENT_MODE.ADD_ROI:
                    RectRoi addRect = new RectRoi();

                    _roiStartPoint = MousePoint2ImagePoint(_mouseDownPoint, _imageOrigin, _zoomRatio);
                    _roiEndPoint = MousePoint2ImagePoint(e.Location, _imageOrigin, _zoomRatio);

                    int x = Math.Min(_roiStartPoint.X, _roiEndPoint.X);
                    int y = Math.Min(_roiStartPoint.Y, _roiEndPoint.Y);
                    int width = Math.Abs(_roiStartPoint.X - _roiEndPoint.X);
                    int height = Math.Abs(_roiStartPoint.Y - _roiEndPoint.Y);

                    if (width > 0 && height > 0)
                    {
                        addRect.Pos = new Rectangle(x, y, width, height);
                        _roiShapes.Add(addRect);

                        object[] rectData = { "삭제", x, y, width, height };
                        roiDataGridView.Rows.Add(rectData);
                        // 마지막셀 세모 표시 이동
                        _numSelectedRoi = roiDataGridView.RowCount - 1;
                        roiDataGridView.CurrentCell = roiDataGridView.Rows[_numSelectedRoi].Cells[0];

                        if (_isHistChartOpend) DisplayHistogramChart();
                        if (_isColorSpaceChartOpend) DisplayColorSpaceChart();
                    }
                    _currentMode = CURRENT_MODE.SELECT_OBJ;
                    ChangeModeParam(_currentMode);

                    break;

                case CURRENT_MODE.ADD_LINE:
                    LineRoi addLine = new LineRoi();
                    Point start = MousePoint2ImagePoint(_mouseDownPoint, _imageOrigin, _zoomRatio);
                    Point end = MousePoint2ImagePoint(e.Location, _imageOrigin, _zoomRatio);
                    double length = addLine.CalculateLineLength(start, end);

                    if (length > 0)
                    {
                        addLine.Pos = new RoiShape.LinePoint(start, end);
                        _lineShapes.Add(addLine);
                        object[] lineData = { "삭제", start.X, start.Y, end.X, end.Y, length };
                        lineDataGridView.Rows.Add(lineData);
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.Format = "#.#";
                        lineDataGridView.Columns["length"].DefaultCellStyle = style;
                        // 마지막셀 세모 표시 이동
                        _numSelectedLine = lineDataGridView.RowCount - 1;
                        lineDataGridView.CurrentCell = lineDataGridView.Rows[_numSelectedLine].Cells[0];

                        if (_isLineProfileOpend) DisplayLineProfile();
                    }
                    _currentMode = CURRENT_MODE.SELECT_OBJ;
                    ChangeModeParam(_currentMode);

                    break;
                case CURRENT_MODE.SELECT_OBJ:
                    // 마지막셀 세모 표시 이동
                    if (_numSelectedRoi != -1) roiDataGridView.CurrentCell = roiDataGridView.Rows[_numSelectedRoi].Cells[0];
                    if (_isHistChartOpend) DisplayHistogramChart();
                    if (_isColorSpaceChartOpend) DisplayColorSpaceChart();

                    if (_numSelectedLine != -1) lineDataGridView.CurrentCell = lineDataGridView.Rows[_numSelectedLine].Cells[0];
                    if (_isLineProfileOpend) DisplayLineProfile();
                    break;
            }

            if (_isMoving) _isMoving = false;
            if (_isMovingObject) _isMovingObject = false;
            if (_isReSizingObject) _isReSizingObject = false;

            Cursor = Cursors.Arrow;
            _mouseDownPoint = Point.Empty;
        }

        private void UpdateLabels()
        {
            switch (_loadingType)
            {
                case LOADING_TYPE.FILE:
                    if (_totalNumImage == 0)
                        fileNameLabel.Text = "파일 이름: ";
                    else if (_image == null)
                        fileNameLabel.Text = "[" + (_numImage + 1).ToString() + "/" + _totalNumImage.ToString() + "] 해상도: 이미지 파일 아님,  파일 이름: " + _imageFileList[_numImage];
                    else
                        fileNameLabel.Text = "[" + (_numImage + 1).ToString() + "/" + _totalNumImage.ToString() + "] 해상도: " + _image.Width.ToString() + "x" + _image.Height.ToString() + " (" + _image.PixelFormat.ToString() + ") , 파일 이름: " + _imageFileList[_numImage];
                    break;

                case LOADING_TYPE.CLIPBOARD:
                    fileNameLabel.Text = "[클립보드] 해상도: " + _image.Width.ToString() + "x" + _image.Height.ToString() + " (" + _image.PixelFormat.ToString() + ")";
                    break;

            }
            zoomRatioLabel.Text = "확대/축소: " + Math.Round(_zoomRatio * 100.0).ToString("0") + " %";


            if (_isOutside || _image == null)
            {
                imagePointLabel.Text = "x: -, y: -";
                pixelValueLabel.Text = "픽셀 값: -";
            }
            else
            {
                Point imagePt = MousePoint2ImagePoint(_mousePoint, _imageOrigin, _zoomRatio);

                if (CheckMousePointInImage(imagePt))
                {
                    imagePointLabel.Text = "x: " + imagePt.X.ToString().PadLeft(5) + ", y: " + imagePt.Y.ToString().PadLeft(5);
                    DisplayPixelValue(imagePt, _colorCh);
                }
                else
                {
                    imagePointLabel.Text = "x: -, y: -";
                    pixelValueLabel.Text = "픽셀 값: -";
                }
            }

            this.Update();
        }

        private bool CheckMousePointInImage(Point mousePt)
        {
            return CheckMousePointInImage(mousePt.X, mousePt.Y);
        }

        private bool CheckMousePointInImage(int x, int y)
        {
            if (x >= 0 && x < _image.Width && y >= 0 && y < _image.Height)
                return true;
            else
                return false;
        }

        private Point MousePoint2ImagePoint(Point mousetPt, PointF imageOrigin, float zoomRatio)
        {

            Point imagePt = new Point
            {
                X = (int)(mousetPt.X / zoomRatio + imageOrigin.X + 0.5),
                Y = (int)(mousetPt.Y / zoomRatio + imageOrigin.Y + 0.5)
            };

            //if (imagePt.X < 0) imagePt.X = 0;
            //if (imagePt.Y < 0) imagePt.Y = 0;
            //if (imagePt.X >= image.Width) imagePt.X = image.Width - 1;
            //if (imagePt.Y >= image.Height) imagePt.Y = image.Height - 1;

            return imagePt;
        }

        private Point ImagePoint2MousePoint(Point imagePt, float zoomRatio)
        {
            Point mousePt = new Point
            {
                X = (int)Math.Round(imagePt.X * zoomRatio - 0.5 * zoomRatio),
                Y = (int)Math.Round(imagePt.Y * zoomRatio - 0.5 * zoomRatio)
            };

            if (mousePt.X < 0) mousePt.X = 0;
            if (mousePt.Y < 0) mousePt.Y = 0;
            if (mousePt.X >= _image.Width) mousePt.X = _image.Width - 1;
            if (mousePt.Y >= _image.Height) mousePt.Y = _image.Height - 1;

            return mousePt;
        }

        private void DisplayPixelValue(Point pt, COLOR_CHANNEL ch)
        {
            Color pixel = _image.GetPixel(pt.X, pt.Y);

            switch (ch)
            {
                case COLOR_CHANNEL.RGB:
                    pixelValueLabel.Text = "r: " + pixel.R.ToString().PadLeft(3) + ", g: " + pixel.G.ToString().PadLeft(3) + ", b: " + pixel.B.ToString().PadLeft(3);
                    break;
                case COLOR_CHANNEL.HSV:
                    ColorSpaceConverter.Point3b hsv = csc.Rgb2Hsv255(pixel);
                    pixelValueLabel.Text = "h: " + hsv.Ch1.ToString().PadLeft(3) + ", s: " + hsv.Ch2.ToString().PadLeft(3) + ", v: " + hsv.Ch3.ToString().PadLeft(3);
                    break;
                case COLOR_CHANNEL.YCbCr:
                    ColorSpaceConverter.Point3b ycvcr = csc.Rgb2YCbCr255(pixel.R, pixel.G, pixel.B);
                    pixelValueLabel.Text = "y: " + ycvcr.Ch1.ToString().PadLeft(3) + ", cb: " + ycvcr.Ch2.ToString().PadLeft(3) + ", cr: " + ycvcr.Ch3.ToString().PadLeft(3);
                    break;
            }
        }

        private void ChangePixelColorSpace(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            switch (item.Text)
            {
                case "rgb":
                    dispPixelRgbButton.Checked = true;
                    dispPixelHsvButton.Checked = false;
                    dispPixelYCbCrButton.Checked = false;
                    _colorCh = COLOR_CHANNEL.RGB;
                    break;
                case "hsv":
                    dispPixelRgbButton.Checked = false;
                    dispPixelHsvButton.Checked = true;
                    dispPixelYCbCrButton.Checked = false;
                    _colorCh = COLOR_CHANNEL.HSV;
                    break;
                case "ycbcr":
                    dispPixelRgbButton.Checked = false;
                    dispPixelHsvButton.Checked = false;
                    dispPixelYCbCrButton.Checked = true;
                    _colorCh = COLOR_CHANNEL.YCbCr;
                    break;
                default:
                    dispPixelRgbButton.Checked = true;
                    dispPixelHsvButton.Checked = false;
                    dispPixelYCbCrButton.Checked = false;
                    _colorCh = COLOR_CHANNEL.RGB;
                    break;

            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (_image == null) return;


            float[] dash = { 2, 2 };
            Pen gray = new Pen(Color.Gray, 1);
            Pen redDash = new Pen(Color.Red, 1);
            Pen green = new Pen(Color.Green, 3);
            Pen white = new Pen(Color.White, 1);
            Font font = new Font("Arial", 16);
            SolidBrush fontBrush = new SolidBrush(Color.Green);
            redDash.DashPattern = dash;


            PointF imageOrigin = new PointF
            {
                X = _imageOrigin.X - _imageMovePoint.X,
                Y = _imageOrigin.Y - _imageMovePoint.Y
            };


            // moving picturebox
            e.Graphics.Clear(Color.Black);
            e.Graphics.DrawImage(_image,
              new RectangleF(0, 0, pictureBox1.Width, pictureBox1.Height),
              new RectangleF(imageOrigin.X, imageOrigin.Y, pictureBox1.Width / _zoomRatio, pictureBox1.Height / _zoomRatio),
              GraphicsUnit.Pixel);

            if (_currentMode == CURRENT_MODE.ADD_LINE || _currentMode == CURRENT_MODE.ADD_ROI)
            {
                e.Graphics.DrawLine(gray, 0, _mousePoint.Y, pictureBox1.Width, _mousePoint.Y);
                e.Graphics.DrawLine(gray, _mousePoint.X, 0, _mousePoint.X, pictureBox1.Height);
                Point imagePt = MousePoint2ImagePoint(_mousePoint, _imageOrigin, _zoomRatio);
                e.Graphics.DrawString("x: " + imagePt.X.ToString() + ", y: " + imagePt.Y.ToString(), font, fontBrush, _mousePoint.X, _mousePoint.Y - 23);

                if (_isMoving)
                {
                    switch (_currentMode)
                    {
                        case CURRENT_MODE.ADD_LINE:
                            e.Graphics.DrawLine(green, _mouseDownPoint, _mousePoint);
                            e.Graphics.DrawLine(white, _mouseDownPoint, _mousePoint);
                            break;
                        case CURRENT_MODE.ADD_ROI:
                            int x = Math.Min(_mouseDownPoint.X, _mousePoint.X);
                            int y = Math.Min(_mouseDownPoint.Y, _mousePoint.Y);
                            int width = Math.Abs(_mousePoint.X - _mouseDownPoint.X);
                            int height = Math.Abs(_mousePoint.Y - _mouseDownPoint.Y);
                            e.Graphics.DrawRectangle(green, x, y, width, height);
                            e.Graphics.DrawRectangle(white, x, y, width, height);
                            break;
                    }
                }
            }
            // --- roi -----
            for (int roiIdx = 0; roiIdx < _roiShapes.Count; roiIdx++)
            {
                if (_numSelectedRoi == roiIdx)
                    _roiShapes[roiIdx].DrawSelectedRoi(imageOrigin, Color.Red, 1, _zoomRatio, e);
                else
                    _roiShapes[roiIdx].DrawRoi(imageOrigin, Color.Green, 1, _zoomRatio, e);
            }

            for (int lineIdx = 0; lineIdx < _lineShapes.Count; lineIdx++)
            {
                if (_numSelectedLine == lineIdx)
                    _lineShapes[lineIdx].DrawSelectedRoi(imageOrigin, Color.Red, 1, _zoomRatio, e);
                else
                    _lineShapes[lineIdx].DrawRoi(imageOrigin, Color.Green, 1, _zoomRatio, e);
            }

            gray.Dispose();
            redDash.Dispose();
            green.Dispose();
            font.Dispose();
            fontBrush.Dispose();
        }

        private void zoom100Button_Click(object sender, EventArgs e)
        {
            if (_image == null)
                return;

            _imageOrigin = PointF.Empty;
            _zoomRatio = 1.0F;
            UpdateLabels();
            pictureBox1.Refresh();
        }

        private void fitButton_Click(object sender, EventArgs e)
        {
            if (_image == null) return;

            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            double boxRatio = (double)height / width;
            double imageRatio = (double)_image.Height / _image.Width;

            if (boxRatio > imageRatio)
            {
                _zoomRatio = (float)width / _image.Width;
                _imageOrigin.X = 0;
                _imageOrigin.Y = -height / _zoomRatio / 2 + _image.Height / 2;
            }
            else
            {
                _zoomRatio = (float)height / _image.Height;

                _imageOrigin.X = -width / _zoomRatio / 2 + _image.Width / 2;
                _imageOrigin.Y = 0;
            }

            pictureBox1.Refresh();
            UpdateLabels();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            int preIndex = e.RowIndex;
            int selectedRow = -1;

            if (e.ColumnIndex == 0 && preIndex > -1)
            {
                dataGridView.Rows.RemoveAt(preIndex);

                if (dataGridView.RowCount - 1 >= preIndex)
                    selectedRow = preIndex;
                else
                    selectedRow = preIndex - 1;
            }
            else
            {
                selectedRow = e.RowIndex;
            }

            switch (dataGridView.Name)
            {
                case "roiDataGridView":
                    _numSelectedRoi = selectedRow;
                    _numSelectedLine = -1;
                    if (_isHistChartOpend) DisplayHistogramChart();
                    if (_isColorSpaceChartOpend) DisplayColorSpaceChart();
                    break;
                case "lineDataGridView":
                    _numSelectedRoi = -1;
                    _numSelectedLine = selectedRow;
                    break;
            }

            _currentMode = CURRENT_MODE.SELECT_OBJ;
            ChangeModeParam(_currentMode);

            pictureBox1.Refresh();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //string name = dataGridView1.CurrentCell.OwningColumn.Name;
            //if (!(name == "x" || name == "y" || name == "width" || name == "height")) return;

            //// focus 때문에 깜빡이는 커서가 안나와서 처리함
            //dataGridView1.BeginEdit(false);
            //string str = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //((TextBox)dataGridView1.EditingControl).SelectionStart = str.Length;

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            // null 체크
            int index, cell1, cell2, cell3, cell4;

            if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                index = e.RowIndex;
                cell1 = Convert.ToInt32(dataGridView.Rows[index].Cells[1].Value);
                cell2 = Convert.ToInt32(dataGridView.Rows[index].Cells[2].Value);
                cell3 = Convert.ToInt32(dataGridView.Rows[index].Cells[3].Value);
                cell4 = Convert.ToInt32(dataGridView.Rows[index].Cells[4].Value);

                switch (dataGridView.Name)
                {
                    case "roiDataGridView":
                        _roiShapes[index].UpdateRoi(cell1, cell2, cell3, cell4);
                        if (_isHistChartOpend) DisplayHistogramChart();
                        if (_isColorSpaceChartOpend) DisplayColorSpaceChart();
                        break;
                    case "lineDataGridView":
                        _lineShapes[index].UpdateRoi(cell1, cell2, cell3, cell4);
                        if (_isLineProfileOpend) DisplayLineProfile();

                        double length = _lineShapes[index].CalculateLineLength(cell1, cell2, cell3, cell4);
                        dataGridView.Rows[index].Cells[5].Value = length;
                        break;
                }

                pictureBox1.Refresh();
            }
            else
            {
                dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _preText;
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                _preText = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            int index = dataGridView.CurrentCell.OwningColumn.Index;
            if (index >= 1 && index <= 4)
                e.Control.KeyPress += new KeyPressEventHandler(txtCheckNumeric_KeyPress);
            else
                e.Control.KeyPress -= new KeyPressEventHandler(txtCheckNumeric_KeyPress);
        }

        private void txtCheckNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링  //숫자와 백스페이스를 제외한 나머지를 바로 처리
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            switch (dataGridView.Name)
            {
                case "roiDataGridView":
                    _roiShapes.RemoveAt(e.RowIndex);
                    break;

                case "lineDataGridView":
                    _lineShapes.RemoveAt(e.RowIndex);
                    break;
            }

            pictureBox1.Refresh();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // gridview 키보드 화살표 이동 시 해당 오브젝트 표시 용
            // 추가 시 일단 막음
            if (_currentMode == CURRENT_MODE.ADD_LINE || _currentMode == CURRENT_MODE.ADD_ROI) return;

            DataGridView dataGridView = (DataGridView)sender;

            int selectedRow = dataGridView.CurrentCell.RowIndex;

            if (selectedRow == -1) return;

            switch (dataGridView.Name)
            {
                case "roiDataGridView":
                    _numSelectedRoi = selectedRow;
                    _numSelectedLine = -1;
                    if (_isHistChartOpend) DisplayHistogramChart();
                    if (_isColorSpaceChartOpend) DisplayColorSpaceChart();
                    break;
                case "lineDataGridView":
                    _numSelectedRoi = -1;
                    _numSelectedLine = selectedRow;
                    if (_isLineProfileOpend) DisplayLineProfile();
                    break;
            }

            _currentMode = CURRENT_MODE.SELECT_OBJ;
            ChangeModeParam(_currentMode);

            pictureBox1.Refresh();
        }




        private void DisplayHistogramButton_Click(object sender, EventArgs e)
        {
            _isHistChartOpend = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "HistogramChart")
                    _isHistChartOpend = true;
            }

            if (!_isHistChartOpend)
            {
                if (histChart != null)
                {
                    histChart.Dispose();
                    histChart = null;
                }

                histChart = new HistogramChart();
                histChart.Owner = (Form)this.Parent;
                histChart.Show();
                _isHistChartOpend = true;
            }

            DisplayHistogramChart();
        }

        private void DisplayHistogramChart()
        {
            if (_image == null) return;
            if (histChart.IsDisposed) return;

            if (_numSelectedRoi == -1)
            {
                //histChart.DrawHistogram(image.Width, image.Height, new Rectangle(0, 0, image.Width, image.Height), _imageArray);
                histChart.InitializeView();
            }
            else
            {
                int x = _roiShapes[_numSelectedRoi].Pos.X;
                int y = _roiShapes[_numSelectedRoi].Pos.Y;
                int width = _roiShapes[_numSelectedRoi].Pos.Width;
                int height = _roiShapes[_numSelectedRoi].Pos.Height;

                if (x < 0)
                {
                    width += x;
                    x = 0;
                }

                if (y < 0)
                {
                    height += y;
                    y = 0;
                }


                if (x + width > _image.Width) width = _image.Width - x;
                if (y + height > _image.Height) height = _image.Height - y;

                if (width > 0 && height > 0)
                {
                    histChart.DrawHistogram(_image.Width, _image.Height, new Rectangle(x, y, width, height), _imageArray);
                }
                else
                {
                    histChart.InitializeView();
                }

            }

        }

        private void DisplayColorSpaceButton_Click(object sender, EventArgs e)
        {
            _isColorSpaceChartOpend = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "ColorSpaceChart")
                    _isColorSpaceChartOpend = true;
            }

            if (!_isColorSpaceChartOpend)
            {
                colorSapceChart = new ColorSpaceChart();
                colorSapceChart.Owner = (Form)this.Parent;
                colorSapceChart.Show();
                _isColorSpaceChartOpend = true;
            }

            DisplayColorSpaceChart();
        }

        private void DisplayColorSpaceChart()
        {
            //
            if (_image == null) return;
            if (colorSapceChart.IsDisposed) return;

            if (_numSelectedRoi == -1)
            {
                //colorSapceChart.DrawColorSpaceChart(image.Width, image.Height, new Rectangle(0, 0, image.Width, image.Height), _imageArray);
                colorSapceChart.InitailizeView();
            }
            else
            {
                int x = _roiShapes[_numSelectedRoi].Pos.X;
                int y = _roiShapes[_numSelectedRoi].Pos.Y;
                int width = _roiShapes[_numSelectedRoi].Pos.Width;
                int height = _roiShapes[_numSelectedRoi].Pos.Height;

                if (x < 0)
                {
                    width += x;
                    x = 0;
                }

                if (y < 0)
                {
                    height += y;
                    y = 0;
                }

                if (x + width > _image.Width) width = _image.Width - x;
                if (y + height > _image.Height) height = _image.Height - y;

                if (width > 0 && height > 0)
                {
                    colorSapceChart.DrawColorSpaceChart(_image.Width, _image.Height, new Rectangle(x, y, width, height), _imageArray);
                }
                else
                {
                    colorSapceChart.InitailizeView();
                }

            }
        }

        private void AddLineButton_Click(object sender, EventArgs e)
        {
            if (_image == null) return;
            _numSelectedRoi = -1;
            _currentMode = CURRENT_MODE.ADD_LINE;
            ChangeModeParam(_currentMode);
        }

        private void CutImageButton_Click(object sender, EventArgs e)
        {
            //
            if (_image == null) return;

            if (_numSelectedRoi == -1)
            {
                // 에러 표시 추가
                MessageBox.Show("영역이 선택되지 않았습니다.", "실패");
                return;
            }
            else
            {
                int x = _roiShapes[_numSelectedRoi].Pos.X;
                int y = _roiShapes[_numSelectedRoi].Pos.Y;
                int width = _roiShapes[_numSelectedRoi].Pos.Width;
                int height = _roiShapes[_numSelectedRoi].Pos.Height;

                if (x < 0)
                {
                    width += x;
                    x = 0;
                }

                if (y < 0)
                {
                    height += y;
                    y = 0;
                }

                if (x + width > _image.Width) width = _image.Width - x;
                if (y + height > _image.Height) height = _image.Height - y;

                if (width > 0 && height > 0)
                {
                    //                    
                    Bitmap cropImage = imageProcessing.CropImage(_image, new Rectangle(x, y, width, height));
                    Clipboard.SetImage((Image)cropImage);
                    MessageBox.Show("선택된 영역이 클립보드에 복사되었습니다.", "성공");
                }
                else
                {
                    // 에러 추가
                    MessageBox.Show("선택된 영역의 크기가 작거나 이미지 영역 내부에 존재하지 않습니다.", "실패");
                }

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //
            if (_image == null) return;

            if (_numSelectedRoi == -1)
            {
                // 에러 표시 추가
                MessageBox.Show("영역이 선택되지 않았습니다.", "실패");
                return;
            }
            else
            {
                int x = _roiShapes[_numSelectedRoi].Pos.X;
                int y = _roiShapes[_numSelectedRoi].Pos.Y;
                int width = _roiShapes[_numSelectedRoi].Pos.Width;
                int height = _roiShapes[_numSelectedRoi].Pos.Height;

                if (x < 0)
                {
                    width += x;
                    x = 0;
                }

                if (y < 0)
                {
                    height += y;
                    y = 0;
                }

                if (x + width > _image.Width) width = _image.Width - x;
                if (y + height > _image.Height) height = _image.Height - y;

                if (width > 0 && height > 0)
                {
                    //                    
                    Bitmap cropImage = imageProcessing.CropImage(_image, new Rectangle(x, y, width, height));

                    SaveFileDialog saveFileDlg = new SaveFileDialog();
                    saveFileDlg.Filter = "Png Image|*.png|JPeg Image|*.jpg|Bitmap Image(24-bit)|*.bmp|Bitmap Image(32-bit)|*.bmp|Tiff Image|*.tif";
                    saveFileDlg.Title = "Save an Image File";


                    if (saveFileDlg.ShowDialog() == DialogResult.OK)
                    {
                        // If the file name is not an empty string open it for saving.  
                        if (saveFileDlg.FileName != "")
                        {
                            System.IO.FileStream fs = (System.IO.FileStream)saveFileDlg.OpenFile();
                            SaveAs(cropImage, fs, saveFileDlg.FilterIndex);
                            fs.Close();
                        }
                    }

                }
                else
                {
                    // 에러 추가
                    MessageBox.Show("선택된 영역의 크기가 작거나 이미지 영역 내부에 존재하지 않습니다.", "실패");
                }

            }
        }

        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (_image != null)
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        if (_currentMode == CURRENT_MODE.ADD_LINE || _currentMode == CURRENT_MODE.ADD_ROI)
                        {
                            _currentMode = CURRENT_MODE.SELECT_OBJ;
                            ChangeModeParam(_currentMode);
                            if (_isMoving) _isMoving = false;
                        }
                        break;
                    case Keys.Left:
                        _numImage--;
                        break;
                    case Keys.Right:
                        _numImage++;
                        break;
                    case Keys.ShiftKey:
                        if (_currentMode == CURRENT_MODE.ADD_LINE)
                        {
                            _mousePoint.Y = (int)_mouseDownPoint.Y;
                        }
                        break;
                    default:
                        break;
                }

                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                {
                    if (_numImage < 0)
                        _numImage = _totalNumImage - 1;
                    else if (_numImage >= _totalNumImage)
                        _numImage = 0;

                    if (_loadingType == LOADING_TYPE.FILE)
                        DisplayImage(_numImage);
                }

                pictureBox1.Refresh();
            }

            if (e.Control && e.KeyCode == Keys.V)
            {
                try
                {
                    // 클립보드에 데이타가 있는지 검사
                    if (Clipboard.GetDataObject() != null)
                    {
                        // 클립보드에서 데이타를 가져온다.
                        IDataObject data = Clipboard.GetDataObject();

                        // 클립보드에 있던 데이타가 이미지 형식인지 검사
                        if (data.GetDataPresent(DataFormats.Bitmap))
                        {
                            // 클립보드의 데이타를 이미지 형식으로 로드 한다.
                            Bitmap clipboardImage = (Bitmap)data.GetData(DataFormats.Bitmap, true);
                            InitailizeParams();
                            _totalNumImage = 1;
                            _numImage = 1;
                            _loadingType = LOADING_TYPE.CLIPBOARD;
                            DisplayClipboardImage(clipboardImage);
                        }
                    }
                }
                catch (Exception)
                {

                }

            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if (_image == null) return;
            _isOutside = true;
            _mousePoint = Point.Empty;
            UpdateLabels();
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            if (_image == null) return;
            _isOutside = false;
        }

        private void ChangePreviousNextImage(object sender, EventArgs e)
        {
            if (_totalNumImage < 1) return;

            Button btn = (Button)sender;

            if (btn.Text == "<")
                _numImage--;
            else
                _numImage++;

            if (_numImage < 0)
                _numImage = _totalNumImage - 1;
            else if (_numImage >= _totalNumImage)
                _numImage = 0;
            DisplayImage(_numImage);
            pictureBox1.Refresh();
        }

        private void ChangeInterpolationType(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            System.Drawing.Drawing2D.InterpolationMode interpolationType;

            switch (item.Text)
            {
                case "Nearest Neighbor":
                    nearestNeighborItem.Checked = true;
                    lowItem.Checked = false;
                    highItem.Checked = false;
                    interpolationType = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    break;
                case "Low":
                    nearestNeighborItem.Checked = false;
                    lowItem.Checked = true;
                    highItem.Checked = false;
                    interpolationType = System.Drawing.Drawing2D.InterpolationMode.Low;
                    break;
                case "High":
                    nearestNeighborItem.Checked = false;
                    lowItem.Checked = false;
                    highItem.Checked = true;
                    interpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    break;
                default:
                    nearestNeighborItem.Checked = true;
                    lowItem.Checked = false;
                    highItem.Checked = false;
                    interpolationType = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    break;

            }
            pictureBox1.ChangeInterpolationType(interpolationType);
            pictureBox1.Refresh();
        }

        private void AddRectButton_Click(object sender, EventArgs e)
        {
            if (_image == null) return;
            _numSelectedLine = -1;
            _currentMode = CURRENT_MODE.ADD_ROI;
            ChangeModeParam(_currentMode);
        }


        private void moveButton_Click(object sender, EventArgs e)
        {
            if (_image == null) return;

            _currentMode = CURRENT_MODE.MOVE_IMAGE;
            ChangeModeParam(_currentMode);
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            if (_image == null) return;

            _currentMode = CURRENT_MODE.SELECT_OBJ;
            ChangeModeParam(_currentMode);
        }

        private void ChangeModeParam(CURRENT_MODE mode)
        {
            switch (mode)
            {
                case CURRENT_MODE.MOVE_IMAGE:
                    _numSelectedRoi = -1;
                    _numSelectedLine = -1;
                    selectButton.BackColor = Color.Transparent;
                    moveButton.BackColor = Color.LightGreen;
                    AddRectButton.BackColor = Color.Transparent;
                    AddLineButton.BackColor = Color.Transparent;
                    pictureBox1.Cursor = Cursors.Hand;

                    break;
                case CURRENT_MODE.ADD_ROI:
                    selectButton.BackColor = Color.Transparent;
                    moveButton.BackColor = Color.Transparent;
                    AddRectButton.BackColor = Color.LightGreen;
                    AddLineButton.BackColor = Color.Transparent;
                    pictureBox1.Cursor = Cursors.Cross;
                    break;
                case CURRENT_MODE.ADD_LINE:
                    selectButton.BackColor = Color.Transparent;
                    moveButton.BackColor = Color.Transparent;
                    AddRectButton.BackColor = Color.Transparent;
                    AddLineButton.BackColor = Color.LightGreen;
                    pictureBox1.Cursor = Cursors.Cross;
                    break;
                case CURRENT_MODE.SELECT_OBJ:
                    selectButton.BackColor = Color.LightGreen;
                    moveButton.BackColor = Color.Transparent;
                    AddRectButton.BackColor = Color.Transparent;
                    AddLineButton.BackColor = Color.Transparent;
                    pictureBox1.Cursor = Cursors.Arrow;
                    break;
                case CURRENT_MODE.NONE:
                    selectButton.BackColor = Color.Transparent;
                    moveButton.BackColor = Color.Transparent;
                    AddRectButton.BackColor = Color.Transparent;
                    AddLineButton.BackColor = Color.Transparent;
                    pictureBox1.Cursor = Cursors.Arrow;
                    break;
            }
        }

        private void DisplayLineProfileButton_Click(object sender, EventArgs e)
        {
            _isLineProfileOpend = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "LineProfile")
                    _isLineProfileOpend = true;
            }

            if (!_isLineProfileOpend)
            {
                if (lineProfile != null)
                {
                    lineProfile.Dispose();
                    lineProfile = null;
                }

                lineProfile = new LineProfile();
                lineProfile.Owner = (Form)this.Parent;
                lineProfile.Show();
                _isLineProfileOpend = true;
            }

            DisplayLineProfile();
        }

        private void DisplayLineProfile()
        {
            if (_image == null) return;
            if (lineProfile.IsDisposed) return;

            if (_numSelectedLine != -1)
            {
                Point start = _lineShapes[_numSelectedLine].Pos.Start;
                Point end = _lineShapes[_numSelectedLine].Pos.End;

                //
                bool isIn0, isIn1;
                isIn0 = false;
                isIn1 = false;

                if (start.X >= 0 && start.X < _image.Width && start.Y >= 0 && start.Y < _image.Height)
                    isIn0 = true;
                if (end.X >= 0 && end.X < _image.Width && end.Y >= 0 && end.Y < _image.Height)
                    isIn1 = true;

                if (isIn0 || isIn1)
                {
                    if (start.X < 0) start.X = 0;
                    if (start.X > _image.Width) start.X = _image.Width - 1;
                    if (end.X < 0) end.X = 0;
                    if (end.X > _image.Width) end.X = _image.Width - 1;

                    if (start.Y < 0) start.Y = 0;
                    if (start.Y > _image.Height) start.Y = _image.Height - 1;
                    if (end.Y < 0) end.Y = 0;
                    if (end.Y > _image.Height) end.Y = _image.Height - 1;

                    int w = Math.Abs(end.X - start.X);
                    int h = Math.Abs(end.Y - start.Y);

                    if (w > 0 || h > 0)
                        lineProfile.DrawLineProfile(start, end, _image.Width, _image.Height, _imageArray);
                    else
                        lineProfile.InitializeView();
                }
                else
                {
                    lineProfile.InitializeView();
                }


            }
            else
            {
                lineProfile.InitializeView();
            }

        }

        private void rotateButton_Click(object sender, EventArgs e)
        {
            _image.RotateFlip(RotateFlipType.Rotate90FlipXY);
            imageProcessing.Image2Array(_image, ref _imageArray);

            if (_isHistChartOpend) DisplayHistogramChart();
            if (_isColorSpaceChartOpend) DisplayColorSpaceChart();
            if (_isLineProfileOpend) DisplayLineProfile();

            pictureBox1.Refresh();

        }
    }

    class MyPictureBox : PictureBox
    {
        System.Drawing.Drawing2D.InterpolationMode interpolationType;

        public MyPictureBox()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, false);
            this.UpdateStyles();
            interpolationType = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        }

        public void ChangeInterpolationType(System.Drawing.Drawing2D.InterpolationMode type)
        {
            this.interpolationType = type;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.InterpolationMode = this.interpolationType;
            base.OnPaint(pe);
        }


    }
}


