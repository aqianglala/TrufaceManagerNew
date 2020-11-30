using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrufaceManager.Model
{
    public class User : ViewModelBase
    {
        private int id;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        private string fullName;
        private string password;
        private bool enable;
        private string role;



        public string Role
        {
            get { return role; }
            set { role = value; RaisePropertyChanged(); }
        }


        public bool Enable
        {
            get { return enable; }
            set { enable = value; RaisePropertyChanged(); }
        }


        public string Password
        {
            get { return password; }
            set { password = value;RaisePropertyChanged(); }
        }


        public string FullName
        {
            get { return fullName; }
            set { fullName = value; RaisePropertyChanged(); }
        }


        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(); }
        }

    }
}
