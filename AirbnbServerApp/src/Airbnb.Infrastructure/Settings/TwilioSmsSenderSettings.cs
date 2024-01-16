﻿namespace Airbnb.Infrastructure.Settings;

public class TwilioSmsSenderSettings
{
    public string AccountSid { get; set; } = default!;

    public string AuthToken { get; set; } = default!;

    public string SenderPhoneNumber { get; set; } = default!;
}