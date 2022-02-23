<<<<<<< Updated upstream
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
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelOfFearBar : MonoBehaviour
{
    public RectMask2D mask;
    public float maxValue;
    public Gradient gradient;
    public Image fill;

     public void SetInitialFear(float lvOfFear)
    {
        mask.padding = new Vector4(0f,0f,0f,maxValue);
        fill.color = gradient.Evaluate(maxValue);

        //slider.maxValue = lvOfFear;
        //slider.value = 0;

        //fill.color = gradient.Evaluate(0f);
    }

    public void SetFear(float lvOfFear)
    {
        float fear = maxValue-lvOfFear;
        mask.padding = new Vector4(0f,0f,0f,fear);
        fill.color = gradient.Evaluate(fear/maxValue);
        //slider.value = lvOfFear;
        //fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
>>>>>>> Stashed changes
