using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowYeild : MonoBehaviour
{
    public GameObject DisplayItemPrefab;
    public Transform GridParent;

    private GatheringManager gatheringManager;

    private void Start()
    {
        gatheringManager = GameObject.FindGameObjectWithTag("GatheringManager").GetComponent<GatheringManager>();    

        foreach(Item item in gatheringManager.NewYeild)
        {
            GameObject ThisDisplayItemGameObject = Instantiate(DisplayItemPrefab, GridParent);
            DisplayItem DisplayItemComponent = ThisDisplayItemGameObject.GetComponent<DisplayItem>();
            DisplayItemComponent.item = item;
            DisplayItemComponent.FillItemDisplay(item);
        }
    }
}
