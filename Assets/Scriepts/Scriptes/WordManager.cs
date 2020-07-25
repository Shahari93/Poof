using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DigitalRubyShared;
using UnityEngine.UI;

public class WordManager : MonoBehaviour
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
    
    
    public int nextLevel;
    public int thisStage;

    public GameObject winCanvas;
    public GameObject knight;

    public int currentLetter;


    public bool isStage1 , isStage2, isStage3, isStage4 , isStage5;

  
    public Animator castlevenia;

    public GameObject loseCanvas;
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
        if(lettersEnd == LetterNumber)
        {
            WinGame();
        }




        if(isStage1 == true)
        {
            castlevenia.Play("Castle_1");
        }

        if(isStage2 == true)
        {
            castlevenia.Play("Castle_2");
        }

        if (isStage3 == true)
        {
            castlevenia.Play("Castle_3");
        }

        if (isStage4 == true)
        {
            castlevenia.Play("Castle_4");
        }

        if (isStage5 == true)
        {
            castlevenia.Play("Castle_3");
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



            

            canSummon = true;

            lettersEnd++;
            currentLetter = letterIndex;
            return true;


        }
       // knightAnimator.Play("Knight_fight_2");
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
        //GameOverSCreen.lastScene = SceneManager.GetActiveScene().buildIndex;
        loseCanvas.SetActive(true);
        Debug.Log("GAME OVER");
        
       // SceneManager.LoadScene("GameOver");
    }

    public void restart()
    {
        SceneManager.LoadScene(thisStage);
        Debug.Log(thisStage);
    }
    public void WinGame()
    {
        winCanvas.SetActive(true);
        knight.SetActive(false);
       
        
    }
}