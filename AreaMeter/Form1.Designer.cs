namespace AreaMeter
{
	partial class Form1
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
			this.label1 = new System.Windows.Forms.Label();
			this.textSquare = new System.Windows.Forms.TextBox();
			this.buttonClear = new System.Windows.Forms.Button();
			this.labelLengthSegment = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.labelLengthAll = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.открытьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.сохранитьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.heplToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.dataSet1 = new System.Data.DataSet();
			this.labelSquare1 = new System.Windows.Forms.Label();
			this.labelSquare2 = new System.Windows.Forms.Label();
			this.labelTurn1 = new System.Windows.Forms.Label();
			this.textTurn = new System.Windows.Forms.TextBox();
			this.labelTurn2 = new System.Windows.Forms.Label();
			this.textScale = new System.Windows.Forms.TextBox();
			this.labelScale1 = new System.Windows.Forms.Label();
			this.labelScale2 = new System.Windows.Forms.Label();
			this.labelPerimetr1 = new System.Windows.Forms.Label();
			this.labelPerimetr2 = new System.Windows.Forms.Label();
			this.открытьФайлToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.сохранитьФайлToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.infoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.открытьФайлToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.сохранитьФайлToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.infoToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.butScaleMax = new System.Windows.Forms.Button();
			this.butScaleMin = new System.Windows.Forms.Button();
			this.buttonRight = new System.Windows.Forms.Button();
			this.buttonLeft = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 66);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(106, 30);
			this.label1.TabIndex = 6;
			this.label1.Text = "Сторона внешнего квадрата, м";
			// 
			// textSquare
			// 
			this.textSquare.Location = new System.Drawing.Point(8, 99);
			this.textSquare.Name = "textSquare";
			this.textSquare.Size = new System.Drawing.Size(103, 20);
			this.textSquare.TabIndex = 0;
			this.textSquare.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textSquare_KeyPress);
			// 
			// buttonClear
			// 
			this.buttonClear.Enabled = false;
			this.buttonClear.Location = new System.Drawing.Point(8, 31);
			this.buttonClear.Name = "buttonClear";
			this.buttonClear.Size = new System.Drawing.Size(106, 31);
			this.buttonClear.TabIndex = 8;
			this.buttonClear.Text = "Удалить всё";
			this.buttonClear.UseVisualStyleBackColor = true;
			this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
			// 
			// labelLengthSegment
			// 
			this.labelLengthSegment.AutoSize = true;
			this.labelLengthSegment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelLengthSegment.ForeColor = System.Drawing.Color.Green;
			this.labelLengthSegment.Location = new System.Drawing.Point(669, 533);
			this.labelLengthSegment.Name = "labelLengthSegment";
			this.labelLengthSegment.Size = new System.Drawing.Size(16, 17);
			this.labelLengthSegment.TabIndex = 3;
			this.labelLengthSegment.Text = "0";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(532, 534);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(136, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "Длина сегмента, м:";
			// 
			// labelLengthAll
			// 
			this.labelLengthAll.AutoSize = true;
			this.labelLengthAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelLengthAll.ForeColor = System.Drawing.Color.Firebrick;
			this.labelLengthAll.Location = new System.Drawing.Point(669, 560);
			this.labelLengthAll.Name = "labelLengthAll";
			this.labelLengthAll.Size = new System.Drawing.Size(16, 17);
			this.labelLengthAll.TabIndex = 1;
			this.labelLengthAll.Text = "0";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(542, 560);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(119, 17);
			this.label2.TabIndex = 0;
			this.label2.Text = "Общая длина, м:";
			// 
			// panel2
			// 
			this.panel2.Location = new System.Drawing.Point(770, 32);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(40, 501);
			this.panel2.TabIndex = 15;
			// 
			// открытьФайлToolStripMenuItem
			// 
			this.открытьФайлToolStripMenuItem.Name = "открытьФайлToolStripMenuItem";
			this.открытьФайлToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
			// 
			// сохранитьФайлToolStripMenuItem
			// 
			this.сохранитьФайлToolStripMenuItem.Name = "сохранитьФайлToolStripMenuItem";
			this.сохранитьФайлToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
			// 
			// heplToolStripMenuItem
			// 
			this.heplToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.heplToolStripMenuItem.Name = "heplToolStripMenuItem";
			this.heplToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.heplToolStripMenuItem.Text = "Help";
			// 
			// infoToolStripMenuItem
			// 
			this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
			this.infoToolStripMenuItem.Size = new System.Drawing.Size(78, 22);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(78, 22);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "Text files (*.txt)|*.txt";
			this.openFileDialog1.InitialDirectory = "c:\\";
			this.openFileDialog1.Title = "Загрузка данных";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.FileName = "File01";
			this.saveFileDialog1.Filter = "\"Text file (*.txt)|*.txt";
			this.saveFileDialog1.InitialDirectory = "c:\\";
			this.saveFileDialog1.Title = "Сохранение данных";
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Enabled = false;
			this.dataGridView1.Location = new System.Drawing.Point(8, 125);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(250, 329);
			this.dataGridView1.TabIndex = 1;
			// 
			// dataSet1
			// 
			this.dataSet1.DataSetName = "NewDataSet";
			// 
			// labelSquare1
			// 
			this.labelSquare1.Location = new System.Drawing.Point(262, 533);
			this.labelSquare1.Name = "labelSquare1";
			this.labelSquare1.Size = new System.Drawing.Size(79, 31);
			this.labelSquare1.TabIndex = 18;
			this.labelSquare1.Text = "Площадь фигуры, кв.м";
			// 
			// labelSquare2
			// 
			this.labelSquare2.AutoSize = true;
			this.labelSquare2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelSquare2.ForeColor = System.Drawing.Color.Blue;
			this.labelSquare2.Location = new System.Drawing.Point(261, 562);
			this.labelSquare2.Name = "labelSquare2";
			this.labelSquare2.Size = new System.Drawing.Size(18, 20);
			this.labelSquare2.TabIndex = 19;
			this.labelSquare2.Text = "0";
			// 
			// labelTurn1
			// 
			this.labelTurn1.Location = new System.Drawing.Point(102, 457);
			this.labelTurn1.Name = "labelTurn1";
			this.labelTurn1.Size = new System.Drawing.Size(55, 17);
			this.labelTurn1.TabIndex = 22;
			this.labelTurn1.Text = "Поворот,";
			// 
			// textTurn
			// 
			this.textTurn.Enabled = false;
			this.textTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textTurn.Location = new System.Drawing.Point(86, 490);
			this.textTurn.Name = "textTurn";
			this.textTurn.Size = new System.Drawing.Size(89, 26);
			this.textTurn.TabIndex = 2;
			this.textTurn.Text = "0";
			// 
			// labelTurn2
			// 
			this.labelTurn2.AutoSize = true;
			this.labelTurn2.Location = new System.Drawing.Point(87, 473);
			this.labelTurn2.Name = "labelTurn2";
			this.labelTurn2.Size = new System.Drawing.Size(87, 13);
			this.labelTurn2.TabIndex = 24;
			this.labelTurn2.Text = ")-360; 360(  град";
			// 
			// textScale
			// 
			this.textScale.Enabled = false;
			this.textScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textScale.Location = new System.Drawing.Point(86, 551);
			this.textScale.Name = "textScale";
			this.textScale.Size = new System.Drawing.Size(89, 26);
			this.textScale.TabIndex = 5;
			this.textScale.Text = "100";
			// 
			// labelScale1
			// 
			this.labelScale1.AutoSize = true;
			this.labelScale1.Location = new System.Drawing.Point(101, 519);
			this.labelScale1.Name = "labelScale1";
			this.labelScale1.Size = new System.Drawing.Size(56, 13);
			this.labelScale1.TabIndex = 26;
			this.labelScale1.Text = "Масштаб,";
			// 
			// labelScale2
			// 
			this.labelScale2.AutoSize = true;
			this.labelScale2.Location = new System.Drawing.Point(97, 535);
			this.labelScale2.Name = "labelScale2";
			this.labelScale2.Size = new System.Drawing.Size(66, 13);
			this.labelScale2.TabIndex = 29;
			this.labelScale2.Text = "[10; 1000] %";
			// 
			// labelPerimetr1
			// 
			this.labelPerimetr1.Location = new System.Drawing.Point(398, 533);
			this.labelPerimetr1.Name = "labelPerimetr1";
			this.labelPerimetr1.Size = new System.Drawing.Size(60, 30);
			this.labelPerimetr1.TabIndex = 30;
			this.labelPerimetr1.Text = "Периметр фигуры, м";
			// 
			// labelPerimetr2
			// 
			this.labelPerimetr2.AutoSize = true;
			this.labelPerimetr2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPerimetr2.ForeColor = System.Drawing.Color.Magenta;
			this.labelPerimetr2.Location = new System.Drawing.Point(397, 562);
			this.labelPerimetr2.Name = "labelPerimetr2";
			this.labelPerimetr2.Size = new System.Drawing.Size(18, 20);
			this.labelPerimetr2.TabIndex = 31;
			this.labelPerimetr2.Text = "0";
			// 
			// открытьФайлToolStripMenuItem1
			// 
			this.открытьФайлToolStripMenuItem1.Name = "открытьФайлToolStripMenuItem1";
			this.открытьФайлToolStripMenuItem1.Size = new System.Drawing.Size(94, 20);
			this.открытьФайлToolStripMenuItem1.Text = "Открыть файл";
			// 
			// сохранитьФайлToolStripMenuItem1
			// 
			this.сохранитьФайлToolStripMenuItem1.Name = "сохранитьФайлToolStripMenuItem1";
			this.сохранитьФайлToolStripMenuItem1.Size = new System.Drawing.Size(103, 20);
			this.сохранитьФайлToolStripMenuItem1.Text = "Сохранить файл";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// infoToolStripMenuItem1
			// 
			this.infoToolStripMenuItem1.Name = "infoToolStripMenuItem1";
			this.infoToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
			this.infoToolStripMenuItem1.Text = "Info";
			// 
			// aboutToolStripMenuItem1
			// 
			this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
			this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
			this.aboutToolStripMenuItem1.Text = "About";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьФайлToolStripMenuItem2,
            this.сохранитьФайлToolStripMenuItem2,
            this.helpToolStripMenuItem1});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(817, 24);
			this.menuStrip1.TabIndex = 32;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// открытьФайлToolStripMenuItem2
			// 
			this.открытьФайлToolStripMenuItem2.Name = "открытьФайлToolStripMenuItem2";
			this.открытьФайлToolStripMenuItem2.Size = new System.Drawing.Size(94, 20);
			this.открытьФайлToolStripMenuItem2.Text = "Открыть файл";
			this.открытьФайлToolStripMenuItem2.Click += new System.EventHandler(this.открытьФайлToolStripMenuItem2_Click);
			// 
			// сохранитьФайлToolStripMenuItem2
			// 
			this.сохранитьФайлToolStripMenuItem2.Enabled = false;
			this.сохранитьФайлToolStripMenuItem2.Name = "сохранитьФайлToolStripMenuItem2";
			this.сохранитьФайлToolStripMenuItem2.Size = new System.Drawing.Size(103, 20);
			this.сохранитьФайлToolStripMenuItem2.Text = "Сохранить файл";
			this.сохранитьФайлToolStripMenuItem2.Click += new System.EventHandler(this.сохранитьФайлToolStripMenuItem2_Click);
			// 
			// helpToolStripMenuItem1
			// 
			this.helpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem2,
            this.aboutToolStripMenuItem2});
			this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
			this.helpToolStripMenuItem1.Size = new System.Drawing.Size(40, 20);
			this.helpToolStripMenuItem1.Text = "Help";
			// 
			// infoToolStripMenuItem2
			// 
			this.infoToolStripMenuItem2.Name = "infoToolStripMenuItem2";
			this.infoToolStripMenuItem2.Size = new System.Drawing.Size(114, 22);
			this.infoToolStripMenuItem2.Text = "Info";
			this.infoToolStripMenuItem2.Click += new System.EventHandler(this.infoToolStripMenuItem2_Click);
			// 
			// aboutToolStripMenuItem2
			// 
			this.aboutToolStripMenuItem2.Name = "aboutToolStripMenuItem2";
			this.aboutToolStripMenuItem2.Size = new System.Drawing.Size(114, 22);
			this.aboutToolStripMenuItem2.Text = "About";
			this.aboutToolStripMenuItem2.Click += new System.EventHandler(this.aboutToolStripMenuItem2_Click);
			// 
			// pictureBox2
			// 
            this.pictureBox2.Image = global::AreaMeter.Properties.Resources.roza;
			this.pictureBox2.Location = new System.Drawing.Point(158, 32);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(100, 87);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 33;
			this.pictureBox2.TabStop = false;
			// 
			// butScaleMax
			// 
            this.butScaleMax.BackgroundImage = global::AreaMeter.Properties.Resources.Plus;
			this.butScaleMax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.butScaleMax.Enabled = false;
			this.butScaleMax.Location = new System.Drawing.Point(186, 537);
			this.butScaleMax.Name = "butScaleMax";
			this.butScaleMax.Size = new System.Drawing.Size(65, 40);
			this.butScaleMax.TabIndex = 7;
			this.butScaleMax.UseVisualStyleBackColor = true;
			// 
			// butScaleMin
			// 
            this.butScaleMin.BackgroundImage = global::AreaMeter.Properties.Resources.Minus;
			this.butScaleMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.butScaleMin.Enabled = false;
			this.butScaleMin.Location = new System.Drawing.Point(12, 537);
			this.butScaleMin.Name = "butScaleMin";
			this.butScaleMin.Size = new System.Drawing.Size(65, 40);
			this.butScaleMin.TabIndex = 6;
			this.butScaleMin.UseVisualStyleBackColor = true;
			// 
			// buttonRight
			// 
            this.buttonRight.BackgroundImage = global::AreaMeter.Properties.Resources.Right;
			this.buttonRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.buttonRight.Enabled = false;
			this.buttonRight.Location = new System.Drawing.Point(186, 471);
			this.buttonRight.Name = "buttonRight";
			this.buttonRight.Size = new System.Drawing.Size(55, 40);
			this.buttonRight.TabIndex = 4;
			this.buttonRight.UseVisualStyleBackColor = true;
			// 
			// buttonLeft
			// 
            this.buttonLeft.BackgroundImage = global::AreaMeter.Properties.Resources.Left;
			this.buttonLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.buttonLeft.Enabled = false;
			this.buttonLeft.Location = new System.Drawing.Point(22, 471);
			this.buttonLeft.Name = "buttonLeft";
			this.buttonLeft.Size = new System.Drawing.Size(55, 40);
			this.buttonLeft.TabIndex = 3;
			this.buttonLeft.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.White;
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBox1.Location = new System.Drawing.Point(265, 31);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(500, 500);
			this.pictureBox1.TabIndex = 13;
			this.pictureBox1.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(817, 586);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.labelPerimetr2);
			this.Controls.Add(this.labelPerimetr1);
			this.Controls.Add(this.labelLengthAll);
			this.Controls.Add(this.labelLengthSegment);
			this.Controls.Add(this.labelScale2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.butScaleMax);
			this.Controls.Add(this.butScaleMin);
			this.Controls.Add(this.labelScale1);
			this.Controls.Add(this.labelSquare2);
			this.Controls.Add(this.labelSquare1);
			this.Controls.Add(this.textScale);
			this.Controls.Add(this.labelTurn2);
			this.Controls.Add(this.textTurn);
			this.Controls.Add(this.labelTurn1);
			this.Controls.Add(this.buttonRight);
			this.Controls.Add(this.buttonLeft);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.buttonClear);
			this.Controls.Add(this.textSquare);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.menuStrip1);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(825, 620);
			this.MinimumSize = new System.Drawing.Size(825, 620);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Файл \"Без имени\"";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textSquare;
		private System.Windows.Forms.Button buttonClear;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.ToolStripMenuItem открытьФайлToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem сохранитьФайлToolStripMenuItem;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Data.DataSet dataSet1;
		private System.Windows.Forms.Label labelSquare1;
		private System.Windows.Forms.Label labelSquare2;
		private System.Windows.Forms.Button buttonLeft;
		private System.Windows.Forms.Button buttonRight;
		private System.Windows.Forms.Label labelTurn1;
		private System.Windows.Forms.TextBox textTurn;
		private System.Windows.Forms.Label labelTurn2;
		private System.Windows.Forms.TextBox textScale;
		private System.Windows.Forms.Label labelScale1;
		private System.Windows.Forms.Button butScaleMin;
		private System.Windows.Forms.Button butScaleMax;
		private System.Windows.Forms.Label labelScale2;
		private System.Windows.Forms.ToolStripMenuItem heplToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label labelLengthSegment;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label labelLengthAll;
		private System.Windows.Forms.Label labelPerimetr1;
		private System.Windows.Forms.Label labelPerimetr2;
		private System.Windows.Forms.ToolStripMenuItem открытьФайлToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem сохранитьФайлToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem открытьФайлToolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem сохранитьФайлToolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem2;
		private System.Windows.Forms.PictureBox pictureBox2;
	}
}

