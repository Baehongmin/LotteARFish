using UnityEngine;
using System.Collections;

public class globalFlock : MonoBehaviour {

	public globalFlock myFlock;
	public GameObject fishPrefab;

	static int numFish = 20;
	public GameObject[] allFish = new GameObject[numFish];
	public Vector3 goalPos;
	//set the size of the bounding box to keep the fish within.
	//its actual side length will be twice the values given here
	public Vector3 swimLimits = new Vector3(5,5,5);


	//draw bounding box for limits of swim space
	//as well as the fish goal pos
	void OnDrawGizmosSelected() 
	{
        Gizmos.color = new Color(1, 0, 0, 0.5F);
        Gizmos.DrawCube(transform.position, new Vector3(swimLimits.x*2, swimLimits.y*2, swimLimits.z*2));
        Gizmos.color = new Color(0, 1, 0, 1);
        Gizmos.DrawSphere(goalPos, 0.1f);
    }

	// Use this for initialization
	void Start () 
	{
		myFlock = this;
		goalPos = this.transform.position;
		RenderSettings.fogColor = Camera.main.backgroundColor;
		RenderSettings.fogDensity = 0.03F;
        RenderSettings.fog = true;
		for(int i = 0; i < numFish; i++)
		{
			Vector3 pos = this.transform.position + new Vector3(Random.Range(-swimLimits.x,swimLimits.x),
				                      							Random.Range(-swimLimits.y,swimLimits.y),
				                      							Random.Range(-swimLimits.z,swimLimits.z));
			allFish[i] = (GameObject) Instantiate(fishPrefab, pos, Quaternion.identity);
			allFish[i].GetComponent<flock>().myManager = this;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Random.Range(0,10000) < 50)
		{
			goalPos = this.transform.position + new Vector3(Random.Range(-swimLimits.x,swimLimits.x),
				                      							Random.Range(-swimLimits.y,swimLimits.y),
				                      							Random.Range(-swimLimits.z,swimLimits.z));
		}
	}
}
