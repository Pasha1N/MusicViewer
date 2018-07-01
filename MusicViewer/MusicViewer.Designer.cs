namespace MusicViewer
{
    partial class MusicViewer
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLoad = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.fromDateTime = new System.Windows.Forms.DateTimePicker();
            this.toDateTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.albumLabel = new System.Windows.Forms.Label();
            this.releasedLabel = new System.Windows.Forms.Label();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.labelGenres = new System.Windows.Forms.Label();
            this.albumText = new System.Windows.Forms.Label();
            this.releasedText = new System.Windows.Forms.Label();
            this.playTime = new System.Windows.Forms.Label();
            this.genresText = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // buttonLoad
            // 
            this.buttonLoad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLoad.Location = new System.Drawing.Point(12, 11);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 21);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.ButtonLoad_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 73);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(242, 316);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(93, 11);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(420, 21);
            this.comboBox.TabIndex = 3;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // fromDateTime
            // 
            this.fromDateTime.Enabled = false;
            this.fromDateTime.Location = new System.Drawing.Point(54, 39);
            this.fromDateTime.Name = "fromDateTime";
            this.fromDateTime.Size = new System.Drawing.Size(200, 20);
            this.fromDateTime.TabIndex = 4;
            this.fromDateTime.ValueChanged += new System.EventHandler(this.FromDateTime_ValueChanged);
            // 
            // toDateTime
            // 
            this.toDateTime.Enabled = false;
            this.toDateTime.Location = new System.Drawing.Point(313, 39);
            this.toDateTime.Name = "toDateTime";
            this.toDateTime.Size = new System.Drawing.Size(200, 20);
            this.toDateTime.TabIndex = 5;
            this.toDateTime.ValueChanged += new System.EventHandler(this.ToDateTime_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "From:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(283, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "To:";
            // 
            // albumLabel
            // 
            this.albumLabel.AutoSize = true;
            this.albumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.albumLabel.Location = new System.Drawing.Point(282, 73);
            this.albumLabel.Name = "albumLabel";
            this.albumLabel.Size = new System.Drawing.Size(49, 16);
            this.albumLabel.TabIndex = 8;
            this.albumLabel.Text = "Album:";
            // 
            // releasedLabel
            // 
            this.releasedLabel.AutoSize = true;
            this.releasedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.releasedLabel.Location = new System.Drawing.Point(261, 99);
            this.releasedLabel.Name = "releasedLabel";
            this.releasedLabel.Size = new System.Drawing.Size(71, 16);
            this.releasedLabel.TabIndex = 9;
            this.releasedLabel.Text = "Released:";
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lengthLabel.Location = new System.Drawing.Point(281, 129);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(51, 16);
            this.lengthLabel.TabIndex = 10;
            this.lengthLabel.Text = "Length:";
            // 
            // labelGenres
            // 
            this.labelGenres.AutoSize = true;
            this.labelGenres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGenres.Location = new System.Drawing.Point(277, 159);
            this.labelGenres.Name = "labelGenres";
            this.labelGenres.Size = new System.Drawing.Size(55, 16);
            this.labelGenres.TabIndex = 11;
            this.labelGenres.Text = "Genres:";
            // 
            // albumText
            // 
            this.albumText.AutoSize = true;
            this.albumText.Location = new System.Drawing.Point(338, 76);
            this.albumText.Name = "albumText";
            this.albumText.Size = new System.Drawing.Size(10, 13);
            this.albumText.TabIndex = 12;
            this.albumText.Text = " ";
            // 
            // releasedText
            // 
            this.releasedText.AutoSize = true;
            this.releasedText.Location = new System.Drawing.Point(338, 102);
            this.releasedText.Name = "releasedText";
            this.releasedText.Size = new System.Drawing.Size(10, 13);
            this.releasedText.TabIndex = 13;
            this.releasedText.Text = " ";
            // 
            // playTime
            // 
            this.playTime.AutoSize = true;
            this.playTime.Location = new System.Drawing.Point(338, 132);
            this.playTime.Name = "playTime";
            this.playTime.Size = new System.Drawing.Size(10, 13);
            this.playTime.TabIndex = 14;
            this.playTime.Text = " ";
            // 
            // genresText
            // 
            this.genresText.AutoSize = true;
            this.genresText.Location = new System.Drawing.Point(338, 162);
            this.genresText.Name = "genresText";
            this.genresText.Size = new System.Drawing.Size(10, 13);
            this.genresText.TabIndex = 15;
            this.genresText.Text = " ";
            // 
            // MusicViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 401);
            this.Controls.Add(this.genresText);
            this.Controls.Add(this.playTime);
            this.Controls.Add(this.releasedText);
            this.Controls.Add(this.albumText);
            this.Controls.Add(this.labelGenres);
            this.Controls.Add(this.lengthLabel);
            this.Controls.Add(this.releasedLabel);
            this.Controls.Add(this.albumLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toDateTime);
            this.Controls.Add(this.fromDateTime);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.buttonLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MusicViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Music Viewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.DateTimePicker fromDateTime;
        private System.Windows.Forms.DateTimePicker toDateTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label albumLabel;
        private System.Windows.Forms.Label releasedLabel;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.Label labelGenres;
        private System.Windows.Forms.Label albumText;
        private System.Windows.Forms.Label releasedText;
        private System.Windows.Forms.Label playTime;
        private System.Windows.Forms.Label genresText;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

