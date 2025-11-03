using BankApp.Accounts;
using Microsoft.Extensions.Configuration;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankApp
{
   internal static class EmailService
    {
        //private const string SmtpHost = "smtp.gmail.com"; 
        //private const int SmtpPort = 587;
        //private const string SenderEmail = "";
        //private const string SenderPassword = "";
        //private const string recipientEmail = "";

        private static MailConfig? _config;

        private static string lastGeneratedCode;

        private static readonly Random Random = new Random();

        public static void Initialize(IConfiguration configuration)
        {
            // Binds the "EmailSettings" from .json file to our actual code
            _config = configuration.GetSection("EmailSettings").Get<MailConfig>();
            
        }

        public static  string GenerateRandomCode()
        {

            string Block() => Random.Next(0, 11000000).ToString("D6");
          

            return Block();
        }
      
        public  static string SendLoginCodeEmail()
        {
            Console.WriteLine("Please write recipients email:");
            string recipientEmail = Console.ReadLine();
            
            string loginCode = GenerateRandomCode();
            lastGeneratedCode = loginCode;

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(_config.SenderEmail, "Secure Login Service");
                    mail.To.Add(recipientEmail);
                  
                    mail.Subject = "Your One-Time Login Code";
                  
                    mail.IsBodyHtml = true;
                    mail.Body = $@"
                    <html>
                        <body style='font-family: Arial, sans-serif; text-align: center; padding: 20px; border: 1px solid #eee;'>
                            <h2>Hello!</h2>
                            <p>Your temporary login code is:</p>
                            <div style='font-size: 24px; font-weight: bold; color: #4CAF50; padding: 10px; border: 2px solid #4CAF50; display: inline-block; border-radius: 5px; margin: 15px;'>
                                {loginCode}
                            </div>
                            <p style='color: #888;'>This code is valid for a short time only.</p>
                        </body>
                    </html>";

                 
                    using (SmtpClient smtp = new SmtpClient(_config.SmtpHost, _config.SmtpPort))
                    {
                        smtp.Credentials = new NetworkCredential(_config.SenderEmail, _config.SenderPassword);
                        smtp.EnableSsl = true; 

                        smtp.Send(mail);
                    }
                }

                return loginCode;
            }
            catch (SmtpException sx)
            {
                Console.WriteLine($" Could not send email. Check your host, port, and credentials. Message: {sx.Message}");
                throw;
            }
           
        }
        public static string GetLastLoginCode()
        {
            return lastGeneratedCode;
        }

        public static void SendIssueCodeEmail(int issueOption, User? user, string? issueText , Transaction? tx )
        {
            const string recipientEmail = "";
            string IssueText = issueOption switch
            {
                1 => $"A User: {user.Name.ToString()} has had their account locked. \n Assist them if a mistake was made.",
                2 => $"{issueText}",
                3 => $"Suspicious Transaction occurred {tx.ToString()}, \n please investigate, and forward to Fraud team if necessary.",
                _ => "Unknown issue encountered, please check logs."
            };
            try
            {
                using (MailMessage mail = new MailMessage())
                {

                    mail.From = new MailAddress(SenderEmail, "Issue Code Handler");
                    mail.To.Add(recipientEmail);


                    mail.Subject = "New Issue assigned to you.";

                    mail.IsBodyHtml = true;
                    mail.Body = $@"
                    <html>
                        <body style='font-family: Arial, sans-serif; text-align: center; padding: 20px; border: 1px solid #eee;'>
                            <h2>Hello!</h2>
                            <p>A new issue has been assigned to you.</p>
                            <div style='font-size: 24px; font-weight: bold; color: #4CAF50; padding: 10px; border: 2px solid #4CAF50; display: inline-block; border-radius: 5px; margin: 15px;'>
                               {IssueText}
                            </div>
                          
                        </body>
                    </html>";


                    using (SmtpClient smtp = new SmtpClient(SmtpHost, SmtpPort))
                    {
                        smtp.Credentials = new NetworkCredential(SenderEmail, SenderPassword);
                        smtp.EnableSsl = true;

                        smtp.Send(mail);
                    }
                }


            }
            catch (SmtpException sx)
            {
                Console.WriteLine($" Could not send email. Check your host, port, and credentials. Message: {sx.Message}");
                throw;
            }

        }


    }
}
