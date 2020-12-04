using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrufaceManager.View;

namespace TrufaceManager.ViewModel
{
    public class VisitorListViewModel : ViewModelBase
    {
        private readonly ORMContext db;
        private bool isEdit;
        public VisitorListViewModel(bool isEdit)
        {
            this.isEdit = isEdit;
            db = new ORMContext();
            db.Employees.ToList();
            employees = db.Employees.Local;
            DoCommand = new RelayCommand(EditOrDelete);
        }

        private Employee selectedEmployee;

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set { selectedEmployee = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<Employee> employees;

        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set { employees = value; RaisePropertyChanged(); }
        }

        public RelayCommand DoCommand { get; set; }

        private void EditOrDelete()
        {
            if (isEdit)
            {
                Employee employee = new Employee();
                employee.Id = selectedEmployee.Id;
                employee.Number = selectedEmployee.Number;
                employee.IcCard = selectedEmployee.IcCard;
                employee.LastName = selectedEmployee.LastName;
                employee.FirstName = selectedEmployee.FirstName;
                employee.MiddleName = selectedEmployee.MiddleName;
                employee.JobPosition = selectedEmployee.JobPosition;
                employee.Company = selectedEmployee.Company;
                employee.PositionToVisit = selectedEmployee.PositionToVisit;
                employee.Gender = selectedEmployee.Gender;
                employee.Department = selectedEmployee.Department;
                employee.ValidityDate = selectedEmployee.ValidityDate;
                employee.ExpirationDate = selectedEmployee.ExpirationDate;
                employee.AccessCount = selectedEmployee.AccessCount;
                employee.Blacklist = selectedEmployee.Blacklist;
                employee.FaceImage = selectedEmployee.FaceImage;
                employee.FingerImage = selectedEmployee.FingerImage;
                employee.ValidTime1 = selectedEmployee.ValidTime1;
                employee.ValidTime2 = selectedEmployee.ValidTime2;
                employee.ValidTime3 = selectedEmployee.ValidTime3;
                employee.ValidTime4 = selectedEmployee.ValidTime4;
                employee.ValidTime5 = selectedEmployee.ValidTime5;
                employee.ValidTime6 = selectedEmployee.ValidTime6;
                employee.ValidTime7 = selectedEmployee.ValidTime7;
                AddVisitorWindow window = new AddVisitorWindow(employee);
                var r = window.ShowDialog();
                if (r.Value)
                {
                    Employee item = db.Employees.FirstOrDefault(i => i.Id == employee.Id);
                    item.Id = employee.Id;
                    item.Number = employee.Number;
                    item.IcCard = employee.IcCard;
                    item.LastName = employee.LastName;
                    item.FirstName = employee.FirstName;
                    item.MiddleName = employee.MiddleName;
                    item.JobPosition = employee.JobPosition;
                    item.Company = employee.Company;
                    item.PositionToVisit = employee.PositionToVisit;
                    item.Gender = employee.Gender;
                    item.Department = employee.Department;
                    item.ValidityDate = employee.ValidityDate;
                    item.ExpirationDate = employee.ExpirationDate;
                    item.AccessCount = employee.AccessCount;
                    item.Blacklist = employee.Blacklist;
                    item.FaceImage = employee.FaceImage;
                    item.FingerImage = employee.FingerImage;
                    item.ValidTime1 = employee.ValidTime1;
                    item.ValidTime2 = employee.ValidTime2;
                    item.ValidTime3 = employee.ValidTime3;
                    item.ValidTime4 = employee.ValidTime4;
                    item.ValidTime5 = employee.ValidTime5;
                    item.ValidTime6 = employee.ValidTime6;
                    item.ValidTime7 = employee.ValidTime7;
                    db.SaveChanges();
                }
            }
            else
            {
                Employee item = db.Employees.FirstOrDefault(i => i.Id == selectedEmployee.Id);
                db.Employees.Remove(item);
                db.SaveChanges();
            }
        }

    }
}
