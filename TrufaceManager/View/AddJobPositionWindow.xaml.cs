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

namespace TrufaceManager.View
{
    /// <summary>
    /// AddDepartment.xaml 的交互逻辑
    /// </summary>
    public partial class AddJobPositionWindow
    {
        public AddJobPositionWindow(JobPosition jobPosition)
        {
            InitializeComponent();
            this.DataContext = new
            {
                Model = jobPosition
            };
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
