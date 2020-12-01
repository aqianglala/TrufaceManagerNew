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
        private string jobPosition;
        private string gender;
        private string department;
        private string validityDate;
        private string expirationDate;
        private int accessCount = -1;
        private int blacklist;
        private string faceImage;
        private string fingerImage;
        private string validTime1 = "1,00:00=23:59";
        private string validTime2 = "1,00:00=23:59";
        private string validTime3 = "1,00:00=23:59";
        private string validTime4 = "1,00:00=23:59";
        private string validTime5 = "1,00:00=23:59";
        private string validTime6 = "0,00:00=23:59";
        private string validTime7 = "0,00:00=23:59";

        public string ValidTime1
        {
            get { return validTime1; }
            set { validTime1 = value; RaisePropertyChanged(); }
        }


        public string ValidTime2
        {
            get { return validTime2; }
            set { validTime2 = value; RaisePropertyChanged(); }
        }


        public string ValidTime3
        {
            get { return validTime3; }
            set { validTime3 = value; RaisePropertyChanged(); }
        }

        public string ValidTime4
        {
            get { return validTime4; }
            set { validTime4 = value; RaisePropertyChanged(); }
        }

        public string ValidTime5
        {
            get { return validTime5; }
            set { validTime5 = value; RaisePropertyChanged(); }
        }

        public string ValidTime6
        {
            get { return validTime6; }
            set { validTime6 = value; RaisePropertyChanged(); }
        }

        public string ValidTime7
        {
            get { return validTime7; }
            set { validTime7 = value; RaisePropertyChanged(); }
        }


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
        public int Id
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

        public string JobPosition
        {
            get { return jobPosition; }
            set { jobPosition = value; RaisePropertyChanged(); }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; RaisePropertyChanged(); }
        }

        public string Department
        {
            get { return department; }
            set { department = value; RaisePropertyChanged(); }
        }

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
