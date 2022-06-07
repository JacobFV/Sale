namespace Sale
{
    partial class addElement
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
            this.add = new System.Windows.Forms.Button();
            this.spanishPlural = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.feminine = new System.Windows.Forms.RadioButton();
            this.masculine = new System.Windows.Forms.RadioButton();
            this.firstPerson = new System.Windows.Forms.RadioButton();
            this.thirdPerson = new System.Windows.Forms.RadioButton();
            this.secondPerson = new System.Windows.Forms.RadioButton();
            this.groupBoxPerson = new System.Windows.Forms.GroupBox();
            this.groupBoxGender = new System.Windows.Forms.GroupBox();
            this.englishPlural = new System.Windows.Forms.TextBox();
            this.englishSingular = new System.Windows.Forms.TextBox();
            this.spanishSingular = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxIOP = new System.Windows.Forms.CheckBox();
            this.checkBoxDOP = new System.Windows.Forms.CheckBox();
            this.checkBoxSP = new System.Windows.Forms.CheckBox();
            this.groupBoxPerson.SuspendLayout();
            this.groupBoxGender.SuspendLayout();
            this.SuspendLayout();
            // 
            // add
            // 
            this.add.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.add.Enabled = false;
            this.add.Location = new System.Drawing.Point(148, 193);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 27);
            this.add.TabIndex = 0;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // spanishPlural
            // 
            this.spanishPlural.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.spanishPlural.Location = new System.Drawing.Point(319, 194);
            this.spanishPlural.Name = "spanishPlural";
            this.spanishPlural.Size = new System.Drawing.Size(120, 27);
            this.spanishPlural.TabIndex = 1;
            this.spanishPlural.TextChanged += new System.EventHandler(this.spanishPlural_TextChanged);
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label.Font = new System.Drawing.Font("Calibri", 14F);
            this.label.Location = new System.Drawing.Point(12, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(414, 46);
            this.label.TabIndex = 2;
            this.label.Text = "Add Pronoun";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // feminine
            // 
            this.feminine.AutoSize = true;
            this.feminine.Location = new System.Drawing.Point(10, 55);
            this.feminine.Name = "feminine";
            this.feminine.Size = new System.Drawing.Size(84, 23);
            this.feminine.TabIndex = 3;
            this.feminine.Text = "feminine";
            this.feminine.UseVisualStyleBackColor = true;
            // 
            // masculine
            // 
            this.masculine.AutoSize = true;
            this.masculine.Checked = true;
            this.masculine.Location = new System.Drawing.Point(10, 29);
            this.masculine.Name = "masculine";
            this.masculine.Size = new System.Drawing.Size(93, 23);
            this.masculine.TabIndex = 4;
            this.masculine.TabStop = true;
            this.masculine.Text = "masculine";
            this.masculine.UseVisualStyleBackColor = true;
            // 
            // firstPerson
            // 
            this.firstPerson.AutoSize = true;
            this.firstPerson.Location = new System.Drawing.Point(6, 26);
            this.firstPerson.Name = "firstPerson";
            this.firstPerson.Size = new System.Drawing.Size(103, 23);
            this.firstPerson.TabIndex = 6;
            this.firstPerson.Text = "1st singular";
            this.firstPerson.UseVisualStyleBackColor = true;
            // 
            // thirdPerson
            // 
            this.thirdPerson.AutoSize = true;
            this.thirdPerson.Checked = true;
            this.thirdPerson.Location = new System.Drawing.Point(6, 84);
            this.thirdPerson.Name = "thirdPerson";
            this.thirdPerson.Size = new System.Drawing.Size(104, 23);
            this.thirdPerson.TabIndex = 8;
            this.thirdPerson.TabStop = true;
            this.thirdPerson.Text = "3rd singular";
            this.thirdPerson.UseVisualStyleBackColor = true;
            // 
            // secondPerson
            // 
            this.secondPerson.AutoSize = true;
            this.secondPerson.Location = new System.Drawing.Point(6, 55);
            this.secondPerson.Name = "secondPerson";
            this.secondPerson.Size = new System.Drawing.Size(107, 23);
            this.secondPerson.TabIndex = 10;
            this.secondPerson.Text = "2nd singular";
            this.secondPerson.UseVisualStyleBackColor = true;
            // 
            // groupBoxPerson
            // 
            this.groupBoxPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxPerson.Controls.Add(this.firstPerson);
            this.groupBoxPerson.Controls.Add(this.secondPerson);
            this.groupBoxPerson.Controls.Add(this.thirdPerson);
            this.groupBoxPerson.Location = new System.Drawing.Point(12, 58);
            this.groupBoxPerson.Name = "groupBoxPerson";
            this.groupBoxPerson.Size = new System.Drawing.Size(120, 151);
            this.groupBoxPerson.TabIndex = 11;
            this.groupBoxPerson.TabStop = false;
            this.groupBoxPerson.Text = "person";
            // 
            // groupBoxGender
            // 
            this.groupBoxGender.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxGender.Controls.Add(this.masculine);
            this.groupBoxGender.Controls.Add(this.feminine);
            this.groupBoxGender.Location = new System.Drawing.Point(138, 58);
            this.groupBoxGender.Name = "groupBoxGender";
            this.groupBoxGender.Size = new System.Drawing.Size(109, 124);
            this.groupBoxGender.TabIndex = 12;
            this.groupBoxGender.TabStop = false;
            this.groupBoxGender.Text = "gender";
            // 
            // englishPlural
            // 
            this.englishPlural.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.englishPlural.Location = new System.Drawing.Point(319, 128);
            this.englishPlural.Name = "englishPlural";
            this.englishPlural.Size = new System.Drawing.Size(120, 27);
            this.englishPlural.TabIndex = 13;
            this.englishPlural.TextChanged += new System.EventHandler(this.englishPlural_TextChanged);
            // 
            // englishSingular
            // 
            this.englishSingular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.englishSingular.Location = new System.Drawing.Point(319, 95);
            this.englishSingular.Name = "englishSingular";
            this.englishSingular.Size = new System.Drawing.Size(120, 27);
            this.englishSingular.TabIndex = 15;
            this.englishSingular.TextChanged += new System.EventHandler(this.englishSingular_TextChanged);
            // 
            // spanishSingular
            // 
            this.spanishSingular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.spanishSingular.Location = new System.Drawing.Point(319, 161);
            this.spanishSingular.Name = "spanishSingular";
            this.spanishSingular.Size = new System.Drawing.Size(120, 27);
            this.spanishSingular.TabIndex = 14;
            this.spanishSingular.TextChanged += new System.EventHandler(this.spanishSingular_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "En. Sing";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 19);
            this.label2.TabIndex = 17;
            this.label2.Text = "En. Plur";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(253, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 19);
            this.label3.TabIndex = 19;
            this.label3.Text = "Sp. Plur";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(253, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 19);
            this.label4.TabIndex = 18;
            this.label4.Text = "Sp. Sing";
            // 
            // checkBoxIOP
            // 
            this.checkBoxIOP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxIOP.AutoSize = true;
            this.checkBoxIOP.BackColor = System.Drawing.SystemColors.Control;
            this.checkBoxIOP.Checked = true;
            this.checkBoxIOP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIOP.Location = new System.Drawing.Point(388, 66);
            this.checkBoxIOP.Name = "checkBoxIOP";
            this.checkBoxIOP.Size = new System.Drawing.Size(51, 23);
            this.checkBoxIOP.TabIndex = 20;
            this.checkBoxIOP.Text = "IOP";
            this.checkBoxIOP.UseVisualStyleBackColor = false;
            this.checkBoxIOP.CheckedChanged += new System.EventHandler(this.checkBoxIOP_CheckedChanged);
            // 
            // checkBoxDOP
            // 
            this.checkBoxDOP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxDOP.AutoSize = true;
            this.checkBoxDOP.Checked = true;
            this.checkBoxDOP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDOP.Location = new System.Drawing.Point(319, 66);
            this.checkBoxDOP.Name = "checkBoxDOP";
            this.checkBoxDOP.Size = new System.Drawing.Size(57, 23);
            this.checkBoxDOP.TabIndex = 21;
            this.checkBoxDOP.Text = "DOP";
            this.checkBoxDOP.UseVisualStyleBackColor = true;
            this.checkBoxDOP.CheckedChanged += new System.EventHandler(this.checkBoxDOP_CheckedChanged);
            // 
            // checkBoxSP
            // 
            this.checkBoxSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxSP.AutoSize = true;
            this.checkBoxSP.Checked = true;
            this.checkBoxSP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSP.Location = new System.Drawing.Point(257, 66);
            this.checkBoxSP.Name = "checkBoxSP";
            this.checkBoxSP.Size = new System.Drawing.Size(53, 23);
            this.checkBoxSP.TabIndex = 22;
            this.checkBoxSP.Text = "SUP";
            this.checkBoxSP.UseVisualStyleBackColor = true;
            this.checkBoxSP.CheckedChanged += new System.EventHandler(this.checkBoxSP_CheckedChanged);
            // 
            // addElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 235);
            this.Controls.Add(this.checkBoxSP);
            this.Controls.Add(this.checkBoxDOP);
            this.Controls.Add(this.checkBoxIOP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.englishSingular);
            this.Controls.Add(this.spanishSingular);
            this.Controls.Add(this.englishPlural);
            this.Controls.Add(this.groupBoxGender);
            this.Controls.Add(this.groupBoxPerson);
            this.Controls.Add(this.label);
            this.Controls.Add(this.spanishPlural);
            this.Controls.Add(this.add);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "addElement";
            this.Text = "Add Pronoun";
            this.groupBoxPerson.ResumeLayout(false);
            this.groupBoxPerson.PerformLayout();
            this.groupBoxGender.ResumeLayout(false);
            this.groupBoxGender.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button add;
        private System.Windows.Forms.TextBox spanishPlural;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.RadioButton feminine;
        private System.Windows.Forms.RadioButton masculine;
        private System.Windows.Forms.RadioButton firstPerson;
        private System.Windows.Forms.RadioButton thirdPerson;
        private System.Windows.Forms.RadioButton secondPerson;
        private System.Windows.Forms.GroupBox groupBoxPerson;
        private System.Windows.Forms.GroupBox groupBoxGender;
        private System.Windows.Forms.TextBox englishPlural;
        private System.Windows.Forms.TextBox englishSingular;
        private System.Windows.Forms.TextBox spanishSingular;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxIOP;
        private System.Windows.Forms.CheckBox checkBoxDOP;
        private System.Windows.Forms.CheckBox checkBoxSP;
    }
}