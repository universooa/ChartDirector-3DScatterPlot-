namespace ChartDirector로3DScatterPlot그리기
{
    partial class Form1
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.winChartViewer1 = new ChartDirector.WinChartViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.DrawFrameOnRotate = new System.Windows.Forms.CheckBox();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.PointerPB = new System.Windows.Forms.RadioButton();
            this.zoomInPB = new System.Windows.Forms.RadioButton();
            this.zoomOutPB = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.winChartViewer1)).BeginInit();
            this.SuspendLayout();
            // 
            // winChartViewer1
            // 
            this.winChartViewer1.Location = new System.Drawing.Point(171, 35);
            this.winChartViewer1.Name = "winChartViewer1";
            this.winChartViewer1.Size = new System.Drawing.Size(1229, 480);
 
            this.winChartViewer1.ViewPortChanged += new ChartDirector.WinViewPortEventHandler(this.winChartViewer1_ViewPortChanged);
            this.winChartViewer1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.winChartViewer1_MouseDown);
            this.winChartViewer1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.winChartViewer1_MouseMove);
            this.winChartViewer1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.winChartViewer1_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 62);
            this.button1.TabIndex = 1;
            this.button1.Text = "Open File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // DrawFrameOnRotate
            // 
            this.DrawFrameOnRotate.AutoSize = true;
            this.DrawFrameOnRotate.Location = new System.Drawing.Point(12, 4);
            this.DrawFrameOnRotate.Name = "DrawFrameOnRotate";
            this.DrawFrameOnRotate.Size = new System.Drawing.Size(231, 25);
            this.DrawFrameOnRotate.TabIndex = 2;
            this.DrawFrameOnRotate.Text = "Draw Frame On Rotate";
            this.DrawFrameOnRotate.UseVisualStyleBackColor = true;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 524);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(1438, 30);
            this.hScrollBar1.TabIndex = 3;
           // 
            // PointerPB
            // 
            this.PointerPB.AutoSize = true;
            this.PointerPB.Location = new System.Drawing.Point(13, 104);
            this.PointerPB.Name = "PointerPB";
            this.PointerPB.Size = new System.Drawing.Size(93, 25);
            this.PointerPB.TabIndex = 4;
            this.PointerPB.Text = "Pointer";
            this.PointerPB.UseVisualStyleBackColor = true;
            this.PointerPB.CheckedChanged += new System.EventHandler(this.pointerPB_CheckedChanged);
            // 
            // zoomInPB
            // 
            this.zoomInPB.AutoSize = true;
            this.zoomInPB.Location = new System.Drawing.Point(12, 136);
            this.zoomInPB.Name = "zoomInPB";
            this.zoomInPB.Size = new System.Drawing.Size(119, 25);
            this.zoomInPB.TabIndex = 5;
            this.zoomInPB.TabStop = true;
            this.zoomInPB.Text = "zoomInPB";
            this.zoomInPB.UseVisualStyleBackColor = true;
            this.zoomInPB.CheckedChanged += new System.EventHandler(this.zoomInPB_CheckedChanged);
            // 
            // zoomOutPB
            // 
            this.zoomOutPB.AutoSize = true;
            this.zoomOutPB.Location = new System.Drawing.Point(12, 168);
            this.zoomOutPB.Name = "zoomOutPB";
            this.zoomOutPB.Size = new System.Drawing.Size(137, 25);
            this.zoomOutPB.TabIndex = 6;
            this.zoomOutPB.TabStop = true;
            this.zoomOutPB.Text = "zoomOutPB";
            this.zoomOutPB.UseVisualStyleBackColor = true;
            this.zoomOutPB.CheckedChanged += new System.EventHandler(this.zoomOutPB_CheckedChanged);
            // 
            // Form1
            //  
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1438, 554);
            this.Controls.Add(this.zoomOutPB);
            this.Controls.Add(this.zoomInPB);
            this.Controls.Add(this.PointerPB);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.DrawFrameOnRotate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.winChartViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.winChartViewer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChartDirector.WinChartViewer winChartViewer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox DrawFrameOnRotate;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.RadioButton PointerPB;
        private System.Windows.Forms.RadioButton zoomInPB;
        private System.Windows.Forms.RadioButton zoomOutPB;
    }
}

