using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrufaceManager
{
    public class AddEmployeeViewModel:ViewModelBase
    {
        public static DateTime TodayStart;
        public static DateTime TodayEnd;
        private readonly ORMContext db;
        public List<JobPosition> JobPositions { get; set; }
        public List<Department> Departments { get; set; }
        public List<string> Genders { get; set; }
        private Employee employee;

        public Employee Model
        {
            get { return employee; }
            set { employee = value; RaisePropertyChanged(); }
        }


        public AddEmployeeViewModel(Employee employee)
        {
            TodayStart = DateTime.Today.Date;
            TodayEnd = DateTime.Today.Date.AddDays(1).AddSeconds(-1);
            db = new ORMContext();
            this.employee = employee;
            JobPositions = db.JobPositions.ToList();
            Departments = db.Departments.ToList();
            Genders = new List<string>();
            Genders.Add("male");
            Genders.Add("female");
        }

    }
}
