using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manager.SecurityManager
{

    public enum Permissions
    {
        Create = 0,
        Delete = 1,
        Write = 2,
        Edit = 3,
        Read = 4,
        Session = 5
    }

    public enum Roles
    {
        Admins = 0,
        Writers = 1,
        Readers = 2,
    }

    public class RolesConfig
    {
        static string[] AdminPermissions = new string[] { Permissions.Session.ToString(), Permissions.Create.ToString(), Permissions.Delete.ToString() };
        static string[] WriterPermissions = new string[] { Permissions.Session.ToString(), Permissions.Write.ToString(), Permissions.Edit.ToString() };
        static string[] ReaderPermissions = new string[] { Permissions.Session.ToString(), Permissions.Read.ToString() };
        static string[] Empty = new string[] { };
        public static string[] GetPermissions(string role)
        {
            switch (role)
            {
                case "Admins": return AdminPermissions;
                case "Writers": return WriterPermissions;
                case "Readers": return ReaderPermissions;
                default: return Empty;
            }
        }
    }
}
