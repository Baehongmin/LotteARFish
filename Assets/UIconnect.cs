using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text;

public class UIconnect : MonoBehaviour {
    public InputField tex;
    public InputField tex1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ChangeGameScene()
    {
        if (tex.text == "root")
        {
            SceneManager.LoadScene("SecondScenes");
        }
    }
}
