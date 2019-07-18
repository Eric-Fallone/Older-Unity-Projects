using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public float speed;
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (0,this.transform.position.y-speed,0);
	}
}
