using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {

	public gameRunner runner;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Apple") {
			runner.addScore (1);
		}
		Destroy(other.gameObject);
	}
}
