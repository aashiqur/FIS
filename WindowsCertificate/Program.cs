using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
   class Program
   {
      static void Main(string[] args)
      {
         X509Store store = new X509Store("MY", StoreLocation.LocalMachine);
         store.Open(OpenFlags.ReadOnly);

         X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
         foreach (X509Certificate2 x509 in collection)
         {
            try
            {
               Console.WriteLine("Friendly Name: {0}{1}", x509.FriendlyName, Environment.NewLine);
               Console.WriteLine("Subject Name: {0}{1}", x509.SubjectName.Name, Environment.NewLine);
               Console.WriteLine("Certificate Verified?: {0}{1}", x509.Verify(), Environment.NewLine);
               x509.Reset();
            }
            catch (Exception exception)
            {
               Console.WriteLine("Information could not be written out for this certificate." + exception.Message);
            }
         }
         store.Close();
      }
   }
}
