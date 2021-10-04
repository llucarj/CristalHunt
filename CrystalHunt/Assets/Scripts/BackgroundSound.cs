using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSound : MonoBehaviour
{

    public static BackgroundSound instance = null;
    private AudioSource audio;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }

        if (instance == this) return;
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartBackgroundSound();
    }

    public void StartBackgroundSound()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
    }

    public void StopBackgroundSound()
    {
        audio = GetComponent<AudioSource>();
        audio.Stop();
    }
}
