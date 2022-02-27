using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressTracker : MonoBehaviour
{
    [Header("0 llaves")]
    public GameObject lana0;
    public GameObject mark0;
    [Header("2 llaves")]
    public GameObject lana2;
    public GameObject mark2;
    [Header("4 llaves")]
    public GameObject lana4;
    public GameObject bloqueo;
    public Text keyCount;


    void Update()
    {
        int keys = int.Parse(keyCount.text);

        if (keys < 2)
        {
            lana0.SetActive(true);
            mark0.SetActive(true);
            lana2.SetActive(false);
            mark2.SetActive(false);
            lana4.SetActive(false);
        }else if (keys < 4)
        {
            lana0.SetActive(false);
            mark0.SetActive(false);
            lana2.SetActive(true);
            mark2.SetActive(true);
            lana4.SetActive(false);
        }
        else if (keys < 6)
        {
            bloqueo.SetActive(false);
            lana0.SetActive(false);
            mark0.SetActive(false);
            lana2.SetActive(false);
            mark2.SetActive(false);
            lana4.SetActive(true);
        }
        else
        {
            lana0.SetActive(false);
            mark0.SetActive(false);
            lana2.SetActive(false);
            mark2.SetActive(false);
            lana4.SetActive(false);
        }
    }
}
