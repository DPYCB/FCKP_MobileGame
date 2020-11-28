using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    public bool isMuted;

    // Start is called before the first frame update
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

        isMuted = false;

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play (string clipName)
    {
        Sound s = Array.Find(sounds, sound => sound.clipName == clipName);
        if (s == null)
        {
            Debug.Log(clipName + " not found!");
            return;
        }
        s.source.Play();
    }

    public void Stop (string clipName)
    {
        Sound s = Array.Find(sounds, sound => sound.clipName == clipName);
        if (s == null)
        {
            Debug.Log(clipName + " not found!");
            return;
        }
        s.source.Stop();
    }

    public void SetMute(bool isMuted)
    {
        this.isMuted = isMuted;
        foreach (Sound s in sounds)
        {
            s.source.mute = isMuted;
        }
    }
}
