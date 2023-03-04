using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameGod
{
    public static Color CombineColor(Color Color1, Color Color2)
    {

        Color CombinedColor = new Color();
        CombinedColor.r = (Color1.r + Color2.r) / 2.0f;
        CombinedColor.g = (Color1.g + Color2.g) / 2.0f;
        CombinedColor.b = (Color1.b + Color2.b) / 2.0f;

        return CombinedColor;
    }

    public static ColorHSV CombineColor(ColorHSV Color1, ColorHSV Color2)
    {
        ColorHSV CombinedColor = new ColorHSV();
        //TempColor2 = Color2.ToHSV();

        CombinedColor.h = (Color1.h + Color2.h) / 2.0f;
        CombinedColor.s = (Color1.s + Color2.s) / 2.0f;
        CombinedColor.v = (Color1.v + Color2.v) / 2.0f;

        return CombinedColor;

    }

    public static float DistanceBetweenTwoColors(Color Color1, Color Color2)
    {
        float R = DistanceBetweenTwoNumbers(Color1.r, Color2.r);
        float G = DistanceBetweenTwoNumbers(Color1.g, Color2.g);
        float B = DistanceBetweenTwoNumbers(Color1.b, Color2.b);

        //Vector3 TempDistanceBetweenColorsVec3 = new Vector3(R, G, B);

        Vector3 DistanceBetweenColorsVec3 = new Vector3(R, G, B);

        return DistanceBetweenColorsVec3.magnitude;
    }

    public static float DistanceBetweenTwoColors(ColorHSV ColorToCheck, ColorHSV TargetColor, float HueWeight)
    {

        float TempColorDistanceToNearestHueMax = DistanceFromNearestMax(ColorToCheck.h, 1.0f);
        float TempTargetColorDistanceToNearestHueMax = DistanceFromNearestMax(TargetColor.h, 1.0f);

        float H = DistanceBetweenTwoNumbers(TempColorDistanceToNearestHueMax, TempTargetColorDistanceToNearestHueMax) * HueWeight;
        float S = DistanceBetweenTwoNumbers(ColorToCheck.s, TargetColor.s);
        float V = DistanceBetweenTwoNumbers(ColorToCheck.v, TargetColor.v);

        Vector3 DistanceBetweenColorsVec3 = new Vector3(H, S, V);

        return DistanceBetweenColorsVec3.x + DistanceBetweenColorsVec3.y + DistanceBetweenColorsVec3.z;
    }



    public static float DistanceBetweenTwoNumbers(float Num1, float Num2)
    {
            float NewResult1;
            float NewResult2;

            NewResult1 = Num1 - Num2;
            NewResult2 = Num2 - Num1;

            if (NewResult1 <= NewResult2)
            {
                return NewResult1;
            }
            else
            {
                return NewResult2;
            }
        
    }

    public static float DistanceFromNearestMax(float Num, float Max)
    {
        float DistanceToMax;

        DistanceToMax = Max - Num;

        if (DistanceToMax < Num)
        {
            return DistanceToMax;
        }
        else
        {
            return Num;
        }
    }

    public static float ExpressDistanceAsAPercentage(float distance)
    {
        float DistanceAsAPercent = 105.0f - (distance * 100.0f);

        if(DistanceAsAPercent > 100.0f)
        {
            DistanceAsAPercent = 100.0f;
        }
        if(DistanceAsAPercent < 0.0f)
        {
            DistanceAsAPercent = 0.0f;
        }

        return DistanceAsAPercent;
    }
}
