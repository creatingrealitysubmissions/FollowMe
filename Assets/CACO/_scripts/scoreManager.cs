using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreManager : MonoBehaviour {

	public GameObject star1;
	public GameObject star2;
	public GameObject star3;
	public GameObject star4;

	public AudioSource starSuccess;

	public int score = 0;


	// Use this for initialization
	void Start () {

		starSuccess = gameObject.GetComponent<AudioSource> ();
		starSuccess.Play ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (score == 1) {
			star1.SetActive (true);
		}
		if (score == 2) {
			star2.SetActive (true);
		}
		if (score == 3) {
			star3.SetActive (true);
		}
		if (score == 4) {
			star4.SetActive (true);
		}
		
	}

	public void ScoreCounter(){
		score++;
		starSuccess.Play ();
	}

}
