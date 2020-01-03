using CodePad.QB64;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodePad
{
    static class EntryPoint
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainWindowLogic logic = new MainWindowLogicQB64();

            Application.Run(new MainWindow(logic));
        }
    }
}
