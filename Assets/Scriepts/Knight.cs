using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public float restartTime = 1;
    public int health;
    public Animator animator;

    public GameObject Life1, Life2, Life3, Life4 , Life5;
    public int lifeLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeLeft <= 0)
        {

            Invoke("gameOver" , restartTime);
            Debug.Log("game over");
            
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Dragon"))
        {

            Debug.Log("YOU HAVE BEEN HIT!");
            lifeLeft--;
            Life(lifeLeft);
        }


    }

    void gameOver()
    {
       FindObjectOfType<WordManager>().EndGame();
    }

    void Life(int lifeLeft)
    {
        switch(lifeLeft)
        {
            case 5:
                Life1.SetActive(true);
                Life2.SetActive(true);
                Life3.SetActive(true);
                Life4.SetActive(true);
                Life5.SetActive(true);
                break;
            case 4:
                Life1.SetActive(true);
                Life2.SetActive(true);
                Life3.SetActive(true);
                Life4.SetActive(true);
                Life5.SetActive(false);
                break;
            case 3:
                Life1.SetActive(true);
                Life2.SetActive(true);
                Life3.SetActive(true);
                Life4.SetActive(false);
                Life5.SetActive(false);
                break;
            case 2:
                Life1.SetActive(true);
                Life2.SetActive(true);
                Life3.SetActive(false);
                Life4.SetActive(false);
                Life5.SetActive(false);
                break;

            case 1:
                Life1.SetActive(true);
                Life2.SetActive(false);
                Life3.SetActive(false);
                Life4.SetActive(false);
                Life5.SetActive(false);
                break;

            case 0:
                Life1.SetActive(false);
                Life2.SetActive(false);
                Life3.SetActive(false);
                Life4.SetActive(false);
                Life5.SetActive(false);
                break;

        }
    
    }

}
