using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormSQLScriptExcutionar
{
    public partial class ErrorDetails : Form
    {
        public ErrorDetails()
        {
            InitializeComponent();
        }
        public ErrorDetails(string errorMessageDetails)
        {
            InitializeComponent();
            rtbErrorDetails.Text = errorMessageDetails;
        }
    }
}
