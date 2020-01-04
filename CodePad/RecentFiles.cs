using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePad
{
    public class RecentFiles
    {
        public List<string> Files { get; private set; }
        public bool IsEmpty => Files.Count == 0;

        private const string RecentFilesListFile = "recent.dat";

        public RecentFiles()
        {
            Files = new List<string>();

            if (File.Exists(RecentFilesListFile))
            {
                Load();
            }
            else
            {
                File.Create(RecentFilesListFile);
            }
        }

        public void Load()
        {
            Files = File.ReadAllLines(RecentFilesListFile).ToList();
        }

        public void Save()
        {
            File.WriteAllLines(RecentFilesListFile, Files);
        }

        public void AddIfNotExists(string file)
        {
            if (!Files.Contains(file))
            {
                Files.Add(file);
            }
        }

        public void Clear()
        {
            Files.Clear();
        }
    }
}
