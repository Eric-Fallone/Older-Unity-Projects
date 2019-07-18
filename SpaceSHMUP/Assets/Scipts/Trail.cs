using UnityEngine;
using System.Collections;

public class Trail : MonoBehaviour {

	public Color target;
	public float decaySpeed;

	// Update is called once per frame
	void Start(){

	}
	void Update () {
		if (renderer.material.color != target) {
			renderer.material.color = Color.Lerp (renderer.material.color, target, Time.deltaTime * decaySpeed);
		} else {

			GameObject.Destroy (this.gameObject);
		}
	}
}
