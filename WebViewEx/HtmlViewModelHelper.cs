using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebViewEx
{

       public static class JsonSerializationExtentions
       {
           public static bool IsObjectOrArray (string json)
           {
               return json.Contains('{') || json.Contains('[');
           }
       }

        public static class HtmlViewModelHelpers
        {
            private const string RESPONSE_SCRIPT = @"/* function */{0}(/* id */""{1}"", /* responsedata */{2});";
            private const string SUCCESS_RESPONSE_HANDLER = @"ST.receivedSmartThingsMessageSuccess";
            private const string ERROR_RESPONSE_HANDLER = @"ST.receivedSmartThingsMessageSuccess";
            private const string RESPONSE_STRING_DATA = "{{\"data\":\"{0}\"}}";

            public static async Task<string> ExecuteScriptAsync (ScriptNotificationMessage message)
            {
                //return await Task<string>.FromResult("{\"foo\":\"fooValue\"}");  // pass object
                return await Task<string>.FromResult("just a string");           // pass string value
                //return await Task<string>.FromResult("[1, \"two\", {\"three\":\"value is 3\"}]"); // pass array
                //return await Task<string>.FromResult(null); // pass null
            }

            public static async Task<string> HandleScriptNotify(ScriptNotificationMessage message, Func<ScriptNotificationMessage, Task<string>> executeScriptActionAsync)
            {
                string responseScript = null;
                string responseData = null;

                try
                {
                    var response = await executeScriptActionAsync(message);

                    if (response == null)
                    {
                        // return empty json object {}
                        responseData = "{}";
                    }
                    else if (JsonSerializationExtentions.IsObjectOrArray(response))
                    {
                        // response is a json: return it as it is
                        responseData = response;
                    }
                    else
                    {
                        // non-json string
                        // build {data: response} json
                        responseData = String.Format(RESPONSE_STRING_DATA, response);
                    }

                    responseScript = String.Format(RESPONSE_SCRIPT, SUCCESS_RESPONSE_HANDLER, message.Id, responseData);

                }
                catch (System.Exception ex)
                {
                    responseData = String.Format(RESPONSE_STRING_DATA, ex.Message);
                    responseScript = String.Format(RESPONSE_SCRIPT, ERROR_RESPONSE_HANDLER, message.Id, responseData);
                }

                return responseScript;
            }


            #region Support Object

            public class ScriptNotificationMessage
            {
                public string Id { get; set; }
                public string Method { get; set; }
                public string Path { get; set; }
                public Dictionary<string, object> Params { get; set; }

            }


            #endregion
        }
    

}
