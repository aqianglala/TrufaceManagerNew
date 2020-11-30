using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrufaceManager.Model;

namespace TrufaceManager.ViewModel
{
    public class AddUserViewModel:ViewModelBase
    {
        private int id;
        private ORMContext db;
        private User user;

        public User User
        {
            get { return user; }
            set { user = value; RaisePropertyChanged(); }
        }

        public AddUserViewModel(ORMContext db, int id)
        {
            this.db = db;
            this.id = id;
        }

        private RelayCommand ok;

        public RelayCommand OK
        {
            get {
                if (ok == null)
                {
                    ok = new RelayCommand(() => AddUser()); ;
                }
                return ok; 
            }
        }

        private void AddUser()
        {
            //if (Mode == 0)
            //{
            //    // add
            //    db.Users.Add
            //}
            //else if (Mode == 1)
            //{
            //    // update
            //}
        }
    }
}
