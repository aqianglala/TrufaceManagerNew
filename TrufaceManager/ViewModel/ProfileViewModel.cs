using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TrufaceManager.Model;
using TrufaceManager.View;

namespace TrufaceManager.ViewModel
{
    public class ProfileViewModel : ViewModelBase
    {
        private readonly ORMContext db;

        public ProfileViewModel()
        {
            db = new ORMContext();
            // init users
            db.Users.ToList();
            users = db.Users.Local;
            // init departments
            db.Departments.ToList();
            departments = db.Departments.Local;
            AddDepartmentCommand = new RelayCommand(AddDepartment);
            EditDepartmentCommand = new RelayCommand(EditDepartment);
            DeleteDepartmentCommand = new RelayCommand(DeleteDepartment);
            // init job positions
            db.JobPositions.ToList();
            jobPositions = db.JobPositions.Local;
            AddJobPositionCommand = new RelayCommand(AddJobPosition);
            EditJobPositionCommand = new RelayCommand(EditJobPosition);
            DeleteJobPositionCommand = new RelayCommand(DeleteJobPosition);
        }

        #region Department

        private Department selectedDepartment;

        public Department SelectedDepartment
        {
            get { return selectedDepartment; }
            set { selectedDepartment = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<Department> departments;

        public ObservableCollection<Department> Departments
        {
            get { return departments; }
            set { departments = value; RaisePropertyChanged(); }
        }

        public RelayCommand AddDepartmentCommand { get; set; }
        public RelayCommand EditDepartmentCommand { get; set; }
        public RelayCommand DeleteDepartmentCommand { get; set; }

        private void AddDepartment()
        {
            Department department = new Department();
            AddDepartmentWindow window = new AddDepartmentWindow(department);
            var r = window.ShowDialog();
            if (r.Value)
            {
                string createBy = ((App)App.Current).CurrentUser.Name;
                department.CreateBy = createBy;
                department.CreateTime = DateTime.Now.ToString();
                db.Departments.Add(department);
                db.SaveChanges();
            }
        }

        private void EditDepartment()
        {
            Department department = new Department()
            {
                Id = selectedDepartment.Id,
                Name = selectedDepartment.Name,
                CreateBy = selectedDepartment.CreateBy,
                CreateTime = selectedDepartment.CreateTime
            };
            AddDepartmentWindow window = new AddDepartmentWindow(department);
            var r = window.ShowDialog();
            if (r.Value)
            {
                Department item = db.Departments.FirstOrDefault(i => i.Id == department.Id);
                item.Name = department.Name;
                db.SaveChanges();
            }
        }

        private void DeleteDepartment()
        {
            var r = MessageBox.Show("确认删除?", "操作提示", MessageBoxButton.OK, MessageBoxImage.Question);
            if (r == MessageBoxResult.OK)
            {
                Department item = db.Departments.FirstOrDefault(i => i.Id == selectedDepartment.Id);
                db.Departments.Remove(item);
                db.Employees.RemoveRange(db.Employees.Where(i => i.Department == item.Name));
                db.SaveChanges();
            }
        }

        #endregion

        #region JobPosition

        private JobPosition selectedJobPosition;

        public JobPosition SelectedJobPosition
        {
            get { return selectedJobPosition; }
            set { selectedJobPosition = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<JobPosition> jobPositions;

        public ObservableCollection<JobPosition> JobPositions
        {
            get { return jobPositions; }
            set { jobPositions = value; RaisePropertyChanged(); }
        }

        public RelayCommand AddJobPositionCommand { get; set; }
        public RelayCommand EditJobPositionCommand { get; set; }
        public RelayCommand DeleteJobPositionCommand { get; set; }

        private void AddJobPosition()
        {
            JobPosition jobPosition = new JobPosition();
            AddJobPositionWindow window = new AddJobPositionWindow(jobPosition);
            var r = window.ShowDialog();
            if (r.Value)
            {
                string createBy = ((App)App.Current).CurrentUser.Name;
                jobPosition.CreateBy = createBy;
                jobPosition.CreateTime = DateTime.Now.ToString();
                db.JobPositions.Add(jobPosition);
                db.SaveChanges();
            }
        }

        private void EditJobPosition()
        {
            JobPosition jobPosition = new JobPosition()
            {
                Id = selectedJobPosition.Id,
                Name = selectedJobPosition.Name,
                CreateBy = selectedJobPosition.CreateBy,
                CreateTime = selectedJobPosition.CreateTime
            };
            AddJobPositionWindow window = new AddJobPositionWindow(jobPosition);
            var r = window.ShowDialog();
            if (r.Value)
            {
                JobPosition item = db.JobPositions.FirstOrDefault(i => i.Id == jobPosition.Id);
                item.Name = jobPosition.Name;
                db.SaveChanges();
            }
        }

        private void DeleteJobPosition()
        {
            var r = MessageBox.Show("确认删除?", "操作提示", MessageBoxButton.OK, MessageBoxImage.Question);
            if (r == MessageBoxResult.OK)
            {
                JobPosition item = db.JobPositions.FirstOrDefault(i => i.Id == selectedJobPosition.Id);
                db.JobPositions.Remove(item);
                db.Employees.RemoveRange(db.Employees.Where(i => i.JobPosition == item.Name));
                db.SaveChanges();
            }
        }

        #endregion

        private User selectedUser;

        public User SelectedUser
        {
            get { return selectedUser; }
            set { selectedUser = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<User> users;

        public ObservableCollection<User> Users
        {
            get { return users; }
            set { users = value; RaisePropertyChanged(); }
        }

        private RelayCommand addUser;

        public RelayCommand AddUser
        {
            get
            {
                if (addUser == null)
                {
                    addUser = new RelayCommand(() =>
                    {
                        User user = new User();
                        AddUserWindow window = new AddUserWindow(user);
                        var r = window.ShowDialog();
                        if (r.Value)
                        {
                            db.Users.Add(user);
                            db.SaveChanges();
                        }
                    });
                }
                return addUser;
            }
        }

        private RelayCommand editUser;

        public RelayCommand EditUser
        {
            get
            {
                if (editUser == null)
                {
                    editUser = new RelayCommand(() =>
                    {
                        User newUser = new User()
                        {
                            Id = selectedUser.Id,
                            Name = selectedUser.Name,
                            FullName = selectedUser.FullName,
                            Role = selectedUser.Role,
                            Password = selectedUser.Password,
                            Enable = selectedUser.Enable
                        };
                        AddUserWindow window = new AddUserWindow(newUser);
                        var r = window.ShowDialog();
                        if (r.Value)
                        {
                            User user = db.Users.FirstOrDefault(u => u.Id == newUser.Id);
                            if (user != null)
                            {
                                user.Name = newUser.Name;
                                user.FullName = newUser.FullName;
                                user.Role = newUser.Role;
                                user.Password = newUser.Password;
                                db.SaveChanges();
                            }
                        }
                    });
                }
                return editUser;
            }
        }

        private RelayCommand disable;

        public RelayCommand Disable
        {
            get
            {
                if (disable == null)
                {
                    disable = new RelayCommand(() =>
                    {
                        User user = db.Users.FirstOrDefault(u => u.Id == selectedUser.Id);
                        user.Enable = false;
                        db.SaveChanges();
                    });
                }
                return disable;
            }
        }



    }
}
