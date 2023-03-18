using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewingItem : MonoBehaviour
{
    public Item item;

    public SpriteRenderer spriteRenderer;

    public int IndexInInventory;

    private void Update()
    {
        spriteRenderer.sprite = item.ItemImage;
        spriteRenderer.color = item.IngredientColor;
    }
}
