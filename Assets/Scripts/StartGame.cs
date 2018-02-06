using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {
    private GameObject startImage; 
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartFishMazeGame()
    {
        //Disable the levelImage gameObject.
        SceneManager.LoadScene("fish_maze");
    }
}
