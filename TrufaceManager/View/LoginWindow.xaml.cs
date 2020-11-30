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

namespace TrufaceManager.View
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ORMContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Name.Equals(TbName.Text) && u.Password.Equals(TbPwd.Text));
                if (user == null)
                {
                    MessageBox.Show("用户名或密码错误", "操作提示", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!user.Enable)
                {
                    MessageBox.Show("该用户已被禁用");
                    return;
                }
                ((App)App.Current).CurrentUser = user;
                MainWindow window = new MainWindow();
                window.Show();
                this.Hide();//todo
            }
        }
    }
}
