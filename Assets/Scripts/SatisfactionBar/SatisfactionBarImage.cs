using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SatisfactionBarImage : MonoBehaviour
{
    public Slider satisfactionBar;
    public GameObject Happy;
    public GameObject Content;
    public GameObject Angry;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (satisfactionBar.value < satisfactionBar.maxValue / 3)
        {
            Happy.SetActive(false);
            Angry.SetActive(true);
            Content.SetActive(false);
        }
        else if (satisfactionBar.value > satisfactionBar.maxValue/3 && satisfactionBar.value < satisfactionBar.maxValue / 1.5)
        {
            Happy.SetActive(false);
            Angry.SetActive(false);
            Content.SetActive(true);
        }
        else if (satisfactionBar.value > satisfactionBar.maxValue / 1.5) 
        {
            Happy.SetActive(true);
            Angry.SetActive(false);
            Content.SetActive(false);
        }
    }
}
