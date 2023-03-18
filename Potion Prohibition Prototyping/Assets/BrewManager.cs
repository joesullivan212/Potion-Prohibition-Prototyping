using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewManager : MonoBehaviour
{
    [Header("Plugin Components")]
    //public TriggerCheck PotionContentsTriggerCheck;
    //public SpriteRenderer PotionContentsSprite;
    public PotionBottle CurrentPotionBottle;

    public bool IsBrewing = false;

    //public Color PotionColor;

    private PlayerInventory playerInventory;

    private void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerInventory>();
    }

    public void BrewFunction()
    {
        if (IsBrewing == false)
        {

            Invoke("ReloadingIsBrewing", 2.0f);

            IsBrewing = true;

            for (int i = 0; i < CurrentPotionBottle.PotionContentsTriggerCheck.EntitiesInTrigger.Count; i++)
            {
                CurrentPotionBottle.PotionColor = GameGod.CombineColor(CurrentPotionBottle.PotionColor, CurrentPotionBottle.PotionContentsTriggerCheck.EntitiesInTrigger[i].GetComponent<BrewingItem>().item.IngredientColor, CurrentPotionBottle.PotionContentsTriggerCheck.EntitiesInTrigger[i].GetComponent<BrewingItem>().item.PowerWeight, 1.0f);
            }

            Color TempColor = new Color(CurrentPotionBottle.PotionColor.r, CurrentPotionBottle.PotionColor.g, CurrentPotionBottle.PotionColor.b, 1.0f);

            CurrentPotionBottle.PotionContentSpriteRenderer.color = TempColor;

            //Remove items from inventory and in game
            for (int i = 0; i < CurrentPotionBottle.PotionContentsTriggerCheck.EntitiesInTrigger.Count; i++)
            {
                Destroy(CurrentPotionBottle.PotionContentsTriggerCheck.EntitiesInTrigger[i]);
                playerInventory.Items.RemoveAt(CurrentPotionBottle.PotionContentsTriggerCheck.EntitiesInTrigger[i].GetComponent<BrewingItem>().IndexInInventory);
               // playerInventory.Items.Remove(CurrentPotionBottle.PotionContentsTriggerCheck.EntitiesInTrigger[i].GetComponent<BrewingItem>().item);
            }

            CurrentPotionBottle.PotionContentsTriggerCheck.EntitiesInTrigger.Clear();
        }
    }

    public void ReloadingIsBrewing()
    {
        IsBrewing = false;
    }
}
