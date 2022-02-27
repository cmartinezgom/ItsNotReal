using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public string musicName;


    void Start()
    {
        Invoke("SetMusic", 0.01f);
    }

    void SetMusic()
    {
        FindObjectOfType<AudioManager>().Transition(musicName);
    }
}
