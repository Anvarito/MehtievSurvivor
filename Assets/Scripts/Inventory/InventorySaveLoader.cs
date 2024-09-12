using System;
using System.Collections.Generic;
using Infrastructure;

public class InventorySaveLoader
{
    private readonly SaveLoadService _saveLoadService;
    private readonly string _saveFilePath = "Save/inventory.json";

    public InventorySaveLoader(SaveLoadService saveLoadService)
    {
        _saveLoadService = saveLoadService;
    }

    public void Save(List<InventorySlot> slots)
    {
        _saveLoadService.Save(CreateSerializationWrapper(slots), _saveFilePath);
    }

    public List<SerializableSlotsData> Load()
    {
        SerializationWrapper wrapper = _saveLoadService.Load<SerializationWrapper>(_saveFilePath);
        
        if (wrapper.Slots == null)
            return new List<SerializableSlotsData>();

        return wrapper.Slots;
    }
    
    private static SerializationWrapper CreateSerializationWrapper(List<InventorySlot> slots)
    {
        var serializableSlots = new List<SerializableSlotsData>();
        foreach (var slot in slots)
        {
            serializableSlots.Add(slot.ToSerializable());
        }

        SerializationWrapper wrapper = new SerializationWrapper { Slots = serializableSlots };
        return wrapper;
    }
}

[Serializable]
public class SerializationWrapper
{
    public List<SerializableSlotsData> Slots;
}