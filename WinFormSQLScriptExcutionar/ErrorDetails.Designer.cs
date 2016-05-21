namespace WinFormSQLScriptExcutionar
{
    partial class ErrorDetails
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
            this.rtbErrorDetails = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbErrorDetails
            // 
            this.rtbErrorDetails.Location = new System.Drawing.Point(13, 23);
            this.rtbErrorDetails.Name = "rtbErrorDetails";
            this.rtbErrorDetails.Size = new System.Drawing.Size(518, 238);
            this.rtbErrorDetails.TabIndex = 0;
            this.rtbErrorDetails.Text = "";
            // 
            // ErrorDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 277);
            this.Controls.Add(this.rtbErrorDetails);
            this.Name = "ErrorDetails";
            this.Text = "ErrorDetails";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbErrorDetails;
    }
}