using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    public GameObject slotHolder;
    public GameObject itemManager;
    private bool inventoryEnabled;

    private int slots;
    private Transform[] slot;
    public int itemsPickedUp = 0;

    private GameObject itemPickedUp;
    private bool itemAdded;

    private void Start()
    {
        // Slots being detected
        slots = slotHolder.transform.childCount;
        //print(slots);
        slot = new Transform[slots];
        itemAdded = false;
        DetectInventorySlots();
    }

    private void DetectInventorySlots()
    {
        for (int i = 0; i < slots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i);
            //print(slot[i].name);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventoryEnabled = !inventoryEnabled;
        }

        if (inventoryEnabled)
            inventory.SetActive(true);
        else
            inventory.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            print("Item");
            itemPickedUp = other.gameObject;
            print(itemPickedUp.name);
            AddItem(itemPickedUp);
            itemsPickedUp++;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Item")
        {
            itemAdded = false;
        }
    }

    public void AddItem(GameObject item)
    {
        for (int i = 0; i < slots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty && !itemAdded)
            {
                print("Item added");
                slot[i].GetComponent<Slot>().item = itemPickedUp;
                slot[i].GetComponent<Slot>().itemIcon = itemPickedUp.GetComponent<Item>().icon;
                item.transform.parent = itemManager.transform;
                item.transform.position = itemManager.transform.position;
                if (item.GetComponent<MeshRenderer>())
                    item.GetComponent<MeshRenderer>().enabled = false;
                item.SetActive(false);
                Destroy(item.GetComponent<Rigidbody>());
                itemAdded = true;
            }
        }
    }
}
