using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePotion : MonoBehaviour
{
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
        YeildPotionWindowObj.SetActive(true);
        yeildPotionWindow.PotionDescriptionText.text = potentialPotionRepo.PotentialPotions[brewManager.CurrentPotionBottle.CloesestMatch].PotionTypeName;
        yeildPotionWindow.PotionPurityText.text = brewManager.CurrentPotionBottle.ClosenessToPotentialMatch[brewManager.CurrentPotionBottle.CloesestMatch].ToString() + "% Purity";

        brewManager.CurrentPotionBottle.PotionColor = Color.white;
    }
}
