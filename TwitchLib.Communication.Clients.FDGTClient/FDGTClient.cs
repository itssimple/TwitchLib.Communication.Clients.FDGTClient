using System.Linq;
using System.Reflection;

namespace TwitchLib.Communication.Clients
{
    public class FDGTClient : WebSocketClient
    {

        public FDGTClient() : base()
        {
            var urlField = GetType().BaseType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f => f.Name.Contains("Url"));
            urlField.SetValue(this, "wss://irc.fdgt.dev:443");
        }
    }
}
