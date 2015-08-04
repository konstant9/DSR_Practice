using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCServer.Models
{
    public class Authenticator
    {
        private const string _login = "admin";
        private const string _password = "admin";

        public static void Authenticate(string login, string password)
        {
            if (login == _login  && password == _password)
                return;
            throw new UnauthorizedAccessException();
        }

    }
}