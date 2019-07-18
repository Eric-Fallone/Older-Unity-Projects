using UnityEngine;
using System.Collections;

public class UnpackAndDelete : MonoBehaviour {

	// Use this for initialization
	void Update () {
		this.transform.DetachChildren ();
		GameObject.Destroy (this.gameObject);
	}
	

}
