# Akentas.Mailer
Simple SMTP mailer using plaintext templates - written in C#.

You can use this library to send emails from your .NET program.

# Install via NuGet
```
Install-Package Akentas.Mailer
```

# Usage
1. Install the NuGet package / Reference the library
2. Set the mailSettings in the app.config or web.config
3. Instance the EmailSender and use the SendEmail method

# Settings in app.config or web.config

## mailSettings
Use the following snippet to test the mailer locally (no email is sent - just dropped to the specified folder)
```
<system.net>
    <mailSettings>
        <smtp deliveryMethod="SpecifiedPickupDirectory">
            <specifiedPickupDirectory pickupDirectoryLocation="c:\temp\maildrop\" />
        </smtp>
    </mailSettings>
</system.net>
```

Use the following snippet to use SMTP
```
<system.net>
    <mailSettings>
        <smtp from="akentas-mailer@yourprovider.de">
            <network host="smtp.yourprovider.com" userName="email@yourprovider.com" password="yourpassword" enableSsl="true" />
        </smtp>
    </mailSettings>
</system.net>
```

# EmailSender

```
// Instanciate the EmailSender with the root path of the email templates
var emailSender = new EmailSender(Server.MapPath(ConfigurationManager.AppSettings["AkentasMailer.MessagesTemplatesRootDirectory"]));

// Then specify the placeholders from the email template you want to use and set the corresponding values (each placeholder will be replaced with the given value)
var placeholdersWithValues = new Dictionary<string, string> { { "link", "https://www.testapp.de/xyz8478" } };

// Finally use the SendMail method (use the filename without extension as template name)
emailSender.SendEmail("from@email.com", "to@email.com", "bcc@email.com", "Email subject", "template-filename", placeholdersWithValues);
```

# Example Web App
Check the included WebApplicationToTestMailer ASP.NET MVC app for more examples (two templates - welcome and reset-password mail templates).

## License
MIT