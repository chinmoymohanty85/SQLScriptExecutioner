using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace WinFormSQLScriptExcutionar
{
    public partial class Home : Form
    {
        OpenFileDialog ofd;
        Server server;
        string DBtoBackup;
        Database db;
        BackupDeviceItem bdi;
        int recoverymod;
        string errorMessageDetails = String.Empty;
        public Home()
        {
            InitializeComponent();
            lblMessage.Text = String.Empty;
            txtConnectionString.Text = @"Data Source=.\SQLExpress;Initial Catalog=master;Integrated Security=True";
            DBtoBackup = "eMARDevice";
            SqlConnection conn = new SqlConnection(txtConnectionString.Text);
            server = new Server(new ServerConnection(conn));
            List<String> lstDatabases = new List<string>();

            try
            {
                btnErrorDetails.Visible = false;
                for (int i = 0; i < server.Databases.Count; i++)
                {
                    lstDatabases.Add(server.Databases[i].Name);
                }

            }
            catch (ConnectionFailureException ex)
            {
                lblMessage.Text = "Please enter a valid connection string. Please check if the credentials are valid.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                errorMessageDetails = ex.ToString();
                btnErrorDetails.Visible = true;
            }

            cmbDatabases.DataSource = lstDatabases;
            btnRestore.Enabled = false;

        }

        private void btnRunUsingSmo_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(rtbStatus.Text) || String.IsNullOrWhiteSpace(rtbStatus.Text))
            {
                MessageBox.Show("Please enter some valid SQL scripts in the Text Area or upload a script file.");
            }
            lblMessage.Text = String.Empty;
            string sqlConnectionString = txtConnectionString.Text;

            if (/*ofd !=null && !String.IsNullOrEmpty(ofd.FileName) &&*/ !String.IsNullOrWhiteSpace(rtbStatus.Text) && !String.IsNullOrEmpty(rtbStatus.Text))
            {
                //FileInfo file = new FileInfo(ofd.FileName);
                //string script = file.OpenText().ReadToEnd();

                string script = rtbStatus.Text;
                SqlConnection conn = new SqlConnection(sqlConnectionString);
                server = new Server(new ServerConnection(conn));

                try
                {
                    btnErrorDetails.Visible = false;
                    server.ConnectionContext.BeginTransaction();
                    server.ConnectionContext.ExecuteNonQuery(script);
                    server.ConnectionContext.CommitTransaction();
                    lblMessage.Text = "Script RUN Successfull";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                catch (Exception ex)
                {
                    server.ConnectionContext.RollBackTransaction();
                    lblMessage.Text = String.Format("Error : {0}", ex.Message);
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    errorMessageDetails = ex.ToString();
                    btnErrorDetails.Visible = true;
                }
            }
        }

        private void btnOpenFileDialog_Click(object sender, EventArgs e)
        {
            btnErrorDetails.Visible = false;
            lblMessage.Text = String.Empty;
            ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFilePath.Text = ofd.FileName;
            }
            FileInfo file = new FileInfo(ofd.FileName);
            string script = file.OpenText().ReadToEnd();
            lblMessage.Text = "Please preview the script below and make changes if necessary.";
            lblMessage.ForeColor = System.Drawing.Color.Blue;
            rtbStatus.Text = script;
        }

        private void BackUpDatabase()
        {
            lblMessage.Text = String.Empty;
            RefreshServerReference();
            db = server.Databases[DBtoBackup];

            //Store the current recovery model in a variable. 

            recoverymod = (int)db.DatabaseOptions.RecoveryModel;

            //Define a Backup object variable. 
            Backup bk = new Backup();

            //Specify the type of backup, the description, the name, and the database to be backed up. 
            bk.Action = BackupActionType.Database;
            bk.BackupSetDescription = "Full backup of " + DBtoBackup;
            bk.BackupSetName = DBtoBackup + " Backup";
            bk.Database = DBtoBackup;

            //Declare a BackupDeviceItem by supplying the backup device file name in the constructor, and the type of device is a file. 
            bdi = default(BackupDeviceItem);
            bdi = new BackupDeviceItem("Full_Backup1" + DBtoBackup, DeviceType.File);

            //Add the device to the Backup object. 
            bk.Devices.Add(bdi);
            //Set the Incremental property to False to specify that this is a full database backup. 
            bk.Incremental = false;

            /*
            //Set the expiration date. 
            System.DateTime backupdate = new System.DateTime();
            backupdate = new System.DateTime(2006, 10, 5);
            bk.ExpirationDate = backupdate;
            */

            //Specify that the log must be truncated after the backup is complete. 
            bk.LogTruncation = BackupTruncateLogType.Truncate;

            //Run SqlBackup to perform the full database backup on the instance of SQL Server. 
            bk.SqlBackup(server);

            //Inform the user that the backup has been completed. 
            lblMessage.Text = "Full Backup complete.";
            lblMessage.ForeColor = System.Drawing.Color.Green;

            //Remove the backup device from the Backup object. 
            bk.Devices.Remove(bdi);

            /*
            //Make a change to the database, in this case, add a table called test_table. 
            Table t = default(Table);
            t = new Table(db, "test_table");
            Column c = default(Column);
            c = new Column(t, "col", DataType.Int);
            t.Columns.Add(c);
            t.Create();

            //Create another file device for the differential backup and add the Backup object. 
            BackupDeviceItem bdid = default(BackupDeviceItem);
            bdid = new BackupDeviceItem("Test_Differential_Backup1", DeviceType.File);

            //Add the device to the Backup object. 
            bk.Devices.Add(bdid);

            //Set the Incremental property to True for a differential backup. 
            bk.Incremental = true;

            //Run SqlBackup to perform the incremental database backup on the instance of SQL Server. 
            bk.SqlBackup(server);

            //Inform the user that the differential backup is complete. 
            Console.WriteLine("Differential Backup complete.");            

            //Remove the device from the Backup object. 
            bk.Devices.Remove(bdid);
            */
        }

        private void RestoreDatabase()
        {
            lblMessage.Text = String.Empty;
            //Kills any active connections on the database
            server.KillAllProcesses(DBtoBackup);

            //Deletes the database and kills any active connections - Optional - Chinmoy
            server.KillDatabase(DBtoBackup);

            //db = server.Databases[DBtoBackup];
            //Delete the AdventureWorks2012 database before restoring it
            //db.Drop();

            //Define a Restore object variable.
            Restore rs = new Restore();

            //Set the NoRecovery property to true, so the transactions are not recovered. 
            rs.NoRecovery = false;

            //Add the device that contains the full database backup to the Restore object. 
            rs.Devices.Add(bdi);

            //Specify the database name. 
            rs.Database = DBtoBackup;

            //Restore the full database backup with no recovery. 
            rs.SqlRestore(server);

            //Inform the user that the Full Database Restore is complete. 
            lblMessage.Text = "Full Database Restore complete.";
            lblMessage.ForeColor = System.Drawing.Color.Green;

            //reacquire a reference to the database
            RefreshServerReference();
            db = server.Databases[DBtoBackup];

            //Remove the device from the Restore object.
            rs.Devices.Remove(bdi);

            //Set the database recovery mode back to its original value.
            db.RecoveryModel = (RecoveryModel)recoverymod;

            //Remove the backup files from the hard disk.
            //This location is dependent on the installation of SQL Server
            //File.Delete(server.BackupDirectory + "\\" + "Full_Backup1" + DBtoBackup);

        }
        private void RefreshServerReference()
        {
            SqlConnection conn = new SqlConnection(txtConnectionString.Text);
            server = new Server(new ServerConnection(conn));
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                btnErrorDetails.Visible = false;
                this.DBtoBackup = cmbDatabases.SelectedItem.ToString();
                BackUpDatabase();
                cmbDatabases.Enabled = false;
                btnRestore.Enabled = true;
                btnBackup.Enabled = false;
            }
            catch (Exception ex)
            {
                lblMessage.Text = String.Format("Error : {0}", ex.Message);
                lblMessage.ForeColor = System.Drawing.Color.Red;
                btnErrorDetails.Visible = true;
                errorMessageDetails = ex.ToString();
            }

        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                btnErrorDetails.Visible = false;
                RestoreDatabase();
                cmbDatabases.Enabled = true;
                btnRestore.Enabled = false;
                btnBackup.Enabled = true;
            }
            catch (Exception ex)
            {
                lblMessage.Text = String.Format("Error : {0}", ex.Message);
                lblMessage.ForeColor = System.Drawing.Color.Red;
                btnErrorDetails.Visible = true;
                errorMessageDetails = ex.ToString();
            }

        }

        private void txtConnectionString_Leave(object sender, EventArgs e)
        {
            lblMessage.Text = String.Empty;            
            List<String> lstDatabasesNew = new List<string>();
            try
            {
                RefreshServerReference();
                btnErrorDetails.Visible = false;
                for (int i = 0; i < server.Databases.Count; i++)
                {
                    lstDatabasesNew.Add(server.Databases[i].Name);
                }

                cmbDatabases.DataSource = lstDatabasesNew;
            }
            catch (Exception ex)
            {
                cmbDatabases.DataSource = null;
                lblMessage.Text = "Please enter a valid connection string. Please check if the credentials are valid.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                btnErrorDetails.Visible = true;
                errorMessageDetails = ex.ToString();
            }

        }

        private void btnRunUsingSQLCMD_Click(object sender, EventArgs e)
        {
            lblMessage.Text = String.Empty;
            string sqlConnectionString = txtConnectionString.Text;
            if (String.IsNullOrEmpty(rtbStatus.Text) || String.IsNullOrWhiteSpace(rtbStatus.Text))
            {
                MessageBox.Show("Please enter some valid SQL scripts in the Text Area or upload a script file.");
            }
            if (/*ofd !=null && !String.IsNullOrEmpty(ofd.FileName) &&*/ !String.IsNullOrWhiteSpace(rtbStatus.Text) && !String.IsNullOrEmpty(rtbStatus.Text))
            {
                //FileInfo file = new FileInfo(ofd.FileName);
                //string script = file.OpenText().ReadToEnd();
                try
                {
                    btnErrorDetails.Visible = false;
                    if (File.Exists("D:\temp.sql"))
                    {
                        File.Delete(@"D:\temp.sql");
                    }                   

                    File.WriteAllText(@"D:\temp.sql", rtbStatus.Text);
                    string command = String.Empty;

                    string[] sArr = sqlConnectionString.Split(';');

                    Dictionary<string, string> dictConnString = new Dictionary<string, string>();
                    foreach (var str in sArr)
                    {
                        dictConnString.Add(str.Split('=')[0], str.Split('=')[1]);
                    }
                    
                    if (dictConnString["Integrated Security"] != null && dictConnString["Integrated Security"].ToLower() == "true")
                    {
                        command = @"sqlcmd -S " + dictConnString["Data Source"] + " -i " + @"D:\temp.sql" + @" -r0 2> " + @"D:\errorLog.log";
                    }
                    else
                    {
                        command = @"sqlcmd -S " + dictConnString["Data Source"] + " -U " + dictConnString["userID"] + " -P " + dictConnString["password"] + " -i " + @"D:\temp.sql" + @" -r0 2> " + @"D:\errorLog.log";
                    }

                    //command = @"sqlcmd -S .\SQLExpress -i " + @"D:\temp.sql" + @" -r0 2> D:\install-err.log";
                    //command = @"sqlcmd -S .\SQLExpress -U sa -P sapassword -i " + @"D:\temp.sql";

                    System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);
                    // The following commands are needed to redirect the standard output.
                    // This means that it will be redirected to the Process.StandardOutput StreamReader.
                    procStartInfo.RedirectStandardOutput = true;
                    procStartInfo.UseShellExecute = false;
                    // Do not create the black window.
                    procStartInfo.CreateNoWindow = true;
                    // Now we create a process, assign its ProcessStartInfo and start it
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo = procStartInfo;
                    proc.Start();
                    // Get the output into a string
                    string result = proc.StandardOutput.ReadToEnd();
                    if (!String.IsNullOrEmpty(File.ReadAllText(@"D:\errorLog.log")))
                    {
                        errorMessageDetails = File.ReadAllText(@"D:\errorLog.log");
                        File.Delete(@"D:\errorLog.log");
                        lblMessage.Text = String.Format("Error : {0}", "Could NOT execute the script successfully");
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        btnErrorDetails.Visible = true;
                        return;
                    }
                    lblMessage.Text = "Script RUN Successfull";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                catch (Exception ex)
                {
                    lblMessage.Text = String.Format("Error : {0}", ex.Message);
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    btnErrorDetails.Visible = true;
                    errorMessageDetails = ex.ToString();
                }
            }
        }

        private void btnErrorDetails_Click(object sender, EventArgs e)
        {
            ErrorDetails frm = new ErrorDetails(errorMessageDetails);
            
            frm.ShowDialog();
        }
    }
}
