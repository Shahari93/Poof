using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundAtInterval : MonoBehaviour
{ 
public bool playAtStartup = false;
public float interval = 3.0f;
public AudioClip clipToPlay;
private bool disableScript = false;
private float trackedTime = 0.0f;
private bool playedAtStartup = false;

// Use this for initialization
void Start()
{
    if (interval < 1.0f)
    { // Make sure the interval isn't 0, or we'll be constantly playing the sound!
        Debug.LogError("Interval base must be at least 1.0!");
        disableScript = true;
    }
}

// Update is called once per frame
void Update()
    {
    if (!disableScript)
    {
        // Increment the timer
        trackedTime += Time.deltaTime;

        // Check to see that the proper amount of time has passed
        if (trackedTime >= interval)
        {
            // Play the sound, reset the timer
            GetComponent<AudioSource>().PlayOneShot(clipToPlay);
            trackedTime = 0.0f;
        }
    }
    }
}
