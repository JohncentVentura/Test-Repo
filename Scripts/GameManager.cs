using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; } //GameManager is a singleton

    public string[] scenes = {"SpaceScene"};

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject); //If there is another instance of this class, destroy it because this class is a singleton
            return;
        }
        instance = this; //If there are no instance of this class, this becomes the first & only instance of this class
        DontDestroyOnLoad(this.gameObject); //The gameObject must be in the root of a scene, to persist when loading to other scenes
    }

    void Start()
    {
        
    }

    void Update(){

    }

    public void ChangeScene(string nextScene){
        SceneManager.LoadScene(nextScene);
    }
    
}
