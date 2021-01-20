# TwitchLib.Communication.Clients.FDGTClient
[![Nuget](https://img.shields.io/nuget/v/TwitchLib.Communication.Clients.FDGTClient)](https://www.nuget.org/packages/TwitchLib.Communication.Clients.FDGTClient/)
[![Nuget](https://img.shields.io/nuget/dt/TwitchLib.Communication.Clients.FDGTClient)](https://www.nuget.org/packages/TwitchLib.Communication.Clients.FDGTClient/)

This client allows you to connect to [FDGT](https://fdgt.dev)


## Usage

```csharp
void Main()
{
  TwitchClient client = new TwitchClient(new FDGTClient());
  client.Initialize(
    new ConnectionCredentials(
      "fdgttest",                   // The bot username
      "",                           // The oauth-pass (not used)
      "wss://irc.fdgt.dev:443",     // Just to make the output correct when you connect
      true),                        // Disabled namechecking in TwitchLib
    "fdgt"                          // Channel to autojoin
  );

  var channel = string.Empty;

  client.OnJoinedChannel += (sender, args) =>
  {
    channel = args.Channel;
  };
	
  client.OnLog += (sender, args) => {
    Console.WriteLine(args.Data);	
  };

  client.Connect();
	
  var lastLine = string.Empty;
	
  while(lastLine != "exit")
  {
    lastLine = Console.ReadLine();
    client.SendMessage(channel, lastLine);
  }
	
  client.Disconnect();
}
```