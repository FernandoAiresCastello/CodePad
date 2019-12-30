﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodePad
{
    public class Settings
    {
        public static readonly string SettingsFile = "settings.ini";

        public string CompilerDirectory { set; get; }
        public string CompilerExecutable { set; get; }
        public string CompilerHelpDirectory { set; get; }

        public Settings()
        {
            string[] lines = File.ReadAllLines(SettingsFile);

            CompilerDirectory = lines[0].Trim();
            CompilerExecutable = lines[1].Trim();
            CompilerHelpDirectory = lines[2].Trim();
        }
    }
}