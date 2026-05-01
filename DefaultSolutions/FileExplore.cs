namespace DefaultSolutions
{
    public static class FileExplore
    {
        public static string OpenAndReadText(string? sourceFilePath)
        {
            if (string.IsNullOrWhiteSpace(sourceFilePath)
                || !File.Exists(sourceFilePath))
            {
                return "";
            }

            string text;

            try
            {
                text = File.ReadAllText(sourceFilePath);
            }
            catch
            {
                string fileName = Path.GetFileName(sourceFilePath);
                string openPath =
                    Path.Combine(AppContext.BaseDirectory, fileName);

                try
                {
                    File.Copy(sourceFilePath, openPath, true);
                    text = File.ReadAllText(openPath);
                }
                catch
                {
                    return "";
                }

                try
                {
                    File.Delete(openPath);
                }
                finally { }
            }

            return text;
        }

        public static string OpenAndReadText(this FileInfo sourceFile)
        {
            if (sourceFile is null)
            {
                return "";
            }

            return OpenAndReadText(sourceFile.FullName);
        }
    }
}