using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager  {

    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips = new Dictionary<AudioClipName, AudioClip>();

    public static bool Initialized
    {
        get { return initialized; }
    }

    public static void Initialize(AudioSource source)
    {
        audioSource = source;
        initialized = true;

        audioClips.Add(AudioClipName.Click, Resources.Load<AudioClip>("ButtonMenu"));
        audioClips.Add(AudioClipName.Explosion, Resources.Load<AudioClip>("explosion"));
        audioClips.Add(AudioClipName.GameOver, Resources.Load<AudioClip>("gameEnd"));
    }

    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
	
}
