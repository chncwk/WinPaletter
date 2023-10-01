﻿using System.ComponentModel;
using System.Windows.Forms;

namespace WinPaletter.UI.WP
{

    [Description("TreeView fixed to respect dark/light mode")]
    public class TreeView : System.Windows.Forms.TreeView
    {
        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style = parms.Style | 0x80;
                return parms;
            }
        }
    }

}