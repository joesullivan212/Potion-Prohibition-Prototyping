using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemChancePair
{
    public Item item;
    public float PercentageChanceToBeFoundThisLevel;
}

[System.Serializable]
public class GatherableItemsPerLevel
{
    public ItemChancePair[] itemChancePairs;
}

public class GatheringRepo : MonoBehaviour
{
    public GatherableItemsPerLevel[] gatherableIngredientsPerLevel;
}
