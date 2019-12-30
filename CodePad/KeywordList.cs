﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodePad
{
    public class KeywordList : List<Keyword>
    {
        public KeywordList()
        {
        }

        public KeywordList(string commandsPath)
        {
            DirectoryInfo directory = new DirectoryInfo(commandsPath);
            var files = directory.EnumerateFiles();

            foreach (FileInfo file in files)
            {
                Keyword command = ParseKeywordFromFile(file);
                Add(command);
            }
        }

        public KeywordList(KeywordList other)
        {
            AddRange(other);
        }

        private Keyword ParseKeywordFromFile(FileInfo file)
        {
            string filename = file.Name;
            string name = filename.Replace(file.Extension, "").Trim();
            string wikitext = File.ReadAllText(file.FullName);
            string description = name + 
                Environment.NewLine + 
                Environment.NewLine + 
                WikiTextParser.Parse(wikitext);

            if (string.IsNullOrWhiteSpace(name))
                name = "\\";
            else if (name.Contains("%2F"))
                name = name.Replace("%2F", "/");
            else if (name.Contains("%26"))
                name = name.Replace("%26", "&");

            Keyword keyword = new Keyword(name, description);

            return keyword;
        }
    }
}
