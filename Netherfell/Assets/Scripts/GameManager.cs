using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //find the container for the text and set the text by getting from the container
    public GameObject locationContainer;
    public TMP_Text locationText;

    public AudioSource bgm;

    string[] floors = new string[4] {"B1", "F1", "F2", "A1"};
    /*
        In Build settings:
        SceneIndex 1 = b1, [0]    
        SceneIndex 2 = f1, [1] 
        SceneIndex 3 = f2, [2]
        SceneIndex 4 = a1, [3]
    */
    [SerializeField] public int currentScene = 0;
    void Awake()
    {
        //Dontdestroyonload the game manage when we switch scenes
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        bgm = GetComponent<AudioSource>();

        //finds and sets the text by looking at the child of the canvas object
        locationContainer = GameObject.Find("Location Text Canvas");
        locationText = locationContainer.gameObject.transform.GetChild(0).GetComponent<TMP_Text>();

        //makes sure the text is set
        if(locationText == null)
        {
            locationText = locationContainer.GetComponent<TMP_Text>();
        }

        currentScene = 0;
        checkScene();
    }

    void Update()
    {
        checkScene();
        playBGM();

        //quit application any time
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    
    //forces unity to set the text objects because it resets every scene change
    public void setTextObjects()
    {
        locationContainer = GameObject.Find("Location Text Canvas");
        locationText = locationContainer.gameObject.transform.GetChild(0).GetComponent<TMP_Text>();

        if(locationText == null)
        {
            locationText = locationContainer.GetComponent<TMP_Text>();
        }
    }

    public void playBGM()
    {
        //while the scenes stay on the dungeon levels play the background music
        while(currentScene <= 0 && currentScene >= 3)
        {
            //Play sound and animation
            bgm.Play(0);
        }
    }

    //check what floor the player is on
    public void checkScene()
    {
        //check the current scene name and change to the next one
        if(SceneManager.GetActiveScene().name == "BasementOne")
        {
            currentScene = 0;
            updateLocation(currentScene);
            setTextObjects();
        }
        else if(SceneManager.GetActiveScene().name == "FloorOne")
        {
            currentScene = 1;
            updateLocation(currentScene);
            setTextObjects();
        }
        else if(SceneManager.GetActiveScene().name == "FloorTwo")
        {
            currentScene = 2;
            updateLocation(currentScene);
            setTextObjects(); 
        }
        else if(SceneManager.GetActiveScene().name == "ArenaOne")
        {
            currentScene = 3;
            updateLocation(currentScene);
            setTextObjects(); 
        }
    }

    //function to update the location text when the scene changes to the next level
    public void updateLocation(int floorIndex)
    {
        locationText.text = floors[floorIndex]; 
    }
}
