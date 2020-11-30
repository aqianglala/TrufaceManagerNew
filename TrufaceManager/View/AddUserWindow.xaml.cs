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
using TrufaceManager.Model;
using TrufaceManager.ViewModel;

namespace TrufaceManager.View
{
    /// <summary>
    /// AddUserWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AddUserWindow
    {
        public AddUserWindow(User user)
        {
            InitializeComponent();
            this.DataContext = new
            {
                User = user
            };
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (!TbPwd.Text.Equals(TbConfirmPwd.Text))
            {
                MessageBox.Show("两次密码不一致");
                return;
            }
            this.DialogResult = true;
        }
    }
}
