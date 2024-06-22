﻿using System;
using System.Windows.Forms;
using Stall_Rental_Management_System.Helpers.NavigateHelpers;
using Stall_Rental_Management_System.Services;

namespace Stall_Rental_Management_System.Views.Panel_Forms
{
    public partial class FrmManagerPanel : Form
    {
        private readonly AuthenticationService _authService;
        public FrmManagerPanel(AuthenticationService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private void buttonStalls_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonStaffs_Click(object sender, EventArgs e)
        {
            ManagerNavigateHelper.NavigateToStaffForm(this, _authService);
        }
    }
}
