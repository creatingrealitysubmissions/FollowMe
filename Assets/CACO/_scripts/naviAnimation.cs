using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naviAnimation : MonoBehaviour {

	public Animation currentAnim;

	public int animPos = 0;

	// Use this for initialization
	void Start () {
		currentAnim = gameObject.GetComponent<Animation> ();
	}

	public void NaviAnimPlay(){

		if (animPos == 1) {
			currentAnim.Play ("IntroToFireAlarm");
		}
		if (animPos == 2) {
			currentAnim.Play ("FireAlarmToDoor");
		}
		if (animPos == 3) {
			currentAnim.Play ("DoorToExit");
		}
		if (animPos == 4) {
			currentAnim.Play ("ExitToTop");
		}
	}

	//moves to the next animation
	public void MoveToNextAnim(){
		animPos++;
        NaviAnimPlay();
    }
}
