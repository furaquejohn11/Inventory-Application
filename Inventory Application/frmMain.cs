﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Application
{  
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            frmLogin login = new frmLogin();
            label2.Text = login.username;
            

    
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        public static Form currentForm = null;
        public void openChildForm(Form childForm)
        {
            try
            {
                if (currentForm != null)

                    currentForm.Close();
                currentForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                pnlChildForm.Controls.Add(childForm);
                pnlChildForm.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();

            }
            catch
            {

            }


        }
    }
 
}