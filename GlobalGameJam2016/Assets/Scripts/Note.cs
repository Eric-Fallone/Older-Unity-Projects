using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {

	public int slot;
	public GameObject image;

	public void destroySelf(){
		StartCoroutine (delayDeath());
	}

	public IEnumerator delayDeath(){
		//instatateexploding object 
		yield return new WaitForSeconds(.5f);
		GameObject.Destroy (this.gameObject);
	}

}
