using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelOfFearBar : MonoBehaviour
{
    public Slider slider;

     public void SetInitialFear(float lvOfFear)
    {
        slider.maxValue = lvOfFear;
        slider.value = 0;
    }

    public void SetFear(float lvOfFear)
    {
        slider.value = lvOfFear;
    }
}
