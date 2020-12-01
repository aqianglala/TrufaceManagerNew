using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows;
using TrufaceManager.Model;
using TrufaceManager.View;

namespace TrufaceManager.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>

        public MainViewModel()
        {
            AddEmployeeCommand = new RelayCommand(AddEmployee);
        }

        public RelayCommand AddEmployeeCommand { get; set; }

        private void AddEmployee()
        {
            Employee employee = new Employee();
            AddEmployeeWindow window = new AddEmployeeWindow(employee);
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

        private RelayCommand addDevice;

        public RelayCommand AddDevice
        {
            get {
                if (addDevice == null)
                {
                    addDevice = new RelayCommand(()=> {
                        MessageBox.Show("aaa");
                    });
                }
                return addDevice; 
            }
        }


        private RelayCommand profile;

        public RelayCommand Profile
        {
            get {
                if (profile == null)
                {
                    profile = new RelayCommand(()=> {
                        ProfileWindow window = new ProfileWindow();
                        window.ShowDialog();
                    });
                }
                return profile; 
            }
        }

    }
}