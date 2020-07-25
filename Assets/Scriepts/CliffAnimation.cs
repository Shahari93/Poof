using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliffAnimation : MonoBehaviour
{

    public Animator animator;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
        
        
       

    }

    // Update is called once per frame
    void Update()
    {
        
        animator.Play("cliff");
    }
}
