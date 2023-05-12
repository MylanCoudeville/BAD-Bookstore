using System.Text.Json;
namespace BookStore.Data
{
    public static class SessionHelper
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var val = session.GetString(key);
            return val == null ? default(T) : JsonSerializer.Deserialize<T>(val);
        }
    }
}
