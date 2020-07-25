using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{

    public Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        animator.Play("Castle_1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
