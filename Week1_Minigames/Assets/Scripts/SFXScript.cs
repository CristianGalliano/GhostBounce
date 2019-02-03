using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXScript : MonoBehaviour
{
    private AudioSource thisAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        thisAudioSource = gameObject.GetComponent<AudioSource>();
        thisAudioSource.volume = PlayerPrefs.GetFloat("SFX", 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
