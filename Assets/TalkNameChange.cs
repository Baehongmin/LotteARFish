using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkNameChange : MonoBehaviour {
    static Text tex;
	// Use this for initialization
	void Start () {
        tex = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public static void NameChange(string name)
    {
        tex.text = name;
    }
}
