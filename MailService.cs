using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using BankApp.Accounts;

namespace BankApp
{
    public class EmailService
    {
 
        private const string SmtpHost = "smtp.gmail.com"; 
        private const int SmtpPort = 587;
        private const string SenderEmail = "no-reply@yourdomain.com";
        private const string SenderPassword = "YOUR_APP_PASSWORD";
        private const string recipientEmail = "";

        private static string lastGeneratedCode;


        private static readonly Random Random = new Random();

    
        public string GenerateRandomCode()
        {

            string Block() => Random.Next(0, 11000000).ToString("D6");

          
            return Block();
        }

      
        public string SendLoginCodeEmail(string recipientEmail)
        {
          
            string loginCode = GenerateRandomCode();
            lastGeneratedCode = loginCode;



            try
            {
                using (MailMessage mail = new MailMessage())
                {
                  
                    mail.From = new MailAddress(SenderEmail, "Secure Login Service");
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

                 
                    using (SmtpClient smtp = new SmtpClient(SmtpHost, SmtpPort))
                    {
                        smtp.Credentials = new NetworkCredential(SenderEmail, SenderPassword);
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

        public string SendIssueCodeEmail( int issueOption, User? user)
        {

            switch (issueOption)
            {
                case 1:
                     $"A User: {user.Name} has had their account locked, kindly resolve that.";
                    break;

                case 2:
            }
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
