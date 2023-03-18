using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewEnding : MonoBehaviour
{
    public BrewingStart brewingStart;
    private PlayerInventory playerInventory;

    private void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerInventory>();
    }
    public void RefillPlayerInventory()
    {
        foreach (GameObject BrewingItem in brewingStart.inventoryBrewingItemsCurrentlyInPlay) 
        {
            if (BrewingItem != null)
            {
                playerInventory.Items.Add(BrewingItem.GetComponent<BrewingItem>().item);
            }
        }
    }
}
