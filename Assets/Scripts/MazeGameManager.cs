using UnityEngine;
using System.Collections;
using System;
using System.Threading;
using System.Collections.Generic;       //Allows us to use Lists. 
using UnityEngine.UI;                   //Allows us to use UI.
using UnityEngine.SceneManagement;
public class MazeGameManager : MonoBehaviour
{
    public float gameStartDelay = 2f;                      //Time to wait before starting level, in seconds.
    public static MazeGameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

    private Text startMessage;                                 //Text to display current level number.
    private GameObject startImage;                          //Image to block out level as levels are being set up, background for levelText.

    private BoardManager boardScript;                       //Store a reference to our BoardManager which will set up the level.
   
    [HideInInspector]
    public bool isGameOver;

    [HideInInspector]
    public bool didWin;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Get a component reference to the attached BoardManager script
        boardScript = GetComponent<BoardManager>();

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    //This is called each time a scene is loaded.
    void OnLevelWasLoaded(int index)
    {
        //Call InitGame to initialize our level.
        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {
        isGameOver = false;
        didWin = false;
        /*
        //Get a reference to our image LevelImage by finding it by name.
        startImage = GameObject.Find("StartImage");

        //Get a reference to our text LevelText's text component by finding it by name and calling GetComponent.
        startMessage = GameObject.Find("StartMessage").GetComponent<Text>();

        //Set the text of levelText to the string "Day" and append the current level number.
        startMessage.text = "친구들을 만나보자!";

        //Set levelImage to active blocking player's view of the game board during setup.
        startImage.SetActive(true);
        */
        //Call the HideLevelImage function with a delay in seconds of levelStartDelay.
        //Invoke("HideStartImage", gameStartDelay);

    }


    //Hides black image used between levels
    void HideStartImage()
    {
        //Disable the levelImage gameObject.
        startImage.SetActive(false);
    }

    //Update is called every frame.
    void Update()
    {

    }

    public void GameOver()
    {
        if (didWin && isGameOver)
        {
            startMessage.text = "성공!";
            startImage.SetActive(true);
        }
        else
        {
          
            SceneManager.LoadScene("retry_fish_maze");
          
        }
       
    }

    void ReStart() {
      
       SceneManager.LoadScene("fish_maze");
       
    }

    

}