using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaArrow : MonoBehaviour {
    GameObject goCamera;
    GameObject goCamera_Minmap;

    // Use this for initialization
    void Start () {
        this.goCamera_Minmap = GameObject.Find("Main Minmap");
    }
    public void PressKey(int nKey)
    {
        //처음 데이터 받기
        Vector3 rectTemp = this.goCamera.transform.localPosition;

        switch (nKey)
        {
            case 1: //left
                rectTemp.x -= 0.1f;
                break;
            case 2: //up
                rectTemp.y += 0.1f;
                break;
            case 3: //right
                rectTemp.x += 0.1f;
                break;
            case 4: //down
                rectTemp.y -= 0.1f;
                break;

        }

        //완성된 데이터 저장
        this.goCamera.transform.localPosition = rectTemp;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
