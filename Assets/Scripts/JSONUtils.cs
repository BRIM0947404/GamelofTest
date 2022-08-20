using Newtonsoft.Json;
using UnityEngine;

public class JSONUtils : MonoBehaviour
{
    public static T ReadJSONFile<T>(TextAsset file)
    {
        return JsonConvert.DeserializeObject<T>(file.text);
    }
}
