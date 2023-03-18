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

            Debug.Log("Comining color");

            for (int i = 0; i < CurrentPotionBottle.PotionContentsTriggerCheck.EntitiesInTrigger.Count; i++)
            {
                CurrentPotionBottle.PotionColor = GameGod.CombineColor(CurrentPotionBottle.PotionColor, 
                CurrentPotionBottle.PotionContentsTriggerCheck.EntitiesInTrigger[i].GetComponent<BrewingItem>().item.IngredientColor, 
                CurrentPotionBottle.PotionContentsTriggerCheck.EntitiesInTrigger[i].GetComponent<BrewingItem>().item.PowerWeight, 
                //Remove Weight from the potions current liquid if its lower
                1.0f - ((CurrentPotionBottle.LevelOfLiquid - 4.0f) * 0.25f));
            }

            Color TempColor = new Color(CurrentPotionBottle.PotionColor.r, CurrentPotionBottle.PotionColor.g, CurrentPotionBottle.PotionColor.b, 1.0f);

            CurrentPotionBottle.PotionContentSpriteRenderer.color = TempColor;

           // for(int i = CurrentPotionBottle.PotionContentsTriggerCheck.EntitiesInTrigger.Count; i <= 0; i--)
           // {
           //     Destroy(CurrentPotionBottle.PotionContentsTriggerCheck.EntitiesInTrigger[i]);
           // }
          //  for (int i = 0; i < CurrentPotionBottle.PotionContentsTriggerCheck.EntitiesInTrigger.Count; i++)
          //  {
          //         Destroy(CurrentPotionBottle.PotionContentsTriggerCheck.EntitiesInTrigger[i]);
          //  }

            GameObject[] ObjectsInTrigger;
            ObjectsInTrigger = CurrentPotionBottle.PotionContentsTriggerCheck.EntitiesInTrigger.ToArray();
            
            foreach (GameObject BrewingItem in ObjectsInTrigger)
            {
                Destroy(BrewingItem);
            }

            CurrentPotionBottle.PotionContentsTriggerCheck.EntitiesInTrigger.Clear();
        }
    }

    public void ReloadingIsBrewing()
    {
        IsBrewing = false;
    }
}
