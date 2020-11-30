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
    public class Employee : ViewModelBase
    {
        private int id;
        private string number;
        private string icCard;
        private string lastName;
        private string firstName;
        private string middleName;
        private int jobPositionId;
        private string gender;
        private int departmentId;
        private string validityDate;
        private string expirationDate;
        private int accessCount = -1;
        private int blacklist;
        private string faceImage;
        private string fingerImage;

        public string FaceImage
        {
            get { return faceImage; }
            set { faceImage = value; }
        }

        public string FingerImage
        {
            get { return fingerImage; }
            set { fingerImage = value; }
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId
        {
            get { return id; }
            set { id = value; RaisePropertyChanged(); }
        }

        public string Number
        {
            get { return number; }
            set { number = value; RaisePropertyChanged(); }
        }

        public string IcCard
        {
            get { return icCard; }
            set { icCard = value; RaisePropertyChanged(); }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; RaisePropertyChanged(); }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; RaisePropertyChanged(); }
        }

        public string MiddleName
        {
            get { return middleName; }
            set { middleName = value; RaisePropertyChanged(); }
        }
        
        // 外键
        public int JobPositionId
        {
            get { return jobPositionId; }
            set { jobPositionId = value; RaisePropertyChanged(); }
        }
        public JobPosition JobPosition { get; set; }

        public string Gender
        {
            get { return gender; }
            set { gender = value; RaisePropertyChanged(); }
        }
        // 外键
        public int DepartmentId
        {
            get { return departmentId; }
            set { departmentId = value; RaisePropertyChanged(); }
        }
        public Department Department { get; set; }

        public string ValidityDate
        {
            get { return validityDate; }
            set { validityDate = value; RaisePropertyChanged(); }
        }

        public string ExpirationDate
        {
            get { return expirationDate; }
            set { expirationDate = value; RaisePropertyChanged(); }
        }

        public int AccessCount
        {
            get { return accessCount; }
            set { accessCount = value; RaisePropertyChanged(); }
        }

        public int Blacklist
        {
            get { return blacklist; }
            set { blacklist = value; RaisePropertyChanged(); }
        }
    }
}
