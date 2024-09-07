using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class InventorySaveLoader
{
    private string _saveFilePath;
    
    public InventorySaveLoader()
    {
        _saveFilePath = Path.Combine(Application.persistentDataPath, "inventory.json");
    }
    
    public void SaveInventory(List<InventorySlot> slots)
    {
        var serializableSlots = new List<SerializableSlotsData>();
        foreach (var slot in slots)
        {
            serializableSlots.Add(slot.ToSerializable());
        }

        SerializationWrapper wrapper = new SerializationWrapper { Slots = serializableSlots };
        string json = JsonConvert.SerializeObject(wrapper, Formatting.Indented);
        Debug.Log("Saving Inventory: " + json);
        File.WriteAllText(_saveFilePath, json);
    }

    public List<SerializableSlotsData> LoadInventory()
    {
        if (File.Exists(_saveFilePath))
        {
            string json = File.ReadAllText(_saveFilePath);
            SerializationWrapper wrapper = JsonConvert.DeserializeObject<SerializationWrapper>(json);
            return wrapper.Slots;
        }

        return new List<SerializableSlotsData>();
    }
}

[Serializable]
public class SerializationWrapper
{
    public List<SerializableSlotsData> Slots;
}
