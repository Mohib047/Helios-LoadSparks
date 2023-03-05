using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Time Variables
    public float timer;
    public float totalTimer;
    public TextMeshProUGUI timerText;
    public Image timerImage;

    //SatisfactionBar
    public Slider satisfactionBar;

    //PowerGridBar
    public Slider powerGridBar;

    //Level Variables
    public bool satisfied;

    //Day AND Night Cycle
    public Light directionalLight;

    //SlidingPuzzle Variables
    public List<GameObject> SlidingPuzzle;
    public ST_PuzzleDisplay ST_Puzzle;
    public bool puzzleSolved = false;

    //Pause Mechanic
    public bool isPaused = true;

    //Level UI
    public GameObject LevelCompleteUI;
    public GameObject LevelFailedUI;

    //MainMenu
    public GameObject MainMenu;
    public bool isStarted;

    //Levels Array
    public List<GameObject> Levels;
    public int levelCount;


    //In Game UI
    public GameObject dayUI;
    public GameObject NightUI;
    // Start is called before the first frame update

    private void Awake()
    {
        satisfactionBar.value = satisfactionBar.minValue;
        powerGridBar.value = powerGridBar.maxValue;
    }
    void Start()
    {
        isPaused = true;
        totalTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused) 
        {
            DisplayTime(timer);
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                if (satisfactionBar.value > satisfactionBar.maxValue / 2)
                {
                    LevelComplete();
                }
                else
                {
                    LevelFailed();
                }
            }
            else
            {
                if (timer <= totalTimer / 2)
                {
                    if (directionalLight.intensity <= 1)
                    {
                        directionalLight.intensity += 0.5f * Time.deltaTime;
                        dayUI.SetActive(true);
                        NightUI.SetActive(false);
                        timerImage.color = Color.black;
                        timerText.color = Color.black;
                    }
                }
                else
                {
                    if (directionalLight.intensity <= 0)
                    {
                        directionalLight.intensity -= 0.5f * Time.deltaTime;
                        dayUI.SetActive(false);
                        NightUI.SetActive(true); ;
                        timerImage.color = Color.white;
                        timerText.color = Color.white;
                    }
                }
                if (satisfactionBar.value == satisfactionBar.maxValue)
                {
                    LevelComplete();
                }
                else if (powerGridBar.value <= powerGridBar.minValue)
                {
                    LevelFailed();
                }
            }
        }
    }

    private void DisplayTime(float timeToDisplay) 
    {
        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void LevelComplete()
    {
        isPaused = true;
        Levels[levelCount].SetActive(false);
        levelCount++;
        LevelCompleteUI.SetActive(true);
        Debug.Log("Level Pass");
    }
    public void LevelFailed()
    {
        isPaused = true;
        Levels[levelCount].SetActive(false);
        LevelFailedUI.SetActive(true);
        Debug.Log("Level Failed");
    }
    public void onClickStart() 
    {
        MainMenu.SetActive(false);
        isStarted = true;
        Levels[levelCount].SetActive(true);
    }
    public void onClickQuit() 
    {
        Application.Quit();
    }
    public void onClickNext() 
    {
        Levels[levelCount].SetActive(true);
        LevelCompleteUI.SetActive(false);
        isPaused = false;
        resetLevel();
    }
    public void onClickMainMenu() 
    {
        isPaused = true;
        LevelCompleteUI.SetActive(false);
        LevelFailedUI.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void onClickRetry() 
    {
        resetLevel();
        LevelFailedUI.SetActive(false);
        Levels[levelCount].SetActive(true);
        isPaused = false;
    }
    public void resetLevel() 
    {
        timer = totalTimer;
        satisfactionBar.value = satisfactionBar.minValue;
        powerGridBar.value = powerGridBar.maxValue;
        directionalLight.intensity = 0;
        ST_Puzzle = SlidingPuzzle[levelCount].gameObject.GetComponentInChildren<ST_PuzzleDisplay>();
    }
}
