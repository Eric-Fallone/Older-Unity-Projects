using UnityEngine;
using System.Collections;

public class PlayerLogic : MonoBehaviour {
	public static PlayerLogic S;

	public GameObject playerModel;

	public int shotsMissed;
	public int shotsFired=1;

	public int numLives;

	public float shieldDuration;
	public int numShields;
	public GameObject shieldsImage;
	public bool shieldActive;

	public Color onHit;
	public Color normal;

	public Quaternion normalRotation;

	public Renderer playerRenderer;

	public ParticleSystem onHitParticleSystem;
	public ParticleSystem engineParticles;

	// Use this for initialization
	void Start () {
		S = this;
		normal = playerRenderer.material.color;
		normalRotation = playerModel.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {

		if(numLives<0){
			return;
		}

		//change color back to normal
		if(playerRenderer!=null && playerRenderer.material.color !=normal){
			playerRenderer.material.color =
				Color.Lerp(playerRenderer.material.color,
				normal,.05f);
		}
		//model rotation back to normal
		if (playerModel.transform.rotation != normalRotation) {
			playerModel.transform.rotation= Quaternion.Lerp(playerModel.transform.rotation,normalRotation,.1f);
		}

		//use a shield
		if(Input.GetKey(KeyCode.LeftControl)==true){
			if(numShields>0 && shieldActive==false){
				numShields--;
				HUD.S.useShield();
				StartCoroutine(shields());
			}
		}
	}


	public void isHit(){
		if(numLives<0){
			return;
		}
		//if shields are up nothing happens
		if(shieldActive==true){
			return;
		}
		//gets hit loose life and activates shields
		if (this.GetComponentInChildren<Renderer> () != null) {
			this.GetComponentInChildren<Renderer> ().material.color = onHit;
		}

		playerModel.transform.rotation = playerModel.transform.rotation * Quaternion.Euler(new Vector3 (0f,Random.Range(-30,30),0));
		onHitParticleSystem.Play ();
		if (numLives > 1) {
			numLives--;
			HUD.S.loseLife();

			StartCoroutine (shields ());
			return;
		} else {
		//no lives left
			numLives--;
			HUD.S.setGameOverText();
			playerModel.SetActive(false);
			engineParticles.enableEmission=false;
			onHitParticleSystem.Play();
			onHitParticleSystem.Play();

			}
	}
	IEnumerator shields(){
		shieldsImage.SetActive (true);
		shieldActive = true;
		yield return new WaitForSeconds(shieldDuration);
		shieldsImage.SetActive (false);
		shieldActive = false;
	}
	void OnTriggerEnter(Collider other){
		if(other.tag=="Proj_E"){
			GameObject.Destroy(other.gameObject);
		}
		if (other.tag == "Enemy" ) {
			PlayerLogic.S.isHit ();
		}
	}
}
