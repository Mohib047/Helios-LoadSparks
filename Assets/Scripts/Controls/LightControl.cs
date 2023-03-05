using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    public int consumptionRate;
    public int satisfactionRate;
    public bool LightOn = false;
    public string areaName;
    public GameManager gameManager;
    public GameObject areaLight;
    public GameObject fuseEffect;
    public int lightCount;
    public bool fused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isPaused) 
        {
            AreaLightOn();
        }
    }
    public void onClickLight()
    {
        if (LightOn)
        {
            Debug.Log(areaName +"Light Off");
            areaLight.SetActive(false);
            LightOn = false;
        }
        else
        {
            if (lightCount < 5)
            {
                Debug.Log(areaName + "Light On");
                LightOn = true;
                areaLight.SetActive(true);
                lightCount++;
            }
            else 
            {
                if (gameManager.puzzleSolved)
                {
                    Debug.Log(areaName + "Light On");
                    LightOn = true;
                    areaLight.SetActive(true);
                    lightCount = 0;
                    fuseEffect.SetActive(false);
                    fused = false;
                    gameManager.puzzleSolved = false;
                    gameManager.ST_Puzzle.Complete = false;
                    gameManager.ST_Puzzle.completeCount++;
                    StopCoroutine(Fuse());
                }
                else
                {
                    LightOn = true;
                    fused = true;
                    StartCoroutine(Fuse());
                    gameManager.isPaused = true;
                }
            }

            
        }
    }
    public void AreaLightOn() 
    {
        if (LightOn)
        {
            gameManager.powerGridBar.value -= consumptionRate * Time.deltaTime;
            gameManager.satisfactionBar.value += satisfactionRate * Time.deltaTime;
        }
        else
        {
            gameManager.powerGridBar.value += consumptionRate * Time.deltaTime;
            gameManager.satisfactionBar.value -= satisfactionRate * Time.deltaTime;
        }
    }

    public IEnumerator Fuse() 
    {
        areaLight.SetActive(true);
        fuseEffect.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        LightOn = false;
        areaLight.SetActive(false);
        gameManager.SlidingPuzzle[gameManager.levelCount].SetActive(true);
    }
}
