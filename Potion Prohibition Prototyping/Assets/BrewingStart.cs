using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewingStart : MonoBehaviour
{
    private PlayerInventory PlayerInventory;

    public GameObject BrewingItemPrefab;
    public Transform[] PotentialSpawnPoints;

    // Start is called before the first frame update
    void Start()
    {

        PlayerInventory = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerInventory>();

        int i = 0;

        foreach (Item ThisBrewingItem in PlayerInventory.Items)
        {
            if (ThisBrewingItem != null)
            {
                GameObject ThisBrewingItemObj = Instantiate(BrewingItemPrefab, PotentialSpawnPoints[Random.Range(0, PotentialSpawnPoints.Length)]);
                BrewingItem ThisBrewingItemComponent = ThisBrewingItemObj.GetComponent<BrewingItem>();
                ThisBrewingItemComponent.item = ThisBrewingItem;
                ThisBrewingItemComponent.IndexInInventory = i;

                i++;
            }
        }
    }
}
