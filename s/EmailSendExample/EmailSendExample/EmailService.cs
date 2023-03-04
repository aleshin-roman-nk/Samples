using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSendExample
{
    internal class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "aleshin.roman.nk@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                client.Connected += Client_Connected;
                client.Authenticated += Client_Authenticated;

                await client.ConnectAsync("smtp.gmail.com", 465, true);
                await client.AuthenticateAsync("aleshin.roman.nk@gmail.com", "zxmzrmmzrgbfldwb");
                await client.SendAsync(emailMessage);

                IsConnected = client.IsConnected ? "OK" : "fail";
                IsAuthenticated = client.IsAuthenticated ? "OK" : "fail";

                await client.DisconnectAsync(true);
            }
        }

        private void Client_Authenticated(object? sender, MailKit.AuthenticatedEventArgs e)
        {
            Console.WriteLine($"Authenticated : {e.Message}");
        }

        private void Client_Connected(object? sender, MailKit.ConnectedEventArgs e)
        {
            Console.WriteLine($"Connected to {e.Host} on port {e.Port} with options {e.Options}");
        }

        public string IsConnected { get; set; } = "fail";
        public string IsAuthenticated { get; set; } = "fail";
    }
}
