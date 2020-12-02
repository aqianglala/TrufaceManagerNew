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

        public AddVisitorWindow(Employee employee)
        {
            viewModel = new AddVisitorViewModel(employee);
            this.DataContext = viewModel;
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            viewModel.setTime();
            this.DialogResult = true;
        }
    }
}
