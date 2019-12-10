namespace Task12
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listFrom = new System.Windows.Forms.ComboBox();
            this.listTo = new System.Windows.Forms.ComboBox();
            this.labelResult1 = new System.Windows.Forms.Label();
            this.labelResult2 = new System.Windows.Forms.Label();
            this.boxResults = new System.Windows.Forms.GroupBox();
            this.loadingStatus = new System.Windows.Forms.ProgressBar();
            this.boxFirst = new System.Windows.Forms.GroupBox();
            this.boxSecond = new System.Windows.Forms.GroupBox();
            this.boxResults.SuspendLayout();
            this.boxFirst.SuspendLayout();
            this.boxSecond.SuspendLayout();
            this.SuspendLayout();
            // 
            // listFrom
            // 
            this.listFrom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listFrom.Enabled = false;
            this.listFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listFrom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listFrom.FormattingEnabled = true;
            this.listFrom.Location = new System.Drawing.Point(3, 23);
            this.listFrom.Name = "listFrom";
            this.listFrom.Size = new System.Drawing.Size(279, 28);
            this.listFrom.TabIndex = 2;
            this.listFrom.Text = "Choose the currency...";
            this.listFrom.SelectedIndexChanged += new System.EventHandler(this.List_SelectedIndexChanged);
            // 
            // listTo
            // 
            this.listTo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listTo.Enabled = false;
            this.listTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listTo.FormattingEnabled = true;
            this.listTo.Location = new System.Drawing.Point(3, 23);
            this.listTo.Name = "listTo";
            this.listTo.Size = new System.Drawing.Size(279, 28);
            this.listTo.TabIndex = 2;
            this.listTo.Text = "Choose the currency...";
            // 
            // labelResult1
            // 
            this.labelResult1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelResult1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelResult1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelResult1.Location = new System.Drawing.Point(6, 26);
            this.labelResult1.Name = "labelResult1";
            this.labelResult1.Size = new System.Drawing.Size(51, 20);
            this.labelResult1.TabIndex = 3;
            this.labelResult1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelResult2
            // 
            this.labelResult2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelResult2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelResult2.Location = new System.Drawing.Point(6, 54);
            this.labelResult2.Name = "labelResult2";
            this.labelResult2.Size = new System.Drawing.Size(51, 20);
            this.labelResult2.TabIndex = 3;
            // 
            // boxResults
            // 
            this.boxResults.AutoSize = true;
            this.boxResults.Controls.Add(this.loadingStatus);
            this.boxResults.Controls.Add(this.labelResult1);
            this.boxResults.Controls.Add(this.labelResult2);
            this.boxResults.Dock = System.Windows.Forms.DockStyle.Right;
            this.boxResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boxResults.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.boxResults.Location = new System.Drawing.Point(285, 0);
            this.boxResults.MinimumSize = new System.Drawing.Size(270, 0);
            this.boxResults.Name = "boxResults";
            this.boxResults.Size = new System.Drawing.Size(271, 108);
            this.boxResults.TabIndex = 5;
            this.boxResults.TabStop = false;
            this.boxResults.Text = "Results";
            // 
            // loadingStatus
            // 
            this.loadingStatus.Location = new System.Drawing.Point(6, 82);
            this.loadingStatus.Maximum = 10;
            this.loadingStatus.Name = "loadingStatus";
            this.loadingStatus.Size = new System.Drawing.Size(259, 20);
            this.loadingStatus.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.loadingStatus.TabIndex = 4;
            this.loadingStatus.Value = 10;
            // 
            // boxFirst
            // 
            this.boxFirst.AutoSize = true;
            this.boxFirst.Controls.Add(this.listFrom);
            this.boxFirst.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boxFirst.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.boxFirst.Location = new System.Drawing.Point(0, 0);
            this.boxFirst.Name = "boxFirst";
            this.boxFirst.Size = new System.Drawing.Size(285, 54);
            this.boxFirst.TabIndex = 6;
            this.boxFirst.TabStop = false;
            this.boxFirst.Text = "First currency";
            // 
            // boxSecond
            // 
            this.boxSecond.AutoSize = true;
            this.boxSecond.Controls.Add(this.listTo);
            this.boxSecond.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.boxSecond.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boxSecond.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.boxSecond.Location = new System.Drawing.Point(0, 54);
            this.boxSecond.Name = "boxSecond";
            this.boxSecond.Size = new System.Drawing.Size(285, 54);
            this.boxSecond.TabIndex = 7;
            this.boxSecond.TabStop = false;
            this.boxSecond.Text = "Second currency";
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(556, 108);
            this.Controls.Add(this.boxSecond);
            this.Controls.Add(this.boxFirst);
            this.Controls.Add(this.boxResults);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(574, 155);
            this.MinimumSize = new System.Drawing.Size(574, 155);
            this.Name = "MainForm";
            this.Text = "Currency Converter";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.boxResults.ResumeLayout(false);
            this.boxFirst.ResumeLayout(false);
            this.boxSecond.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ComboBox listFrom;
        private System.Windows.Forms.ComboBox listTo;
        private System.Windows.Forms.Label labelResult1;
        private System.Windows.Forms.Label labelResult2;
        private System.Windows.Forms.GroupBox boxResults;
        private System.Windows.Forms.GroupBox boxFirst;
        private System.Windows.Forms.GroupBox boxSecond;
        private System.Windows.Forms.ProgressBar loadingStatus;
    }
}

