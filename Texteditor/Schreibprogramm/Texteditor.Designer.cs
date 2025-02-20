namespace Texteditor
{
    partial class Texteditor
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
            components = new System.ComponentModel.Container();
            comboBoxSize = new ComboBox();
            buttonBold = new Button();
            buttonItalic = new Button();
            panel1 = new Panel();
            buttonColor = new Button();
            comboBoxFont = new ComboBox();
            buttonUnderline = new Button();
            richTextBox1 = new RichTextBox();
            menuStrip1 = new MenuStrip();
            dateiToolStripMenuItem = new ToolStripMenuItem();
            neuToolStripMenuItem = new ToolStripMenuItem();
            speichernToolStripMenuItem = new ToolStripMenuItem();
            ladenToolStripMenuItem = new ToolStripMenuItem();
            einstellungenToolStripMenuItem = new ToolStripMenuItem();
            dunkelmodusToolStripMenuItem = new ToolStripMenuItem();
            hellToolStripMenuItem = new ToolStripMenuItem();
            dunkelToolStripMenuItem = new ToolStripMenuItem();
            colorDialog1 = new ColorDialog();
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog1 = new OpenFileDialog();
            statusTimer = new System.Windows.Forms.Timer(components);
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxSize
            // 
            comboBoxSize.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxSize.FormattingEnabled = true;
            comboBoxSize.Location = new Point(12, 4);
            comboBoxSize.Name = "comboBoxSize";
            comboBoxSize.Size = new Size(37, 23);
            comboBoxSize.TabIndex = 1;
            comboBoxSize.Text = "11";
            comboBoxSize.SelectedIndexChanged += comboBoxSize_SelectedIndexChanged;
            // 
            // buttonBold
            // 
            buttonBold.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonBold.Location = new Point(12, 32);
            buttonBold.Name = "buttonBold";
            buttonBold.Size = new Size(24, 23);
            buttonBold.TabIndex = 2;
            buttonBold.Text = "F";
            buttonBold.UseVisualStyleBackColor = true;
            buttonBold.Click += buttonBold_Click;
            // 
            // buttonItalic
            // 
            buttonItalic.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            buttonItalic.Location = new Point(42, 32);
            buttonItalic.Name = "buttonItalic";
            buttonItalic.Size = new Size(23, 23);
            buttonItalic.TabIndex = 3;
            buttonItalic.Text = "K";
            buttonItalic.UseVisualStyleBackColor = true;
            buttonItalic.Click += buttonItalic_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonColor);
            panel1.Controls.Add(comboBoxFont);
            panel1.Controls.Add(buttonUnderline);
            panel1.Controls.Add(comboBoxSize);
            panel1.Controls.Add(buttonItalic);
            panel1.Controls.Add(buttonBold);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 61);
            panel1.TabIndex = 4;
            panel1.Paint += panel1_Paint;
            // 
            // buttonColor
            // 
            buttonColor.Location = new Point(103, 32);
            buttonColor.Name = "buttonColor";
            buttonColor.Size = new Size(24, 23);
            buttonColor.TabIndex = 6;
            buttonColor.UseVisualStyleBackColor = true;
            buttonColor.Click += buttonColor_Click;
            // 
            // comboBoxFont
            // 
            comboBoxFont.FormattingEnabled = true;
            comboBoxFont.Location = new Point(55, 4);
            comboBoxFont.Name = "comboBoxFont";
            comboBoxFont.RightToLeft = RightToLeft.No;
            comboBoxFont.Size = new Size(99, 23);
            comboBoxFont.TabIndex = 5;
            comboBoxFont.Text = "Arial";
            comboBoxFont.SelectedIndexChanged += comboBoxSize_SelectedIndexChanged;
            // 
            // buttonUnderline
            // 
            buttonUnderline.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            buttonUnderline.Location = new Point(71, 32);
            buttonUnderline.Name = "buttonUnderline";
            buttonUnderline.Size = new Size(26, 23);
            buttonUnderline.TabIndex = 4;
            buttonUnderline.Text = "U";
            buttonUnderline.UseVisualStyleBackColor = true;
            buttonUnderline.Click += buttonUnderline_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Font = new Font("Microsoft Sans Serif", 8.25F);
            richTextBox1.Location = new Point(0, 85);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(800, 343);
            richTextBox1.TabIndex = 5;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { dateiToolStripMenuItem, einstellungenToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            dateiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { neuToolStripMenuItem, speichernToolStripMenuItem, ladenToolStripMenuItem });
            dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            dateiToolStripMenuItem.Size = new Size(46, 20);
            dateiToolStripMenuItem.Text = "Datei";
            // 
            // neuToolStripMenuItem
            // 
            neuToolStripMenuItem.Name = "neuToolStripMenuItem";
            neuToolStripMenuItem.Size = new Size(126, 22);
            neuToolStripMenuItem.Text = "Neu";
            neuToolStripMenuItem.Click += neuToolStripMenuItem_Click;
            // 
            // speichernToolStripMenuItem
            // 
            speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            speichernToolStripMenuItem.Size = new Size(126, 22);
            speichernToolStripMenuItem.Text = "Speichern";
            speichernToolStripMenuItem.Click += speichernToolStripMenuItem_Click;
            // 
            // ladenToolStripMenuItem
            // 
            ladenToolStripMenuItem.Name = "ladenToolStripMenuItem";
            ladenToolStripMenuItem.Size = new Size(126, 22);
            ladenToolStripMenuItem.Text = "Öffnen";
            ladenToolStripMenuItem.Click += ladenToolStripMenuItem_Click;
            // 
            // einstellungenToolStripMenuItem
            // 
            einstellungenToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dunkelmodusToolStripMenuItem });
            einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            einstellungenToolStripMenuItem.Size = new Size(90, 20);
            einstellungenToolStripMenuItem.Text = "Einstellungen";
            einstellungenToolStripMenuItem.Click += einstellungenToolStripMenuItem_Click;
            // 
            // dunkelmodusToolStripMenuItem
            // 
            dunkelmodusToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { hellToolStripMenuItem, dunkelToolStripMenuItem });
            dunkelmodusToolStripMenuItem.Name = "dunkelmodusToolStripMenuItem";
            dunkelmodusToolStripMenuItem.Size = new Size(180, 22);
            dunkelmodusToolStripMenuItem.Text = "Dunkelmodus";
            // 
            // hellToolStripMenuItem
            // 
            hellToolStripMenuItem.Name = "hellToolStripMenuItem";
            hellToolStripMenuItem.Size = new Size(111, 22);
            hellToolStripMenuItem.Text = "Hell";
            hellToolStripMenuItem.Click += hellToolStripMenuItem_Click;
            // 
            // dunkelToolStripMenuItem
            // 
            dunkelToolStripMenuItem.Name = "dunkelToolStripMenuItem";
            dunkelToolStripMenuItem.Size = new Size(111, 22);
            dunkelToolStripMenuItem.Text = "Dunkel";
            dunkelToolStripMenuItem.Click += dunkelToolStripMenuItem_Click;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.FileOk += saveFileDialog1_FileOk;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // statusTimer
            // 
            statusTimer.Tick += statusTimer_Tick;
            // 
            // statusStrip1
            // 
            statusStrip1.AutoSize = false;
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.RightToLeft = RightToLeft.Yes;
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 7;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 17);
            // 
            // Texteditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox1);
            Controls.Add(statusStrip1);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Texteditor";
            Text = "Texteditor";
            panel1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox comboBoxSize;
        private Button buttonBold;
        private Button buttonItalic;
        private Panel panel1;
        private RichTextBox richTextBox1;
        private Button buttonUnderline;
        private ComboBox comboBoxFont;
        private MenuStrip menuStrip1;
        private Button buttonColor;
        private ColorDialog colorDialog1;
        private ToolStripMenuItem einstellungenToolStripMenuItem;
        private ToolStripMenuItem dunkelmodusToolStripMenuItem;
        private ToolStripMenuItem hellToolStripMenuItem;
        private ToolStripMenuItem dunkelToolStripMenuItem;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer statusTimer;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem dateiToolStripMenuItem;
        private ToolStripMenuItem neuToolStripMenuItem;
        private ToolStripMenuItem speichernToolStripMenuItem;
        private ToolStripMenuItem ladenToolStripMenuItem;
    }
}
