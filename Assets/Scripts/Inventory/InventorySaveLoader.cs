using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InventorySaveLoader
{
    private string _saveFilePath;
    
    public InventorySaveLoader()
    {
        _saveFilePath = Path.Combine(Application.persistentDataPath, "inventory.json");
    }
    
    public void SaveInventory(List<InventorySlot> list)
    {
        string json = JsonUtility.ToJson(list, true);
        Debug.Log("Saving Inventory: " + json);
        File.WriteAllText(_saveFilePath, json);
    }
    
    public List<InventorySlot> LoadInventory()
    {
        if (File.Exists(_saveFilePath))
        {
            string json = File.ReadAllText(_saveFilePath);
            Debug.Log("Loading Inventory: " + json);
            return JsonUtility.FromJson<List<InventorySlot>>(json);
        }
        else
        {
            Debug.LogWarning("Save file not found!");
        }

        return new List<InventorySlot>();
    }
}
