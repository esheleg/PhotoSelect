
using System.Diagnostics; // for using Debug
//using System.Runtime.InteropServices; // import dll's
// --- default -----
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
// -----------------
using PhotoSelectGui;
using Features;


static class guiRunner
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainPS());        
    }
}
