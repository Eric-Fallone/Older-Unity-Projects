using UnityEngine;
using System.Collections;

public class Slot : MonoBehaviour {

	public Note note;
	public int num;

	void OnTriggerEnter(Collider other) {

		note = other.gameObject.GetComponent<Note>();
		if(note.slot != num){
			note = null;
		}
	}
	void OnTriggerExit(Collider other) {
		if(note==null){
			return;
		}
		Song.S.notesMisses += 1;
		Song.S.miss.text = "Miss: "+Song.S.notesMisses;
		if(note!=null){
			note.destroySelf();
		}
		note = null;
	}
}
