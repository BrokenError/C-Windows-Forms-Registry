namespace registry
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.данныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.предприятиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подразделениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помещениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запросыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.предприятиеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.подразделениеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.помещениеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.журналыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.документToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкаПаролейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.данныеToolStripMenuItem,
            this.запросыToolStripMenuItem,
            this.журналыToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // данныеToolStripMenuItem
            // 
            this.данныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.предприятиеToolStripMenuItem,
            this.подразделениеToolStripMenuItem,
            this.помещениеToolStripMenuItem});
            this.данныеToolStripMenuItem.Name = "данныеToolStripMenuItem";
            this.данныеToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.данныеToolStripMenuItem.Text = "Данные";
            // 
            // предприятиеToolStripMenuItem
            // 
            this.предприятиеToolStripMenuItem.Name = "предприятиеToolStripMenuItem";
            this.предприятиеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.предприятиеToolStripMenuItem.Text = "Предприятие";
            this.предприятиеToolStripMenuItem.Click += new System.EventHandler(this.предприятиеToolStripMenuItem_Click);
            // 
            // подразделениеToolStripMenuItem
            // 
            this.подразделениеToolStripMenuItem.Name = "подразделениеToolStripMenuItem";
            this.подразделениеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.подразделениеToolStripMenuItem.Text = "Подразделение";
            this.подразделениеToolStripMenuItem.Click += new System.EventHandler(this.подразделениеToolStripMenuItem_Click);
            // 
            // помещениеToolStripMenuItem
            // 
            this.помещениеToolStripMenuItem.Name = "помещениеToolStripMenuItem";
            this.помещениеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.помещениеToolStripMenuItem.Text = "Помещение";
            this.помещениеToolStripMenuItem.Click += new System.EventHandler(this.помещениеToolStripMenuItem_Click);
            // 
            // запросыToolStripMenuItem
            // 
            this.запросыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.предприятиеToolStripMenuItem1,
            this.подразделениеToolStripMenuItem1,
            this.помещениеToolStripMenuItem1});
            this.запросыToolStripMenuItem.Name = "запросыToolStripMenuItem";
            this.запросыToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.запросыToolStripMenuItem.Text = "Запросы";
            // 
            // предприятиеToolStripMenuItem1
            // 
            this.предприятиеToolStripMenuItem1.Name = "предприятиеToolStripMenuItem1";
            this.предприятиеToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.предприятиеToolStripMenuItem1.Text = "Предприятие";
            this.предприятиеToolStripMenuItem1.Click += new System.EventHandler(this.предприятиеToolStripMenuItem1_Click);
            // 
            // подразделениеToolStripMenuItem1
            // 
            this.подразделениеToolStripMenuItem1.Name = "подразделениеToolStripMenuItem1";
            this.подразделениеToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.подразделениеToolStripMenuItem1.Text = "Подразделение";
            this.подразделениеToolStripMenuItem1.Click += new System.EventHandler(this.подразделениеToolStripMenuItem1_Click);
            // 
            // помещениеToolStripMenuItem1
            // 
            this.помещениеToolStripMenuItem1.Name = "помещениеToolStripMenuItem1";
            this.помещениеToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.помещениеToolStripMenuItem1.Text = "Помещение";
            this.помещениеToolStripMenuItem1.Click += new System.EventHandler(this.помещениеToolStripMenuItem1_Click);
            // 
            // журналыToolStripMenuItem
            // 
            this.журналыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.документToolStripMenuItem});
            this.журналыToolStripMenuItem.Name = "журналыToolStripMenuItem";
            this.журналыToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.журналыToolStripMenuItem.Text = "Журналы";
            // 
            // документToolStripMenuItem
            // 
            this.документToolStripMenuItem.Name = "документToolStripMenuItem";
            this.документToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.документToolStripMenuItem.Text = "Документ";
            this.документToolStripMenuItem.Click += new System.EventHandler(this.документToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.пToolStripMenuItem,
            this.настройкаПаролейToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // пToolStripMenuItem
            // 
            this.пToolStripMenuItem.Name = "пToolStripMenuItem";
            this.пToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.пToolStripMenuItem.Text = "Просмотр справки";
            this.пToolStripMenuItem.Click += new System.EventHandler(this.пToolStripMenuItem_Click);
            // 
            // настройкаПаролейToolStripMenuItem
            // 
            this.настройкаПаролейToolStripMenuItem.Name = "настройкаПаролейToolStripMenuItem";
            this.настройкаПаролейToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.настройкаПаролейToolStripMenuItem.Text = "Настройка паролей";
            this.настройкаПаролейToolStripMenuItem.Click += new System.EventHandler(this.настройкаПаролейToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 423);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Электронный реестр помещений";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem данныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem предприятиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem подразделениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помещениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запросыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem предприятиеToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem подразделениеToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem помещениеToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem журналыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem документToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкаПаролейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

