using System.Windows.Forms;
using System.IO;
using System;

namespace FocoEditor
{
    public static class Gerenciador
    {
        // valores padrão
        public static string DefaultFolderPath => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\";
        public static string DefaultFileName => "Novo Documento";
        public static string DefaultFileExt => ".txt";
        public static bool DefaultFileSaved => true;

        // valores atribuidos
        public static string FolderPath { get; set; } = DefaultFolderPath;
        public static string FileName { get; set; } = DefaultFileName;
        public static string FileExt { get; set; } = DefaultFileExt;
        public static bool FileSaved { get; set; } = DefaultFileSaved;
        public static string FilePath => FolderPath + FileName + FileExt;

        public static void DefaultFile()
        {
            FolderPath = DefaultFolderPath;
            FileName = DefaultFileName;
            FileExt = DefaultFileExt;
            FileSaved = DefaultFileSaved;
            Form.ActiveForm.Text = DefaultFileName + DefaultFileExt;
        }

        public static void EditFile(string path)
        {
            FileInfo file = new FileInfo(path);

            FolderPath = file.DirectoryName + "\\";
            FileName = file.Name.Remove(file.Name.LastIndexOf("."));
            FileExt = file.Extension;
            FileSaved = true;
            Form.ActiveForm.Text = FileName + FileExt;
        }
    }
}
