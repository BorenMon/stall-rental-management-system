﻿using System;
using System.Data.SqlClient;

using Stall_Rental_Management_System.Enums;
using Stall_Rental_Management_System.Helpers;
using Stall_Rental_Management_System.Models;
using Stall_Rental_Management_System.Services.Service_Interfaces;
using Stall_Rental_Management_System.Utils;


namespace Stall_Rental_Management_System.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public bool Login(string phoneNumber, string password, UserType userType)
        {
            var tableName = userType == UserType.VENDOR ? "tbVendor" : "tbStaff";
            var query = $"SELECT * FROM {tableName} WHERE PhoneNumber = @PhoneNumber";

            using (var connection = DatabaseUtil.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var hashedPasswordFromDb = reader["Password"].ToString();
                        if (AuthHelper.VerifyPassword(password, hashedPasswordFromDb))
                        {
                            CurrentUser = new User
                            {
                                PhoneNumber = phoneNumber,
                                UserType = userType,
                                LastNameEn = reader["LastNameEN"].ToString(),
                                FirstNameEn = reader["FirstNameEN"].ToString(),
                                LastNameKh = reader["LastNameKH"].ToString(),
                                FirstNameKh = reader["FirstNameKH"].ToString(),
                                BirthDate = reader["BirthDate"] != DBNull.Value ? Convert.ToDateTime(reader["BirthDate"]) : default,
                                Gender = reader["Gender"].ToString(),
                                Email = reader["Email"].ToString(),
                                Address = reader["Address"].ToString(),
                                ProfileImageUrl = reader["ProfileImageURL"].ToString()
                            };

                            if (userType == UserType.SUPERMARKET_STAFF)
                            {
                                CurrentUser.Position = Enum.TryParse<StaffPosition>(reader["Position"].ToString(), out var position) ? position : StaffPosition.STAFF;
                            }
                            
                            CurrentUserUtil.User = CurrentUser; // Set the current user in the static class

                            return true;
                        }
                    }
                }
                connection.Close();
            }

            return false;
        }

        public void Logout()
        {
            CurrentUser = null;
            CurrentUserUtil.User = null; // Clear the current user in the static class
        }

        public bool IsAuthenticated => CurrentUser != null;
        public User CurrentUser { get; private set; }
    }
}