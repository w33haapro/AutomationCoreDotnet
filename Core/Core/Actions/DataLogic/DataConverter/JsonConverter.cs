using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;


/// <summary>
/// JSON Serialization and Deserialization Assistant Class
/// </summary>
public static class JsonConverter
{
    /// <summary>
    /// JSON Serialization
    /// </summary>
    public static string ToJson<T>(this T t)
    {
        var result = JsonConvert.SerializeObject(t);
        return result;
    }

    /// <summary>
    /// JSON Deserialization
    /// </summary>
    public static T ToObject<T>(this string jsonString)
    {
        var result = JsonConvert.DeserializeObject<T>(jsonString);
        return result;
    }


    /// <summary>
    /// JSON Deserialization to list object
    /// </summary>
    public static List<T> ToListObject<T>(this string jsonString)
    {
        List<T> result = JsonConvert.DeserializeObject<List<T>>(jsonString);

        return result;
    }

    /// <summary>
    /// JSON Serialization list object
    /// </summary>
    public static string ToJson<T>(this List<T> listObject)
    {
        var result = JsonConvert.SerializeObject(listObject, Formatting.Indented);
        return result;
    }

    /// <summary>
    /// This function get json object value by path
    /// </summary>
    public static string JsonObjectGetJValue(this string jsonString, string path)
    {
        var jObject = JObject.Parse(jsonString);
        var result = jObject.SelectToken(path).ToString();

        return result;
    }

    /// <summary>
    /// This function get json array value by path
    /// </summary>
    public static string JsonArrayGetJValue(this string jsonString, string path)
    {
        var jArray = JArray.Parse(jsonString);
        var result = jArray.SelectToken(path).ToString();

        return result;
    }
}

