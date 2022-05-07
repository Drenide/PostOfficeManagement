using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PostOfficeManagement.DAL;

namespace PostOfficeManagement.BLL
{
    public class LoginBLL
    {
        private LoginDAL _Login;

        public LoginBLL()
        {
            _Login = new LoginDAL();
        }

        public DataSet GetAll()
        {
            return _Login.GetAll();
        }
    }
}
