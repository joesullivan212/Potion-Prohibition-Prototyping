using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBottle : MonoBehaviour
{
    [Header("Variables")]
    public Color PotionColor;
    public Sprite[] LevelOfLiquidSprites;
    public int LevelOfLiquid = 4;

    [Header("Plugins")]
    public SpriteRenderer PotionContentSpriteRenderer;
    public SpriteRenderer ConstilationSpriteRenderer;
    public TriggerCheck PotionContentsTriggerCheck;

    


    [Header("Debug")]
    public float[] ClosenessToPotentialMatch;
    public int CloesestMatch;

    private PotentialPotionRepo potentialPotionRepo;

    private void Start()
    {
        potentialPotionRepo = GameObject.FindGameObjectWithTag("Data").GetComponent<PotentialPotionRepo>();
    }

    private void Update()
    {
        PotionContentSpriteRenderer.sprite = LevelOfLiquidSprites[LevelOfLiquid];

        float HighestNumber = 0;

        // Calculate all distances
        for (int i = 0; i < potentialPotionRepo.PotentialPotions.Length; i++)
        {
            ClosenessToPotentialMatch[i] = GameGod.DistanceBetweenTwoColors(potentialPotionRepo.PotentialPotions[i].PerfectColor, PotionColor);
            ClosenessToPotentialMatch[i] = GameGod.ExpressDistanceAsAPercentage(ClosenessToPotentialMatch[i]);

            if(ClosenessToPotentialMatch[i] > HighestNumber)
            {
                HighestNumber = ClosenessToPotentialMatch[i];
                CloesestMatch = i;
            }
        }

        ConstilationSpriteRenderer.sprite = potentialPotionRepo.PotentialPotions[CloesestMatch].Constilation;

        if (ClosenessToPotentialMatch[CloesestMatch] > 80.0f)
        {
            ConstilationSpriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, (ClosenessToPotentialMatch[CloesestMatch] - 65.0f) / 35.0f);
        }
    }

    public void Reset()
    {
        LevelOfLiquid = 4;
        PotionColor = Color.white;
    }
}
