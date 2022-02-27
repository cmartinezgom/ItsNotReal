using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        var sceneName = SceneManager.GetActiveScene().name;

        if (sceneName.Contains("Intro"))
        {
            Play("Menu");
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) return;
        s.source.Play();
    }

    public void Transition(string oldMusic, string newMusic)
    {
        Sound oldM = Array.Find(sounds, sound => sound.name == oldMusic);
        Sound newM = Array.Find(sounds, sound => sound.name == newMusic);

        StartCoroutine(FadeOutMusic(oldM));
        StartCoroutine(FadeInMusic(newM));
    }

    public void Transition(string newMusic)
    {
        Sound newM = Array.Find(sounds, sound => sound.name == newMusic);

        foreach (var sound in sounds)
        {
            if (sound.source.isPlaying)
            {
                StartCoroutine(FadeOutMusic(sound));
            }
        }

        StartCoroutine(FadeInMusic(newM));
    }

    IEnumerator FadeOutMusic(Sound oldM)
    {
        yield return new WaitForSeconds(.01f);

        for (float ft = oldM.volume; ft >= 0; ft -= 0.05f)
        {
            oldM.source.volume = ft;
            yield return new WaitForSeconds(.1f);
        }

        oldM.source.Stop();
    }

    IEnumerator FadeInMusic(Sound newM)
    {
        yield return new WaitForSeconds(.01f);

        newM.source.Play();

        for (float ft = newM.volume; ft <= 1; ft += 0.05f)
        {
            newM.source.volume = ft;
            yield return new WaitForSeconds(.1f);
        }
    }
}
