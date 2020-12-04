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

        private void BtnModifyEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeListWindow window = new EmployeeListWindow(true);
            window.ShowDialog();
        }

        private void BtnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeListWindow window = new EmployeeListWindow(false);
            window.ShowDialog();
        }

        private void BtnAddVisitor_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee();
            employee.AccessCount = 1;
            AddVisitorWindow window = new AddVisitorWindow(employee);
            var r = window.ShowDialog();
            if (r.Value)
            {
                using (var db = new ORMContext())
                {
                    db.Employees.Add(employee);
                    db.SaveChanges();
                }
            }
        }

        private void BtnModifyVisitor_Click(object sender, RoutedEventArgs e)
        {
            VisitorListWindow window = new VisitorListWindow(true);
            window.ShowDialog();
        }

        private void BtnDeleteVisitor_Click(object sender, RoutedEventArgs e)
        {
            VisitorListWindow window = new VisitorListWindow(false);
            window.ShowDialog();
        }
    }
}
