using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class InventorySaveLoader
{
    private readonly SaveLoadService _saveLoadService;
    private string _saveFilePath;

    public InventorySaveLoader(SaveLoadService saveLoadService)
    {
        _saveLoadService = saveLoadService;

        string saveDirectoryPath = Path.Combine(Application.persistentDataPath, "Save");

        if (!Directory.Exists(saveDirectoryPath))
            Directory.CreateDirectory(saveDirectoryPath);

        _saveFilePath = Path.Combine(saveDirectoryPath, "inventory.json");
    }

    public async Task Save(List<InventorySlot> slots)
    {
        var serializableSlots = new List<SerializableSlotsData>();
        foreach (var slot in slots)
        {
            serializableSlots.Add(slot.ToSerializable());
        }

        SerializationWrapper wrapper = new SerializationWrapper { Slots = serializableSlots };
        await _saveLoadService.Save(wrapper, _saveFilePath);
    }

    public async Task<List<SerializableSlotsData>> Load()
    {
        SerializationWrapper wrapper = await _saveLoadService.Load<SerializationWrapper>(_saveFilePath);
        if (wrapper.Slots != null)
            return wrapper.Slots;

        return new List<SerializableSlotsData>();
    }

    public void SaveSynchronously(List<InventorySlot> slots)
    {
        var serializableSlots = new List<SerializableSlotsData>();
        foreach (var slot in slots)
        {
            serializableSlots.Add(slot.ToSerializable());
        }

        SerializationWrapper wrapper = new SerializationWrapper { Slots = serializableSlots };
        _saveLoadService.SaveSync(wrapper, _saveFilePath);
    }
}

[Serializable]
public class SerializationWrapper
{
    public List<SerializableSlotsData> Slots;
}