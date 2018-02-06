using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class Typing : MonoBehaviour {
    List<string> texs = new List<string>();
    public Text tex;
    public GameObject StartButton;
	// Use this for initialization
	void Start () {
        tex = GetComponent<Text>();
        disableButton();
        texs.Add("L!:쓰레기에 쫓기던 친구들이 해초 더미에 갇혀버렸어! 친구들을 구출하는 걸 도와줘!");
        StartCoroutine("Printing");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator Printing()
    {
        int colidex = texs[0].IndexOf(":");
        for (int j = colidex + 1; j < texs[0].Length; j++)
        {
            tex.text += texs[0][j];
            yield return new WaitForSeconds(0.1f);
        }
        enableButton();

    }

    private void enableButton() {
        StartButton.SetActive(true);
    }

    private void disableButton() {
        StartButton.SetActive(false);
    }
}
