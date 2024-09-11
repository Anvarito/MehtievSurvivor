using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

public class InventorySaveLoader
{
    private string _saveFilePath;

    public InventorySaveLoader()
    {
        string saveDirectoryPath = Path.Combine(Application.persistentDataPath, "Save");

        if (!Directory.Exists(saveDirectoryPath))
        {
            Directory.CreateDirectory(saveDirectoryPath);
        }

        _saveFilePath = Path.Combine(saveDirectoryPath, "inventory.json");
    }

    public async Task SaveInventory(List<InventorySlot> slots)
    {
        var serializableSlots = new List<SerializableSlotsData>();
        foreach (var slot in slots)
        {
            serializableSlots.Add(slot.ToSerializable());
        }

        SerializationWrapper wrapper = new SerializationWrapper { Slots = serializableSlots };
        string json = JsonConvert.SerializeObject(wrapper, Formatting.Indented);
        Debug.Log("Saving inventory to: " + _saveFilePath);
        await File.WriteAllTextAsync(_saveFilePath, json);
    }

    public List<SerializableSlotsData> LoadInventory()
    {
        if (File.Exists(_saveFilePath))
        {
            string json = File.ReadAllText(_saveFilePath);
            SerializationWrapper wrapper = JsonConvert.DeserializeObject<SerializationWrapper>(json);
            Debug.Log("Load inventory from: " + _saveFilePath);
            return wrapper.Slots;
        }

        Debug.Log("Load EMPTY inventory from: " + _saveFilePath);
        return new List<SerializableSlotsData>();
    }
}

[Serializable]
public class SerializationWrapper
{
    public List<SerializableSlotsData> Slots;
}