using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    const float defaultVolume = 1.0f;
    const bool defaultPlayOnAwake = false;
    const bool defaultLoop = false;
    // keep pool of audio objects
    // allows a 
    AudioSource[] audioPool;
    const int maxPool = 15;

    int currentIdx;

    void Awake()
    {
        audioPool = new AudioSource[maxPool];
        for (int i = 0; i < audioPool.Length; i++)
        {
            audioPool[i] = gameObject.AddComponent<AudioSource>();
            audioPool[i].playOnAwake = defaultPlayOnAwake;
            audioPool[i].loop = defaultLoop;
            audioPool[i].spatialBlend = 0.0f;
            //audioPool[i].outputAudioMixerGroup = 
        }

        currentIdx = 0;
    }

    public AudioSource CreateReplacableAudio(AudioClip clip)
    {
        if (clip != null)
        {
            currentIdx = (currentIdx + 1) % maxPool;

            audioPool[currentIdx].clip = clip;
            audioPool[currentIdx].Play();

            return audioPool[currentIdx];
        }
        else
        {
            Debug.LogError("No audio clip found for: " + gameObject.name);
            return null;
        }
    }

    public AudioSource CreatePeristentAudio(GameObject designatedGameObject, AudioClip clip, bool looping, bool play)
    {
        if (clip == null)
        {
            Debug.LogError("No audio clip found for: " + designatedGameObject.name);
            return null;
        }

        AudioSource newSource = designatedGameObject.AddComponent<AudioSource>();

        newSource.clip = clip;

        newSource.loop = looping;

        if (play)
            newSource.Play();
        else
            newSource.Stop();

        newSource.playOnAwake = defaultPlayOnAwake;

        return newSource;
    }
}
