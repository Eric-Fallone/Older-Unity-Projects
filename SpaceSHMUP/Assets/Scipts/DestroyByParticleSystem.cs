using UnityEngine;
using System.Collections;

public class DestroyByParticleSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Destroy (this.gameObject,GetComponent<ParticleSystem>().duration);
	}
	

}
