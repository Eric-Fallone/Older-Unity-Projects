using UnityEngine;
using System.Collections;

public class Projectels : MonoBehaviour {
	public int damage;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		//check to see if it is a enemy ship
		if (other.GetComponent<Enemy>() != null && this.tag=="Proj_P") {
			other.GetComponent<Enemy>().getHit(damage);
			GameObject.Destroy(this.gameObject);
		}
		if(other.tag=="Player" && this.tag=="Proj_E"){
			PlayerLogic.S.isHit();
		}

	}
}
