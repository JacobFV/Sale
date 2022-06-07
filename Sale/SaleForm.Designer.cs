namespace Sale
{
    partial class SaleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textInput = new System.Windows.Forms.TextBox();
            this.SaleTitleLabel = new System.Windows.Forms.Label();
            this.subtitle = new System.Windows.Forms.Label();
            this.translateGoButton = new System.Windows.Forms.Button();
            this.outputText = new System.Windows.Forms.TextBox();
            this.addVerbButton = new System.Windows.Forms.Label();
            this.iLabel = new System.Windows.Forms.Label();
            this.oLabel = new System.Windows.Forms.Label();
            this.uLabel = new System.Windows.Forms.Label();
            this.nLabel = new System.Windows.Forms.Label();
            this.eLabel = new System.Windows.Forms.Label();
            this.aLabel = new System.Windows.Forms.Label();
            this.properNouns = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textInput
            // 
            this.textInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textInput.Location = new System.Drawing.Point(12, 119);
            this.textInput.Name = "textInput";
            this.textInput.Size = new System.Drawing.Size(523, 38);
            this.textInput.TabIndex = 0;
            this.textInput.WordWrap = false;
            this.textInput.Enter += new System.EventHandler(this.textInput_Enter);
            this.textInput.Leave += new System.EventHandler(this.textInput_Leave);
            // 
            // SaleTitleLabel
            // 
            this.SaleTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaleTitleLabel.Font = new System.Drawing.Font("Calibri", 48F);
            this.SaleTitleLabel.Location = new System.Drawing.Point(12, 9);
            this.SaleTitleLabel.Name = "SaleTitleLabel";
            this.SaleTitleLabel.Size = new System.Drawing.Size(615, 66);
            this.SaleTitleLabel.TabIndex = 3;
            this.SaleTitleLabel.Text = "Sale";
            this.SaleTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // subtitle
            // 
            this.subtitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subtitle.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.subtitle.Location = new System.Drawing.Point(12, 75);
            this.subtitle.Name = "subtitle";
            this.subtitle.Size = new System.Drawing.Size(615, 25);
            this.subtitle.TabIndex = 4;
            this.subtitle.Text = "ENTER TEXT BELOW";
            this.subtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // translateGoButton
            // 
            this.translateGoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.translateGoButton.Font = new System.Drawing.Font("Calibri Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.translateGoButton.Location = new System.Drawing.Point(541, 119);
            this.translateGoButton.Name = "translateGoButton";
            this.translateGoButton.Size = new System.Drawing.Size(75, 38);
            this.translateGoButton.TabIndex = 5;
            this.translateGoButton.Text = "Go";
            this.translateGoButton.UseVisualStyleBackColor = true;
            this.translateGoButton.Click += new System.EventHandler(this.translateGoButton_Click);
            // 
            // outputText
            // 
            this.outputText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outputText.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputText.Location = new System.Drawing.Point(12, 173);
            this.outputText.Multiline = true;
            this.outputText.Name = "outputText";
            this.outputText.ReadOnly = true;
            this.outputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputText.Size = new System.Drawing.Size(604, 256);
            this.outputText.TabIndex = 6;
            this.outputText.WordWrap = false;
            // 
            // addVerbButton
            // 
            this.addVerbButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addVerbButton.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Underline);
            this.addVerbButton.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.addVerbButton.Location = new System.Drawing.Point(549, 9);
            this.addVerbButton.Name = "addVerbButton";
            this.addVerbButton.Size = new System.Drawing.Size(67, 17);
            this.addVerbButton.TabIndex = 7;
            this.addVerbButton.Text = "VERBS";
            this.addVerbButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addVerbButton.Click += new System.EventHandler(this.addVerbButton_Click);
            // 
            // iLabel
            // 
            this.iLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iLabel.AutoSize = true;
            this.iLabel.BackColor = System.Drawing.Color.White;
            this.iLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.iLabel.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.iLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(82)))), ((int)(((byte)(102)))));
            this.iLabel.Location = new System.Drawing.Point(428, 127);
            this.iLabel.Name = "iLabel";
            this.iLabel.Size = new System.Drawing.Size(14, 23);
            this.iLabel.TabIndex = 8;
            this.iLabel.Text = "í";
            this.iLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.iLabel.Visible = false;
            this.iLabel.Click += new System.EventHandler(this.accentLabel_Click);
            // 
            // oLabel
            // 
            this.oLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.oLabel.AutoSize = true;
            this.oLabel.BackColor = System.Drawing.Color.White;
            this.oLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.oLabel.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.oLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(82)))), ((int)(((byte)(102)))));
            this.oLabel.Location = new System.Drawing.Point(474, 127);
            this.oLabel.Name = "oLabel";
            this.oLabel.Size = new System.Drawing.Size(20, 23);
            this.oLabel.TabIndex = 9;
            this.oLabel.Text = "ó";
            this.oLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.oLabel.Visible = false;
            this.oLabel.Click += new System.EventHandler(this.accentLabel_Click);
            // 
            // uLabel
            // 
            this.uLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uLabel.AutoSize = true;
            this.uLabel.BackColor = System.Drawing.Color.White;
            this.uLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.uLabel.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.uLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(82)))), ((int)(((byte)(102)))));
            this.uLabel.Location = new System.Drawing.Point(500, 127);
            this.uLabel.Name = "uLabel";
            this.uLabel.Size = new System.Drawing.Size(20, 23);
            this.uLabel.TabIndex = 10;
            this.uLabel.Text = "ú";
            this.uLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uLabel.Visible = false;
            this.uLabel.Click += new System.EventHandler(this.accentLabel_Click);
            // 
            // nLabel
            // 
            this.nLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nLabel.AutoSize = true;
            this.nLabel.BackColor = System.Drawing.Color.White;
            this.nLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.nLabel.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.nLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(82)))), ((int)(((byte)(102)))));
            this.nLabel.Location = new System.Drawing.Point(448, 127);
            this.nLabel.Name = "nLabel";
            this.nLabel.Size = new System.Drawing.Size(20, 23);
            this.nLabel.TabIndex = 11;
            this.nLabel.Text = "ñ";
            this.nLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.nLabel.Visible = false;
            this.nLabel.Click += new System.EventHandler(this.accentLabel_Click);
            // 
            // eLabel
            // 
            this.eLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.eLabel.AutoSize = true;
            this.eLabel.BackColor = System.Drawing.Color.White;
            this.eLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.eLabel.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.eLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(82)))), ((int)(((byte)(102)))));
            this.eLabel.Location = new System.Drawing.Point(403, 127);
            this.eLabel.Name = "eLabel";
            this.eLabel.Size = new System.Drawing.Size(19, 23);
            this.eLabel.TabIndex = 12;
            this.eLabel.Text = "é";
            this.eLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.eLabel.Visible = false;
            this.eLabel.Click += new System.EventHandler(this.accentLabel_Click);
            // 
            // aLabel
            // 
            this.aLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aLabel.AutoSize = true;
            this.aLabel.BackColor = System.Drawing.Color.White;
            this.aLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.aLabel.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.aLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(82)))), ((int)(((byte)(102)))));
            this.aLabel.Location = new System.Drawing.Point(378, 127);
            this.aLabel.Name = "aLabel";
            this.aLabel.Size = new System.Drawing.Size(19, 23);
            this.aLabel.TabIndex = 13;
            this.aLabel.Text = "á";
            this.aLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.aLabel.Visible = false;
            this.aLabel.Click += new System.EventHandler(this.accentLabel_Click);
            // 
            // properNouns
            // 
            this.properNouns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.properNouns.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Underline);
            this.properNouns.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.properNouns.Location = new System.Drawing.Point(541, 31);
            this.properNouns.Name = "properNouns";
            this.properNouns.Size = new System.Drawing.Size(75, 22);
            this.properNouns.TabIndex = 14;
            this.properNouns.Text = "NOUNS";
            this.properNouns.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.properNouns.Click += new System.EventHandler(this.properNouns_Click);
            // 
            // SaleForm
            // 
            this.AcceptButton = this.translateGoButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 441);
            this.Controls.Add(this.properNouns);
            this.Controls.Add(this.aLabel);
            this.Controls.Add(this.eLabel);
            this.Controls.Add(this.nLabel);
            this.Controls.Add(this.uLabel);
            this.Controls.Add(this.oLabel);
            this.Controls.Add(this.iLabel);
            this.Controls.Add(this.addVerbButton);
            this.Controls.Add(this.outputText);
            this.Controls.Add(this.translateGoButton);
            this.Controls.Add(this.subtitle);
            this.Controls.Add(this.SaleTitleLabel);
            this.Controls.Add(this.textInput);
            this.MinimumSize = new System.Drawing.Size(320, 320);
            this.Name = "SaleForm";
            this.Text = "Sale";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textInput;
        private System.Windows.Forms.Label SaleTitleLabel;
        private System.Windows.Forms.Label subtitle;
        private System.Windows.Forms.Button translateGoButton;
        private System.Windows.Forms.TextBox outputText;
        private System.Windows.Forms.Label addVerbButton;
        private System.Windows.Forms.Label iLabel;
        private System.Windows.Forms.Label oLabel;
        private System.Windows.Forms.Label uLabel;
        private System.Windows.Forms.Label nLabel;
        private System.Windows.Forms.Label eLabel;
        private System.Windows.Forms.Label aLabel;
        private System.Windows.Forms.Label properNouns;
    }
}

