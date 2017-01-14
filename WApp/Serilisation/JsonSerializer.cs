


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Dynamic;

namespace AutoServer.Common
{

    public class JsonSerializer : JavaScriptSerializer
    {

        public JsonSerializer()
        {
            RegisterConverters(new[] { new ExpandoObjectConverter() });
        }

        private class ExpandoObjectConverter : JavaScriptConverter
        {
            public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
            {
                var result = new ExpandoObject();
                var resultDict = (IDictionary<string, object>)result;
                if (dictionary != null)
                {
                    foreach (var pair in dictionary)
                    {
                        resultDict[pair.Key] = pair.Value;
                    }
                }
                return result;
            }

            public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
            {
                var result = new Dictionary<string, object>();
                var expObj = obj as ExpandoObject;
                if (expObj != null)
                {
                    foreach (var pair in ((IDictionary<string, object>)expObj))
                    {
                        result[pair.Key] = pair.Value;
                    }
                }
                return result;
            }

            public override IEnumerable<Type> SupportedTypes
            {
                get
                {
                    return new[] { typeof(ExpandoObject) };
                }
            }
        }
    }

}
