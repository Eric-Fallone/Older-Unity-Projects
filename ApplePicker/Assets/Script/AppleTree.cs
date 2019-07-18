using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour {

	public GameObject apple;
	public Transform spawnSpot;
	public bool gameRunning;
	public GUIText roundText;
	int numRound=1;
	int prevApple=6;

	public float speed;
	public float maxSpeed;
	//right is positive
	public int goingRight;
	public bool roundOver= false;

	public float minX;
	public float maxX;
	// Use this for initialization
	void Start () {
		goingRight = 1;
		StartCoroutine (DropApples());
		StartCoroutine (movement());
	}

	IEnumerator movement(){
		while (gameRunning==true) {
			while(roundOver==false){

				if(1==(int)Random.Range(0,15)){
					goingRight=goingRight*-1;
				}
				this.transform.rigidbody.velocity=this.transform.rigidbody.velocity + new Vector3(goingRight*(speed),0f,0f);
				if(goingRight==1 && this.transform.rigidbody.velocity.x>maxSpeed){
					this.transform.rigidbody.velocity= new Vector3(goingRight * maxSpeed,0f,0f);
				}
				if(goingRight==-1 && this.transform.rigidbody.velocity.x<(maxSpeed*-1)){
					this.transform.rigidbody.velocity= new Vector3(goingRight * maxSpeed,0f,0f);
				}
				yield return new WaitForSeconds (.1f);
			}
			yield return new WaitForSeconds (1);
		}
	}

	IEnumerator DropApples(){
		while (gameRunning==true) {
			for(int i=prevApple;i>0;i=i-1){

				if(gameRunning==false){
					break;
				}
				Instantiate (apple, spawnSpot.position, Quaternion.identity);
				yield return new WaitForSeconds(.5f);

				}
			prevApple=prevApple+((int)Random.Range(1,4));
			roundOver=true;
			this.rigidbody.velocity=new Vector3(0f,0f,0f);
			yield return new WaitForSeconds(3);
			roundOver=false;
			if(gameRunning==false){
				break;
			}
			numRound=numRound+1;

			roundText.text="Round: "+numRound;
			}
		}


	// Update is called once per frame
	void Update () {

		this.transform.position = new Vector3 (Mathf.Clamp (rigidbody.position.x, minX, maxX), this.transform.position.y,0f);

		if (goingRight == 1 && this.transform.position.x==maxX) {
			goingRight=-1;
		}
		if (goingRight == -1 && this.transform.position.x==minX) {
			goingRight=1;
		}
	}
}
