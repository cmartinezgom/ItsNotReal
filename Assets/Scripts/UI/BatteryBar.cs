using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBar : MonoBehaviour
{
    public RectMask2D mask;
    public float maxValue, maxBattery;
    public Gradient gradient;
    public Image fill;

    public GameObject emptyBattery1;
    public GameObject emptyBattery2;
    public GameObject fullBattery1;
    public GameObject fullBattery2;

    public void SetInitialBattery()
    {
        mask.padding = new Vector4(0f,0f,0f, 0f );
        fill.color = gradient.Evaluate(maxBattery);
    }

    public void SetBattery(int batteryLvl)
    {
        float battery = (batteryLvl*1.0f)/maxBattery;
        mask.padding = new Vector4(0f,0f,0f,maxValue-(maxValue*battery));
        fill.color = gradient.Evaluate(battery);
    }

    public void SetExtraBatteries(int extraBatteries)
    {
        switch (extraBatteries)
        {
            case 0:
                emptyBattery1.SetActive(true);
                fullBattery1.SetActive(false);
                emptyBattery2.SetActive(true);
                fullBattery2.SetActive(false);
                return;
            case 1:
                Debug.Log("AAAAAAAAAAAAA");
                emptyBattery1.SetActive(false);
                fullBattery1.SetActive(true);
                emptyBattery2.SetActive(true);
                fullBattery2.SetActive(false);
                return;
            case 2:
                emptyBattery1.SetActive(false);
                fullBattery1.SetActive(true);
                emptyBattery2.SetActive(false);
                fullBattery2.SetActive(true);
                return;
        }
    }
}