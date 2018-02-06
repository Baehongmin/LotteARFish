using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MazeGameFail : MonoBehaviour {

    public Button LPointButton;
    public Button AdButton;
    public Button QRButton;
    public Button GiveUpButton;

    public Text Message;
	// Use this for initialization
	void Start () {
        Message = GameObject.Find("Message").GetComponent<Text>();

        LPointButton = GameObject.Find("UsePointButton").GetComponent<Button>();
        LPointButton.onClick.AddListener(UseLPoint);

        AdButton = GameObject.Find("AdButton").GetComponent<Button>();
        AdButton.onClick.AddListener(Ad);

        QRButton = GameObject.Find("SnackButton").GetComponent<Button>();
        QRButton.onClick.AddListener(QR);

        GiveUpButton = GameObject.Find("GiveUpButton").GetComponent<Button>();
        GiveUpButton.onClick.AddListener(GiveUp);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UseLPoint() {
        Message.text = "2 L.Point를 사용합니다.";
        Invoke("Restart", 1f);
    }

    public void Ad() {
        Message.text = "광고를 시청합니다.";
        Application.OpenURL("https://www.youtube.com/watch?v=WUJM0bTB_2w");
        Invoke("Restart", 10f);
    }

    public void QR()
    {
        Message.text = "다음 업데이트부터 지원 예정입니다.";
    }

    public void GiveUp() {
        Message.text = "게임을 포기합니다. 물고기를 얻을 수 없습니다.";

    }
    void Restart() {
        SceneManager.LoadScene("fish_maze");
    }
}
