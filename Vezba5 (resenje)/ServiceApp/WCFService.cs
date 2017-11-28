using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using Manager;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.IO;
using DBparam;
using System.ServiceModel;
using Manager.SecurityManager;
using System.Threading;

namespace ServiceApp
{
    
    public class WCFService : ChannelFactory<ISecurityService>, ISecurityService, IDisposable, IDatabaseManagement, ISSLHandshake
    {
        ISecurityService factory;

        public WCFService(NetTcpBinding binding, string address) : base(binding, address)
		{
            factory = this.CreateChannel();
        }

        public WCFService(){ }
        public bool Replicate()
        {
            try
            {
                return factory.Replicate();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while Replicating: {0}", e.Message);
                return false;
            }
        }
        
        # region SSL Handshake
        static byte[] session_key;

        public X509Certificate2 RequestSession()
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;

            if(principal.IsInRole(Permissions.Session.ToString()))
            {
                X509Certificate2 serverCertificate;
                string srvCertCN = Formatter.ParseName(WindowsIdentity.GetCurrent().Name);
                serverCertificate = CertManager.GetCertificateFromStorage(StoreName.TrustedPeople, StoreLocation.LocalMachine, srvCertCN);

                //Audit succesfull

                return serverCertificate;
            }
            else
            {
                //Audit failed
            }
            return null;
        }

        public bool SendSessionKey(byte[] encrypted_session_key)
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;

            if(principal.IsInRole(Permissions.Session.ToString()))
            {

                X509Certificate2 serverCertificate;
                string srvCertCN = Formatter.ParseName(WindowsIdentity.GetCurrent().Name);
                serverCertificate = CertManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, srvCertCN);

                session_key = RSA_ASymm_Algorithm.RSADecrypt(encrypted_session_key, serverCertificate);

                //Audit successfull

