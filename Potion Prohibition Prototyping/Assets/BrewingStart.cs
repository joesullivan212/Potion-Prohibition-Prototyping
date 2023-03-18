using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewingStart : MonoBehaviour
{
    private PlayerInventory PlayerInventory;

    public GameObject BrewingItemPrefab;
    public Transform[] PotentialSpawnPoints;

    public List<GameObject> inventoryBrewingItemsCurrentlyInPlay = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

        PlayerInventory = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerInventory>();

        

        foreach (Item ThisBrewingItem in PlayerInventory.Items)
        {
            if (ThisBrewingItem != null)
            {
                GameObject ThisBrewingItemObj = Instantiate(BrewingItemPrefab, PotentialSpawnPoints[Random.Range(0, PotentialSpawnPoints.Length)]);
                ThisBrewingItemObj.transform.parent = null;
                BrewingItem ThisBrewingItemComponent = ThisBrewingItemObj.GetComponent<BrewingItem>();
                ThisBrewingItemComponent.item = ThisBrewingItem;
                inventoryBrewingItemsCurrentlyInPlay.Add(ThisBrewingItemObj);
            }
        }

        PlayerInventory.Items.Clear();
    }
}
