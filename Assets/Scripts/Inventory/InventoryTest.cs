using System;
using Items;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class InventoryTest : MonoBehaviour
    {
        public Inventory _inventory;
        
        private ItemDatabase _itemDatabase;

        [Inject]
        private void Construct(ItemDatabase itemDatabase, Inventory inventory)
        {
            _itemDatabase = itemDatabase;
            _inventory = inventory;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _inventory.AddItem(_itemDatabase.GetItemConfigByType(EItemType.Wisdom));
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _inventory.AddItem(_itemDatabase.GetItemConfigByType(EItemType.Speed));
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _inventory.AddItem(_itemDatabase.GetItemConfigByType(EItemType.Strength));
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                _inventory.AddItem(_itemDatabase.GetItemConfigByType(EItemType.Heal));
            }
        }

       
    }
