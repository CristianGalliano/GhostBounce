using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    private AudioSource thisAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        thisAudioSource = gameObject.GetComponent<AudioSource>();
        thisAudioSource.volume = PlayerPrefs.GetFloat("Music", 0.20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
