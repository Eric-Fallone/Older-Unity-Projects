using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Card : MonoBehaviour {

	public string    suit;
	public int       rank;
	public Color     color = Color.black;
	public string    colS = "Black";  // or "Red"

	//public bool faceUp;

	public List<GameObject> decoGOs = new List<GameObject>();
	public List<GameObject> pipGOs = new List<GameObject>();
	
	public GameObject back;  // back of card;
	public CardDefinition def;  // from DeckXML.xml		

	public SpriteRenderer[] spriteRenderes;

	void Start(){
		SetSortingOrder (0);
	}

	public void PopulateSpriteRenderes(){
		if (spriteRenderes == null || spriteRenderes.Length == 0) {
			spriteRenderes = GetComponentsInChildren<SpriteRenderer>();
		}
	}

	public void SetSortingLayerName(string tSLN){
		PopulateSpriteRenderes ();

		foreach(SpriteRenderer tSR in spriteRenderes){
			tSR.sortingLayerName = tSLN;
		}
	}

	public void SetSortingOrder(int sOrd){
		PopulateSpriteRenderes();

		foreach(SpriteRenderer tSR in spriteRenderes){
			if(tSR.gameObject == this.gameObject){
				tSR.sortingOrder = sOrd;
				continue;
			}
			switch(tSR.gameObject.name){
			case "back":
				tSR.sortingOrder = sOrd+2;
				break;
			case"face":
			default:
				tSR.sortingOrder=sOrd+1;
				break;
			}
		}
	}
	virtual public void OnMouseUpAsButton(){
		Debug.Log (name);
	}

	public bool faceUp{
		get{
			return(!back.activeSelf);
		}
		set {
			back.SetActive(!value);
		}
	}

} // class Card

[System.Serializable]
public class Decorator{
	public string	type;			// For card pips, tyhpe = "pip"
	public Vector3	loc;			// location of sprite on the card
	public bool		flip = false;	//whether to flip vertically
	public float 	scale = 1.0f;
}

[System.Serializable]
public class CardDefinition{
	public string	face;	//sprite to use for face cart
	public int		rank;	// value from 1-13 (Ace-King)
	public List<Decorator>	
					pips = new List<Decorator>();  // Pips Used
}
