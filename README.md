# WebhookSpammer
A Discord Webhook Spammer with Proxy Scaper to bypass Rate Limits from Disc

A webhook spammer to swallow Discord servers.

## Supportet Protector
 - Default Discord Webhook
 - [Discord Webhook Protector from Rdimo](https://github.com/Rdimo/Discord-Webhook-Protector)
 - Any OTP base32 Based Webhook Protector

## Features
 - Automated Proxy Webscrapeer and Switcher
 - Fully customizable webhooks
 - Bypass any know Discord Webhook protector's
 - TTS for Normal Discord Webhook

## Configuration

At the first start an INI file is created

### INI Structure

````ini
[SYSCONFIG]
WebhookURL=https://discord.com/webhook       # If it is a normal webhook the URL must be here
isDWP=false      # Is this a Discord Webhook Protector? true / false
CheckProxyBeforeRequest=            # In Dev Feature


[WEBHOOK]
Username=Webhook Spammer by NONE     # Name of the webhook
UserImage=https://image-for-user.com   # Webhook Usericon
Content=This Webhook got spammed by     # There he is added text. With normal Discord this supports @everyone. This value is also used with the Discord Webhook Protector
TextToSpeek=true/false                  # Only Normale Discord Webhook.

[DWHP]
WebhookprotectorURL=https://qpi.protector.example/webhooks # URL from the Protector Page
Password=base32 Passswort to generate OTPs
ChangeAfterRequest=1      # ASfter X Request the Proxy will channge
Port=3000                 # Indev Feature
````


HAVE FUN