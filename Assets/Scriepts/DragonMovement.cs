using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float moveSpeed = 2f;
    int waypointIndex = 0;
    Vector2 targetPosition;
    private Vector2 targetPos;
    Rigidbody2D rb;
    private SpriteRenderer sp;
    private Animator dragonAnimator;
    [SerializeField] ParticleSystem smokeParicle;
    public float distance;
    [SerializeField] GameObject knight;
    public float delay = 0f;
    private float stopMoving = 0;
    private AudioSource acdc;
    public static AudioClip Poof;
    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        dragonAnimator = GetComponent<Animator>();
        smokeParicle.Emit(0);
        acdc = GetComponent<AudioSource>();
        Poof = Resources.Load<AudioClip>("dragon_dead");

    }

    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
        targetPosition = waypoints[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        distance = Vector3.Distance(transform.position, knight.transform.position);
        if (distance <= 3)
        {
            dragonAnimator.Play("Roar");
            smokeParicle.Emit(1);

            // moveSpeed = stopMoving;
        }
        else
            dragonAnimator.SetFloat("IsLowerThan", 1f);
            smokeParicle.Emit(0);

        
            
        
    }

    private void Move()
    {
        Vector2 dir = targetPosition - (Vector2)transform.position;


        if (waypointIndex <= waypoints.Count - 1)
        {
            targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            
            if ((Vector2)transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }

        else
        {
            waypointIndex = 0;
            waypointIndex++;
            /*Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0f, 0f);*/
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Spin"))
        {
            sp.flipX = false;
        }
        if(collision.gameObject.CompareTag("Spin1"))
        {
            sp.flipX = true;
        }
    }





        public void dragonPoof()
    {
        acdc.PlayOneShot(Poof);
        dragonAnimator.Play("Poof");
        Debug.Log("poof");
        
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
        
    }


}
