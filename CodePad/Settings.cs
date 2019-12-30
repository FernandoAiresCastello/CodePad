using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace CodePad
{
    public class Settings
    {
        public static readonly string SettingsFile = "settings.ini";

        public string CompilerDirectory { get; }
        public string CompilerExecutable { get; }
        public string CompilerHelpDirectory { get; }
        public Font Font { get; }
        public Color ForeColor { get; }
        public Color BackColor { get; }

        public Settings()
        {
            string[] lines = File.ReadAllLines(SettingsFile);
            for (int i = 0; i < lines.Length; i++)
                lines[i] = lines[i].Trim();

            CompilerDirectory = lines[0];
            CompilerExecutable = lines[1];
            CompilerHelpDirectory = lines[2];

            Font = new Font(lines[3], int.Parse(lines[4]), 
                bool.Parse(lines[5]) ? FontStyle.Bold : FontStyle.Regular);

            ForeColor = Color.FromName(lines[6]);
            BackColor = Color.FromName(lines[7]);
        }
    }
}
