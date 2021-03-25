
namespace Hex2Bin
{
    partial class frMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frMain));
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenHex = new System.Windows.Forms.Button();
            this.tbHexPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbBinPath = new System.Windows.Forms.TextBox();
            this.btnOut = new System.Windows.Forms.Button();
            this.openHexDlg = new System.Windows.Forms.OpenFileDialog();
            this.saveBinDlg = new System.Windows.Forms.SaveFileDialog();
            this.pbConvert = new System.Windows.Forms.ProgressBar();
            this.btnConvert = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.MergeBoot = new System.Windows.Forms.CheckBox();
            this.SaveMergeHex = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hex文件";
            // 
            // btnOpenHex
            // 
            this.btnOpenHex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenHex.Location = new System.Drawing.Point(430, 33);
            this.btnOpenHex.Name = "btnOpenHex";
            this.btnOpenHex.Size = new System.Drawing.Size(62, 23);
            this.btnOpenHex.TabIndex = 1;
            this.btnOpenHex.Text = "打开";
            this.btnOpenHex.UseVisualStyleBackColor = true;
            this.btnOpenHex.Click += new System.EventHandler(this.btnOpenHex_Click);
            // 
            // tbHexPath
            // 
            this.tbHexPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHexPath.Location = new System.Drawing.Point(64, 34);
            this.tbHexPath.Name = "tbHexPath";
            this.tbHexPath.Size = new System.Drawing.Size(349, 21);
            this.tbHexPath.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Bin文件";
            // 
            // tbBinPath
            // 
            this.tbBinPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBinPath.Location = new System.Drawing.Point(64, 72);
            this.tbBinPath.Name = "tbBinPath";
            this.tbBinPath.Size = new System.Drawing.Size(349, 21);
            this.tbBinPath.TabIndex = 2;
            // 
            // btnOut
            // 
            this.btnOut.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOut.Location = new System.Drawing.Point(430, 71);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(62, 23);
            this.btnOut.TabIndex = 2;
            this.btnOut.Text = "输出";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // openHexDlg
            // 
            this.openHexDlg.Filter = "HEX文件(*.hex)|*.hex";
            this.openHexDlg.Title = "选择需要转换的HEX文件";
            // 
            // saveBinDlg
            // 
            this.saveBinDlg.Filter = "BIN文件(*.Bin)|*.Bin";
            // 
            // pbConvert
            // 
            this.pbConvert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbConvert.Location = new System.Drawing.Point(64, 112);
            this.pbConvert.Name = "pbConvert";
            this.pbConvert.Size = new System.Drawing.Size(349, 21);
            this.pbConvert.Step = 1;
            this.pbConvert.TabIndex = 3;
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvert.Location = new System.Drawing.Point(430, 111);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(62, 23);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "转换";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "转换进度";
            // 
            // MergeBoot
            // 
            this.MergeBoot.AutoSize = true;
            this.MergeBoot.Location = new System.Drawing.Point(13, 12);
            this.MergeBoot.Name = "MergeBoot";
            this.MergeBoot.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MergeBoot.Size = new System.Drawing.Size(96, 16);
            this.MergeBoot.TabIndex = 7;
            this.MergeBoot.Text = "合并Boot.hex";
            this.MergeBoot.UseVisualStyleBackColor = true;
            this.MergeBoot.CheckedChanged += new System.EventHandler(this.MergeBoot_CheckedChanged);
            // 
            // SaveMergeHex
            // 
            this.SaveMergeHex.AutoSize = true;
            this.SaveMergeHex.Location = new System.Drawing.Point(127, 12);
            this.SaveMergeHex.Name = "SaveMergeHex";
            this.SaveMergeHex.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SaveMergeHex.Size = new System.Drawing.Size(162, 16);
            this.SaveMergeHex.TabIndex = 8;
            this.SaveMergeHex.Text = "输出合并Hex文件至原路径";
            this.SaveMergeHex.UseVisualStyleBackColor = true;
            this.SaveMergeHex.Visible = false;
            this.SaveMergeHex.CheckedChanged += new System.EventHandler(this.SaveMergeHex_CheckedChanged);
            // 
            // frMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 145);
            this.Controls.Add(this.SaveMergeHex);
            this.Controls.Add(this.MergeBoot);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.pbConvert);
            this.Controls.Add(this.tbBinPath);
            this.Controls.Add(this.tbHexPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.btnOpenHex);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ANSO_Hex2Bin";
            this.Load += new System.EventHandler(this.frMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frMain_DragEnter);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frMain_BtnPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenHex;
        private System.Windows.Forms.TextBox tbHexPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbBinPath;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.OpenFileDialog openHexDlg;
        private System.Windows.Forms.SaveFileDialog saveBinDlg;
        private System.Windows.Forms.ProgressBar pbConvert;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox MergeBoot;
        private System.Windows.Forms.CheckBox SaveMergeHex;
    }
}

