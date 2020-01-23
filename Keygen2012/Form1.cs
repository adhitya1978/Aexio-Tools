using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Security.Permissions;
using System.Security;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DevExpress.Skins.XtraForm;
using DevExpress.XtraEditors.Controls;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using DevExpress.XtraEditors;
using DeployLX.Licensing.v3;
using System.Threading;
using System.Xml.Serialization;
using System.Xml;



[assembly : SuppressIldasm]
namespace Keygen2012
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            
        }
        
       

        private SecureLicense _securelicense;
       
        /**Install Trial Emulator***/
        private void bt_install_Click(object sender, EventArgs e)
        {
            try
            {

                if (fbd.SelectedPath != string.Empty)
                {
                    ExtractingFile(fbd.SelectedPath, "haspdinst.exe");
                    ExtractingFile(fbd.SelectedPath, "Install.bat");
                    if (File.Exists(fbd.SelectedPath + @"\haspdinst") ||File.Exists( fbd.SelectedPath + @"\install.bat"))
                    {
                        Process oprocess = new Process();
                        oprocess.StartInfo.FileName = "Install.bat";
                        oprocess.StartInfo.WorkingDirectory = fbd.SelectedPath;
                        oprocess.StartInfo.CreateNoWindow = true;
                        oprocess.StartInfo.UseShellExecute = true;
                        oprocess.Start();
                        oprocess.WaitForExit();
                        oprocess.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
           
            
        }
        /**Remove Trial Emulator**/
        private void bt_Remove_Click(object sender, EventArgs e)
        {
            /*
            if (bt_Remove.Enabled == true)
            {

                try
                {
                    // Write Emulator to diectory //
                    Assembly emul = Assembly.GetExecutingAssembly();
                    string emulname = "aksinstdel_windows.exe";
                    string emulpath = "C:\\Program Files\\Aexio\\Xeus Pro 2012 Trial\\aksinstdel_windows.exe";
                    WriteResourceToFile(emul, emulname, emulpath);
                    try
                    {
                        Assembly bat = Assembly.GetExecutingAssembly();
                        string batname = "Remove.bat";
                        string batpath = "C:\\Program Files\\Aexio\\Xeus Pro 2012 Trial\\Remove.bat";
                        WriteResourceToFile(bat, batname, batpath);
                        Process scriptProc = new Process();
                        if (File.Exists("C:\\Program Files\\Aexio\\Xeus Pro 2012 Trial\\Remove.bat"))
                        {
                            scriptProc.StartInfo.WorkingDirectory = "C:\\Program Files\\Aexio\\Xeus Pro 2012 Trial\\";
                            scriptProc.StartInfo.FileName = "Remove.bat";
                            scriptProc.StartInfo.CreateNoWindow = false;
                            scriptProc.Start();
                            scriptProc.WaitForExit();
                            bt_install.Visible = true;
                            bt_Remove.Visible = false;
                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Installation emulator Error = Directory not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Cant access file. Maybe File in Use Please Close first/directory not found", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            } */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textEdit2.Text = "Dream RE Experience";
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("McSkin");
            string[] AllVersion = new string[] { "2010 Version 10.2.29", 
                                                 "2012 Version 12.1.66",
                                                 "2012 Version 12.2.10.24897",
                                                 "2012 Version 12.3.28",
                                                 "2012 Version 12.4.35.19489",
                                                 "2012 Version 12.4.87.33030",
                                                 "2012 Version 12.6.29.20417",
                                                 "2013 Version 13.1.118",
                                                 "2013 Version 13.1.158",
                                                 "2013 Version 13.2.84"};


            ComboBoxItemCollection Version = Cb_Version.Properties.Items;
            foreach (string _version in AllVersion)
            {
                Version.Add(_version);
                if (_version == "")
                    break;

            }
            cb_LicMethod.SelectedIndex = 0;
            //xtraTabPage2.PageEnabled = false;
            simpleButton3.Enabled = false;
            simpleButton3.LookAndFeel.SetSkinStyle("Glass Oceans");
            Bt_Generate.LookAndFeel.SetSkinStyle("Glass Oceans");
            Bt_Scan.LookAndFeel.SetSkinStyle("Glass Oceans");
            Bt_Upgrade.LookAndFeel.SetSkinStyle("Glass Oceans");
            bt_install.LookAndFeel.SetSkinStyle("Pumpkin");
            bt_install.Enabled = false;
            bt_Remove.LookAndFeel.SetSkinStyle("Pumpkin");
            bt_Remove.Enabled = false;



            String[] ListFeature = new string[] { "DriveTest", "Statistics", "Ericsson Gpeh", "Huawei PChr", "NSN Megamon", "ZTE Cts", "Ericsson LTE Trace","Huawei LTE", "AluCtg" };
            foreach (string feature in ListFeature)
            {
               checkedComboBoxEdit1.Properties.Items.Add(feature,CheckState.Unchecked,true);
            }
            checkedComboBoxEdit1.Properties.Items["AluCtg"].Enabled = false;
           /**
            DateTime LastWriteAcces = File.GetLastWriteTime(Application.StartupPath + @"\Keygen2012.exe");
            if ((DateTime.Now < LastWriteAcces) || (DateTime.Now > LastWriteAcces.AddMonths(7)))
            {
                XtraMessageBox.Show("Sorry Application Already Expired", "Aexio Tools", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            ***/

        }

        private void Cb_Version_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Cb_Version.SelectedIndex)
            {
                case 0:
                    textEdit1.Text = "1th Jan 2010";
                    Thread.Sleep(TimeSpan.FromMilliseconds(100));
                    simpleButton3.Enabled = true;
                    bt_install.Enabled = true;
                    bt_Remove.Enabled = true;
                    break;
                case 1:
                    textEdit1.Text = "18th July 2011";
                    Thread.Sleep(TimeSpan.FromMilliseconds(500));
                    simpleButton3.Enabled = true;
                     bt_install.Enabled = true;
                    bt_Remove.Enabled = true;
                    break;
                case 2:
                    textEdit1.Text = "28th July 2011";
                    Thread.Sleep(TimeSpan.FromMilliseconds(500));
                    simpleButton3.Enabled = true;
                     bt_install.Enabled = true;
                    bt_Remove.Enabled = true;
                    break;
                case 3:
                    textEdit1.Text = "7th Sept 2011";
                    Thread.Sleep(TimeSpan.FromMilliseconds(500));
                    simpleButton3.Enabled = true;
                     bt_install.Enabled = true;
                    bt_Remove.Enabled = true;
                    break;
                case 4:
                    textEdit1.Text = "3rd Oct 2011";
                    Thread.Sleep(TimeSpan.FromMilliseconds(500));
                    simpleButton3.Enabled = true;
                     bt_install.Enabled = true;
                    bt_Remove.Enabled = true;
                    break;
                case 5:
                    textEdit1.Text = "16th Jan 2012";
                    Thread.Sleep(TimeSpan.FromMilliseconds(500));
                    simpleButton3.Enabled = true;
                     bt_install.Enabled = true;
                    bt_Remove.Enabled = true;
                    break;
                case 6:
                    textEdit1.Text = "11th Sept 2012";
                    Thread.Sleep(TimeSpan.FromMilliseconds(500));
                    simpleButton3.Enabled = true;
                     bt_install.Enabled = true;
                    bt_Remove.Enabled = true;
                    break;
                case 7:
                    textEdit1.Text = "18th Jan 2013";
                    Thread.Sleep(TimeSpan.FromMilliseconds(500));
                    simpleButton3.Enabled = true;
                     bt_install.Enabled = true;
                    bt_Remove.Enabled = true;
                    break;
                case 8:
                    textEdit1.Text = "xxth July 2013";
                    Thread.Sleep(TimeSpan.FromMilliseconds(500));
                    simpleButton3.Enabled = true;
                     bt_install.Enabled = true;
                    bt_Remove.Enabled = true;
                    break;

                case 9:
                    textEdit1.Text = "12 November 2013";
                    Thread.Sleep(TimeSpan.FromMilliseconds(500));
                    simpleButton3.Enabled = true;
                     bt_install.Enabled = true;
                    bt_Remove.Enabled = true;
                    break;

            }


        }

        private void Bt_Generate_Click(object sender, EventArgs e)
        {
            MemoryStream MemStream = new MemoryStream(Properties.Resources.Keys);
            string value = string.Empty;
            SecureLicense sl = new SecureLicense();
            sl.SerialNumber = "1234";
            DeployLX.Licensing.Management.v3.LicenseKey mykey3 = new DeployLX.Licensing.Management.v3.LicenseKey(MemStream);
           // DeployLX.Licensing.Management.v4.LicenseKey key = new DeployLX.Licensing.Management.v4.LicenseKey(MemStream);
            
            memoEdit1.Text = "";
            memoEdit1.SelectedText = DateTime.Now +"---"+ "Start Generate." + Environment.NewLine;
            Thread.Sleep(TimeSpan.FromMilliseconds(100));
            memoEdit1.SelectedText = "----------------" + Environment.NewLine;
            Thread.Sleep(TimeSpan.FromMilliseconds(100));
            switch (cb_LicMethod.SelectedIndex)
            {
                case 0 :
                    memoEdit1.SelectedText = DateTime.Now + "---" + "Generate Serial Standard edition." + Environment.NewLine;
                    string prefix =   "STD-";
                    TxtBox_Result.Text = mykey3.MakeSerialNumber(prefix, 1, DeployLX.Licensing.v3.SerialNumberFlags.None, -1, 0, -1, 0, null, "U9VWT2FG3Q7RS0AC1DEYMNX6P8HJ4KL5", DeployLX.Licensing.v3.CodeAlgorithm.SerialNumber);
                    break;
                case 1 :
                    memoEdit1.SelectedText = DateTime.Now + "---" + "Generate Serial Profesional edition." + Environment.NewLine;
                     string prefix1 =  "PRO-";
                     TxtBox_Result.Text = mykey3.MakeSerialNumber(prefix1, 1, SerialNumberFlags.None, -1, 0, -1, 0, null, "U9VWT2FG3Q7RS0AC1DEYMNX6P8HJ4KL5", CodeAlgorithm.SerialNumber);                   
                     break;
            }
            memoEdit1.SelectedText = "Serial is : " + Environment.NewLine;
            Thread.Sleep(TimeSpan.FromMilliseconds(100));
            memoEdit1.SelectedText = TxtBox_Result.Text + Environment.NewLine;
        }

        private void Bt_Scan_Click(object sender, EventArgs e)
        {
            
            var result = fbd.ShowDialog();
            string path = fbd.SelectedPath;
            
            Thread.Sleep(TimeSpan.FromMilliseconds(100));
            switch (result)
            {
                case DialogResult.OK:
                    if (Directory.Exists(path))
                    {
                        DirectoryInfo info = new DirectoryInfo(path);
                        foreach (FileInfo infoName in info.GetFiles("*.exe"))
                        {
                            if (infoName.Name == "aexioXeus.exe")
                            {
                                var version = DetectVersion(infoName.FullName);
                                memoEdit1.Text = "";
                                memoEdit1.SelectedText = "Version installed : " + Environment.NewLine;
                                memoEdit1.SelectedText = Cb_Version.SelectedItem + Environment.NewLine;
                            }
                            if (infoName.Name == "aexioXeusFree.exe")
                            {
                                string version = DetectVersion(infoName.FullName);
                                memoEdit1.Text = "";
                                memoEdit1.SelectedText = "Version installed : " + Environment.NewLine;
                                memoEdit1.SelectedText = Cb_Version.SelectedItem + Environment.NewLine;
                            }
                        }
                       
                       

                    }
                    else
                    {
                        memoEdit1.SelectedText = Environment.NewLine + "Version Not Found.";
                        Thread.Sleep(TimeSpan.FromMilliseconds(100));
                        XtraMessageBox.Show("Version Not Found." + "\n" + "Please Contact R&D Department !", "Aexio Tools", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case DialogResult.Cancel :
                    break;
            }
           

        }



        /*Utillity*/
        private void Bt_Enc_Click(object sender, EventArgs e)
        {
            try
            {
                string PassWord = "ESsBFuck!.<:{0)9";
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (DialogResult.OK == fbd.ShowDialog())
                {
                    Encrypt(fbd.SelectedPath + @"\aexioXeus.exe", fbd.SelectedPath + @"\aexioXeus.enc", PassWord);
                }


            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
            

        }
        private void BT_Dec_Click(object sender, EventArgs e)
        {
            string PassWord = "ESsBFuck!.<:{0)9";
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (DialogResult.OK == fbd.ShowDialog())
                {
                    decrypt(fbd.SelectedPath + @"\aexioXeus.enc", fbd.SelectedPath + @"\aexioXeus.exe.dec", PassWord);
                }


            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }

        }
        static void Encrypt(string sInputFilename, string sOutputFilename, string sKey)
        {
            RijndaelManaged aes = new RijndaelManaged();

            try
            {
                byte[] key = ASCIIEncoding.UTF8.GetBytes(sKey);

                using (FileStream fsCrypt = new FileStream(sOutputFilename, FileMode.Create))
                {
                    using (CryptoStream cs = new CryptoStream(fsCrypt, aes.CreateEncryptor(key, key), CryptoStreamMode.Write))
                    {
                        using (FileStream fsIn = new FileStream(sInputFilename, FileMode.Open))
                        {
                            int data;

                            while ((data = fsIn.ReadByte()) != -1)
                            {
                                cs.WriteByte((byte)data);
                            }

                            aes.Clear();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                aes.Clear();
            }

        }
        static void decrypt(string sInputFilename, string sOutputFilename, string sKey)
        {
            RijndaelManaged aes = new RijndaelManaged();

            try
            {
                byte[] key = ASCIIEncoding.UTF8.GetBytes(sKey);

                using (FileStream fsCrypt = new FileStream(sInputFilename, FileMode.Open))
                {
                    using (FileStream fsOut = new FileStream(sOutputFilename, FileMode.Create))
                    {
                        using (CryptoStream cs = new CryptoStream(fsCrypt, aes.CreateDecryptor(key, key), CryptoStreamMode.Read))
                        {
                            int data;

                            while ((data = cs.ReadByte()) != -1)
                            {
                                fsOut.WriteByte((byte)data);
                            }

                            aes.Clear();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                aes.Clear();
            }
        }

        
        private void Bt_RmvKey_Click(object sender, EventArgs e)
        {
            
            if(_securelicense.IsActivated || XtraMessageBox.Show("Are you sure you want clear the license? This will stop the application from running.","Aexio Tools",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                _securelicense = SecureLicenseManager.Validate(this, null, null);
             XtraMessageBox.Show("The license has been reset. The application will be shut down");               

            }
           
        }
        private void Bt_Decrypt_Click(object sender, EventArgs e)
        {
            DeployLX.Licensing.v3.SecureLicense Secure = new SecureLicense();
            DeployLX.Licensing.Management.v3.LicenseKey myLicenseKey = new DeployLX.Licensing.Management.v3.LicenseKey(new FileStream("", FileMode.Open));

            myLicenseKey.DecryptLicense(Secure);
        }

        private void cb_LicMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb_LicMethod.SelectedIndex)
            {
                case 0 :
                    cb_LicMethod.ToolTip = "Standard Edition";
                    checkedComboBoxEdit1.Enabled = false;
                    Bt_Upgrade.Enabled = false;
                    break;
                case 1 :
                    cb_LicMethod.ToolTip = "Profesional Edition" + "\n"+ "Require Dongle.";
                    checkedComboBoxEdit1.Enabled = true;
                    Bt_Upgrade.Enabled = true;
                    break;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            
            var UserAnswer = XtraMessageBox.Show("Are U sure about Version.", "Aexio Tools", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            switch (UserAnswer)
            {
                case System.Windows.Forms.DialogResult.OK :
                    try
                    {
                        memoEdit1.Text = "";
                        memoEdit1.SelectedText = "Start Patching " + Environment.NewLine;
                        Thread.Sleep(TimeSpan.FromMilliseconds(100));
                        memoEdit1.SelectedText = "------------------" + Environment.NewLine;
                        Thread.Sleep(TimeSpan.FromMilliseconds(100));
                        if (File.Exists(fbd.SelectedPath +@"\aexioXeus.exe") && Cb_Version.SelectedIndex == 0)
                        {
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Starting ...." + Environment.NewLine;
                            File.Copy(fbd.SelectedPath + @"\aexioXeus.exe", fbd.SelectedPath + @"\aexioXeus.bak", true);
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Create Backup Done." + Environment.NewLine;
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                            ExtractingFile(fbd.SelectedPath, "hasp_windows_93680.dll");
                            if (File.Exists(Environment.CurrentDirectory + @"\2010.10.2.29\AexioXeus.enc"))
                            {
                                decrypt(Environment.CurrentDirectory + @"\Source\2010.10.2.29\aexioXeus.enc",fbd.SelectedPath + @"\aexioXeus.exe", "ESsBFuck!.<:{0)9");
                            }
                            else
                            {
                                XtraMessageBox.Show("File Patch Not Found." + Cb_Version.SelectedText);
                            }
                            
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Patching Done." + Environment.NewLine;
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                        }
                        if (File.Exists(fbd.SelectedPath + @"\aexioXeus.exe") && Cb_Version.SelectedIndex == 1)
                        {
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Starting ...." + Environment.NewLine;
                            File.Copy(fbd.SelectedPath + @"\aexioXeus.exe", fbd.SelectedPath + @"\aexioXeus.bak", true);
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Create Backup Done." + Environment.NewLine;
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                            ExtractingFile(fbd.SelectedPath, "hasp_windows_93680.dll");
                            decrypt(Environment.CurrentDirectory + @"\Source\2012.12.1.66\aexioXeus.enc", fbd.SelectedPath + @"\aexioXeus.exe", "ESsBFuck!.<:{0)9");
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Patching Done." + Environment.NewLine;
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                        }
                        if (File.Exists(fbd.SelectedPath + @"\aexioXeus.exe") && Cb_Version.SelectedIndex == 2)
                        {
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Starting ...." + Environment.NewLine;
                            File.Copy(fbd.SelectedPath + @"\aexioXeus.exe", fbd.SelectedPath + @"\aexioXeus.bak", true);
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Create Backup Done." + Environment.NewLine;
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                            ExtractingFile(fbd.SelectedPath, "hasp_windows_93680.dll");
                            decrypt(Environment.CurrentDirectory + @"\Source\2012.12.2.10.24897\aexioXeus.enc", fbd.SelectedPath + @"\aexioXeus.exe", "ESsBFuck!.<:{0)9");
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Patching Done." + Environment.NewLine;
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                        }
                        if (File.Exists(fbd.SelectedPath + @"\aexioXeus.exe") && Cb_Version.SelectedIndex == 3)
                        {
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Starting ...." + Environment.NewLine;
                            File.Copy(fbd.SelectedPath + @"\aexioXeus.exe", fbd.SelectedPath + @"\aexioXeus.bak", true);
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Create Backup Done." + Environment.NewLine;
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                            ExtractingFile(fbd.SelectedPath, "hasp_windows_93680.dll");
                            decrypt(Environment.CurrentDirectory + @"\Source\2012.12.3.28\aexioXeus.enc", fbd.SelectedPath + @"\aexioXeus.exe", "ESsBFuck!.<:{0)9");
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Patching Done." + Environment.NewLine;
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                        }
                        if (File.Exists(fbd.SelectedPath + @"\aexioXeus.exe") && Cb_Version.SelectedIndex == 4)
                        {
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Starting ...." + Environment.NewLine;
                            File.Copy(fbd.SelectedPath + @"\aexioXeus.exe", fbd.SelectedPath + @"\aexioXeus.bak", true);
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Create Backup Done." + Environment.NewLine;
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                            ExtractingFile(fbd.SelectedPath, "hasp_windows_93680.dll");
                            decrypt(Environment.CurrentDirectory + @"\Source\2012.12.4.35.19489\aexioXeus.enc", fbd.SelectedPath + @"\aexioXeus.exe", "ESsBFuck!.<:{0)9");
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Patching Done." + Environment.NewLine;
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                        }
                        if (File.Exists(fbd.SelectedPath + @"\aexioXeus.exe") && Cb_Version.SelectedIndex == 5)
                        {
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Starting ...." + Environment.NewLine;
                            File.Copy(fbd.SelectedPath + @"\aexioXeus.exe", fbd.SelectedPath + @"\aexioXeus.bak", true);
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Create Backup Done." + Environment.NewLine;
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                            ExtractingFile(fbd.SelectedPath, "hasp_windows_93680.dll");
                            decrypt(Environment.CurrentDirectory + @"\Source\2012.12.4.87.33030\aexioXeus.enc", fbd.SelectedPath + @"\aexioXeus.exe", "ESsBFuck!.<:{0)9");
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Patching Done." + Environment.NewLine;
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                        }
                        if (File.Exists(fbd.SelectedPath + @"\aexioXeus.exe") && Cb_Version.SelectedIndex == 6)
                        {
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Starting ...." + Environment.NewLine;
                            File.Copy(fbd.SelectedPath + @"\aexioXeus.exe", fbd.SelectedPath + @"\aexioXeus.bak", true);
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Create Backup Done." + Environment.NewLine;
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                            ExtractingFile(fbd.SelectedPath, "hasp_windows_93680.dll");
                            decrypt(Environment.CurrentDirectory + @"\Source\2012.12.6.29.20417\aexioXeus.enc", fbd.SelectedPath + @"\aexioXeus.exe", "ESsBFuck!.<:{0)9");
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Patching Done." + Environment.NewLine;
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                        }
                        if (File.Exists(fbd.SelectedPath + @"\aexioXeus.exe") && Cb_Version.SelectedIndex == 7)
                        {
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Starting ...." + Environment.NewLine;
                            File.Copy(fbd.SelectedPath + @"\aexioXeus.exe", fbd.SelectedPath + @"\aexioXeus.bak", true);
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Create Backup Done." + Environment.NewLine;
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                            ExtractingFile(fbd.SelectedPath, "hasp_windows_93680.dll");
                            decrypt(Environment.CurrentDirectory + @"s\Source\2013.1.118\aexioXeus.enc", fbd.SelectedPath + @"\aexioXeus.exe", "ESsBFuck!.<:{0)9");
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Patching Done." + Environment.NewLine;
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                        }
                        if (File.Exists(fbd.SelectedPath + @"\aexioXeus.exe") && Cb_Version.SelectedIndex == 8)
                        {
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Starting ...." + Environment.NewLine;
                            File.Copy(fbd.SelectedPath + @"\aexioXeus.exe", fbd.SelectedPath + @"\aexioXeus.bak", true);
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Create Backup Done." + Environment.NewLine;
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                            ExtractingFile(fbd.SelectedPath, "hasp_windows_93680.dll");
                            decrypt(Environment.CurrentDirectory + @"\Source\2013.1.158\aexioXeus.enc", fbd.SelectedPath + @"\aexioXeus.exe", "ESsBFuck!.<:{0)9");
                            memoEdit1.SelectedText = DateTime.Now + "---" + "Patching Done." + Environment.NewLine;
                            Thread.Sleep(TimeSpan.FromMilliseconds(100));
                        }
                        memoEdit1.SelectedText = "Patching Done." + Environment.NewLine;
                        Thread.Sleep(TimeSpan.FromMilliseconds(100));
                        memoEdit1.SelectedText = "------------------" + Environment.NewLine;
                        Thread.Sleep(TimeSpan.FromMilliseconds(100));
                        memoEdit1.SelectedText = "Now Activate. with Serial" + Environment.NewLine;
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, "Aexio Tools");
                    }
                    break;
                case System.Windows.Forms.DialogResult.Cancel :
                    memoEdit1.SelectedText = "Patching Cancel." + Environment.NewLine;
                    break;
            }
        }
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        private void Bt_Upgrade_Click(object sender, EventArgs e)
        {

            if (File.Exists(fbd.SelectedPath + @"\ProfileCatalog.xml") == true)
            {
                File.Delete(fbd.SelectedPath + @"\ProfileCatalog.xml");
                SolutionProfile _solutionProfile = new SolutionProfile();

                /***-----Section Name--------****/
                Section _SectionMain = new Section();
                Section _SectionFeature = new Section();
                Section _sectionPlugins = new Section();

                /****-----Dependencies---------****/
                Dependencies DependenciesMAin = new Dependencies();

                /**----------Dependency--------**/
                Dependency _DependencyMain = new Dependency();
                Dependency _DependencyFeature = new Dependency();
                Dependency _DependencyPlugins = new Dependency();
                Dependency _DependencyPlugins1 = new Dependency();


                /****------------Assemblly file----------------******/
                SolutionProfileSectionModuleInfo Main = new SolutionProfileSectionModuleInfo();
                SolutionProfileSectionModuleInfo Feature = new SolutionProfileSectionModuleInfo();

                /******------Set Section Name----*********/
                _SectionMain.Name = "Main";
                _SectionFeature.Name = "Features";
                _sectionPlugins.Name = "PlugIns";

                /***-----Set Dependency Name---***/
                _DependencyMain.Name = string.Empty;
                _DependencyFeature.Name = "Main";
                _DependencyPlugins.Name = "Main";
                _DependencyPlugins1.Name = "Feature";

                /**----set assemblly file----**/
                Main.AssemblyFile = "aexio.Xeus.Main.dll";
                Feature.AssemblyFile = "aexio.Xeus.Network.dll";

                /**---Collect----**/
                _SectionMain.Modules = new List<SolutionProfileSectionModuleInfo>();
                _SectionFeature.Modules = new List<SolutionProfileSectionModuleInfo>();
                _sectionPlugins.Modules = new List<SolutionProfileSectionModuleInfo>();

                _SectionMain.Dependencies.Dependency = new List<Dependency>();
                _SectionFeature.Dependencies.Dependency = new List<Dependency>();
                _sectionPlugins.Dependencies.Dependency = new List<Dependency>();

                _solutionProfile.Section = new List<Section>();

                /**---adding---**/
                _solutionProfile.Section.Add(_SectionMain);
                _solutionProfile.Section.Add(_SectionFeature);
                _solutionProfile.Section.Add(_sectionPlugins);

                _SectionMain.Dependencies.Dependency.Add(_DependencyMain);
                _SectionFeature.Dependencies.Dependency.Add(_DependencyFeature);
                _sectionPlugins.Dependencies.Dependency.Add(_DependencyPlugins);
                _sectionPlugins.Dependencies.Dependency.Add(_DependencyPlugins1);


                _SectionMain.Modules.Add(Main);
                _SectionFeature.Modules.Add(Feature);


                if (checkedComboBoxEdit1.Properties.Items["DriveTest"].CheckState == CheckState.Checked)
                {
                    SolutionProfileSectionModuleInfo DriveTest = new SolutionProfileSectionModuleInfo();
                    DriveTest.AssemblyFile = "aexio.Xeus.DriveTest.dll";
                    _sectionPlugins.Modules.Add(DriveTest);
                }
                if (checkedComboBoxEdit1.Properties.Items["Statistics"].CheckState == CheckState.Checked)
                {
                    SolutionProfileSectionModuleInfo Statistics = new SolutionProfileSectionModuleInfo();
                    Statistics.AssemblyFile = "aexio.Xeus.Statistics.dll";
                    _sectionPlugins.Modules.Add(Statistics);
                }
                if (checkedComboBoxEdit1.Properties.Items["Ericsson Gpeh"].CheckState == CheckState.Checked)
                {
                    SolutionProfileSectionModuleInfo Gpeh = new SolutionProfileSectionModuleInfo();
                    Gpeh.AssemblyFile = "aexio.Xeus.Gpeh.dll";
                    _sectionPlugins.Modules.Add(Gpeh);
                }
                if (checkedComboBoxEdit1.Properties.Items["Huawei PChr"].CheckState == CheckState.Checked)
                {
                    SolutionProfileSectionModuleInfo Chr = new SolutionProfileSectionModuleInfo();
                    Chr.AssemblyFile = "aexio.Xeus.Chr.dll";
                    _sectionPlugins.Modules.Add(Chr);
                }
                if (checkedComboBoxEdit1.Properties.Items["NSN Megamon"].CheckState == CheckState.Checked)
                {
                    SolutionProfileSectionModuleInfo Mga = new SolutionProfileSectionModuleInfo();
                    Mga.AssemblyFile = "aexio.Xeus.Mga.dll";
                    _sectionPlugins.Modules.Add(Mga);
                }
                if (checkedComboBoxEdit1.Properties.Items["ZTE Cts"].CheckState == CheckState.Checked)
                {
                    SolutionProfileSectionModuleInfo Cts = new SolutionProfileSectionModuleInfo();
                    Cts.AssemblyFile = "aexio.Xeus.Cts.dll";
                    _sectionPlugins.Modules.Add(Cts);
                }
                if (checkedComboBoxEdit1.Properties.Items["Ericsson Lte Trace"].CheckState == CheckState.Checked)
                {
                    SolutionProfileSectionModuleInfo EriLteTr = new SolutionProfileSectionModuleInfo();
                    EriLteTr.AssemblyFile = "aexio.Xeus.EriLteTr.dll";
                    _sectionPlugins.Modules.Add(EriLteTr);
                }
                /**
                if (checkedComboBoxEdit1.Properties.Items["AluCtg"].CheckState == CheckState.Checked)
                {
                    SolutionProfileSectionModuleInfo AluCtg = new SolutionProfileSectionModuleInfo();
                    AluCtg.AssemblyFile = "aexio.Xeus.AluCtg.dll";
                    _sectionPlugins.Modules.Add(AluCtg);
                }
                ***/
                var serializer = new XmlSerializer(typeof(SolutionProfile));
                var stream = new FileStream(fbd.SelectedPath + @"\ProfileCatalog.xml", FileMode.Create, FileAccess.Write);
                serializer.Serialize(stream, _solutionProfile);
                stream.Close();

            }
            else
            {
                XtraMessageBox.Show("Please Select Directory Installation Aexio.");
            }
    }
        public void ReadXml()
        {
            if(File.Exists(fbd.SelectedPath + @"\ProfileCatalog.xml"))
            {
                XmlSerializer _serializer = new XmlSerializer(typeof(SolutionProfile));
                using (var FS = new FileStream(fbd.SelectedPath + @"\ProfileCatalog.xml",FileMode.Open,FileAccess.Read))
                {
                  
                    StreamReader reader = new StreamReader(FS);
                    string read = reader.ReadToEnd();
                    StringReader ReadXmlFile = new StringReader(read);
                    SolutionProfile profile = (SolutionProfile) _serializer.Deserialize(XmlReader.Create(ReadXmlFile) );
                    foreach (Section SectionName in profile.Section)
                    {
                        if (SectionName.Name == "PlugIns")
                        {
                            foreach (SolutionProfileSectionModuleInfo ModuleInfo in SectionName.Modules)
                            {
                                if (ModuleInfo.AssemblyFile == "aexio.Xeus.DriveTest.dll")
                                {
                                    checkedComboBoxEdit1.Properties.Items.Add("Drive Test");
                                }
                                if (ModuleInfo.AssemblyFile == "aexio.Xeus.Statistics.dll")
                                {
                                    checkedComboBoxEdit1.Properties.Items.Add("Statistics");
                                }
                                if (ModuleInfo.AssemblyFile == "aexio.Xeus.Gpeh.dll")
                                {
                                    checkedComboBoxEdit1.Properties.Items.Add("Ericsson Gpeh");
                                }
                                if (ModuleInfo.AssemblyFile == "aexio.Xeus.Chr.dll")
                                {
                                    checkedComboBoxEdit1.Properties.Items.Add("Huawei PChr");
                                }
                                if (ModuleInfo.AssemblyFile == "aexio.Xeus.Mga.dll")
                                {
                                    checkedComboBoxEdit1.Properties.Items.Add("NSN Megamon");
                                }
                                if (ModuleInfo.AssemblyFile == "aexio.Xeus.Cts.dll")
                                {
                                    checkedComboBoxEdit1.Properties.Items.Add("ZTE Cts");
                                }
                                if (ModuleInfo.AssemblyFile == "aexio.Xeus.EriLteTr.dll")
                                {
                                    checkedComboBoxEdit1.Properties.Items.Add("Ericsson Lte Trace");
                                }
                                if (ModuleInfo.AssemblyFile == "aexio.Xeus.AluCtg.dll")
                                {
                                    checkedComboBoxEdit1.Properties.Items.Add("AluCtg");
                                    checkedComboBoxEdit1.Properties.Items["AluCtg"].Enabled = false;
                                }
                                
                                
                            }
                        }
                       
                        
                    }
                    reader.Close();
                    FS.Close();
                }
               
            }
        }
        public string DetectVersion(string filename)
        {
            string FileVersion = string.Empty;
            FileVersionInfo _fileversion = FileVersionInfo.GetVersionInfo(filename);
            string version = _fileversion.ProductVersion;
            Thread.Sleep(TimeSpan.FromMilliseconds(100));
            switch (version)
            {
                case "10.2.29.*":
                    Cb_Version.SelectedIndex = 0;

                    break;
                case "12.1.66.*":
                    Cb_Version.SelectedIndex = 1;

                    break;
                case "12.2.10.*":
                    Cb_Version.SelectedIndex = 2;

                    break;
                case "12.3.28.*":
                    Cb_Version.SelectedIndex = 3;

                    break;
                case "12.4.35.*":
                    Cb_Version.SelectedIndex = 4;

                    break;
                case "2012.4.87.*":
                    Cb_Version.SelectedIndex = 5;

                    break;
                case "2012.6.29.*":
                    Cb_Version.SelectedIndex = 6;

                    break;
                case "2013.1.158.*":
                    Cb_Version.SelectedIndex = 8;

                    break;
                case "2013.2.90.*":
                    Cb_Version.SelectedIndex = 9;
                    break;


            }
            return FileVersion;
 
        }
        public void ExtractingFile(string PathFile,string resourcesName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] ResourcesName = asm.GetManifestResourceNames();
            foreach (string NameFileResources in ResourcesName)
            {
                if (NameFileResources.EndsWith(resourcesName))
                {
                    using (Stream stream = asm.GetManifestResourceStream(NameFileResources))
                    {
                        if (stream != null)
                        {
                            byte[] buffer = new byte[stream.Length];
                            stream.Read(buffer, 0, buffer.Length);
                            using (BinaryWriter writer = new BinaryWriter(new FileStream(PathFile + @"\" + resourcesName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)))
                            {
                                writer.Write(buffer);
                                writer.Close();

                            }

                        }
                    }

 
                }
            }
        }

   
        static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments. 
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("Key");
            byte[] encrypted;
            // Create an Rijndael object 
            // with the specified key and IV. 
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption. 
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream. 
            return encrypted;

        }
        static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments. 
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("Key");

            // Declare the string used to hold 
            // the decrypted text. 
            string plaintext = null;

            // Create an Rijndael object 
            // with the specified key and IV. 
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption. 
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream 
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }

        private void bt_Remove_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (fbd.SelectedPath != string.Empty)
                {
                    ExtractingFile(fbd.SelectedPath, "aksinstdel_windows.exe");
                    ExtractingFile(fbd.SelectedPath, "Remove.bat");
                    if (File.Exists(fbd.SelectedPath + @"\aksinstdel_windows.exe") || File.Exists(fbd.SelectedPath + @"\Remove.bat"))
                    {
                        Process oprocess = new Process();
                        oprocess.StartInfo.FileName = "Remove.bat";
                        oprocess.StartInfo.WorkingDirectory = fbd.SelectedPath;
                        oprocess.StartInfo.CreateNoWindow = true;
                        oprocess.StartInfo.UseShellExecute = true;
                        oprocess.Start();
                        oprocess.WaitForExit();
                        oprocess.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}
