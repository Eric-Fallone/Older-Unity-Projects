using UnityEngine;
using System.Collections;

public class EnemyWeapons : MonoBehaviour {

	public GameObject proj;

	public float fireDelay=1;
	public float initialDelay;

	// Use this for initialization
	void Start () {
		StartCoroutine (fire ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator fire(){
		
		if(proj==null){
			yield break;
		}
		
		yield return new WaitForSeconds (initialDelay);
		while(true){
			Instantiate (proj, this.transform.position, Quaternion.identity);
			yield return new WaitForSeconds (fireDelay);
		}
	}

}
