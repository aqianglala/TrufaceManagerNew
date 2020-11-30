using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrufaceManager
{
    public class Department : ViewModelBase
    {
        private int id;
        private string name;
        private string createBy;
        private string createTime;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(); }
        }

        public string CreateBy
        {
            get { return createBy; }
            set { createBy = value; RaisePropertyChanged(); }
        }

        public string CreateTime
        {
            get { return createTime; }
            set { createTime = value; RaisePropertyChanged(); }
        }

        public ICollection<Employee> Employee { get; set; }
    }
}
