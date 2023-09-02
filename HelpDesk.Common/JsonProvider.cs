using HelpDesk.Common.Models;
using Newtonsoft.Json;

namespace HelpDesk.Common
{
    public class JsonProvider
    {
        public static void Save(ParamDb paramDb)
        {
            var jsonData = JsonConvert.SerializeObject(paramDb, Formatting.Indented);
            FileProvider.EncryptPut(jsonData);
        }

        public static ParamDb Load()
        {
            var cfg = FileProvider.DecryptGet();
            return JsonConvert.DeserializeObject<ParamDb>(cfg);
        }
    }
}
