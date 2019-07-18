using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour {
	 BasketHolder bask;
	// Use this for initialization
	void Start () {
		bask= (BasketHolder)GameObject.FindObjectOfType(typeof(BasketHolder));
		//StartCoroutine(destroyByTime ());
	}
	void Update () {
		if (this.transform.position.y < -20) {
			bask.destroyBasket ();
			GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
			for(int i =0; i<apples.Length;i++ ){
				GameObject.Destroy(apples[i].gameObject);
			}
		}
	}

	IEnumerator destroyByTime(){
		yield return new WaitForSeconds(2.3f);
		bask.destroyBasket ();
		GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
		for(int i =0; i<apples.Length;i++ ){
			GameObject.Destroy(apples[i].gameObject);
		}
	}
}
