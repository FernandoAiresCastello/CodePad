using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Globalization;

namespace CodePad
{
    public class Settings
    {
        public static readonly string SettingsFile = "settings.dat";

        public string CompilerDirectory { set; get; }
        public string CompilerExecutable { set; get; }
        public string CompilerHelpDirectory { set; get; }
        public Font Font { set; get; }
        public Color ForeColor { set; get; }
        public Color BackColor { set; get; }
        public Color MarginColor { set; get; }

        private readonly Font DefaultFont = new Font("Consolas", 10, FontStyle.Regular);
        private readonly Color DefaultForeColor = Color.LightGray;
        private readonly Color DefaultBackColor = Color.DarkBlue;
        private readonly Color DefaultMarginColor = Color.DarkCyan;

        public Settings()
        {
            if (File.Exists(SettingsFile))
            {
                Load();
            }
            else
            {
                File.Create(SettingsFile).Close();
                LoadDefaults();
                Save();
            }
        }

        public void LoadDefaults()
        {
            CompilerDirectory = @"C:\Program Files\qb64";
            CompilerExecutable = @"C:\Program Files\qb64\qb64.exe";
            CompilerHelpDirectory = @"C:\Program Files\qb64\internal\help";
            Font = DefaultFont;
            ForeColor = DefaultForeColor;
            BackColor = DefaultBackColor;
            MarginColor = DefaultMarginColor;
        }

        public void Load()
        {
            string[] lines = File.ReadAllLines(SettingsFile);
            for (int i = 0; i < lines.Length; i++)
                lines[i] = lines[i].Trim();

            CompilerDirectory = lines[0];
            CompilerExecutable = lines[1];
            CompilerHelpDirectory = lines[2];

            Font = new Font(lines[3], int.Parse(lines[4]),
                bool.Parse(lines[5]) ? FontStyle.Bold : FontStyle.Regular);

            ForeColor = Color.FromArgb(int.Parse(lines[6]));
            BackColor = Color.FromArgb(int.Parse(lines[7]));
            MarginColor = Color.FromArgb(int.Parse(lines[8]));
        }

        public void Save()
        {
            List<string> lines = new List<string>();

            lines.Add(CompilerDirectory);
            lines.Add(CompilerExecutable);
            lines.Add(CompilerHelpDirectory);
            lines.Add(Font.FontFamily.Name);
            lines.Add(((int)Font.Size).ToString());
            lines.Add(Font.Style == FontStyle.Bold ? "true" : "false");
            lines.Add(ForeColor.ToArgb().ToString());
            lines.Add(BackColor.ToArgb().ToString());
            lines.Add(MarginColor.ToArgb().ToString());

            File.WriteAllLines(SettingsFile, lines);
        }
    }
}
