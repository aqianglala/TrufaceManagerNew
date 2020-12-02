using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrufaceManager
{
    public class AddVisitorViewModel:ViewModelBase
    {
        public static DateTime TodayStart;
        public static DateTime TodayEnd;
        public List<Department> Departments { get; set; }
        private Employee employee;
        public Employee Model
        {
            get { return employee; }
            set { employee = value; RaisePropertyChanged(); }
        }
        private DateTime timeStart;

        public DateTime TimeStart
        {
            get { return timeStart; }
            set { timeStart = value; }
        }

        private DateTime timeEnd;

        public DateTime TimeEnd
        {
            get { return timeEnd; }
            set { timeEnd = value; }
        }

        public AddVisitorViewModel(Employee employee)
        {
            this.employee = employee;
            using (var db = new ORMContext())
            {
                Departments = db.Departments.ToList();
            }
            timeStart = DateTime.Today.Date;
            timeEnd = DateTime.Today.Date.AddDays(1).AddSeconds(-1);
            TodayStart = DateTime.Today.Date;
            TodayEnd = DateTime.Today.Date.AddDays(1).AddSeconds(-1);
        }

        public void setTime()
        {
            string start = timeStart.ToString("t");
            string end = timeEnd.ToString("t");
            employee.ValidTime1 = $"1,{start}={end}";
            employee.ValidTime2 = $"1,{start}={end}";
            employee.ValidTime3 = $"1,{start}={end}";
            employee.ValidTime4 = $"1,{start}={end}";
            employee.ValidTime5 = $"1,{start}={end}";
            employee.ValidTime6 = $"1,{start}={end}";
            employee.ValidTime7 = $"1,{start}={end}";
        }
    }
}
