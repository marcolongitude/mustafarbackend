using System;

namespace Mustafarbackend.Modules.Users.Models
{
    public struct UserModel
    {
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string ?_name;
        public string Name
        {
            get { return _name!; }
            set { _name = value; }
        }

        private string ?_email;
        public string Email
        {
            get { return _email!; }
            set { _email = value; }
        }

        private string ?_password;
        public string Password
        {
            get { return _password!; }
            set { _password = value; }
        }

        private string ?cel;
        public string Cel
        {
            get { return cel!; }
            set { cel = value; }
        }

        private string ?permission;
        public string Permission
        {
            get { return permission!; }
            set { permission = value; }
        }


        private DateTime _createAt;
        public DateTime CreateAt
        {
            get { return _createAt; }
            set { _createAt = DateTime.UtcNow; }
        }

        private DateTime _updateAt;
        public DateTime UpdateAt
        {
            get { return _updateAt; }
            set { _updateAt = value; }
        }

    }
}

