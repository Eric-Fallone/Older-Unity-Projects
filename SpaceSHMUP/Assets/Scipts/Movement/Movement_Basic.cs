using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class Movement_Basic : MonoBehaviour
{
	public float speed;
	public float angle;
	public float acc;

	void Start () {
		this.transform.rotation = Quaternion.Euler (new Vector3(0,0,angle));
	}


	void Update(){
		transform.position += transform.up * Time.deltaTime * (speed+acc);
		acc += acc*Time.deltaTime;
	}
}
