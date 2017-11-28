using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ServiceReplicator
{
    public class Program
    {
        static void Main(string[] args)
        {
            NetTcpBinding bindingReplicator = new NetTcpBinding();
            bindingReplicator.Security.Mode = SecurityMode.Transport;
            bindingReplicator.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;
            bindingReplicator.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;

            string address = "net.tcp://localhost:8888/SecurityService";

            ServiceHost host = new ServiceHost(typeof(SecurityService));
            host.AddServiceEndpoint(typeof(ISecurityService), bindingReplicator, address);

            host.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
            host.Description.Behaviors.Add(new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });

            host.Open();

            WindowsIdentity wId = WindowsIdentity.GetCurrent(); //vraca informacije o klijentu
            Console.WriteLine(wId.Name.ToString());


            Console.WriteLine("SecurityService service is started.");
            Console.WriteLine("Press <enter> to stop service...");

            Console.ReadLine();
            host.Close();
        }
    }
}
