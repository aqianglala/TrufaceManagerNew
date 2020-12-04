using System;
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
    /// AddVisitorWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AddVisitorWindow
    {
        private AddVisitorViewModel viewModel;
        private Employee employee;

        public AddVisitorWindow(Employee employee)
        {
            this.employee = employee;
            viewModel = new AddVisitorViewModel(employee);
            this.DataContext = viewModel;
            InitializeComponent();
            if (!string.IsNullOrEmpty(employee.Purpose))
            {
                string[] purposes = employee.Purpose.Split(';');
                string otherStr = "";

                foreach (string word in purposes)
                {
                    if (word.Equals("Meeting"))
                    {
                        CbMeeting.IsChecked = true;
                    }
                    else if (word.Equals("Demo"))
                    {
                        CbDemo.IsChecked = true;
                    }
                    else if (word.Equals("Presentation"))
                    {
                        CbPresentation.IsChecked = true;
                    }
                    else if (word.Equals("Personal"))
                    {
                        CbPersonal.IsChecked = true;
                    }
                    else
                    {
                        otherStr += word;
                    }
                }
                if (otherStr.Trim().Length != 0)
                {
                    CbOthers.IsChecked = true;
                    TbOthers.Text = otherStr;
                }
            }
            

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (CbMeeting.IsChecked == true)
            {
                stringBuilder.Append("Meeting;");
            }
            if (CbDemo.IsChecked == true)
            {
                stringBuilder.Append("Demo;");
            }
            if (CbPresentation.IsChecked == true)
            {
                stringBuilder.Append("Presentation;");
            }
            if (CbPersonal.IsChecked == true)
            {
                stringBuilder.Append("Personal;");
            }
            if (CbOthers.IsChecked == true)
            {
                if (TbOthers.Text.ToString().Trim().Length != 0)
                {
                    stringBuilder.Append(TbOthers.Text.ToString().Trim());
                }
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            }
            employee.Purpose = stringBuilder.ToString();
            viewModel.setTime();
            this.DialogResult = true;
        }

        private void BtnRead_Click(object sender, RoutedEventArgs e)
        {
            TbIcCard.Focus();
        }
    }
}
