using UnityEngine;
using System.Collections;

public class Upgrades : MonoBehaviour {
	public int type;
	public GameObject[] typeImage;
	// Use this for initialization
	void Start () {
		this.transform.Rotate(Vector3.up * Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0,100,0) * Time.deltaTime);
	}
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			if(type==-1){
				if(PlayerLogic.S.numShields<3){
					HUD.S.gainShield();
					PlayerLogic.S.numShields++;
				}
			}else{
				PlayerWeapons.S.pickUpWeapon(type);
			}
			
			GameObject.Destroy(this.gameObject);
		}
	}
	public void setType(int i){
		type = i;

		typeImage[i+1].SetActive(true);
	}
}
