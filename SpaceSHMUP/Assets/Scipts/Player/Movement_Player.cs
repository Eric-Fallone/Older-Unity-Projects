using UnityEngine;
using System.Collections;
[RequireComponent (typeof (Rigidbody))]
public class Movement_Player : MonoBehaviour {
	public static Movement_Player S;
	public Vector2 minXY;
	public Vector2 maxXY;

	public float speed;
	public float roll;


	// Use this for initialization
	void Start () {
		S = this;
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerLogic.S.numLives<1){
			return;
		}
		float xAxis = Input.GetAxis ("Horizontal");
		float yAxis = Input.GetAxis ("Vertical");

		Vector3 pos = this.transform.position;
		pos.x += xAxis * speed * Time.deltaTime;
		pos.y += yAxis * speed * Time.deltaTime;
		this.transform.position = pos;

		PlayerLogic.S.playerModel.transform.rotation = PlayerLogic.S.playerModel.transform.rotation * Quaternion.Euler(new Vector3 (0f,xAxis*roll,0f));

		this.transform.position= new Vector3(
			Mathf.Clamp(this.transform.position.x, minXY.x, maxXY.x),
			Mathf.Clamp (this.transform.position.y, minXY.y, maxXY.y),
			0);

	
	}
}
