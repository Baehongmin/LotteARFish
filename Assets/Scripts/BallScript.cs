using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic; 	

public class BallScript : MonoBehaviour
{
    
    public GameObject plane;
   public static BallScript instance = null;
    public GameObject spawnPoint;
    public Text meetFriendText;
    public Text meetFriendNumText;
    public Text winText;
    public int friends;

    [HideInInspector]
    public static int count;

    private static int setupcount;
    private int textTimeCount;
    
    private List<GameObject> meet = new List<GameObject>();

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }
    
    // Use this for initialization
    void Start()
    {
        count = 0;
        textTimeCount = 30;
        meetFriendText.text = "";
        winText.text = "";
        setupcount=1 ;
        //SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < plane.transform.position.y - 10)
        {
            transform.position = spawnPoint.transform.position;
        }
        if (textTimeCount == 30)
        {
            meetFriendText.text = "";
        }
        else
        {
            textTimeCount++;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Friend"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            MeetFriendText(other);
        }
        else if (other.gameObject.CompareTag("Exit")) {
            if (count >= friends)
            {
                MazeGameManager.instance.didWin = true;
            }
            else
            {
                MazeGameManager.instance.didWin = false;
                
            }
            MazeGameManager.instance.isGameOver = true;
            MazeGameManager.instance.GameOver();
        }
    }
    void MeetFriendText(Collider other)
    {
        meetFriendText.text = "친구를 구출했어요!";
        textTimeCount = 0;
        meetFriendNumText.text = "구출한 친구 수 : " + count;
    }
    public void SetUp() {
        
        count = 0;
        textTimeCount = 30;
        meetFriendText.text = "";
        winText.text = "";
        MazeGameManager.instance.didWin = false;
        MazeGameManager.instance.isGameOver = false;
        
        setupcount++;
        meetFriendNumText.text = "만난 친구 수 : " + count;
        
    }
}
