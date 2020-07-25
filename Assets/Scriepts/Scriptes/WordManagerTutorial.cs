using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DigitalRubyShared;
using UnityEngine.UI;

public class WordManagerTutorial : MonoBehaviour
{
    public List<string> letters;
    int currentIndex = 0;
    public int LetterNumber;
    public GameObject[] LatterGameObject;
    int LattersIndex = 0;
    public int lettersEnd;
    public GameObject[] Dragon;
    int DragonIndex = 0;
    List<GameObject> availableDragon;
    public int randomDragon;
    bool canSummon = false;
    public Animator cameraAnimator;
    public int health;
    
    public GameObject Life1, Life2, Life3, Life4, Life5;
    public int nextLevel;

    public GameObject winCanvas;
    public GameObject knight;

    public int currentLetter;

    public Animator handAnimator;
    public GameObject hand;
    public int handNumber;
    public int LastHand;

    public bool isTutorial;

    public GameObject[] tutorialHand;

    public Animator knightAnimator;
    void Awake()
    {
        lettersEnd = 0;
        FingersImageGestureHelperComponentScript.OnMatchFound += MatchFound;
        availableDragon = new List<GameObject>();
        availableDragon.AddRange(Dragon);
        


    }

    private void Update()
    {
        if(handNumber == LastHand)
        {
            hand.SetActive(false);
        }

        if (isTutorial == true && LastHand == handNumber)
        {
            nextScene();
            Debug.Log("great!");
        }
    }

    void MatchFound(string letterName)
    {
        for (int i = 0; i < letters.Count; i++)
        {
            if (Matching(i, letterName))
            {
                break;
            }
        }

        if (lettersEnd == LetterNumber && isTutorial == false)
        {
            
            WinGame();
        }
    }

    public bool Matching(int letterIndex, string letterName)
    {
        if (letters[letterIndex] == letterName && Dragon[letterIndex].activeInHierarchy == true)

        {

            //knightAnimator.Play("Knight_fight_3");
            print("letters[] + success");

            LatterGameObject[letterIndex].SetActive(true);
            letters[letterIndex] = "";
            Dragon[letterIndex].GetComponent<DragonMovement>().dragonPoof();

            availableDragon.Remove(Dragon[letterIndex]);
            //Destroy(Dragon[letterIndex]);
            Dragon[letterIndex].GetComponent<DragonMovement>().dragonPoof();
            dragonSummon();

            handAnimator.Play("TutorialAnimation2");
            handNumber++;
            tutorialHand[0].SetActive(false);
            tutorialHand[handNumber].SetActive(true);

            

            canSummon = true;

            lettersEnd++;
            currentLetter = letterIndex;
            return true;


        }
        
        return false;
    }

    void dragonSummon()
    {
        if(availableDragon.Count <= 0)
        {
            return;
        }

        GameObject availableRandomDragon = availableDragon[Random.Range(0, availableDragon.Count)];
        availableRandomDragon.SetActive(true);
        knightAnimator.Play("Knight_fight_1");
    }



    void Life(GameObject setactive)
    {
        Life1.SetActive(true);
        Life2.SetActive(true);
        Life3.SetActive(true);
        Life4.SetActive(true);
        Life5.SetActive(true);
    }
    public IEnumerator SceneEnd()
    {
        yield return new WaitForSeconds(.01f);
        cameraAnimator.SetBool("Zoom_In", true);
        yield return new WaitForSeconds(3f);
        print("finished word");
        lettersEnd = 0;
        SceneManager.LoadScene(nextLevel);
        nextLevel++;
    }

    public void nextScene()
    {
        StartCoroutine(SceneEnd());
        Debug.Log("next level!");  
    }

    public void EndGame()
    {
        GameOverSCreen.lastScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("GAME OVER");
       // SceneManager.LoadScene("GameOver");
    }

    public void WinGame()
    {
        winCanvas.SetActive(true);
        knight.SetActive(false);
       
        
    }
}