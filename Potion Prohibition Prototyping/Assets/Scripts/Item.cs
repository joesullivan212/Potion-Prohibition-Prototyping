using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 0)]
public class Item : ScriptableObject
{
    public string ItemtName;
    public Sprite ItemImage;

    public bool IsIngredient;
    public bool IsPotion;
    public bool IsCrystal;

    [Header("Ingredient Variables")]
    public Color IngredientColor;
    public float PowerWeight;
    public float RiskModifier;

    [Header("Potion Variables")]
    public Color PotionColor;
    public List<Item> IngredientsThatCreatedIt = new List<Item>();
    public float Purity;

    [Header("Crystal Variables")]
    public Color CrystalColor;
}
