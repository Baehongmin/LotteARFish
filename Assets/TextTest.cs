using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class TextTest : MonoBehaviour
{
    public AudioClip typingsound; //인스펙터에서 지정할 효과음
    public GameObject Panel;
    List<string> texs = new List<string>(); //스크립트 받을 동적배열
    private Text tex; //텍스트 컴포넌트
    //AudioSource au;//오디오 컴포넌트
    int cnt = 0; //몇번째 스크립트인지 받을 int 변수
    //public Text Objtext;
    public Image imag;
    public Image imag2;

    // Use this for initialization
    void Start()
    {
        texs.Clear();
        imag.enabled = true;
        imag2.enabled = false;
        //imag2.enabled = false;
        //Objtext.text = "HelloWorld";
        tex = GetComponent<Text>();
        //au = GetComponent<AudioSource>();
        //스크립트의 저장은 나중에 따로 생각해봐야겠지만, 일단은 임의로 3줄을 생각해서 넣었다.
        //texs.Clear();
        texs.Add("물고기 :사람들이 버린 쓰레기 때문에 친구들이 좀비로 변해 버렸어! 너의 도움이 필요해!");
        texs.Add("L :헐! 내가 무엇을 도와주면 돼???");
        texs.Add("물고기 :좀비 물고기를 피해서 롯데 월드타워 아쿠아리움에 있는 친구들을 구해줘야해! 여러 게임들을 통해 구할 수 있어!!!");
        texs.Add("L :좋아 나와 함께 모험을 떠나자!  ㅡ>");
        tex.text = ""; //문자를 기존에 있던 문자열에 추가하는 방식이므로 처음에는 문자열이 없게 한다.
        StartCoroutine("Printing"); //코루틴 실행
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //엔터키를 누른경우
        {
            if (cnt == 0 || cnt == 2){
                imag.enabled = false;
                imag2.enabled = true;
            }
            else{
                imag.enabled = true;
                imag2.enabled = false;
            }
            
            Debug.Log("엔터키가 입력되었습니다");
            StopCoroutine("Printing"); //실행중이던 코루틴 중지
            //au.Stop(); //실행되던 효과음 중지
            tex.text = ""; //다음 스크립트 출력을 위해 문자열 초기화
            cnt++; //다음 index를 읽기 위해 index 상승.
            if (cnt > 3)
            {
                imag.enabled = false;
                //cnt = 0; //전체 스크립트가 현재 3개뿐이므로 3개를 넘은경우 다시 처음 문자열을 읽도록 한다.
                Panel.gameObject.SetActive(false);


            }
            else
            {
                StartCoroutine("Printing");
            }
             //코루틴 재실행
            //Panel.gameObject.SetActive(false);
        }
    }
    IEnumerator Printing()
    {
        int colindex = texs[cnt].IndexOf(":"); // ":"의 인덱스를 가져온다.
        string name = texs[cnt].Substring(0, colindex);//가져온 인덱스 이전까지의 문자열을 받는다.
        TalkNameChange.NameChange(name); //받은 문자열로  TalkNameChange의 메소드 실행
        for (int j = colindex + 1; j < texs[cnt].Length; j++) // ":"의 인덱스 다음 부분부터 스크립트의 마지막부분까지 for문 실행
        {
            tex.text += texs[cnt][j];//현재 문자열에 해당 index의 문자를 추가한다.
            //if (!au.isPlaying) au.PlayOneShot(typingsound, 0.1f);//효과음이 미재생인 상태에서 타이핑되는경우 타이핑 효과음 출력
            yield return new WaitForSeconds(0.1f);//다음 글자 출력까지 0.1초 동안 대기
        }
        yield return new WaitForSeconds(1f);//효과음 delay를 위해 1초동안 대기
        //au.Stop();//효과음 정지
        StopCoroutine("Printing");//코루틴 정지. 이 상태에서 enter가 들어올때까지 문자열은 변하지 않는다.
    }
}
