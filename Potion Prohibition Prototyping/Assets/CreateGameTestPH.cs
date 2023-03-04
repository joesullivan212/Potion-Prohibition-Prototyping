using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGameTestPH : MonoBehaviour
{
    public ColorCombiningTest colorCombiningTest;
    public CheckColorTest checkColorTest;
    public bool CombineUsingHSV;
    public bool CombineUsingRGB;

    [Header("Your Color !")]
    public Color YourColor;

    [Header("Color that is being mixed with yours")]
    public Color ColorYourMixing;

    [Header("Output")]
    public Color MixedColor;

    [Header("Target Color")]
    public Color TargetColor;

    [Header("Score")]
    public float Score;

    private void Start()
    {
        if(CombineUsingHSV)
        {
            //Generate Two Random Colors
            ColorHSV RandomColor1 = new ColorHSV(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
            ColorHSV RandomColor2 = new ColorHSV(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
            ColorHSV RandomMixedColorResult = GameGod.CombineColor(RandomColor1, RandomColor2);

            colorCombiningTest.Color1 = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            colorCombiningTest.Color2 = RandomColor2;
            checkColorTest.TargetColor = RandomMixedColorResult;
        }
        if (CombineUsingRGB)
        {
            Color RandomColor1 = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            Color RandomColor2 = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            Color RandomMixedColorResult = GameGod.CombineColor(RandomColor1, RandomColor2);

            colorCombiningTest.Color1 = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            colorCombiningTest.Color2 = RandomColor2;
            checkColorTest.TargetColor = RandomMixedColorResult;
        }

        

    }

    private void Update()
    {
        checkColorTest.ColorToCheck = colorCombiningTest.CombinedColor;

        colorCombiningTest.Color1 = YourColor;


        //Show Visuals
        TargetColor = checkColorTest.TargetColor;
        MixedColor = colorCombiningTest.CombinedColor;
        ColorYourMixing = colorCombiningTest.Color2;
        Score = checkColorTest.DistanceBetweenColors1;
    }
}
