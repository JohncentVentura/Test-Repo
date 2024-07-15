using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{   
    void Start()
    {

    }

    public void StartButtonOnClick()
    {
        GameManager.instance.ChangeScene(GameManager.instance.scenes[0]);
    }
}
