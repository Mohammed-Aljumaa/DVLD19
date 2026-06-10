using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvldBusinessLayer;
using DvldBusinessLayer.BLLClasses;
using System.IO;
using System.Windows.Forms;

namespace frmDvld.LoginScreens.ClaassLoginScreen
{
     internal static class clsGlobal
    {
        public static clsUsers CurrentUser;

        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            try
            {
                string currentDirectory=System.IO.Directory.GetCurrentDirectory();

                string FilePath=currentDirectory+"\\data.txt";
                //string FilePath = Path.Combine(currentDirectory, "data.txt");

                if(Username==""&&File.Exists(FilePath))
                    {

                    File.Delete(FilePath);
                    return true;
                }
                string DataToSave=Username+"#//#" + Password;

                using (StreamWriter writer=new StreamWriter(FilePath))
                {
                    writer.WriteLine(DataToSave);
                    return true;
                }

            }catch (Exception ex)
            {
               MessageBox.Show($"An error occurred: {ex.Message}");
                return false;

            }
        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            try
            {

                string currentDirectory = System.IO.Directory.GetCurrentDirectory();



                string filePath = currentDirectory + "\\data.txt";

                if(File.Exists(filePath))
                {
                    using(StreamReader reader=new StreamReader(filePath))
                    {
                        string Line;
                        while((Line=reader.ReadLine())!=null)
                        {
                            Console.WriteLine(Line);
                            string[] Resulte = Line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            Username= Resulte[0];
                            Password= Resulte[1];
                        }
                        return true;
                    }
                }else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }

        }
    }
