using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePad
{
    public class Settings
    {
        public virtual string MainWindowSubtitle => "";
        public virtual string SettingsFile => "settings.dat";
        public virtual string HelpBaseUrl => "";

        public string CompilerDirectory { set; get; }
        public string CompilerExecutable { set; get; }
        public string CompilerHelpDirectory { set; get; }
        
        public Font Font { set; get; }
        public Color ForeColor { set; get; }
        public Color BackColor { set; get; }
        public Color MarginColor { set; get; }
        public Size MainWindowSize { set; get; }

        protected readonly Font DefaultFont = new Font("Consolas", 10, FontStyle.Regular);
        protected readonly Color DefaultForeColor = Color.LightGray;
        protected readonly Color DefaultBackColor = Color.DarkBlue;
        protected readonly Color DefaultMarginColor = Color.DarkCyan;
        protected readonly Size DefaultMainWindowSize = new Size(640, 480);

        public virtual void LoadDefaults()
        {
            Font = DefaultFont;
            ForeColor = DefaultForeColor;
            BackColor = DefaultBackColor;
            MarginColor = DefaultMarginColor;
            MainWindowSize = DefaultMainWindowSize;
        }

        public virtual void Load()
        {
            throw new NotImplementedException();
        }

        public virtual void Save()
        {
            throw new NotImplementedException();
        }

        public virtual ProcessStartInfo GetCompilerProcessInfo(string programSourcePath, string programExecutablePath)
        {
            throw new NotImplementedException();
        }
    }
}
