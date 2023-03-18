using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosenessMeter : MonoBehaviour
{
    public int Index;
    public Gradient gradient;
    public BrewManager brewManager;
    public Image image;

    private void Update()
    {
        image.color = gradient.Evaluate(brewManager.CurrentPotionBottle.ClosenessToPotentialMatch[Index] / 100.0f);
    }

}
