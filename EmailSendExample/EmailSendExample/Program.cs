// See https://aka.ms/new-console-template for more information
using EmailSendExample;
using SendGrid;
using SendGrid.Helpers.Mail;

Console.WriteLine("Hello, World!");

//var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
//var client = new SendGridClient(apiKey);
//var msg = new SendGridMessage()
//{
//    From = new EmailAddress("aleshin.roman.nk@gmail.com", "DX Team"),
//    Subject = "Sending with Twilio SendGrid is Fun",
//    PlainTextContent = "and easy to do anywhere, even with C#",
//    HtmlContent = "<strong>and easy to do anywhere, even with C#</strong>"
//};
//msg.AddTo(new EmailAddress("aleshin.roman.nk@gmail.com", "Test User"));
//var response = await client.SendEmailAsync(msg).ConfigureAwait(false);

//Console.WriteLine(response.StatusCode.ToString());

EmailService srv = new EmailService();

try
{
    await srv.SendEmailAsync("aleshin.roman.nk@gmail.com", "text", "confirmation code : 456710");
    Console.WriteLine($"Connected : {srv.IsConnected} | Aouthenticated : {srv.IsAuthenticated}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine();
Console.WriteLine("Program completed");

Console.ReadLine();