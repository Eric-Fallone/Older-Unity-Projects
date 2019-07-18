using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public int Hp;
	// Use this for initialization

	//public GameObject proj;
	public GameObject projOnDeath;
	//public float fireDelay;
	//public float initialDelay;

	public Upgrades upgrade;
	public int dropChance;
	public int[] whatDrops;

	public Color onHit;
	public Color normal;

	public ParticleSystem onHitParticleSystem;
	public GameObject ParticlOnDealth;


	public int scoreValue;



	void Start (){
		normal = renderer.material.color;
		onHitParticleSystem=this.GetComponent<ParticleSystem>();
		//onHit = new Color32 (83,0,255,1);
	}


	void Update () {
		//change color back to normal
		if (renderer.material.color != normal) {
			renderer.material.color = Color.Lerp (renderer.material.color, normal, .05f);
		}
	}

	void OnTriggerEnter(Collider other){
		 
		if (other.tag == "Player" ) {
			PlayerLogic.S.isHit ();
		}
	}

	//retuns hp of ship
	public void getHit(int dam){
		Hp = Hp- dam;
		if (Hp <= 0) {

			//update score
			HUD.S.updateScore(scoreValue);
			onHitParticleSystem.Play();
			//create on dealth projectiles
			if (projOnDeath != null) {
				Instantiate (projOnDeath, this.transform.position, Quaternion.identity);
			}
			if(ParticlOnDealth!=null){
				Instantiate (ParticlOnDealth, this.transform.position, Quaternion.identity);
			}
			//drop upgrades on dealth
			if (whatDrops.Length != 0) {
				//roll for drop
				if (Random.Range (0, 100) < dropChance) {
					Upgrades upTemp = (Upgrades)Instantiate (upgrade, this.transform.position, Quaternion.identity);
					upTemp.setType (
						whatDrops [(int)Random.Range (0, whatDrops.Length)]
					);
				}
			}
			onHitParticleSystem.Play();
			GameObject.Destroy (this.gameObject);
		} else {
			//still alive
			renderer.material.color=onHit;

			onHitParticleSystem.Play();
		}
	}
}
