using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace TestDeleteFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //DeleteSpecialFile("System.IO.dll");
            //bool result = VerifySpecialFileExist("System.IO.dll");
            //bool resultDelete = VerifySpecialFileNotExist("System.IO.dll");
            //Console.WriteLine(result);
            //Console.WriteLine(resultDelete);
            //VerifyDFUpdateProcessQuit();
            GetSpceialRegistryKey("Demandforce Sync Client");
            Console.ReadLine();
        }

        public static void GetSpceialRegistryKey(string serviceName)
        {
            RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);
            RegistryKey regname = hklm.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\" + serviceName);
            string[] names = hklm.GetValueNames();
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }
        }
        public static void DeleteSpecialFile(String str)
        {
            string deleteFilePath = @"C:\Intuit\Demandforce\Sync Client\DFLinkClient";
            string[] deleteFiles = Directory.GetFiles(deleteFilePath);
            string movedFile = @"C:\Intuit\Demandforce\Sync Client\DFLinkClient\" + str;

                foreach (string deletedFile in deleteFiles)
                {
                if (deletedFile.Equals(movedFile))
                {

                    File.SetAttributes(movedFile, FileAttributes.Normal);
                    try
                    {
                        File.Delete(movedFile);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message.ToString());
                    }
                   
                }
                //File.SetAttributes(movedFile, FileAttributes.Normal);
                //    int retry = 3;
                //    Exception lastException = null;
                //    while (retry-- >= 0)
                //    {
                //        try
                //        {
                //            File.Delete(movedFile);
                //            return;
                //        }
                //        catch (Exception e)
                //        {
                //            lastException = e;
                //            Console.WriteLine(e);
                //        }
                //    }
            }

        }

        public static bool VerifySpecialFileExist(String str)
        {
            string deleteFilePath = @"C:\Intuit\Demandforce\Sync Client\DFLinkClient";
            string[] deleteFiles = Directory.GetFiles(deleteFilePath);
            String movedFile = @"C:\Intuit\Demandforce\Sync Client\DFLinkClient\" + str;
            foreach (string deletedFile in deleteFiles)
            {
                if (deletedFile.Equals(movedFile))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool VerifySpecialFileNotExist(String str)
        {
            string deleteFilePath = @"C:\Intuit\Demandforce\Sync Client\DFLinkClient";
            string[] deleteFiles = Directory.GetFiles(deleteFilePath);
            String movedFile = @"C:\Intuit\Demandforce\Sync Client\DFLinkClient\" + str;
            foreach (string deletedFile in deleteFiles)
            {
                if (deletedFile.Equals(movedFile))
                {
                    return false;
                }
            }
            return true;
        }

        public static void RenameFile(string rootDir, string source, string target)
        {

        }

        public static void VerifyDFUpdateProcessQuit()
        {
            string processDFUpdateName = "DFLinkAdmin";
            DateTime testStarted = DateTime.Now;
            System.Threading.Thread.Sleep(10000);
            Monitor:
            DateTime testEnd = DateTime.Now;
            TimeSpan diff = testEnd.Subtract(testStarted);
            Console.WriteLine(diff);
            if (diff.TotalSeconds>13)
            {
                Console.WriteLine("The waitting time is too long");
                goto End;
            }
            Process[] process = Process.GetProcesses();
            bool UpdateProcessisAlive = true;
            Console.WriteLine("again");
            while (UpdateProcessisAlive)
            {
                foreach (Process pro in process)
                {
                    if (pro.ProcessName.Equals(processDFUpdateName))
                    {
                        UpdateProcessisAlive = true;
                        goto Monitor;
                    }
                }
                Console.WriteLine("DF.exe is quit, go to next step");
                UpdateProcessisAlive = false;
            }
            End:
            Console.WriteLine("Jump form while loop");
        }
    }
}
