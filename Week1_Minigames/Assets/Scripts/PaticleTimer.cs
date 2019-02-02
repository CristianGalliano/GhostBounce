using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaticleTimer : MonoBehaviour
{
    private ParticleSystem thisParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
        thisParticleSystem = gameObject.GetComponent<ParticleSystem>();
        float totalDuration = thisParticleSystem.duration;
        Destroy(gameObject, totalDuration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
