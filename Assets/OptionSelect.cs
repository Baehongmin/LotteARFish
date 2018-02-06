using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSelect : MonoBehaviour {
    public GameObject Building;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    public void BuildingSetActive()
    {
        Building.SetActive(!Building.active);
    }
}
