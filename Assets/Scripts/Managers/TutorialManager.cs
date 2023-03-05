using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    public LightControl flatArea1;
    public GameManager gameManager;
    public Camera Camera;
    public GameObject city;
    public GameObject TutorialCanvas;
    public int popUpIndex = 0;
    private int startCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isStarted) 
        {
            for (int i = 0; i < popUps.Length; i++)
            {
                if (i == popUpIndex)
                {
                    popUps[popUpIndex].SetActive(true);
                }
                else
                {
                    popUps[i].SetActive(false);
                }
            }

            if (popUpIndex == 0)
            {
                if (Input.touchCount >= 1)
                {
                    if (startCount >= 1)
                    {
                        popUpIndex++;
                        Camera.transform.position = new Vector3(19, 200, 24);
                        city.GetComponent<CameraControls>().enabled = false;
                    }
                    else
                    {
                        startCount++;
                    }
                }
            }
            else if (popUpIndex == 1)
            {
                if (flatArea1.LightOn)
                {
                    flatArea1.consumptionRate = 100;
                    flatArea1.satisfactionRate = 100;
                    gameManager.isPaused = false;
                    popUpIndex++;
                }
            }
            else if (popUpIndex == 2) 
            {
                if (gameManager.timer <= gameManager.totalTimer - 10) 
                {
                    popUpIndex++;
                }
            }
            else if (popUpIndex == 3)
            {
                if (flatArea1.fused && gameManager.puzzleSolved)
                {
                    popUpIndex++;

                }
                else if (flatArea1.fused)
                {
                    popUps[popUpIndex].SetActive(false);
                }
            }
            else if (popUpIndex == 4)
            {
                if (Input.touchCount >= 1)
                {
                    popUpIndex++;
                    city.GetComponent<CameraControls>().enabled = true;
                    TutorialCanvas.SetActive(false);
                    flatArea1.satisfactionRate = 5;
                    flatArea1.consumptionRate = 5;
                    gameManager.resetLevel();
                    this.gameObject.SetActive(false);
                }
            }
        }
    }

}
