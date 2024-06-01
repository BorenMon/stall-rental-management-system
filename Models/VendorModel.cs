﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stall_Rental_Management_System.Models
{
    internal class VendorModel
    {
        // fields
        private int vendorID;
        private string firstNameEN;
        private string lastNameEN;
        private string firstNameKH;
        private string lastNameKH;
        private DateTime birthDate;
        private string gender;
        private string email;
        private string password;
        private string phoneNumber;
        //
        // properties
        public int VendorID
        {
            get { return vendorID; }
            set { vendorID = value; }
        }

        public string FirstNameEN
        {
            get { return firstNameEN; }
            set { firstNameEN = value; }
        }

        public string LastNameEN
        {
            get { return lastNameEN; }
            set { lastNameEN = value; }
        }

        public string FirstNameKH
        {
            get { return firstNameKH; }
            set { firstNameKH = value; }
        }

        public string LastNameKH
        {
            get { return lastNameKH; }
            set { lastNameKH = value; }
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public VendorModel() { }

        public VendorModel(int vendorID, string firstNameEN, string lastNameEN, string firstNameKH, string lastNameKH, DateTime birthDate, string gender, string email, string password, string phoneNumber)
        {
            this.vendorID = vendorID;
            this.firstNameEN = firstNameEN;
            this.lastNameEN = lastNameEN;
            this.firstNameKH = firstNameKH;
            this.lastNameKH = lastNameKH;
            this.birthDate = birthDate;
            this.gender = gender;
            this.email = email;
            this.password = password;
            this.phoneNumber = phoneNumber;
        }
    }
}