using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public int indexNumber = 10;
    string myName = "Gomdol";

    // Use this for initialization
	void Start () {

        indexNumber = 20;

        myName = "Kim";
        Debug.Log(indexNumber);
        
		
	}
	
    void ShowMyName()
    {
        indexNumber = 40;
        myName = "Tam";

        float distanceOfit = 10.0f;

        
    }
	// Update is called once per frame
	void Update () {
		
	}
}
