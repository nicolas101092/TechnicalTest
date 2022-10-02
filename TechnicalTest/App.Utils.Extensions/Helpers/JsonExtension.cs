using Newtonsoft.Json;
using System.Text.Json;

namespace App.Utils.Extensions.Helpers
{
    public static class JsonExtension
    {
        /// <summary>
        /// Process object Json without nulls of object.
        /// </summary>
        /// <typeparam name="TEntity">TEntity param type</typeparam>
        /// <param name="jsonSerialize">TEntity object type</param>
        /// <returns>String object type</returns>
        public static string SerializeObjectWithoutNulls<TEntity>(TEntity jsonSerialize)
            where TEntity : class
                => JsonConvert.SerializeObject(jsonSerialize,
                                                Formatting.None,
                                                new JsonSerializerSettings
                                                {
                                                    NullValueHandling = NullValueHandling.Ignore
                                                });

        public static T? DeserializeInsensitive<T>(string data) where T : class
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(data, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
