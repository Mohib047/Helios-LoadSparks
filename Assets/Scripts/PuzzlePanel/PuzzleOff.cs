using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleOff : MonoBehaviour
{
    public ST_PuzzleDisplay display;
    public GameObject puzzle;
    public GameObject puzzleEffect;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        if (display.Complete)
        {
            onComplete();
        }
    }


    private void onComplete() 
    {
        puzzleEffect.SetActive(true);
        Invoke("PuzzleComplete", 2.0f);
        gameManager.puzzleSolved = true;
        gameManager.isPaused = false;
     
    }
    private void PuzzleComplete() 
    {
        puzzle.SetActive(false);
        EffectOff();
    }
    private void EffectOff() 
    {
        puzzleEffect.SetActive(false);
    }
}
