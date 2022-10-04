using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Logic for the inventory system. Held as a reference on the player.
*/

[System.Serializable]
public class Inventory
{
    public List<Slot> slots = new List<Slot>();
    private readonly int itemInventorySize = 5;
    private readonly int keyItemInventorySize = 3;
    public int totalInventorySize;
    public int size;

    // initializes a new inventory object.
    public Inventory() {
        size = 0;
        totalInventorySize = itemInventorySize + keyItemInventorySize;
        for (int i = 0; i < totalInventorySize; i++) {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    /*
        Adds an item to the inventory. The item is added to the first five slots if
        it is not classified as a key item. If it is, it is added to one of the last three slots.
    */

    public void Add(Pickup_Item item) {
        size++;
        if (item.itemType != CollectableType.KEY_ITEM) {
            for (int i = 0; i < itemInventorySize; i++) {
                if (slots[i].itemType == CollectableType.NONE) {
                    slots[i].AddItem(item);
                    return;
                }
            }
        } else {
            for (int i = itemInventorySize; i < itemInventorySize + keyItemInventorySize; i++) {
                if (slots[i].itemType == CollectableType.NONE) {
                    slots[i].AddItem(item);
                    return;
                }
            }
        }
    }

    /*
        Takes in a string as an argument, and compares it to each inventory object's itemName field.
        If the string matches an object's itemName field, set that item to a new empty slot to "remove"
        it from the inventory. Then, call Reorder() and return true.

        If it doesn't find an item with a matching itemName, return false.
    */

    public bool TryRemove(string toRemove) {
        for (int i = 0; i < totalInventorySize; i++) {
            if (string.Compare(slots[i].itemName, toRemove) == 0) {
                slots[i] = new Slot();
                Reorder();
                return true;
            }
        }
        return false;
    }

    // Reorders the inventory to make sure that there aren't any empty gaps in inventory objects.
    public void Reorder() {
        for (int i = 1; i < itemInventorySize; i++) {
            if (slots[i - 1].itemType == CollectableType.NONE) {
                slots[i - 1] = slots[i];
                slots[i] = new Slot();
            }
        }
    }

   /*
        Item type held by the inventory. Holds information on item type, item name, and sprite.
    */

    [System.Serializable]
    public class Slot {
        public CollectableType itemType;
        public string itemName;
        public Sprite icon;

        public Slot() {
            itemType = CollectableType.NONE;
            itemName = "none";
        }

        public void AddItem(Pickup_Item item) {
            this.itemType = item.itemType;
            this.itemName = item.itemName;
            this.icon = item.icon;
        }
    }
}
