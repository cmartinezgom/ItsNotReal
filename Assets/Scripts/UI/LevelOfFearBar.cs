using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelOfFearBar : MonoBehaviour
{
    public RectMask2D mask;
    public Gradient gradient;
    public Image fill;

     public void SetInitialFear(float lvOfFear)
    {
        mask.padding = new Vector4(0f,0f,0f,lvOfFear);
        fill.color = gradient.Evaluate(lvOfFear);
    }

    public void SetFear(float lvOfFear, float maxValue)
    {
        float fear = maxValue-lvOfFear;
        mask.padding = new Vector4(0f,0f,0f,fear);
        fill.color = gradient.Evaluate(fear/maxValue);
    }
}
