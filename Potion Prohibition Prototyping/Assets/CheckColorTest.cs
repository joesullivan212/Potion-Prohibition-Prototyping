using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColorTest : MonoBehaviour
{
    public Color ColorToCheck;

    public Color TargetColor;

    public bool HSV;
    public bool RGB;

    private Vector3 DistanceBetweenColorsVec3;

    [Header("DistanceMesuringSystem")]
    public bool SubtractBiggestFromSmallest = false;
    public bool TryBothSubtractionsThenTakeSmaller = true;

    [Header("Weights")]
    public float HueWeight = 1.0f;
    public float SatWeight = 1.0f;
    public float ValWeight = 1.0f;

    [Header("RGB")]
    public float R;
    public float G;
    public float B;

    [Header("HSV")]
    public float H;
    public float S;
    public float V;

    [Header("Output")]
    public float DistanceBetweenColors1;
    public float DistanceBetweenColors2;
    public float PercentageMatch;

    private void Update()
    {
        if (RGB)
        {
            R = DistanceBetweenTwoNumbers(ColorToCheck.r, TargetColor.r);
            G = DistanceBetweenTwoNumbers(ColorToCheck.g, TargetColor.g);
            B = DistanceBetweenTwoNumbers(ColorToCheck.b, TargetColor.b);

            //Vector3 TempDistanceBetweenColorsVec3 = new Vector3(R, G, B);

            DistanceBetweenColorsVec3 = new Vector3(R, G, B);

            DistanceBetweenColors1 = DistanceBetweenColorsVec3.magnitude;
            DistanceBetweenColors2 = DistanceBetweenColorsVec3.x + DistanceBetweenColorsVec3.y + DistanceBetweenColorsVec3.z;
            PercentageMatch = GameGod.ExpressDistanceAsAPercentage(DistanceBetweenColors2);
        }
        if (HSV)
        {
            ColorHSV TempColor;
            ColorHSV TempTargetColor;

            TempColor = ColorToCheck.ToHSV();
            TempTargetColor = TargetColor.ToHSV();

            float TempColorDistanceToNearestHueMax = DistanceFromNearestMax(TempColor.h, 1.0f);
            float TempTargetColorDistanceToNearestHueMax = DistanceFromNearestMax(TempTargetColor.h, 1.0f);

            H = DistanceBetweenTwoNumbers(TempColorDistanceToNearestHueMax, TempTargetColorDistanceToNearestHueMax) * HueWeight;
            S = DistanceBetweenTwoNumbers(TempColor.s, TempTargetColor.s) * SatWeight;
            V = DistanceBetweenTwoNumbers(TempColor.v, TempTargetColor.v) * ValWeight;

            DistanceBetweenColorsVec3 = new Vector3(H, S, V);

            DistanceBetweenColors1 = DistanceBetweenColorsVec3.magnitude;
            DistanceBetweenColors2 = DistanceBetweenColorsVec3.x + DistanceBetweenColorsVec3.y + DistanceBetweenColorsVec3.z;
            PercentageMatch = GameGod.ExpressDistanceAsAPercentage(DistanceBetweenColors2);
        }
    }

    public float DistanceBetweenTwoNumbers(float Num1, float Num2)
    {
        Debug.Log("IsRunning2");
        if (TryBothSubtractionsThenTakeSmaller)
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

        if (SubtractBiggestFromSmallest) {
            float NewNum;
              if(Num1 > Num2)
              {
                  NewNum = Num1 - Num2;
                  Debug.Log(NewNum.ToString());
                  return NewNum;
              }
              else
              {
                  NewNum = Num2 - Num1;
                  Debug.Log(NewNum.ToString());
                  return NewNum;
              }
        }
        else
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
    }

    public float DistanceFromNearestMax (float Num, float Max)
    {
        float DistanceToMax;

        DistanceToMax = Max - Num;

        if(DistanceToMax < Num)
        {
            return DistanceToMax;
        }
        else
        {
            return Num;
        }
    }
}
