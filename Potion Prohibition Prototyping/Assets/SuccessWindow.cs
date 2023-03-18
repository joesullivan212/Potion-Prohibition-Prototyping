using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SuccessWindow : MonoBehaviour
{
    public Image ItemImageComponent;
    public TextMeshProUGUI ItemNameComponent;

    public void FillInSuccessWindow(Item item)
    {
        ItemImageComponent.sprite = item.ItemImage;
        ItemImageComponent.color = item.IngredientColor;
        ItemNameComponent.text = item.ItemtName;
    }
}
