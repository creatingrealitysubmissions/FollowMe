using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playanim : MonoBehaviour {

	//takes the gameobjects child and turns on and off the object to reveal the animation

	public bool isThisOn = false;
	public GameObject showObject; // switch on and off to show the underlying animation

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (isThisOn) {
			//Debug.Log ("play anim");
			showObject.SetActive (true);
		} 
		if (!isThisOn) {
			showObject.SetActive (false);
		}
		
	}
}
