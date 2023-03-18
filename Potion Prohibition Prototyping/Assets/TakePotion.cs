using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePotion : MonoBehaviour
{
    public int AmountOfPotionToTake = 4;
    public string SizeAdjective;
    public GameObject YeildPotionWindowObj;
    public YeildPotionWindow yeildPotionWindow;
    public BrewManager brewManager;

    private PotentialPotionRepo potentialPotionRepo;

    private void Start()
    {
        potentialPotionRepo = GameObject.FindGameObjectWithTag("Data").GetComponent<PotentialPotionRepo>();
    }

    public void TakePotionFunc()
    {
        if(brewManager.CurrentPotionBottle.LevelOfLiquid >= AmountOfPotionToTake)
        {
            //Enough potion! Take it
            brewManager.CurrentPotionBottle.LevelOfLiquid -= AmountOfPotionToTake;
            YeildPotionWindowObj.SetActive(true);
            yeildPotionWindow.PotionDescriptionText.text = SizeAdjective + " " + potentialPotionRepo.PotentialPotions[brewManager.CurrentPotionBottle.CloesestMatch].PotionTypeName;
            yeildPotionWindow.PotionPurityText.text = brewManager.CurrentPotionBottle.ClosenessToPotentialMatch[brewManager.CurrentPotionBottle.CloesestMatch].ToString() + "% Purity";

            brewManager.CurrentPotionBottle.PotionColor = Color.white;
        }
        else
        {
            //Not enough potion to take
            Debug.Log("Not enough potion!");
        }

        if(brewManager.CurrentPotionBottle.LevelOfLiquid <= 0)
        {
            brewManager.CurrentPotionBottle.Reset();
        }
    }
}
