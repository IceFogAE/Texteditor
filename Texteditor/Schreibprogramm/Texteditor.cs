using System;
using System.Drawing;
using System.Runtime.ConstrainedExecution;

namespace Texteditor
{
    public partial class Texteditor : Form
    {
        // setzte die Standart Farbe auf Schwarz
        private Color currentTextColor = Color.Black;

        public Texteditor()
        {
            InitializeComponent();

            // Aktualisiert das Aussehen des Farbauswahlbuttons
            UpdateColorButtonAppearance();

            // Initialisiere Scrollbalken basierend auf dem Startzustand des Fensters.
            UpdateScrollbars();

            // Schriftgrößen hinzufügen
            int[] fontSizes = { 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 48, 72 };
            foreach (int size in fontSizes)
            {
                comboBoxSize.Items.Add(size.ToString());
            }

            // im System vorhandene Schriftarten laden
            HashSet<string> uniqueFonts = new HashSet<string>(); // verhindert Duplikate bei den Schriftarten
            foreach (FontFamily font in FontFamily.Families)
            {
                if (uniqueFonts.Add(font.Name))
                {
                    comboBoxFont.Items.Add(font.Name);
                }
            }

            comboBoxFont.DrawMode = DrawMode.OwnerDrawFixed;
            comboBoxFont.DrawItem += new DrawItemEventHandler(comboBox2_DrawItem);
            comboBoxFont.DrawItem += comboBoxFont_DrawItem;

            this.Load += new EventHandler(Texteditor_Load);
            comboBoxFont.DropDown += new EventHandler(comboBox2_DropDown);


            this.Resize += new EventHandler(Texteditor_Resize);
        }

        private void Texteditor_Resize(object sender, EventArgs e)
        {
            UpdateScrollbars();
        }

        private void UpdateScrollbars()
        {
            if (WindowState == FormWindowState.Maximized)
            {
                // Vollbild: Scrollbalken ausblenden und Zeilenumbruch aktivieren
                richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
                richTextBox1.WordWrap = true;
            }
            else
            {
                // Fenstermodus: Beide Scrollbalken anzeigen und Zeilenumbruch deaktivieren
                richTextBox1.ScrollBars = RichTextBoxScrollBars.Both;
                richTextBox1.WordWrap = false;
            }
        }

        private void Texteditor_Load(object sender, EventArgs e)
        {
            float defaultFontSize = 11; // standart Schriftgröße
            string defaultFontFamily = "Arial"; // standart Schriftart

            richTextBox1.Font = new Font(defaultFontFamily, defaultFontSize);
            richTextBox1.TextChanged += new EventHandler(richTextBox1_TextChanged);

            comboBoxSize.SelectedItem = defaultFontSize.ToString();
            comboBoxFont.SelectedItem = defaultFontFamily;
            comboBoxFont.SelectedIndexChanged += comboBoxFont_SelectedIndexChanged;

            buttonColor.BackColor = currentTextColor;

            // Timer für Statusaktualisierungen initialisieren
            statusTimer.Interval = 5000; // 5 Sekunden
        }

        // DropDown Menü für die Schriftarten
        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            int width = senderComboBox.Width;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;

            // Berechne die Breite der vertikalen Scrollbar, falls nötig
            int vertScrollBarWidth = (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems) ? SystemInformation.VerticalScrollBarWidth : 0;

            // Ermittle die maximale Breite der Einträge
            foreach (string s in senderComboBox.Items)
            {
                int newWidth = (int)g.MeasureString(s, font).Width + vertScrollBarWidth;
                if (width < newWidth)
                {
                    width = newWidth;
                }
            }
            // Setze die Breite des Dropdown-Menüs auf die maximale Breite der Einträge
            senderComboBox.DropDownWidth = width;
        }

        // Schriftarten im Dropdown Menü in ihrer Schriftart anzeigen
        private void comboBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return; // Wenn kein gültiger Index, beende die Methode

            e.DrawBackground();

            string fontName = comboBoxFont.Items[e.Index].ToString();

            using (Font font = new Font(fontName, comboBoxFont.Font.Size))
            {
                Color textColor = comboBoxFont.ForeColor;
                using (Brush brush = new SolidBrush(textColor))
                {
                    // Zeichne den Schriftnamen in der entsprechenden Schriftart
                    e.Graphics.DrawString(fontName, font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
                }
            }

            e.DrawFocusRectangle();
        }

