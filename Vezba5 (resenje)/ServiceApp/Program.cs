using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Contracts;
using System.ServiceModel.Security;
using Manager;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using Manager.SecurityManager;
using System.IdentityModel.Policy;
using System.ServiceModel.Description;
using System.Threading;

namespace ServiceApp
{
	public class Program
	{
		static void Main(string[] args)
		{

            NetTcpBinding bindingReplicator = new NetTcpBinding();
            bindingReplicator.Security.Mode = SecurityMode.Transport;
            bindingReplicator.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;
            bindingReplicator.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;

            WindowsIdentity wId = WindowsIdentity.GetCurrent();
            Console.WriteLine(wId.Name.ToString());

            string addressReplicator = "net.tcp://localhost:8888/SecurityService";

            /// srvCertCN.SubjectName should be set to the service's username. .NET WindowsIdentity class provides information about Windows user running the given process
            Console.ReadLine();
			string srvCertCN = Formatter.ParseName(WindowsIdentity.GetCurrent().Name);
            IdentityReferenceCollection clGroups = WindowsIdentity.GetCurrent().Groups;
            bool found = false;
            string groupName = "";
            foreach (IdentityReference group in clGroups)
            {
                SecurityIdentifier sid = (SecurityIdentifier)group.Translate(typeof(SecurityIdentifier));
                var name = sid.Translate(typeof(NTAccount));
                groupName = Formatter.ParseName(name.ToString());    /// return name of the Windows group				
                if (groupName == "Servers")
                {
                    found = true;
                    break;
                }

            }
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;

			string address = "net.tcp://localhost:9998/Receiver";
			ServiceHost host = new ServiceHost(typeof(WCFService));
            host.AddServiceEndpoint(typeof(IDatabaseManagement), binding, address);
            host.AddServiceEndpoint(typeof(ISSLHandshake), binding, address);

            host.Authorization.ServiceAuthorizationManager = new CustomAuthorizationManager();

            List<IAuthorizationPolicy> policies = new List<IAuthorizationPolicy>();
            policies.Add(new CustomAuthorizationPolicy());
            host.Authorization.ExternalAuthorizationPolicies = policies.AsReadOnly();

            host.Authorization.PrincipalPermissionMode = PrincipalPermissionMode.Custom;

            ///Custom validation mode enables creation of a custom validator - CustomCertificateValidator
            host.Credentials.ClientCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.Custom;
            host.Credentials.ClientCertificate.Authentication.CustomCertificateValidator = new ServiceCertValidator();
            host.Credentials.ClientCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;
            
            if (found)
            {
                ///Set appropriate service's certificate on the host. Use CertManager class to obtain the certificate based on the "srvCertCN"
                host.Credentials.ServiceCertificate.Certificate = CertManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, srvCertCN, groupName);
                /// host.Credentials.ServiceCertificate.Certificate = CertManager.GetCertificateFromFile("WCFService.pfx");
                
                try
                {
                    host.Open();
                    Console.WriteLine("WCFService is started ...");
                    
                    while (true)
                    {
                            try
                            {
                                using (WCFService proxy = new WCFService(bindingReplicator, addressReplicator))
                                {
                                    proxy.Replicate();
                                    Thread.Sleep(2000);
                                }
                            }
                            catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    } 
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("[ERROR] {0}", e.Message);
                    Console.WriteLine("[StackTrace] {0}", e.StackTrace);
                }
                finally
                {
                    host.Close();
                }
            }
            else
            {
                Console.WriteLine("Server is in no groupe");
                Console.ReadLine();
                host.Close();
            }
		}
	}
}
