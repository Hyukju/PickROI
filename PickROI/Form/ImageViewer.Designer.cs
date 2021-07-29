namespace PickROI
{
    partial class ImageViewer
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageViewer));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.stateBar = new System.Windows.Forms.ToolStrip();
            this.imagePointLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pixelValueLabel = new System.Windows.Forms.ToolStripSplitButton();
            this.dispPixelYCbCrButton = new System.Windows.Forms.ToolStripMenuItem();
            this.dispPixelHsvButton = new System.Windows.Forms.ToolStripMenuItem();
            this.dispPixelRgbButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.zoomRatioLabel = new System.Windows.Forms.ToolStripSplitButton();
            this.zoom100Button = new System.Windows.Forms.ToolStripMenuItem();
            this.fastRunIconBar = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.nearestNeighborItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lowItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectButton = new System.Windows.Forms.ToolStripButton();
            this.moveButton = new System.Windows.Forms.ToolStripButton();
            this.rotateButton = new System.Windows.Forms.ToolStripButton();
            this.fitButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.AddLineButton = new System.Windows.Forms.ToolStripButton();
            this.DisplayLineProfileButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.AddRectButton = new System.Windows.Forms.ToolStripButton();
            this.DisplayHistogramButton = new System.Windows.Forms.ToolStripButton();
            this.DisplayColorSpaceButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.fileInfoPanel = new System.Windows.Forms.Panel();
            this.keepPrePosCheckBox = new System.Windows.Forms.CheckBox();
            this.nextButton = new System.Windows.Forms.Button();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.previousButton = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.roiDataGridView = new System.Windows.Forms.DataGridView();
            this.del = new System.Windows.Forms.DataGridViewButtonColumn();
            this.x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.x1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.y1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.y2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new PickROI.MyPictureBox();
            this.cutImageButton = new System.Windows.Forms.ToolStripButton();
            this.cutSaveButton = new System.Windows.Forms.ToolStripButton();
            this.stateBar.SuspendLayout();
            this.fastRunIconBar.SuspendLayout();
            this.fileInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roiDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // stateBar
            // 
            this.stateBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.stateBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imagePointLabel,
            this.toolStripSeparator1,
            this.pixelValueLabel,
            this.toolStripSeparator2,
            this.zoomRatioLabel});
            this.stateBar.Location = new System.Drawing.Point(0, 478);
            this.stateBar.Name = "stateBar";
            this.stateBar.Size = new System.Drawing.Size(1061, 25);
            this.stateBar.TabIndex = 3;
            this.stateBar.Text = "toolStrip1";
            // 
            // imagePointLabel
            // 
            this.imagePointLabel.AutoSize = false;
            this.imagePointLabel.Name = "imagePointLabel";
            this.imagePointLabel.Size = new System.Drawing.Size(180, 22);
            this.imagePointLabel.Text = "x: -, y: -";
            this.imagePointLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // pixelValueLabel
            // 
            this.pixelValueLabel.AutoSize = false;
            this.pixelValueLabel.AutoToolTip = false;
            this.pixelValueLabel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dispPixelYCbCrButton,
            this.dispPixelHsvButton,
            this.dispPixelRgbButton});
            this.pixelValueLabel.Image = ((System.Drawing.Image)(resources.GetObject("pixelValueLabel.Image")));
            this.pixelValueLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pixelValueLabel.ImageTransparentColor = System.Drawing.Color.Black;
            this.pixelValueLabel.Name = "pixelValueLabel";
            this.pixelValueLabel.Size = new System.Drawing.Size(180, 22);
            this.pixelValueLabel.Text = "픽셀 값: -";
            this.pixelValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dispPixelYCbCrButton
            // 
            this.dispPixelYCbCrButton.Name = "dispPixelYCbCrButton";
            this.dispPixelYCbCrButton.Size = new System.Drawing.Size(103, 22);
            this.dispPixelYCbCrButton.Text = "ycbcr";
            this.dispPixelYCbCrButton.Click += new System.EventHandler(this.ChangePixelColorSpace);
            // 
            // dispPixelHsvButton
            // 
            this.dispPixelHsvButton.Name = "dispPixelHsvButton";
            this.dispPixelHsvButton.Size = new System.Drawing.Size(103, 22);
            this.dispPixelHsvButton.Text = "hsv";
            this.dispPixelHsvButton.Click += new System.EventHandler(this.ChangePixelColorSpace);
            // 
            // dispPixelRgbButton
            // 
            this.dispPixelRgbButton.Name = "dispPixelRgbButton";
            this.dispPixelRgbButton.Size = new System.Drawing.Size(103, 22);
            this.dispPixelRgbButton.Text = "rgb";
            this.dispPixelRgbButton.Click += new System.EventHandler(this.ChangePixelColorSpace);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // zoomRatioLabel
            // 
            this.zoomRatioLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.zoomRatioLabel.AutoSize = false;
            this.zoomRatioLabel.AutoToolTip = false;
            this.zoomRatioLabel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoom100Button});
            this.zoomRatioLabel.Image = ((System.Drawing.Image)(resources.GetObject("zoomRatioLabel.Image")));
            this.zoomRatioLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.zoomRatioLabel.ImageTransparentColor = System.Drawing.Color.White;
            this.zoomRatioLabel.Name = "zoomRatioLabel";
            this.zoomRatioLabel.Size = new System.Drawing.Size(180, 22);
            this.zoomRatioLabel.Text = "확대/축소: -";
            this.zoomRatioLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // zoom100Button
            // 
            this.zoom100Button.Name = "zoom100Button";
            this.zoom100Button.Size = new System.Drawing.Size(109, 22);
            this.zoom100Button.Text = "100 %";
            this.zoom100Button.Click += new System.EventHandler(this.zoom100Button_Click);
            // 
            // fastRunIconBar
            // 
            this.fastRunIconBar.AutoSize = false;
            this.fastRunIconBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripSeparator4,
            this.selectButton,
            this.moveButton,
            this.rotateButton,
            this.fitButton,
            this.toolStripSeparator5,
            this.AddLineButton,
            this.DisplayLineProfileButton,
            this.toolStripSeparator7,
            this.AddRectButton,
            this.cutSaveButton,
            this.cutImageButton,
            this.DisplayHistogramButton,
            this.DisplayColorSpaceButton,
            this.toolStripSeparator6});
            this.fastRunIconBar.Location = new System.Drawing.Point(0, 0);
            this.fastRunIconBar.Name = "fastRunIconBar";
            this.fastRunIconBar.Size = new System.Drawing.Size(1061, 37);
            this.fastRunIconBar.TabIndex = 4;
            this.fastRunIconBar.Text = "toolStrip2";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nearestNeighborItem,
            this.lowItem,
            this.highItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(91, 34);
            this.toolStripSplitButton1.Text = "영상 보간";
            // 
            // nearestNeighborItem
            // 
            this.nearestNeighborItem.Checked = true;
            this.nearestNeighborItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nearestNeighborItem.Name = "nearestNeighborItem";
            this.nearestNeighborItem.Size = new System.Drawing.Size(168, 22);
            this.nearestNeighborItem.Tag = "";
            this.nearestNeighborItem.Text = "Nearest Neighbor";
            this.nearestNeighborItem.Click += new System.EventHandler(this.ChangeInterpolationType);
            // 
            // lowItem
            // 
            this.lowItem.Name = "lowItem";
            this.lowItem.Size = new System.Drawing.Size(168, 22);
            this.lowItem.Tag = "1";
            this.lowItem.Text = "Low";
            this.lowItem.Click += new System.EventHandler(this.ChangeInterpolationType);
            // 
            // highItem
            // 
            this.highItem.Name = "highItem";
            this.highItem.Size = new System.Drawing.Size(168, 22);
            this.highItem.Tag = "2";
            this.highItem.Text = "High";
            this.highItem.Click += new System.EventHandler(this.ChangeInterpolationType);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 37);
            // 
            // selectButton
            // 
            this.selectButton.AutoSize = false;
            this.selectButton.Image = ((System.Drawing.Image)(resources.GetObject("selectButton.Image")));
            this.selectButton.ImageTransparentColor = System.Drawing.Color.White;
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(75, 30);
            this.selectButton.Text = "선택";
            this.selectButton.ToolTipText = "도형 선택";
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // moveButton
            // 
            this.moveButton.AutoSize = false;
            this.moveButton.Image = ((System.Drawing.Image)(resources.GetObject("moveButton.Image")));
            this.moveButton.ImageTransparentColor = System.Drawing.Color.White;
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(75, 30);
            this.moveButton.Text = "이동";
            this.moveButton.ToolTipText = "영상 이동";
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // rotateButton
            // 
            this.rotateButton.AutoSize = false;
            this.rotateButton.Image = ((System.Drawing.Image)(resources.GetObject("rotateButton.Image")));
            this.rotateButton.ImageTransparentColor = System.Drawing.Color.White;
            this.rotateButton.Name = "rotateButton";
            this.rotateButton.Size = new System.Drawing.Size(75, 30);
            this.rotateButton.Text = "회전";
            this.rotateButton.ToolTipText = "영상을 시계 반대방향으로 회전";
            this.rotateButton.Click += new System.EventHandler(this.rotateButton_Click);
            // 
            // fitButton
            // 
            this.fitButton.AutoSize = false;
            this.fitButton.Image = ((System.Drawing.Image)(resources.GetObject("fitButton.Image")));
            this.fitButton.ImageTransparentColor = System.Drawing.Color.White;
            this.fitButton.Name = "fitButton";
            this.fitButton.Size = new System.Drawing.Size(75, 30);
            this.fitButton.Text = "맞추기";
            this.fitButton.ToolTipText = "영상을 화면 중심으로 맞춤";
            this.fitButton.Click += new System.EventHandler(this.fitButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 37);
            // 
            // AddLineButton
            // 
            this.AddLineButton.AutoSize = false;
            this.AddLineButton.Image = ((System.Drawing.Image)(resources.GetObject("AddLineButton.Image")));
            this.AddLineButton.ImageTransparentColor = System.Drawing.Color.White;
            this.AddLineButton.Name = "AddLineButton";
            this.AddLineButton.Size = new System.Drawing.Size(75, 30);
            this.AddLineButton.Text = "직선";
            this.AddLineButton.ToolTipText = "직선 추가";
            this.AddLineButton.Click += new System.EventHandler(this.AddLineButton_Click);
            // 
            // DisplayLineProfileButton
            // 
            this.DisplayLineProfileButton.AutoSize = false;
            this.DisplayLineProfileButton.Image = ((System.Drawing.Image)(resources.GetObject("DisplayLineProfileButton.Image")));
            this.DisplayLineProfileButton.ImageTransparentColor = System.Drawing.Color.White;
            this.DisplayLineProfileButton.Name = "DisplayLineProfileButton";
            this.DisplayLineProfileButton.Size = new System.Drawing.Size(100, 30);
            this.DisplayLineProfileButton.Text = "라인프로파일";
            this.DisplayLineProfileButton.ToolTipText = "라인프로파일 보기";
            this.DisplayLineProfileButton.Click += new System.EventHandler(this.DisplayLineProfileButton_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 37);
            // 
            // AddRectButton
            // 
            this.AddRectButton.AutoSize = false;
            this.AddRectButton.Image = ((System.Drawing.Image)(resources.GetObject("AddRectButton.Image")));
            this.AddRectButton.ImageTransparentColor = System.Drawing.Color.White;
            this.AddRectButton.Name = "AddRectButton";
            this.AddRectButton.Size = new System.Drawing.Size(75, 30);
            this.AddRectButton.Text = "사각형";
            this.AddRectButton.ToolTipText = "사각형 추가";
            this.AddRectButton.Click += new System.EventHandler(this.AddRectButton_Click);
            // 
            // DisplayHistogramButton
            // 
            this.DisplayHistogramButton.AutoSize = false;
            this.DisplayHistogramButton.Image = ((System.Drawing.Image)(resources.GetObject("DisplayHistogramButton.Image")));
            this.DisplayHistogramButton.ImageTransparentColor = System.Drawing.Color.White;
            this.DisplayHistogramButton.Name = "DisplayHistogramButton";
            this.DisplayHistogramButton.Size = new System.Drawing.Size(100, 30);
            this.DisplayHistogramButton.Text = "히스토그램";
            this.DisplayHistogramButton.ToolTipText = "히스토그램 보기";
            this.DisplayHistogramButton.Click += new System.EventHandler(this.DisplayHistogramButton_Click);
            // 
            // DisplayColorSpaceButton
            // 
            this.DisplayColorSpaceButton.AutoSize = false;
            this.DisplayColorSpaceButton.Image = ((System.Drawing.Image)(resources.GetObject("DisplayColorSpaceButton.Image")));
            this.DisplayColorSpaceButton.ImageTransparentColor = System.Drawing.Color.White;
            this.DisplayColorSpaceButton.Name = "DisplayColorSpaceButton";
            this.DisplayColorSpaceButton.Size = new System.Drawing.Size(75, 30);
            this.DisplayColorSpaceButton.Text = "색분포";
            this.DisplayColorSpaceButton.ToolTipText = "색분포 보기";
            this.DisplayColorSpaceButton.Click += new System.EventHandler(this.DisplayColorSpaceButton_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 37);
            // 
            // fileInfoPanel
            // 
            this.fileInfoPanel.BackColor = System.Drawing.Color.White;
            this.fileInfoPanel.Controls.Add(this.keepPrePosCheckBox);
            this.fileInfoPanel.Controls.Add(this.nextButton);
            this.fileInfoPanel.Controls.Add(this.fileNameLabel);
            this.fileInfoPanel.Controls.Add(this.previousButton);
            this.fileInfoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.fileInfoPanel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.fileInfoPanel.Location = new System.Drawing.Point(0, 37);
            this.fileInfoPanel.Name = "fileInfoPanel";
            this.fileInfoPanel.Size = new System.Drawing.Size(1061, 25);
            this.fileInfoPanel.TabIndex = 5;
            // 
            // keepPrePosCheckBox
            // 
            this.keepPrePosCheckBox.AutoSize = true;
            this.keepPrePosCheckBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.keepPrePosCheckBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.keepPrePosCheckBox.Location = new System.Drawing.Point(927, 0);
            this.keepPrePosCheckBox.Name = "keepPrePosCheckBox";
            this.keepPrePosCheckBox.Size = new System.Drawing.Size(134, 25);
            this.keepPrePosCheckBox.TabIndex = 8;
            this.keepPrePosCheckBox.Text = "이전 영상 비율 유지";
            this.keepPrePosCheckBox.UseVisualStyleBackColor = true;
            // 
            // nextButton
            // 
            this.nextButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextButton.Location = new System.Drawing.Point(30, 1);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(23, 23);
            this.nextButton.TabIndex = 7;
            this.nextButton.Text = ">";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.ChangePreviousNextImage);
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.fileNameLabel.Location = new System.Drawing.Point(60, 3);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(0, 17);
            this.fileNameLabel.TabIndex = 0;
            // 
            // previousButton
            // 
            this.previousButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.previousButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previousButton.Location = new System.Drawing.Point(3, 1);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(23, 23);
            this.previousButton.TabIndex = 6;
            this.previousButton.TabStop = false;
            this.previousButton.Text = "<";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.ChangePreviousNextImage);
            // 
            // errorLabel
            // 
            this.errorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errorLabel.AutoSize = true;
            this.errorLabel.BackColor = System.Drawing.Color.Black;
            this.errorLabel.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.errorLabel.ForeColor = System.Drawing.Color.White;
            this.errorLabel.Location = new System.Drawing.Point(50, 186);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 37);
            this.errorLabel.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(297, 220);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(150, 100);
            this.splitContainer1.TabIndex = 7;
            this.splitContainer1.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer2.Size = new System.Drawing.Size(96, 100);
            this.splitContainer2.SplitterDistance = 32;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.TabStop = false;
            // 
            // roiDataGridView
            // 
            this.roiDataGridView.AllowUserToAddRows = false;
            this.roiDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.roiDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.roiDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.roiDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.roiDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.roiDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.roiDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.del,
            this.x,
            this.y,
            this.width,
            this.height});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.roiDataGridView.DefaultCellStyle = dataGridViewCellStyle7;
            this.roiDataGridView.Location = new System.Drawing.Point(173, 341);
            this.roiDataGridView.Name = "roiDataGridView";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.roiDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.roiDataGridView.RowTemplate.Height = 23;
            this.roiDataGridView.Size = new System.Drawing.Size(152, 115);
            this.roiDataGridView.TabIndex = 8;
            this.roiDataGridView.TabStop = false;
            this.roiDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.roiDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.roiDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.roiDataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            this.roiDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.roiDataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            // 
            // del
            // 
            this.del.HeaderText = "";
            this.del.Name = "del";
            this.del.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // x
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.x.DefaultCellStyle = dataGridViewCellStyle3;
            this.x.FillWeight = 110F;
            this.x.HeaderText = "x";
            this.x.Name = "x";
            this.x.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // y
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.y.DefaultCellStyle = dataGridViewCellStyle4;
            this.y.FillWeight = 110F;
            this.y.HeaderText = "y";
            this.y.Name = "y";
            this.y.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // width
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.width.DefaultCellStyle = dataGridViewCellStyle5;
            this.width.FillWeight = 110F;
            this.width.HeaderText = "width";
            this.width.Name = "width";
            this.width.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // height
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.height.DefaultCellStyle = dataGridViewCellStyle6;
            this.height.FillWeight = 110F;
            this.height.HeaderText = "height";
            this.height.Name = "height";
            this.height.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lineDataGridView
            // 
            this.lineDataGridView.AllowUserToAddRows = false;
            this.lineDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.lineDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.lineDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lineDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.lineDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lineDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewButtonColumn1,
            this.x1,
            this.y1,
            this.x2,
            this.y2,
            this.length});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.lineDataGridView.DefaultCellStyle = dataGridViewCellStyle16;
            this.lineDataGridView.Location = new System.Drawing.Point(355, 341);
            this.lineDataGridView.Name = "lineDataGridView";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lineDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.lineDataGridView.RowTemplate.Height = 23;
            this.lineDataGridView.Size = new System.Drawing.Size(209, 115);
            this.lineDataGridView.TabIndex = 9;
            this.lineDataGridView.TabStop = false;
            this.lineDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.lineDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.lineDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.lineDataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            this.lineDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.lineDataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // x1
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.x1.DefaultCellStyle = dataGridViewCellStyle11;
            this.x1.FillWeight = 110F;
            this.x1.HeaderText = "x1";
            this.x1.Name = "x1";
            this.x1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // y1
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.y1.DefaultCellStyle = dataGridViewCellStyle12;
            this.y1.FillWeight = 110F;
            this.y1.HeaderText = "y1";
            this.y1.Name = "y1";
            this.y1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // x2
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.x2.DefaultCellStyle = dataGridViewCellStyle13;
            this.x2.FillWeight = 110F;
            this.x2.HeaderText = "x2";
            this.x2.Name = "x2";
            this.x2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // y2
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.y2.DefaultCellStyle = dataGridViewCellStyle14;
            this.y2.FillWeight = 110F;
            this.y2.HeaderText = "y2";
            this.y2.Name = "y2";
            this.y2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // length
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle15.Format = "#.#";
            dataGridViewCellStyle15.NullValue = null;
            this.length.DefaultCellStyle = dataGridViewCellStyle15;
            this.length.FillWeight = 110F;
            this.length.HeaderText = "길이";
            this.length.Name = "length";
            this.length.ReadOnly = true;
            this.length.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(50, 271);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            this.pictureBox1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pictureBox1_PreviewKeyDown);
            // 
            // cutImageButton
            // 
            this.cutImageButton.AutoSize = false;
            this.cutImageButton.Image = ((System.Drawing.Image)(resources.GetObject("cutImageButton.Image")));
            this.cutImageButton.ImageTransparentColor = System.Drawing.Color.White;
            this.cutImageButton.Name = "cutImageButton";
            this.cutImageButton.Size = new System.Drawing.Size(100, 30);
            this.cutImageButton.Text = "잘라내기";
            this.cutImageButton.ToolTipText = "히스토그램 보기";
            this.cutImageButton.Click += new System.EventHandler(this.CutImageButton_Click);
            // 
            // cutSaveButton
            // 
            this.cutSaveButton.AutoSize = false;
            this.cutSaveButton.Image = ((System.Drawing.Image)(resources.GetObject("cutSaveButton.Image")));
            this.cutSaveButton.ImageTransparentColor = System.Drawing.Color.White;
            this.cutSaveButton.Name = "cutSaveButton";
            this.cutSaveButton.Size = new System.Drawing.Size(100, 30);
            this.cutSaveButton.Text = "자른 후 저장";
            this.cutSaveButton.ToolTipText = "히스토그램 보기";
            this.cutSaveButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // ImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lineDataGridView);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.roiDataGridView);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.stateBar);
            this.Controls.Add(this.fileInfoPanel);
            this.Controls.Add(this.fastRunIconBar);
            this.Name = "ImageViewer";
            this.Size = new System.Drawing.Size(1061, 503);
            this.Load += new System.EventHandler(this.ImageViewer_Load);
            this.stateBar.ResumeLayout(false);
            this.stateBar.PerformLayout();
            this.fastRunIconBar.ResumeLayout(false);
            this.fastRunIconBar.PerformLayout();
            this.fileInfoPanel.ResumeLayout(false);
            this.fileInfoPanel.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.roiDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyPictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip stateBar;
        private System.Windows.Forms.ToolStripLabel imagePointLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton pixelValueLabel;
        private System.Windows.Forms.ToolStripSplitButton zoomRatioLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem zoom100Button;
        private System.Windows.Forms.ToolStrip fastRunIconBar;
        private System.Windows.Forms.ToolStripButton fitButton;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem nearestNeighborItem;
        private System.Windows.Forms.ToolStripMenuItem lowItem;
        private System.Windows.Forms.ToolStripMenuItem highItem;
        private System.Windows.Forms.ToolStripButton AddRectButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem dispPixelHsvButton;
        private System.Windows.Forms.ToolStripMenuItem dispPixelRgbButton;
        private System.Windows.Forms.Panel fileInfoPanel;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.CheckBox keepPrePosCheckBox;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView roiDataGridView;
        private System.Windows.Forms.ToolStripButton DisplayHistogramButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton AddLineButton;
        private System.Windows.Forms.ToolStripButton selectButton;
        private System.Windows.Forms.ToolStripButton moveButton;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView lineDataGridView;
        private System.Windows.Forms.ToolStripButton DisplayColorSpaceButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton DisplayLineProfileButton;
        private System.Windows.Forms.DataGridViewButtonColumn del;
        private System.Windows.Forms.DataGridViewTextBoxColumn x;
        private System.Windows.Forms.DataGridViewTextBoxColumn y;
        private System.Windows.Forms.DataGridViewTextBoxColumn width;
        private System.Windows.Forms.DataGridViewTextBoxColumn height;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn x1;
        private System.Windows.Forms.DataGridViewTextBoxColumn y1;
        private System.Windows.Forms.DataGridViewTextBoxColumn x2;
        private System.Windows.Forms.DataGridViewTextBoxColumn y2;
        private System.Windows.Forms.DataGridViewTextBoxColumn length;
        private System.Windows.Forms.ToolStripMenuItem dispPixelYCbCrButton;
        private System.Windows.Forms.ToolStripButton rotateButton;
        private System.Windows.Forms.ToolStripButton cutSaveButton;
        private System.Windows.Forms.ToolStripButton cutImageButton;
    }
}
