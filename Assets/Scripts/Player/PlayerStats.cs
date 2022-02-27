using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float speed = 4.0f;        // SerializeField para que sea visible desde el editor de Unity pese a ser una variable privada
    [SerializeField] private float sprint = 7.0f;

    [Header("Attack")]
    [SerializeField] private float attack = 10.0f;

    [Header("LoF")]
    [SerializeField] private float lvFear = 0.0f;
    [SerializeField] private float maxLvFear = 870.0f;

    [Header("battery")]
    [SerializeField] private int battery = 4;
    [SerializeField] private int nRecharges = 0;
    [SerializeField] private bool isRunningDown = false;

    public GameObject batteryObj;
    public GameObject lvlOfFearBar;

// Declaro los GETs y los SETs para que las variables sean accesibles desde otras funciones
    #region GETTERS Y SETTERS

    public float GetSpeed()
    {
        return speed;
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public float GetSprint()
    {
        return sprint;
    }
    public void SetSprint(float speed)
    {
        this.sprint = speed;
    }

    public float GetAttack()
    {
        return attack;
    }
    public void SetAttack(float attack)
    {
        this.attack = attack;
    }

    public float GetLvFear()
    {
        return lvFear;
    }
    public void SetLvFear(float lvFear)
    {
        this.lvFear = lvFear;
        var lofHUD = lvlOfFearBar.GetComponent<LevelOfFearBar>();
        lofHUD.SetFear(lvFear, maxLvFear);
    }

    public float GetMaxLvFear()
    {
        return maxLvFear;
    }
    public void SetMaxLvFear(float maxLvFear)
    {
        this.maxLvFear = maxLvFear;
        var lofHUD = lvlOfFearBar.GetComponent<LevelOfFearBar>();
        lofHUD.SetInitialFear(maxLvFear);
    }

    public int GetBattery()
    {
        return battery;
    }
    public void SetBattery(int battery)
    {
        this.battery = battery;
        var batteryHUD = batteryObj.GetComponent<BatteryBar>();
        batteryHUD.SetBattery(battery);
    }

    public int GetRecharges()
    {
        return nRecharges;
    }
    public void SetRecharges(int nRecharges)
    {
        this.nRecharges = nRecharges;
        var batteryHUD = batteryObj.GetComponent<BatteryBar>();
        batteryHUD.SetExtraBatteries(nRecharges);
    }

    public bool GetIsRunningDown()
    {
        return isRunningDown;
    }
    public void SetIsRunningDown(bool isRunningDown)
    {
        this.isRunningDown = isRunningDown;
    }
    
    #endregion
}
