using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Globalization;
using System.Diagnostics;

namespace CodePad.QB64
{
    public class SettingsQB64 : Settings
    {
        public override string HelpBaseUrl => "http://www.qb64.org/wiki/";

        public SettingsQB64()
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

        public override void LoadDefaults()
        {
            base.LoadDefaults();

            CompilerDirectory = @"C:\Program Files\qb64";
            CompilerExecutable = @"C:\Program Files\qb64\qb64.exe";
            CompilerHelpDirectory = @"C:\Program Files\qb64\internal\help";
        }

        public override void Load()
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
            MainWindowSize = new Size(int.Parse(lines[9]), int.Parse(lines[10]));
        }

        public override void Save()
        {
            List<string> lines = new List<string>
            {
                CompilerDirectory,
                CompilerExecutable,
                CompilerHelpDirectory,
                Font.FontFamily.Name,
                ((int)Font.Size).ToString(),
                Font.Style == FontStyle.Bold ? "true" : "false",
                ForeColor.ToArgb().ToString(),
                BackColor.ToArgb().ToString(),
                MarginColor.ToArgb().ToString(),
                MainWindowSize.Width.ToString(),
                MainWindowSize.Height.ToString()
            };

            File.WriteAllLines(SettingsFile, lines);
        }

        public override ProcessStartInfo GetCompilerProcessInfo(string programSourcePath, string programExecutablePath)
        {
            return new ProcessStartInfo(CompilerExecutable,
                "-c \"" + programSourcePath + "\" -o " + "\"" + programExecutablePath + "\"");
        }
    }
}
