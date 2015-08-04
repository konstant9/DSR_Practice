
using System.Configuration;

namespace Client
{
    class ExtraData
    {
        private static bool _isEnglish = true;
        private static readonly ConnectionStringSettings _loginData = ConfigurationManager.ConnectionStrings["LoginConnection"];
        private static readonly ConnectionStringSettings _serverData = ConfigurationManager.ConnectionStrings["ServerConnection"];

        public static bool IsEnglish
        {
            get { return _isEnglish; }
            set { _isEnglish = value; }
        }
        
        public static ConnectionStringSettings LoginData
        {
            get { return _loginData; }
        }

        public static ConnectionStringSettings ServerData
        {
            get { return _serverData; }
        }
    }
}
