﻿using System.Collections.Generic;
using System.Windows.Forms;

namespace Stall_Rental_Management_System.Helpers.DesignHelpers
{
    public static class DataGridViewHelper
    {
        public static void SetDataGridViewColumns(
            DataGridView dataGridView, 
            BindingSource bindingSource, 
            List<(string DataPropertyName, string HeaderText)> columns)
        {
            // Set the data source
            dataGridView.DataSource = bindingSource;

            // Prevent automatic column generation
            dataGridView.AutoGenerateColumns = false;

            // Clear existing columns
            dataGridView.Columns.Clear();

            // Add the columns you want to display
            foreach (var column in columns)
            {
                dataGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = column.DataPropertyName, 
                    HeaderText = column.HeaderText
                });
            }

            // Set the AutoSizeColumnsMode
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}