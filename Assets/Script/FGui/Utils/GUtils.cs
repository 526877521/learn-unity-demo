using Newtonsoft.Json;

namespace Script.FGui.Utils
{
    public static class GUtils
    {
        //
        public static Newtonsoft.Json.Linq.JObject DeserializeString(string jsonStr)
        {
      
            Newtonsoft.Json.Linq.JObject jsonDict = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(jsonStr);

            return jsonDict;

        }
    }
}