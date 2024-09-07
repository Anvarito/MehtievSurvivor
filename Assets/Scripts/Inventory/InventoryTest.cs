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
                Inventory.AddItem(_itemDatabase.GetItemConfigByType(EItemType.BookWisdom));
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Inventory.AddItem(_itemDatabase.GetItemConfigByType(EItemType.SpeedPotion));
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Inventory.AddItem(_itemDatabase.GetItemConfigByType(EItemType.HammerOfPower));
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Inventory.AddItem(_itemDatabase.GetItemConfigByType(EItemType.HealPotion));
            }
        }

       
    }
