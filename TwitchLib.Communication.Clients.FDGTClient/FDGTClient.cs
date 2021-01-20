using System.Linq;
using System.Reflection;

namespace TwitchLib.Communication.Clients
{
    public class FDGTClient : WebSocketClient
    {

        public FDGTClient() : base()
        {
            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var urlField = base.GetType().BaseType.GetFields(bindingFlags).FirstOrDefault(f => f.Name.Contains("Url"));
            urlField.SetValue(this, "wss://irc.fdgt.dev:443");
        }
    }
}
