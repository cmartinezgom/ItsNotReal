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
    [SerializeField] private float lvFear = 100.0f;

    [Header("battery")]
    [SerializeField] private int battery = 4;
    [SerializeField] private int nRecharges = 0;

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
    }

    public int GetBattery()
    {
        return battery;
    }
    public void SetBattery(int battery)
    {
        this.battery = battery;
    }

    public int GetRecharges()
    {
        return nRecharges;
    }
    public void SetRecharges(int nRecharges)
    {
        this.nRecharges = nRecharges;
    }
    
    #endregion
}