        // Button für Fett
        private void buttonBold_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle = currentFont.Style ^ FontStyle.Bold; // Toggle Fett
                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);

                // Highlight-Logik
                if (richTextBox1.SelectionFont.Bold)
                {
                    buttonBold.BackColor = Color.LightGray; // Button gehighlightet
                }
                else
                {
                    buttonBold.BackColor = SystemColors.Control; // Standardfarbe
                }
                richTextBox1.Focus();
            }

        }

        // Button für Kursive
        private void buttonItalic_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle = currentFont.Style ^ FontStyle.Italic; // Toggle Kursive
                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);

                // Highlight-Logik
                if (richTextBox1.SelectionFont.Italic)
                {
                    buttonItalic.BackColor = Color.LightGray; // Button gehighlightet
                }
                else
                {
                    buttonItalic.BackColor = SystemColors.Control; // Standardfarbe
                }
                richTextBox1.Focus();
            }

        }

        // Button für Unterstreichen
        private void buttonUnderline_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle = currentFont.Style ^ FontStyle.Underline; // Toggle Unterstrich
                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);

                // Highlight-Logik
                if (richTextBox1.SelectionFont.Underline)
                {
                    buttonUnderline.BackColor = Color.LightGray; // Button gehighlightet
                }
                else
                {
                    buttonUnderline.BackColor = SystemColors.Control; // Standardfarbe
                }
                richTextBox1.Focus();
            }
        }

        // Button für die Schriftfarbe        
        private void buttonColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                if (richTextBox1.SelectionLength > 0)
                {
                    richTextBox1.SelectionColor = colorDialog1.Color;
                }
                else
                {
                    currentTextColor = colorDialog1.Color;
                    richTextBox1.SelectionColor = currentTextColor;
                }
                UpdateColorButtonAppearance();
            }
            richTextBox1.Focus();
        }

        private void comboBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                float newSize = float.Parse(comboBoxSize.SelectedItem.ToString()); // Neue Schriftgröße aus ComboBox
                Font currentFont = richTextBox1.SelectionFont;
                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, newSize, currentFont.Style);
            }
            richTextBox1.Focus();
        }

        private void comboBoxFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null && comboBoxFont.SelectedItem != null)
            {
                string newFontFamily = comboBoxFont.SelectedItem.ToString();
                Font currentFont = richTextBox1.SelectionFont;
                richTextBox1.SelectionFont = new Font(newFontFamily, currentFont.Size, currentFont.Style);
            }
            richTextBox1.Focus();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // Speichern der aktuellen Cursor-Position und Auswahllänge
            int selectionStart = richTextBox1.SelectionStart;
            int selectionLength = richTextBox1.SelectionLength;

            // Setzen der Auswahl auf das Ende des Textes
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.SelectionLength = 0;
            richTextBox1.SelectionColor = currentTextColor; // Anwenden der aktuellen Textfarbe auf die neue Auswahl (am Ende des Textes)

            // Wiederherstellen der ursprünglichen Cursor-Position und Auswahllänge
            richTextBox1.SelectionStart = selectionStart;
            richTextBox1.SelectionLength = selectionLength;
        }

        // Datei speichern als .rtf mit eigenem Namen
        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Rich Text Format (*.rtf)|*.rtf|All Files (*.*|*.*)";
            saveFileDialog1.DefaultExt = "rtf";
            saveFileDialog1.Title = "Datei speichern";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Rtf);
                    toolStripStatusLabel1.Text = "Datei erfolgreich gespeichert.";
                    statusTimer.Start(); // Timer wird gestartet
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim Speichern der Datei: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    toolStripStatusLabel1.Text = "Fehler beim Speichern";
                }
            }
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        // .rtf Datei öffnen
        private void ladenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "Rich Text Format (*.rtf)|*.rtf|All Files (*.*|*.*)",
                Title = "RTF_Datei öffnen"
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    richTextBox1.Rtf = File.ReadAllText(openFileDialog1.FileName);
                    toolStripStatusLabel1.Text = "Datei erfolgreich geöffnet";
                    statusTimer.Start(); // Timer starten
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim Öffnen der Datei: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    toolStripStatusLabel1.Text = "Fehler beim Öffnen";
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void pdfExportierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO export
        }

        private void hellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleColorMode(false); // aktiviert den hellen Modus
        }

        private void dunkelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleColorMode(true); // aktiviert den dunklen Modus
        }

        // Umschalten zwischen hellem und dunklem Modus
        private void ToggleColorMode(bool isDarkMode)
        {
            // Speichere die aktuelle Cursorposition und Auswahl
            int cursorPosition = richTextBox1.SelectionStart;
            int selectionLength = richTextBox1.SelectionLength;

            if (isDarkMode)
            {
                // Dunkles Farbschema anwenden
                this.BackColor = Color.FromArgb(30, 30, 30);
                this.ForeColor = Color.White;
                menuStrip1.BackColor = Color.FromArgb(45, 45, 45);
                menuStrip1.ForeColor = Color.White;
                richTextBox1.BackColor = Color.FromArgb(30, 30, 30);
                richTextBox1.ForeColor = Color.White;
                currentTextColor = Color.White;

                comboBoxFont.BackColor = Color.FromArgb(45, 45, 45);
                comboBoxFont.ForeColor = Color.White;
            }
            else
            {
                // Helles Farbschema anwenden
                this.BackColor = SystemColors.Window;
                this.ForeColor = SystemColors.WindowText;
                menuStrip1.BackColor = SystemColors.Menu;
                menuStrip1.ForeColor = SystemColors.MenuText;
                richTextBox1.BackColor = SystemColors.Window;
                richTextBox1.ForeColor = SystemColors.WindowText;
                currentTextColor = Color.Black;

                comboBoxFont.BackColor = SystemColors.Window;
                comboBoxFont.ForeColor = SystemColors.WindowText;
            }

            Console.WriteLine($"Mode changed. Current Text Color: {currentTextColor}");

            // Alle Steuerelemente aktualisieren
            UpdateControlColors(this, isDarkMode);

            // Aktualisiere die Textfarbe für den gesamten Text
            richTextBox1.SelectAll();
            richTextBox1.SelectionColor = currentTextColor;
            richTextBox1.SelectionLength = 0; // Hebt die Auswahl auf

            // Stelle die ursprüngliche Cursorposition und Auswahl wieder her
            richTextBox1.Select(cursorPosition, selectionLength);

            // Aktualisiere den Farbbutton separat
            UpdateColorButtonAppearance();

            comboBoxFont.Invalidate(); // Erzwingt Neuzeichnen der ComboBox
        }

        private void UpdateColorButtonAppearance()
        {
            // Aktualisiere die Hintergrundfarbe des Farbbuttons
            buttonColor.BackColor = currentTextColor;
            buttonColor.ForeColor = GetContrastColor(currentTextColor);
            // Erzwinge eine Neuzeichnung des Buttons
            buttonColor.Invalidate();

        }

        private Color GetContrastColor(Color color)
        {
            // Berechne die Helligkeit der Farbe
            double brightness = (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;

            // Wähle Weiß für dunkle Farben und Schwarz für helle Farben
            return brightness > 0.5 ? Color.Black : Color.White;
        }

        private void UpdateControlColors(Control control, bool isDarkMode)
        {
            if (control is Button btn)
            {
                if (isDarkMode)
                {
                    control.BackColor = Color.FromArgb(60, 60, 60);
                    control.ForeColor = Color.White;
                }
                else
                {
                    control.BackColor = SystemColors.Control;
                    control.ForeColor = SystemColors.ControlText;
                }

                if (control == buttonColor)
                {
                    btn.BackColor = currentTextColor;
                    btn.ForeColor = GetContrastColor(currentTextColor);
                }
            }
            else
            {
                if (isDarkMode)
                {
                    control.BackColor = Color.FromArgb(30, 30, 30);
                    control.ForeColor = Color.White;
                }
                else
                {
                    control.BackColor = SystemColors.Window;
                    control.ForeColor = SystemColors.WindowText;
                }
            }
            foreach (Control childControl in control.Controls)
            {
                UpdateControlColors(childControl, isDarkMode);
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        // Timer für die Statusleiste
        private void statusTimer_Tick(object sender, EventArgs e)
        {
            statusTimer.Stop();
            toolStripStatusLabel1.Text = ""; // Statusleiste leeren
        }

        private void comboBoxFont_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();
            string fontName = comboBoxFont.Items[e.Index].ToString();
            using (Font font = new Font(fontName, comboBoxFont.Font.Size))
            {
                // Verwende die aktuelle Vordergrundfarbe der ComboBox
                using (Brush brush = new SolidBrush(comboBoxFont.ForeColor))
                {
                    e.Graphics.DrawString(fontName, font, brush, e.Bounds.X, e.Bounds.Y);
                }
            }
            e.DrawFocusRectangle();
        }

        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Prüfen, ob ungespeicherte Änderungen vorhanden sind
            if (richTextBox1.Modified)
            {
                DialogResult result = MessageBox.Show("Möchten Sie die Änderungen speichern?", "Ungespeicherte Änderungen", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    // Hier Speichern-Funktion aufrufen
                    speichernToolStripMenuItem_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    return; // Abbrechen, wenn der Benutzer auf "Abbrechen" klickt
                }
            }

            // Textfeld leeren
            richTextBox1.Clear();

            // Zurücksetzen des "Modified" Flags
            richTextBox1.Modified = false;

            // Zurücksetzen des Dateinamens (falls Sie einen verwenden)
            // currentFileName = null;

            // Aktualisieren der Statusleiste
            toolStripStatusLabel1.Text = "Neues Dokument erstellt";
            statusTimer.Start();
        }

        private void einstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
