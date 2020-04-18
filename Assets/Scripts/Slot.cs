using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Make getters and setter for empty and item
    public bool empty;
    private bool hovered;

    public GameObject item;
    public Texture itemIcon;

    private GameObject player;

    private void Start()
    {
        empty = true;
        hovered = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (item)
        {
            empty = false;
            itemIcon = item.GetComponent<Item>().icon;
            this.GetComponent<RawImage>().texture = itemIcon;
        } else {
            empty = true;
            itemIcon = null;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(item)
        {
            Item thisItem = item.GetComponent<Item>();

            // Checking Item Type
            if (thisItem.type == "Water")
            {
                player.GetComponent<Player>().Drink(thisItem.decreaseRate);
                Destroy(item);
            }

            if (thisItem.type == "Level1")
            {
                player.GetComponent<Player>().Heal(10);
                Destroy(item);
                item.SetActive(false);
            }
        }
    }
}
