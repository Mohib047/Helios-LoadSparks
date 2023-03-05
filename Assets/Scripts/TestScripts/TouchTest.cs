using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : MonoBehaviour
{
    public bool LightOn = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onClickPrint(int buildingNum)
    {
        if (LightOn)
        {
            Debug.Log("Buildeing #"+buildingNum+"Light Off");
            LightOn = false;
        }
        else 
        {
            Debug.Log("Buildeing #" + buildingNum + "Light On");
            LightOn = true;
        }
    }
}
