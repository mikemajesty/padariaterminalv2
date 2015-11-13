using Mike.Utilities.Desktop;
using System;
using System.Windows.Forms;
namespace UI.View
{
    static class Program
    {      
        [STAThread]
        static void Main()
        {           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);           
            Application.Run(new View.Menu());
          
        }
    }
}
