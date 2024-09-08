using System;
using Items;
using UnityEngine;
using Zenject;

public class InventoryTest : MonoBehaviour
    {
        public Inventory Inventory;
        
        private ItemDatabase _itemDatabase;

        [Inject]
        private void Construct(ItemDatabase itemDatabase)
        {
            _itemDatabase = itemDatabase;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Inventory.AddItem(_itemDatabase.GetItemConfigByType(EItemType.Wisdom));
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Inventory.AddItem(_itemDatabase.GetItemConfigByType(EItemType.Speed));
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Inventory.AddItem(_itemDatabase.GetItemConfigByType(EItemType.Strength));
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Inventory.AddItem(_itemDatabase.GetItemConfigByType(EItemType.Heal));
            }
        }

       
    }
