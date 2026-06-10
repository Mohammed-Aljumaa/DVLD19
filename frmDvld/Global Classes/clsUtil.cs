using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace frmDvld
{
    internal class clsUtil
    {

        public static string GenerateGUID()
        {
            return Guid.NewGuid().ToString();
        }

        public static bool CreateFolderIfDoseNotExist(string FolderPath)
        {
            
                try
                {
                    if (!Directory.Exists(FolderPath))
                    {
                        Directory.CreateDirectory(FolderPath);
                    }

                    // إذا وصل لهون، فكل شيء تمام
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في إنشاء المجلد:\n" + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        

        public static string ReplaceFileNmaeWithGUID(string SourcFile)
        {
            string FileName = SourcFile;
            FileInfo Fi = new FileInfo(FileName);
            string Extn = Fi.Extension;
            return GenerateGUID() + Extn;
        }

        public static bool CopyImageToProjectImageFolder(ref string SourceFile)
        {

            string DestinationFolder = @"C:\PeopleImages_Dvld\";

            if (!CreateFolderIfDoseNotExist(DestinationFolder))
            {
                return false;
            }
            string DestinationFile = DestinationFolder + ReplaceFileNmaeWithGUID(SourceFile);
            try
            {
                File.Copy(SourceFile, DestinationFile, true);
            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            SourceFile = DestinationFile;
            return true;
        }
    }
}
