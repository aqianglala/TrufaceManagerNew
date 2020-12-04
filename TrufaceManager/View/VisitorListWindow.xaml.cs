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
using TrufaceManager.ViewModel;

namespace TrufaceManager.View
{
    /// <summary>
    /// VisitorListWindow.xaml 的交互逻辑
    /// </summary>
    public partial class VisitorListWindow
    {
        public VisitorListWindow(bool isEdit)
        {
            InitializeComponent();
            this.DataContext = new VisitorListViewModel(isEdit);
            if (isEdit)
            {
                Title = "Modify Data";
            }
            else
            {
                Title = "Delete Data";
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
