using UnityEngine;
using System.Collections;
using System;
using System.IO;


public class Song : MonoBehaviour {
	public static Song S;
	//----------------------
	public AudioClip[] soundClips;
	public AudioClip soundError; 
	public Slot[] slots;
	public GameObject mover;
	public Note noteGameObject;
	public float zIncrement;
	public float startingYpos; 
	//----------------------

	public string seed;
	public float yPos = 0;

	public int noteLength;
	public int notesMisses =0;
	public int notesPoor=0;
	public int notesGood=0;
	public int errors=0;

	public GUIText good;
	public GUIText poor;
	public GUIText miss;
	public GUIText error;

	//---example code from online
	protected FileInfo theSourceFile = null;
	protected StreamReader reader = null;
	protected string text = " ";
	
	
	// Use this for initialization
	void Start () {
		S = this;
		if(slots.Length!=5){
			Debug.Log("bad number of slots");
		}
		genSeed ();
		//get shakespear passage
		if(seed.Equals("")){
			int end = UnityEngine.Random.Range(75,100);
			for(int c=0;c < end ; c++){
				seed += UnityEngine.Random.Range(0,6);
			}
			//seed = "1234501020304050";
		}
		yPos = startingYpos;
		//generating the notes
		foreach (char c in seed) {
			if(!(c.Equals('0'))){
				noteLength+=1;
				genNote(c);
			}
			yPos=yPos+zIncrement;
		}
	}



	// Update is called once per frame
	void Update () {
		if(mover.transform.childCount == 0){

		}
		//if(Input.anyKeyDown == true){
		//	Debug.Log (Input.inputString);
		//}
		//---------------key presses
		//slot one
		if(Input.GetKeyDown("1") == true){
			hitNote(0);
		}
		//slot two
		if(Input.GetKeyDown("2") == true){
			hitNote(1);
		}
		//slot three
		if(Input.GetKeyDown("3") == true){
			hitNote(2);;
		}
		//slot four
		if(Input.GetKeyDown("4") == true){
			hitNote(3);
		}
		//slot five
		if(Input.GetKeyDown("5") == true){
			hitNote(4);
		}
		//---------------key presses

	}

	void genNote(char c){
		float xPos= 0;
		float yOffset=0;
		int slotPos=-1;
		if (c.Equals('1')) {
			xPos =-3.25f;
			yOffset=-1.5f;
			slotPos=1;
		}
		if (c.Equals('2')) {
			xPos =-1.75f;
			yOffset = -3.75f;
			slotPos=2;
		}
		if (c.Equals('3')) {
			xPos =0;
			slotPos=3;
		}
		if (c.Equals('4')) {
			xPos =1.75f;
			yOffset=-3.75f;
			slotPos=4;
		}
		if (c.Equals('5')) {
			xPos =3.25f;
			yOffset=-1.5f;
			slotPos=5;
		}
		//Debug.Log (yPos + ":  x:"+xPos);
		Note temp = (Note) GameObject.Instantiate(noteGameObject,new Vector3(xPos,yPos+yOffset,0),Quaternion.identity);
		temp.slot = slotPos;
		temp.transform.parent = mover.transform;

	}

	void hitNote(int num){
		//checks to see if note transform is in range
		if(slots[num].note != null){
			if(Vector3.Distance(slots[num].transform.position,slots[num].note.transform.position)<.5f){
				//good
				notesGood += 1;
				good.text="Good: "+notesGood;
			}else{
				//poor
				notesPoor+= 1;
				poor.text="Poor: "+notesPoor;
			}
			GameObject.Destroy(slots[num].note.gameObject);
		}else{
			//miss
			errors+=1;
			error.text="Errors: "+errors;
		}
	}

	public void genSeed(){
		int bookSelected = UnityEngine.Random.Range (0,1);
		string textLoc ="";
		if(bookSelected==0){
			//Romio
			textLoc="Romio";

		}
		if(bookSelected==1){
			//Midsummer
			textLoc="Midsummer";
		}
		if(textLoc == ""){
			textLoc="Romio";
		}

		theSourceFile = new FileInfo ("Assets/ShakeSpear/"+textLoc+".txt");
		reader = theSourceFile.OpenText ();

	//	while (text != null){

				text = reader.ReadLine();
				Debug.Log(text);
		text = reader.ReadLine();
		Debug.Log(text);
		text = reader.ReadLine();
		Debug.Log(text);
		text = reader.ReadLine();
		Debug.Log(text);
		text = reader.ReadLine();
		Debug.Log(text);

	//	}

	}
}