                return true;
            }
            else
            {
                //Audit failed
            }
            return false;
        }

        public byte[] GetSessionKey()
        {
            return session_key;
        }

        #endregion


        public int AverageUsageInCity(string city, string userName)
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
            string path = "DataBase.txt";

            if (principal.IsInRole(Permissions.Read.ToString()))
            {
                DBParam dbp = new DBParam();

                Audit.AuthorizationSuccess(userName, OperationContext.Current.IncomingMessageHeaders.Action);

                int totalUsage = 0;

                try
                {
                    string[] lines = File.ReadAllLines(path);
                    List<DBParam> wantedCity = new List<DBParam>();
                    Audit.ReadSuccess(path);

                    for (int i = 0; i < lines.Count(); i++)
                    {
                        string[] separeted = lines[i].Split('/');
                        dbp.Id = Int32.Parse(separeted[0]);
                        dbp.Region = separeted[1];
                        dbp.City = separeted[2];
                        dbp.Year = Int32.Parse(separeted[3]);
                        dbp.Month = separeted[4];
                        dbp.ElEnergySpent = Int32.Parse(separeted[5]);

                        if (dbp.City == city)
                        {
                            wantedCity.Add(dbp);
                        }
                    }

                    for (int i = 0; i < wantedCity.Count; i++)
                    {
                        totalUsage += wantedCity[i].ElEnergySpent;
                    }
                    totalUsage = totalUsage / wantedCity.Count;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception was thrown:");
                    Console.WriteLine(e.Message);
                }

                return totalUsage;

            }
            else
            {
                Audit.ReadFailed(path, "Access is denied!");
                Audit.AuthorizationFailed(userName, OperationContext.Current.IncomingMessageHeaders.Action, "Authorization failed.");
                Console.WriteLine("User access is denied for function AverageUsageInCity");
                return -1;
            }
        }

        public int AverageUsageInRegion(string region, string userName)
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
            string path = "DataBase.txt";

            if (principal.IsInRole(Permissions.Read.ToString()))
            {
                DBParam dbp = new DBParam();
                int totalUsage = 0;

                Audit.AuthorizationSuccess(userName, OperationContext.Current.IncomingMessageHeaders.Action);

                try
                {

                    string[] lines = File.ReadAllLines(path);
                    List<DBParam> wantedReg = new List<DBParam>();
                    Audit.ReadSuccess(path);

                    for (int i = 0; i < lines.Count(); i++)
                    {
                        string[] separeted = lines[i].Split('/');
                        dbp.Id = Int32.Parse(separeted[0]);
                        dbp.Region = separeted[1];
                        dbp.City = separeted[2];
                        dbp.Year = Int32.Parse(separeted[3]);
                        dbp.Month = separeted[4];
                        dbp.ElEnergySpent = Int32.Parse(separeted[5]);

                        if (dbp.Region == region)
                        {
                            wantedReg.Add(dbp);
                        }
                    }

                    for (int i = 0; i < wantedReg.Count; i++)
                    {
                        totalUsage += wantedReg[i].ElEnergySpent;
                    }

                    totalUsage = totalUsage / wantedReg.Count;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception was thrown:");
                    Console.WriteLine(e.Message);
                }

                return totalUsage;
            }
            else
            {
                Audit.ReadFailed(path, "Access is denied!");
                Audit.AuthorizationFailed(userName, OperationContext.Current.IncomingMessageHeaders.Action, "Authorization failed.");
                Console.WriteLine("User access is denied for function AverageUsageInRegion");
                return -1;
            }
        }

        public string HighestSpenderInRegion(string region, string userName)
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
            string path = "DataBase.txt";

            if (principal.IsInRole(Permissions.Read.ToString()))
            {
                DBParam dbp = new DBParam();
                Audit.AuthorizationSuccess(userName, OperationContext.Current.IncomingMessageHeaders.Action);

                string hs = "";


                try
                {

                    string[] lines = File.ReadAllLines(path);
                    Audit.ReadSuccess(path);

                    List<DBParam> wantedReg = new List<DBParam>();

                    for (int i = 0; i < lines.Count(); i++)
                    {
                        string[] separeted = lines[i].Split('/');
                        dbp.Id = Int32.Parse(separeted[0]);
                        dbp.Region = separeted[1];
                        dbp.City = separeted[2];
                        dbp.Year = Int32.Parse(separeted[3]);
                        dbp.Month = separeted[4];
                        dbp.ElEnergySpent = Int32.Parse(separeted[5]);

                        if (dbp.Region == region)
                        {
                            wantedReg.Add(dbp);
                        }
                    }

                    Dictionary<string, int> citiesInRegion = new Dictionary<string, int>();
                    foreach (DBParam p in wantedReg)
                    {
                        if (citiesInRegion.ContainsKey(p.City))
                        {
                            citiesInRegion[p.City] += p.ElEnergySpent;
                        }
                        else
                            citiesInRegion.Add(p.City, p.ElEnergySpent);
                    }
                    List<KeyValuePair<string, int>> lista = citiesInRegion.ToList();
                    hs = lista[0].Key;
                    int hsVal = lista[0].Value;
                    for (int i = 1; i < citiesInRegion.Count; i++)
                    {
                        if (lista[i].Value > hsVal)
                        {
                            hsVal = lista[i].Value;
                            hs = lista[i].Key;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception was thrown:");
                    Console.WriteLine(e.Message);
                }

                return hs;
            }
            else
            {
                Audit.ReadFailed(path, "Access is denied!");
                Audit.AuthorizationFailed(userName, OperationContext.Current.IncomingMessageHeaders.Action, "Authorization failed.");
                Console.WriteLine("User access is denied for function HighestSpenderInRegion");
                return "You don't have permission to use this function";
            }
        }

        public bool Add(string userName, DBParam dbp)
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
            string path = "DataBase.txt";

            if (principal.IsInRole(Permissions.Write.ToString()))
            {
                Audit.AuthorizationSuccess(userName, OperationContext.Current.IncomingMessageHeaders.Action);

                try
                {
                    StreamWriter sw;
                    using (sw = new StreamWriter(path, true))
                    {
                        sw.WriteLine(dbp.Id + "/" + dbp.Region + "/" + dbp.City + "/" + dbp.Year + "/" + dbp.Month + "/" + dbp.ElEnergySpent);
                    }
                    sw.Close();
                    Audit.AddSuccess();

                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception was thrown:");
                    Console.WriteLine(e.Message);
                }

                return true;
            }
            else
            {
                Audit.AddFailed("Access is denied!");
                Audit.AuthorizationFailed(userName, OperationContext.Current.IncomingMessageHeaders.Action, "Authorization failed.");
                Console.WriteLine("User access is denied for function Add");
                return false;
            }
        }

        public bool Edit(string userName, DBParam dbp)
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
            string path = "DataBase.txt";

            if (principal.IsInRole(Permissions.Write.ToString()))
            {
                Audit.AuthorizationSuccess(userName, OperationContext.Current.IncomingMessageHeaders.Action);

                try
                {
                    string[] text = File.ReadAllLines(path);
                    text[dbp.CNT] = dbp.Id + "/" + dbp.Region + "/" + dbp.City + "/" + dbp.Year + "/" + dbp.Month + "/" + dbp.ElEnergySpent;
                    File.WriteAllLines(path, text);
                    Audit.UpdateSuccess();
                }
                catch (Exception e)
                 {
                    Console.WriteLine("Exception was thrown: ");
                    Console.WriteLine(e.Message);
                 }

                 return true;
             }
             else
             {
                Audit.UpdateFailed("Access is denied!");
                Audit.AuthorizationFailed(userName, OperationContext.Current.IncomingMessageHeaders.Action, "Authorization failed.");
                Console.WriteLine("User access is denied for function Edit");
                return false;
            }
        }

        public string CreateDatabase(string userName)
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
            string path = "DataBase.txt";

            if (principal.IsInRole(Permissions.Create.ToString()))
            {
                Audit.AuthorizationSuccess(userName, OperationContext.Current.IncomingMessageHeaders.Action);

                if (!File.Exists(path))
                {
                    // Create a file to write to.
                    try
                    {
                        var myFile=File.CreateText(path);
                        myFile.Close();
                        Audit.CreateSuccess(path);
                        //Console.WriteLine("Successfuly created new database!");
                        return "Successfuly created new database!";
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e.Message);
                        return e.Message;
                    }

                }
                else
                {
                    Audit.CreateFailed(path, "Database already exists!");
                    //Console.WriteLine("Database already exists");
                    return "Database already exists";
                }
            }
            else
            {
                Audit.AuthorizationFailed(userName, OperationContext.Current.IncomingMessageHeaders.Action, "Authorization failed.");
                Console.WriteLine("User access is denied for function Create");
                return "You don't have permission to use this function";
            }
        }

        public string DeleteDatabase(string userName)
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
            string path = "DataBase.txt";

            if (principal.IsInRole(Permissions.Delete.ToString()))
            {
                Audit.AuthorizationSuccess(userName, OperationContext.Current.IncomingMessageHeaders.Action);

                if (File.Exists(path))
                {
                    // Delete a file 
                    try
                    {
                        File.Delete(path);
                        Audit.DeleteSuccess(path);
                        //Console.WriteLine("Successfuly deleted database!");
                        return "Successfuly deleted database!";
                    }
                    catch (IOException e)
                    {
                        //Console.WriteLine(e.Message);
                        return e.Message;
                    }

                }
                else
                {
                    Audit.DeleteFailed(path, "Database doesn't exist!");
                    //Console.WriteLine("Database already exists");
                    return "Database doesn't exists";
                }
            }
            else
            {
                Audit.AuthorizationFailed(userName, OperationContext.Current.IncomingMessageHeaders.Action, "Authorization failed.");
                Console.WriteLine("User access is denied for function Delete");
                return "You don't have permission to use this function";
            }
        }

    }
}
