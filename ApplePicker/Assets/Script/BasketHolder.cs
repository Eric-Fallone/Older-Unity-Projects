using UnityEngine;
using System.Collections;

public class BasketHolder : MonoBehaviour {

	public gameRunner runner;
	public GameObject one;
	public GameObject two;
	public GameObject three;
	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = new Vector3(Input.mousePosition.x,Input.mousePosition.y,0f);
		mousePos = Camera.main.ScreenToWorldPoint (mousePos);
		mousePos.z = 0;
		mousePos.y = -12;
		this.transform.position = mousePos;

	}

	public void destroyBasket(){
		if (one != null) {
			GameObject.Destroy(one.gameObject);
			return;
		}
		if (two != null) {
			GameObject.Destroy(two.gameObject);
			return;
		}
		if (three != null) {
			GameObject.Destroy(three.gameObject);
			runner.gameOver();
			return;
		}
	}
}
