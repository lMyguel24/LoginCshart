﻿using DataAccess;
namespace Domain
{
    public class UserModel
    {
        UserData userData = new UserData();
        public bool LoginUser(string username, string password)
        {
            return userData.Login(username, password);
        }
    }
}