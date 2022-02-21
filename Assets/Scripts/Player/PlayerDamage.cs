using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{

    PlayerStats stats = null;
    float fearCounter;
    float lvFear;

    public Text t;
    public GameObject EventSystem;

    void Start()
    {
        stats = GetComponent<PlayerStats>();
        lvFear = stats.GetLvFear();     // Cogemos el nivel de miedo del script PlayerStats
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))        // De momento lo he puesto al pulsar una tecla para probar su funcionamiento, pero esto se debe cambiar a cuando reciba danio de un enemigo
        {
            fearCounter++;       // Tal y como lo he programado de momento, es una vida que decrece, pero imagino que deberia ser un contrario, como un contador de estres que al llegar a cierto punto colapse
        }

        t.text = fearCounter.ToString() + "/" + lvFear.ToString();

        if (fearCounter >= lvFear)
        {
            EventSystem.GetComponent<SceneLoader>().GameOver();
            //loadear la escena de GameOver, que ya hay suenio
        }

    }

}
