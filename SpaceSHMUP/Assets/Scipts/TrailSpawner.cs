using UnityEngine;
using System.Collections;

public class TrailSpawner : MonoBehaviour {
	
	public GameObject trail;
	
	public float fireDelay=1;
	
	// Use this for initialization
	void Start () {
		StartCoroutine (spawn ());
	}
	
	// Update is called once per frame

	
	IEnumerator spawn(){
		
		if(trail==null){
			yield break;
		}
		

		while(true){
			GameObject temp= (GameObject)Instantiate (trail, this.transform.position, this.transform.rotation);
			temp.transform.position+= new Vector3(0,0,.5f);
			yield return new WaitForSeconds (fireDelay);
		}
	}
	
}
