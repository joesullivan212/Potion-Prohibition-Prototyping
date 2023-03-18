using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GatheringChoiceButton : MonoBehaviour
{
    [Header("Variables")]
    public float PercentageOffsetToHelpThePlayer = 10.0f;

    [Header("Item Assigned")]
    public Item item;

    [Header("Risk Level Assigned")]
    public float RiskPercentage;

    [Header("Plugin Componets")]
    public Image ItemImage;
    public TextMeshProUGUI ItemNameText;
    public TextMeshProUGUI RiskLevelText;

    private GatheringManager gatheringManager;
    private PlayerInventory playerInventory;

    private void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerInventory>();
        gatheringManager = GameObject.FindGameObjectWithTag("GatheringManager").GetComponent<GatheringManager>();
        FillChoiceButtonUIInfo();
    }

    public void FillChoiceButtonUIInfo()
    {

        ItemImage.sprite = item.ItemImage;

        if (item.IsIngredient)
        {
            ItemImage.color = item.IngredientColor;
        }
        if (item.IsPotion)
        {
            ItemImage.color = item.PotionColor;
        }
        if (item.IsCrystal)
        {
            ItemImage.color = item.CrystalColor;
        }

        ItemNameText.text = item.ItemtName;

        RiskLevelText.text = RiskPercentage.ToString() + "%";
    }

    public void Chosen()
    {
        //Decide if suceesfully chosen
        float RNG = Random.Range(0.0f, 100.0f) + PercentageOffsetToHelpThePlayer;

        if(RNG < RiskPercentage)
        {
            gatheringManager.FailureWindow.SetActive(true);
        }
        else
        {
            gatheringManager.SuccessWindowObj.SetActive(true);
            gatheringManager.sucessWindow.FillInSuccessWindow(item);

            playerInventory.Items.Add(item);
            gatheringManager.NewYeild.Add(item);
        }
    }
}
