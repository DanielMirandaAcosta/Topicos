namespace GUI_Dinamica
{
    partial class GUI_Dinamica
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
            menuStrip1 = new MenuStrip();
            creadorDeBotonesDinamicosToolStripMenuItem = new ToolStripMenuItem();
            galeriaDinamicaToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { creadorDeBotonesDinamicosToolStripMenuItem, galeriaDinamicaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // creadorDeBotonesDinamicosToolStripMenuItem
            // 
            creadorDeBotonesDinamicosToolStripMenuItem.Name = "creadorDeBotonesDinamicosToolStripMenuItem";
            creadorDeBotonesDinamicosToolStripMenuItem.Size = new Size(183, 20);
            creadorDeBotonesDinamicosToolStripMenuItem.Text = "Creador De Botones Dinamicos";
            creadorDeBotonesDinamicosToolStripMenuItem.Click += creadorDeBotonesDinamicosToolStripMenuItem_Click;
            // 
            // galeriaDinamicaToolStripMenuItem
            // 
            galeriaDinamicaToolStripMenuItem.Name = "galeriaDinamicaToolStripMenuItem";
            galeriaDinamicaToolStripMenuItem.Size = new Size(108, 20);
            galeriaDinamicaToolStripMenuItem.Text = "Galeria Dinamica";
            galeriaDinamicaToolStripMenuItem.Click += galeriaDinamicaToolStripMenuItem_Click;
            // 
            // GUI_Dinamica
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "GUI_Dinamica";
            Text = "GUI_Dinamica";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem creadorDeBotonesDinamicosToolStripMenuItem;
        private ToolStripMenuItem galeriaDinamicaToolStripMenuItem;
    }
}