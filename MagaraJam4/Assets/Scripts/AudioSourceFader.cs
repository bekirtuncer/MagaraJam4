using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSourceFader : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    private void Awake()
    {
        if (source == null)
        {
            source = GetComponent<AudioSource>();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        StartCoroutine("fadeSound");
    }

    public void OnTriggerEnter(Collider other)
    {
        playSound();
    }


    void playSound()
    {
        if (!source.isPlaying)
        {
            source.volume = 1;
            source.Play();
        }
    }

    void stopSound()
    {
        if (!source.isPlaying)
        {
            source.Stop();
        }
    }

    IEnumerator fadeSound()
    {
        while (source.volume > 0.01f)
        {
            source.volume -= Time.deltaTime / 1.0f;
            yield return null;
        }
        source.volume = 0;
        source.Stop();

    }

}
