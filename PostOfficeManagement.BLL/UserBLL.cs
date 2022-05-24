using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PostOfficeManagement.BO;
using PostOfficeManagement.DAL;

namespace PostOfficeManagement.BLL
{
    public class UserBLL
    {
        private UsersDAL _UsersDAL;
        public UserBLL()
        {
            _UsersDAL = new UsersDAL();
        }
        public Users GetUsers(Users useri)
        {
            return _UsersDAL.GetUsers(useri);
        }

    }
}
