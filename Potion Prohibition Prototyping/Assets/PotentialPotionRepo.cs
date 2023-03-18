using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PotentialPotions
{
    public Color PerfectColor;
    public Sprite Constilation;
    public string PotionTypeName;
}

[System.Serializable]
public class PotentialPotionRepo : MonoBehaviour
{
    public PotentialPotions[] PotentialPotions;
}
