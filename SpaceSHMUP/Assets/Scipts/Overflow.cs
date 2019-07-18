using UnityEngine;
using System.Collections;

public class Overflow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerExit(Collider other) {

		if(other.tag=="Proj_P"){
			GameObject.Destroy(other.gameObject);
			PlayerLogic.S.shotsMissed++;
			return;
		}
		if(other.tag=="Proj_E"){
			GameObject.Destroy(other.gameObject);
			return;
		}
		if (other.tag == "Enemy") {
			GameObject.Destroy(other.gameObject);
			return;
		}
		if (other.tag == "Upgrade") {
			GameObject.Destroy(other.gameObject);
			return;
		}
		Debug.Log (other.tag+"may have excaped");
	}
}
