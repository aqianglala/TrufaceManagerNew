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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrufaceManager.View;
using TrufaceManager.ViewModel;

namespace TrufaceManager
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        private void BtnModifyEmployee_Clicked(object sender, RoutedEventArgs e)
        {
            EmployeeListWindow window = new EmployeeListWindow(true);
            window.ShowDialog();
        }

        private void BtnDeleteEmployee_Clicked(object sender, RoutedEventArgs e)
        {
            EmployeeListWindow window = new EmployeeListWindow(false);
            window.ShowDialog();
        }
    }
}
