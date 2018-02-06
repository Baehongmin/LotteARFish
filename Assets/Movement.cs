using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

public class Movement : MonoBehaviour {

    //destination marker reference
    public GameObject markerGoal;
    //parent position
    Vector3 parentPos;
    public GameObject destSprite;

    // public GameObject successText;
    public GameObject backImage;


    public enum PlayerState
    {
        Move,
        Stop,
        Death
    }
    public PlayerState PS;

    private NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
        PitchCtrl();

    }
    //void MoveToTarget()
    //{
    //    if (markerGoal.active)
    //    {
    //        parentPos = markerGoal.transform.parent.position;
    //        agent.SetDestination(parentPos);
    //    }
    //}
    void MoveToTarget()
    {
        if (markerGoal.active)
        {
            parentPos = markerGoal.transform.parent.position;
            agent.SetDestination(parentPos);
            destSprite.transform.position = new Vector3(parentPos.x, 0, parentPos.z);
            System.Diagnostics.Debug.WriteLine("move");
        }
    }
    void PitchCtrl()
    {
        transform.GetChild(0).eulerAngles = new Vector3(
            MapRange(agent.velocity.magnitude, 0f, 2f, 0f, 20f),
            transform.eulerAngles.y,
            transform.eulerAngles.z
            );
    }
    float MapRange(float s, float a1, float a2, float b1, float b2)
    {
        if (s >= a2) return b2;
        if (s <= a1) return b1;
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

    void CoinGet()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        GetComponent<Rigidbody>().WakeUp();
        if (other.gameObject.CompareTag("BoxDone"))
        {
            //gameObject.CompareTag("BoxDone")
            //other.gameObject.SetActive(true);
            //GameObject.Find("Spiral_02.1.3 Portal").SetActive(true);
            GameObject.Find("Manta_Ray").SetActive(false);
            other.gameObject.SetActive(false);
            //count = count + 1;
            //MeetFreindText(other);
            //Destroy(other.gameObject);

            Debug.Log("collision detect");
            backImage.gameObject.SetActive(true);


        }
        /*if (other.gameObject.name == "Coin")
        {
            Destroy(other.gameObject);
            CoinGet();
        }

        if(other.gameObject.name =="DeathZone" && PS != PlayerState.Death)
        {
            GameOver();
            Destroy(other.gameObject);
        }*/
    }

    void OnCollisionEnter(Collision collision)
    {

    }
    void GameOver()
    {
        PS = PlayerState.Death;

    }
}
