using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSH
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StringBuilder result = new StringBuilder();
                string command = "xStatus";
                PasswordConnectionInfo connectionInfo = new PasswordConnectionInfo("192.168.1.54", "admin", "");
                //using (SshClient client = new SshClient("192.168.1.252", "admin", "TANDBERG"))
                using (SshClient client = new SshClient(connectionInfo))
                {
                    //client.
                    client.Connect();
                    result.Append(client.RunCommand(command).Execute() + "\r\n");
                    Console.WriteLine( result.ToString());
                    client.Disconnect();
                }
                //SshClient a = new SshClient();
            }
            catch (Exception e)
            {

                throw;
            }
            
        }
    }
}
