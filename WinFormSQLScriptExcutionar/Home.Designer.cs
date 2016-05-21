namespace WinFormSQLScriptExcutionar
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpenFileDialog = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbStatus = new System.Windows.Forms.RichTextBox();
            this.btnRunUsingSmo = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDatabases = new System.Windows.Forms.ComboBox();
            this.btnRunUsingSQLCMD = new System.Windows.Forms.Button();
            this.btnErrorDetails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenFileDialog
            // 
            this.btnOpenFileDialog.Location = new System.Drawing.Point(504, 11);
            this.btnOpenFileDialog.Name = "btnOpenFileDialog";
            this.btnOpenFileDialog.Size = new System.Drawing.Size(24, 23);
            this.btnOpenFileDialog.TabIndex = 0;
            this.btnOpenFileDialog.Text = "...";
            this.btnOpenFileDialog.UseVisualStyleBackColor = true;
            this.btnOpenFileDialog.Click += new System.EventHandler(this.btnOpenFileDialog_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(122, 13);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(378, 20);
            this.txtFilePath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Script File : ";
            // 
            // rtbStatus
            // 
            this.rtbStatus.Location = new System.Drawing.Point(28, 109);
            this.rtbStatus.Name = "rtbStatus";
            this.rtbStatus.Size = new System.Drawing.Size(609, 371);
            this.rtbStatus.TabIndex = 3;
            this.rtbStatus.Text = "";
            this.rtbStatus.WordWrap = false;
            // 
            // btnRunUsingSmo
            // 
            this.btnRunUsingSmo.Location = new System.Drawing.Point(536, 10);
            this.btnRunUsingSmo.Name = "btnRunUsingSmo";
            this.btnRunUsingSmo.Size = new System.Drawing.Size(43, 23);
            this.btnRunUsingSmo.TabIndex = 4;
            this.btnRunUsingSmo.Text = "Run";
            this.btnRunUsingSmo.UseVisualStyleBackColor = true;
            this.btnRunUsingSmo.Click += new System.EventHandler(this.btnRunUsingSmo_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(28, 92);
            this.lblMessage.MaximumSize = new System.Drawing.Size(600, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(35, 13);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "SQL Connection :";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(122, 41);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(514, 20);
            this.txtConnectionString.TabIndex = 7;
            this.txtConnectionString.Leave += new System.EventHandler(this.txtConnectionString_Leave);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(314, 67);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(53, 23);
            this.btnBackup.TabIndex = 8;
            this.btnBackup.Text = "Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(381, 67);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(52, 23);
            this.btnRestore.TabIndex = 9;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "DB to Backup : ";
            // 
            // cmbDatabases
            // 
            this.cmbDatabases.FormattingEnabled = true;
            this.cmbDatabases.Location = new System.Drawing.Point(122, 68);
            this.cmbDatabases.Name = "cmbDatabases";
            this.cmbDatabases.Size = new System.Drawing.Size(174, 21);
            this.cmbDatabases.TabIndex = 12;
            // 
            // btnRunUsingSQLCMD
            // 
            this.btnRunUsingSQLCMD.Location = new System.Drawing.Point(583, 10);
            this.btnRunUsingSQLCMD.Name = "btnRunUsingSQLCMD";
            this.btnRunUsingSQLCMD.Size = new System.Drawing.Size(54, 23);
            this.btnRunUsingSQLCMD.TabIndex = 13;
            this.btnRunUsingSQLCMD.Text = "sqlCMD";
            this.btnRunUsingSQLCMD.UseVisualStyleBackColor = true;
            this.btnRunUsingSQLCMD.Click += new System.EventHandler(this.btnRunUsingSQLCMD_Click);
            // 
            // btnErrorDetails
            // 
            this.btnErrorDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnErrorDetails.Location = new System.Drawing.Point(561, 84);
            this.btnErrorDetails.Name = "btnErrorDetails";
            this.btnErrorDetails.Size = new System.Drawing.Size(75, 23);
            this.btnErrorDetails.TabIndex = 14;
            this.btnErrorDetails.Text = "Error Details";
            this.btnErrorDetails.UseVisualStyleBackColor = true;
            this.btnErrorDetails.Visible = false;
            this.btnErrorDetails.Click += new System.EventHandler(this.btnErrorDetails_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 499);
            this.Controls.Add(this.btnErrorDetails);
            this.Controls.Add(this.btnRunUsingSQLCMD);
            this.Controls.Add(this.cmbDatabases);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.txtConnectionString);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnRunUsingSmo);
            this.Controls.Add(this.rtbStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnOpenFileDialog);
            this.MaximizeBox = false;
            this.Name = "Home";
            this.Opacity = 0.98D;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SQL Script Executioner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFileDialog;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbStatus;
        private System.Windows.Forms.Button btnRunUsingSmo;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDatabases;
        private System.Windows.Forms.Button btnRunUsingSQLCMD;
        private System.Windows.Forms.Button btnErrorDetails;
    }
}

