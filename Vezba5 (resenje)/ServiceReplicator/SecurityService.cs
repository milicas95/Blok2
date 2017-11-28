using Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceReplicator
{
    public class SecurityService : ISecurityService
    {
        public bool Replicate()
        {
            Console.WriteLine("Hello");

            WindowsIdentity identity = (WindowsIdentity)Thread.CurrentPrincipal.Identity; //samo inf o tome koji je korisnik i koji tip autetifikacije, a prncipal grupe i drugi podaci potrebni za autorizaciju
            WindowsPrincipal principal = (WindowsPrincipal)Thread.CurrentPrincipal;
            //informacije o klijentu koje ce biti ispisane na servisu
            Console.WriteLine(identity.Name.ToString());

            //Copy database.txt to another destination
            string sourceDir = @"C:/Users/Administrator.DOMAINADMINS0/Desktop/!/Blok2/Vezba5 (resenje)/ServiceApp/bin/Debug";
            string backupDir = @"C:/Users/Administrator.DOMAINADMINS0/Desktop/!/Blok2/Vezba5 (resenje)/ServiceReplicator/bin/Debug";

            
            try
            {
                File.Copy(Path.Combine(sourceDir, "DataBase.txt"), Path.Combine(backupDir, "DataBaseCopy.txt"), true);
                Console.WriteLine("Database copied!");
                return true;
            }
            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
                return false;
            }
        }
    }
}
