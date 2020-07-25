using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{

    public static AudioClip Poof;

    static AudioSource adc;
    // Start is called before the first frame update
    void Start()
    {
        Poof = Resources.Load<AudioClip>("dragon_dead");

        adc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void playSound(string clip)
    {
        switch(clip)
        {
            case "Poof":
                adc.PlayOneShot(Poof);
                break;
                
             
        }
    }
}
