using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Newtonsoft.Json;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace ExpenseTracker.Models
{
    public static class SessionExtensions
    {
       // public static object JsonConvert { get; private set; }
        public static double? GetDouble(this ISession session, string key)
        {
            var data = session.Get(key);
            if (data == null)
            {
                return null;
            }
            return BitConverter.ToDouble(data, 0);
        }

        public static void SetDouble(this ISession session, string key, double value)
        {
            session.Set(key, BitConverter.GetBytes(value));
        }
        public static T GetComplexData<T>(this ISession session, string key)
        {
            var data = session.GetString(key);
            if (data == null)
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(data);
        }
        public static void SetComplexData(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
    }
}