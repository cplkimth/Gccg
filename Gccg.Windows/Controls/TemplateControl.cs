using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DG.MiniHTMLTextBox;

namespace Gccg.Windows.Controls;

public partial class TemplateControl : UserControl
{
    public TemplateControl()
    {
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (DesignMode || Program.IsRunTime == false)
            return;

        uscText.ViewMode = MiniHTMLTextBox.ViewModeType.Text;
        uscText.Text = File.ReadAllText(@"C:\git\Gccg\Examples\Chinook\Chinook.Data\Gccg\_Data.jsonmp");
    }
}