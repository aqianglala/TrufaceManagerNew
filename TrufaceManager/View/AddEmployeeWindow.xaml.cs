﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TrufaceManager.View
{
    /// <summary>
    /// AddEmployeeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AddEmployeeWindow
    {
        private Employee employee;

        public AddEmployeeWindow(Employee employee)
        {
            this.employee = employee;
            this.DataContext = new AddEmployeeViewModel(employee);
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void BtnRead_Click(object sender, RoutedEventArgs e)
        {
            TbIcCard.Focus();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            //todo
            if (RbUnLimited.IsChecked == true)
            {
                this.employee.AccessCount = -1;
            }
            this.DialogResult = true;
        }
    }
}
