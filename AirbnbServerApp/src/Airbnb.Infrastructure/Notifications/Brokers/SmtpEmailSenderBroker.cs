using System.Net;
using System.Net.Mail;
using Airbnb.Application.Common.Notifications.Brokers.Interfaces;
using Airbnb.Application.Common.Notifications.Models;
using Airbnb.Infrastructure.Settings;
using Microsoft.Extensions.Options;

namespace Airbnb.Infrastructure.Notifications.Brokers;

///<summary>
/// Email sender broker using SMTP for sending email messages.
/// Initializes a new instance of the SmtpEmailSenderBroker class.
///</summary>
///<param name="emailSenderSettings">The settings for the SMTP email sender.</param>
public class SmtpEmailSenderBroker(IOptions<SmtpEmailSenderSettings> emailSenderSettings) : IEmailSenderBroker
{
    private readonly SmtpEmailSenderSettings _smtpEmailSenderSettings = emailSenderSettings.Value;
    
    ///<summary>
    /// Sends an email message asynchronously using SMTP.
    ///</summary>
    ///<param name="emailMessage">The EmailMessage object containing email details.</param>
    ///<param name="cancellationToken">A cancellation token to cancel the operation.</param>
    ///<returns>A ValueTask representing the asynchronous operation, returning true if the email is successfully sent.</returns>
    public ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default)
    {
        
        //create new mail message
        var mail = new MailMessage(emailMessage.SenderEmailAddress, emailMessage.ReceiverEmailAddress);
        mail.Subject = emailMessage.Subject;
        mail.Body = emailMessage.Body;
        mail.IsBodyHtml = true;
        
        //create smtpClient and send mail message to email
        var smtpClient = new SmtpClient(_smtpEmailSenderSettings.Host, _smtpEmailSenderSettings.Port);
        smtpClient.Credentials =
            new NetworkCredential(_smtpEmailSenderSettings.CredentialAddress, _smtpEmailSenderSettings.Password);
        smtpClient.EnableSsl = true;

        smtpClient.Send(mail);

        return new ValueTask<bool>(true);
    }
}