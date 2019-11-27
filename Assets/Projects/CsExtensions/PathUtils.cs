using System;
using System.IO;

namespace CsExtensions {
    public static class PathUtils {
        public static string FilenameWithoutDirectory(string filepath) {
            int pathId = filepath.LastIndexOf("\\", StringComparison.Ordinal) + 1;
            return pathId > 0 ? filepath.Substring(pathId, filepath.Length - pathId) : null;
        }

        public static string FilenameWithoutDirectoryAndExt(string filepath, string extension) {
            if (string.IsNullOrEmpty(extension))
                return null;
            if (!extension.StartsWith("."))
                extension = "." + extension;
            string filename = FilenameWithoutDirectory(filepath);
            int extId = filename.IndexOf(extension, StringComparison.Ordinal);
            if (extId >= 0)
                return filename.Substring(0, extId);
            return null;
        }

        public static string DirectoryPath(string filepath, bool withSlash = true) {
            int id = filepath.LastIndexOf("\\", StringComparison.Ordinal);
            if (id < 0)
                return null;
            if (withSlash)
                id += 1;
            return filepath.Substring(0, id);
        }

        public static string LastDirectoryName(string path) {
            while (true) {
                int id = path.LastIndexOf("\\", StringComparison.Ordinal);
                if (id < 0) 
                    return string.Empty;
                if (id == path.Length - 1) {
                    path = path.Substring(0, path.Length - 1);
                    continue;
                }
                return path.Substring(id + 1, path.Length - id - 1);
            }
        }

        public static string ProjectPath(string solutionProjectPath) {
            string currentDir = Directory.GetCurrentDirectory();
            return SimplifyPath(Path.Combine(currentDir, string.Format("..\\..\\..\\{0}", solutionProjectPath)));
        }

        public static string SolutionPath(string globalProjectPath) {
            string currentDir = Directory.GetCurrentDirectory();
            string dir = Path.Combine(currentDir, "..\\..\\..\\");
            dir = SimplifyPath(dir);
            int startId = dir.Length;
            if (globalProjectPath.Length < startId)
                return null;
            return globalProjectPath.Substring(startId, globalProjectPath.Length - startId);
        }

        public static string SimplifyPath(string path) {
            int id = path.IndexOf("\\..\\", StringComparison.Ordinal);
            while (id >= 0) {
                int prevSlashesId = path.LastIndexOf("\\", id-1, id-1, StringComparison.Ordinal);
                if (prevSlashesId < 0) 
                    break;
                path = path.Substring(0, prevSlashesId+1) + path.Substring(id + 4);
                id = path.IndexOf("\\..\\", StringComparison.Ordinal);
            }
            return path;
        }
    }
}