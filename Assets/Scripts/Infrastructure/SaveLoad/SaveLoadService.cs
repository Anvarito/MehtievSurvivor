using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using Object = System.Object;

public class SaveLoadService
{
    private ISerializer _serializer;

    public SaveLoadService(ISerializer serializer)
    {
        _serializer = serializer;
    }

    public async Task Save(Object obj, string path)
    {
        string json = _serializer.Serialize(obj);
        Debug.Log("Saving to: " + path);
        await File.WriteAllTextAsync(path, json);
    }

    public async Task<T> Load<T>(string path) where T : new()
    {
        if (File.Exists(path))
        {
            string json = await Task.Run(() => File.ReadAllText(path));
            T result = _serializer.Deserialize<T>(json);
            Debug.Log("Load from: " + path);
            return result;
        }

        Debug.Log("File empty! load default");
        return new T();
    }
}