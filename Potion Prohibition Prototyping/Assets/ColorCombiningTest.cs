using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class ColorCombiningTest : MonoBehaviour
{
    [Header("Test")]
    public Color Color1;
    public Color Color2;

    public Color CombinedColor;

    [Header("Variables")]
    public bool HSV;
    public bool RGBA;

    public void Update()
    {
        CombineColor();
    }

    public void CombineColor()
    {
        if (RGBA)
        {
            CombinedColor.r = (Color1.r + Color2.r) / 2.0f;
            CombinedColor.g = (Color1.g + Color2.g) / 2.0f;
            CombinedColor.b = (Color1.b + Color2.b) / 2.0f;
        }
        if (HSV)
        {
            ColorHSV TempColor1;
            ColorHSV TempColor2;
            ColorHSV TempNewCombinedColor = new ColorHSV();

            TempColor1 = Color1.ToHSV();
            TempColor2 = Color2.ToHSV();

            TempNewCombinedColor.h = (TempColor1.h + TempColor2.h) / 2.0f;
            TempNewCombinedColor.s = (TempColor1.s + TempColor2.s) / 2.0f;
            TempNewCombinedColor.v = (TempColor1.v + TempColor2.v) / 2.0f;

            CombinedColor = TempNewCombinedColor.ToRGB();
        }
    }

    
}
