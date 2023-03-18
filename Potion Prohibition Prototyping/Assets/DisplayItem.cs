using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayItem : MonoBehaviour
{
    public Item item;

    public Image ItemImage;
    public TextMeshProUGUI NameText;

  //  private void Start()
  //  {
  //      ItemImage.sprite = item.ItemImage;
  //      ItemImage.color = item.IngredientColor;
  //      NameText.text = item.ItemtName;
  //  }

    public void FillItemDisplay(Item item)
    {
        ItemImage.sprite = item.ItemImage;
        ItemImage.color = item.IngredientColor;
        NameText.text = item.ItemtName;
    }
}
