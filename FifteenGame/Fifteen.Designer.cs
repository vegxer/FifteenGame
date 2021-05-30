namespace FifteenGame
{
    partial class Fifteen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fifteen));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.отменитьХодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.stepsLabel = new System.Windows.Forms.Label();
            this.gameTimer = new ComponentLibrary.GameTimer();
            this.button0 = new ComponentLibrary.Button();
            this.button1 = new ComponentLibrary.Button();
            this.button2 = new ComponentLibrary.Button();
            this.button4 = new ComponentLibrary.Button();
            this.button5 = new ComponentLibrary.Button();
            this.button6 = new ComponentLibrary.Button();
            this.button7 = new ComponentLibrary.Button();
            this.button8 = new ComponentLibrary.Button();
            this.button9 = new ComponentLibrary.Button();
            this.button10 = new ComponentLibrary.Button();
            this.button11 = new ComponentLibrary.Button();
            this.button12 = new ComponentLibrary.Button();
            this.button13 = new ComponentLibrary.Button();
            this.button14 = new ComponentLibrary.Button();
            this.button15 = new ComponentLibrary.Button();
            this.button3 = new ComponentLibrary.Button();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Beige;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startMenu,
            this.отменитьХодToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // startMenu
            // 
            this.startMenu.Name = "startMenu";
            this.startMenu.Size = new System.Drawing.Size(81, 20);
            this.startMenu.Text = "Новая игра";
            this.startMenu.Click += new System.EventHandler(this.startMenu_Click);
            // 
            // отменитьХодToolStripMenuItem
            // 
            this.отменитьХодToolStripMenuItem.Name = "отменитьХодToolStripMenuItem";
            this.отменитьХодToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.отменитьХодToolStripMenuItem.Text = "Отменить ход";
            this.отменитьХодToolStripMenuItem.Click += new System.EventHandler(this.отменитьХодToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.stepsLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.gameTimer, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.button0, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.button7, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.button8, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button9, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.button10, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.button11, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.button12, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button13, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.button14, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.button15, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.button3, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 564);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // stepsLabel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.stepsLabel, 2);
            this.stepsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.stepsLabel.Location = new System.Drawing.Point(3, 540);
            this.stepsLabel.Name = "stepsLabel";
            this.stepsLabel.Size = new System.Drawing.Size(286, 24);
            this.stepsLabel.TabIndex = 16;
            this.stepsLabel.Text = "Количество ходов: 0";
            // 
            // gameTimer
            // 
            this.gameTimer.Location = new System.Drawing.Point(295, 543);
            this.gameTimer.Name = "gameTimer";
            this.gameTimer.Size = new System.Drawing.Size(64, 17);
            this.gameTimer.TabIndex = 26;
            // 
            // button0
            // 
            this.button0.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button0.Font = new System.Drawing.Font("Times New Roman", 48F);
            this.button0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(15)))));
            this.button0.Location = new System.Drawing.Point(3, 3);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(140, 129);
            this.button0.TabIndex = 27;
            this.button0.Tag = "0";
            this.button0.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button0_MouseClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 48F);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(15)))));
            this.button1.Location = new System.Drawing.Point(149, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 129);
            this.button1.TabIndex = 28;
            this.button1.Tag = "1";
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button0_MouseClick);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 48F);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(15)))));
            this.button2.Location = new System.Drawing.Point(295, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 129);
            this.button2.TabIndex = 29;
            this.button2.Tag = "2";
            this.button2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button0_MouseClick);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Font = new System.Drawing.Font("Times New Roman", 48F);
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(15)))));
            this.button4.Location = new System.Drawing.Point(3, 138);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(140, 129);
            this.button4.TabIndex = 31;
            this.button4.Tag = "4";
            this.button4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button0_MouseClick);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Font = new System.Drawing.Font("Times New Roman", 48F);
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(15)))));
            this.button5.Location = new System.Drawing.Point(149, 138);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(140, 129);
            this.button5.TabIndex = 32;
            this.button5.Tag = "5";
            this.button5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button0_MouseClick);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Font = new System.Drawing.Font("Times New Roman", 48F);
            this.button6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(15)))));
            this.button6.Location = new System.Drawing.Point(295, 138);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(140, 129);
            this.button6.TabIndex = 33;
            this.button6.Tag = "6";
            this.button6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button0_MouseClick);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button7.Font = new System.Drawing.Font("Times New Roman", 48F);
            this.button7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(15)))));
            this.button7.Location = new System.Drawing.Point(441, 138);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(140, 129);
            this.button7.TabIndex = 34;
            this.button7.Tag = "7";
            this.button7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button0_MouseClick);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button8.Font = new System.Drawing.Font("Times New Roman", 48F);
            this.button8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(15)))));
            this.button8.Location = new System.Drawing.Point(3, 273);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(140, 129);
            this.button8.TabIndex = 35;
            this.button8.Tag = "8";
            this.button8.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button0_MouseClick);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button9.Font = new System.Drawing.Font("Times New Roman", 48F);
            this.button9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(15)))));
            this.button9.Location = new System.Drawing.Point(149, 273);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(140, 129);
            this.button9.TabIndex = 36;
            this.button9.Tag = "9";
            this.button9.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button0_MouseClick);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button10.Font = new System.Drawing.Font("Times New Roman", 48F);
            this.button10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(15)))));
            this.button10.Location = new System.Drawing.Point(295, 273);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(140, 129);
            this.button10.TabIndex = 37;
            this.button10.Tag = "10";
            this.button10.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button0_MouseClick);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button11.Font = new System.Drawing.Font("Times New Roman", 48F);
            this.button11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(15)))));
            this.button11.Location = new System.Drawing.Point(441, 273);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(140, 129);
            this.button11.TabIndex = 38;
            this.button11.Tag = "11";
            this.button11.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button0_MouseClick);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button12.Font = new System.Drawing.Font("Times New Roman", 48F);
            this.button12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(15)))));
            this.button12.Location = new System.Drawing.Point(3, 408);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(140, 129);
            this.button12.TabIndex = 39;
            this.button12.Tag = "12";
            this.button12.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button0_MouseClick);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button13.Font = new System.Drawing.Font("Times New Roman", 48F);
            this.button13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(15)))));
            this.button13.Location = new System.Drawing.Point(149, 408);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(140, 129);
            this.button13.TabIndex = 40;
            this.button13.Tag = "13";
            this.button13.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button0_MouseClick);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button14.Font = new System.Drawing.Font("Times New Roman", 48F);
            this.button14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(15)))));
            this.button14.Location = new System.Drawing.Point(295, 408);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(140, 129);
            this.button14.TabIndex = 41;
            this.button14.Tag = "14";
            this.button14.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button0_MouseClick);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button15.Font = new System.Drawing.Font("Times New Roman", 48F);
            this.button15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(15)))));
            this.button15.Location = new System.Drawing.Point(441, 408);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(140, 129);
            this.button15.TabIndex = 42;
            this.button15.Tag = "15";
            this.button15.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button0_MouseClick);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Font = new System.Drawing.Font("Times New Roman", 48F);
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(15)))));
            this.button3.Location = new System.Drawing.Point(441, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 129);
            this.button3.TabIndex = 30;
            this.button3.Tag = "3";
            this.button3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button0_MouseClick);
            // 
            // Fifteen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(584, 588);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Fifteen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пятнашки";
            this.Load += new System.EventHandler(this.Fifteen_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startMenu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label stepsLabel;
        private System.Windows.Forms.ToolStripMenuItem отменитьХодToolStripMenuItem;
        private ComponentLibrary.GameTimer gameTimer;
        private ComponentLibrary.Button button0;
        private ComponentLibrary.Button button1;
        private ComponentLibrary.Button button2;
        private ComponentLibrary.Button button3;
        private ComponentLibrary.Button button4;
        private ComponentLibrary.Button button5;
        private ComponentLibrary.Button button6;
        private ComponentLibrary.Button button7;
        private ComponentLibrary.Button button8;
        private ComponentLibrary.Button button9;
        private ComponentLibrary.Button button10;
        private ComponentLibrary.Button button11;
        private ComponentLibrary.Button button12;
        private ComponentLibrary.Button button13;
        private ComponentLibrary.Button button14;
        private ComponentLibrary.Button button15;
    }
}

