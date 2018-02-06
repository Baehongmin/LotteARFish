using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {
    public GameObject gameManager;			//GameManager prefab to instantiate.
    public GameObject soundManager;			//SoundManager prefab to instantiate.
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake()
    {
        //Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
        if (MazeGameManager.instance == null)

            //Instantiate gameManager prefab
            Instantiate(gameManager);
    }
}
