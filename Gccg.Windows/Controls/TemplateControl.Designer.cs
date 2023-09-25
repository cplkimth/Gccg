namespace Gccg.Windows.Controls
{
    partial class TemplateControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            uscText = new DG.MiniHTMLTextBox.MiniHTMLTextBox();
            SuspendLayout();
            // 
            // uscText
            // 
            uscText.ActionBarRows = 0;
            uscText.ActionsCutCopyPasteRedoVisible = false;
            uscText.ActionsFontStyleVisible = false;
            uscText.ActionsFontVisible = false;
            uscText.ActionsHorizonalRuleVisible = false;
            uscText.ActionsIndentOutdentVisible = false;
            uscText.ActionsJustifyTextVisible = false;
            uscText.ActionsListsVisible = false;
            uscText.ActionsUndoRedoVisible = false;
            uscText.ActionsViewModeVisible = false;
            uscText.Dock = DockStyle.Fill;
            uscText.IllegalPatterns = new string[] { "<script.*?>", "<\\w+\\s+.*?(j|java|vb|ecma)script:.*?>", "<\\w+(\\s+|\\s+.*?\\s+)on\\w+\\s*=.+?>", "</?input.*?>" };
            uscText.Location = new Point(0, 0);
            uscText.Margin = new Padding(4, 3, 4, 3);
            uscText.Name = "uscText";
            uscText.Padding = new Padding(1);
            uscText.Size = new Size(952, 619);
            uscText.TabIndex = 0;
            uscText.Text = "lorem";
            uscText.TextMode = DG.MiniHTMLTextBox.MiniHTMLTextBox.ViewModeType.Text;
            // 
            // TemplateControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(uscText);
            Name = "TemplateControl";
            Size = new Size(952, 619);
            ResumeLayout(false);
        }

        #endregion

        private DG.MiniHTMLTextBox.MiniHTMLTextBox uscText;
    }
}
