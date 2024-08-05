namespace ShoppingCartProject.Manager
{
    public class WriteLoging
    {

        public WriteLoging()
        {
        }

        public void WriteLog(string logMessage)
        {
            string stringLogPath = @"C:\Logs\" + DateTime.Today.ToString("dd-MM-yyyy") + "." + "txt";
            FileInfo log_FileInfo = new FileInfo(stringLogPath);
            DirectoryInfo log_DirInfo = new DirectoryInfo(log_FileInfo.DirectoryName);
            if (!log_DirInfo.Exists) log_DirInfo.Create();
            using (FileStream file_Stream = new FileStream(stringLogPath, FileMode.Append))
            {
                using (StreamWriter log = new StreamWriter(file_Stream))
                {
                    log.WriteLine(logMessage);
                }
            }
        }
    }
}
