using CatalogPdf.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatalogPdf
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);           
            Application.Run(new frmMain());            
        }

        /// <summary>
        /// Сохранить путь в настройки
        /// </summary>
        /// <param name="path"></param>
        public static void SavePath(string path)
        {

            if (Directory.Exists(path))
            {
                Settings.Default.CurrentCatalogPath = path;
                Settings.Default.Save();
            }
        }

        /// <summary>
        /// Диалог выбора папки
        /// </summary>
        /// <returns></returns>
        public static string GetFolderBrowser()
        {
            string folderFind = "";
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    folderFind = fbd.SelectedPath;
                }
            }
            return folderFind;
        }

    }
}
