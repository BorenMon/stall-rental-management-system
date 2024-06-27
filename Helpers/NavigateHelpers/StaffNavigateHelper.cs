﻿using System.Windows.Forms;
using Stall_Rental_Management_System.Repositories;
using Stall_Rental_Management_System.Services;
using Stall_Rental_Management_System.Views;
using Stall_Rental_Management_System.Views.Panel_Forms;

namespace Stall_Rental_Management_System.Helpers.NavigateHelpers
{
    public static class StaffNavigateHelper
    {
        public static void NavigateToStaffForm(Form currentForm, AuthenticationService authService)
        {
            var staffRepository = new StaffRepository();
            var staffForm = new FrmStaff(staffRepository, authService);
            staffForm.Show();
            currentForm.Hide();
            staffForm.FormClosed += (s, args) => currentForm.Close();
        }
        
        public static void NavigateToStallForm(Form currentForm, AuthenticationService authService)
        {
            var repository = new StallRepository();
            var form = new FrmStall(repository, authService);
            form.Show();
            currentForm.Hide();
            form.FormClosed += (s, args) => currentForm.Close();
        }
        
        public static void NavigateToStaffPanel(Form currentForm, AuthenticationService authService)
        {
            var staffPanel = new FrmStaffPanel(authService);
            staffPanel.Show();
            currentForm.Hide();
            staffPanel.FormClosed += (s, args) => currentForm.Close();
        }
    }
}
