using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour {
    public GameObject camera;
    public int speed = -1;
    public string level;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        camera.transform.Translate(Vector3.right * Time.deltaTime * speed);
        StartCoroutine(waitFor());
	}
    IEnumerator waitFor()
    {
        yield return new WaitForSeconds(20);
        Application.LoadLevel(level);
    }
}
