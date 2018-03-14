using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityInteraction : MonoBehaviour, ITargetInteraction {
    private BoxCollider boxCol;
    public Renderer[] renderers;
    public SequenceState seqState;
    public AudioManagerSingleton audioManager;

    public GameObject naviGameObject;
    public bool hasPlayed;

    public bool isEnd;

    public scoreManager ScoreManager;

    public GameObject extraAnimObj;
    //public bool playsAnimation;
    //public string animtransitionname;

    public bool isPlayAudioThenAnim;
    
    // Use this for initialization
    void Start () {
        hasPlayed = false;
        boxCol = GetComponent<BoxCollider>();
        renderers = GetComponentsInChildren<Renderer>();
        audioManager = AudioManagerSingleton.Instance;
	}

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Triggered");
        if (!hasPlayed) {
            hasPlayed = true;
            Success();
        }
    }

    public void PlayAudio() {
        //audioManager.SetClip(seqState.successClip);
        Debug.Log("playing audio");
        AudioManager.Instance.PlayClipAt(seqState.successClip, this.transform.position);
    }

    public void RenderSuccessColor() {
        foreach (Renderer renderer in renderers) {
            renderer.material.color = Color.green;
        }
    }

    public void Success() {
        RenderSuccessColor();
        if (isPlayAudioThenAnim) {
            PlayAudio();
            Invoke("PlayAnimation", 15);
            Invoke("PlaySecondaryAnimation", 15);

        } else {
            PlayAudio();
            PlayAnimation();
            PlaySecondaryAnimation();   
        }

        if (isEnd) {
            EndSequence();
        }
    }

    //For main navi
    public void PlayAnimation() {
        if (naviGameObject != null)
            naviGameObject.GetComponent<naviAnimation>().MoveToNextAnim();

        /*
         Debug.Log("playing:" + seqState.naviAnimClipName);

        if(seqState.navi_avatar_animator != null && seqState.naviAnimClipName != null)
            seqState.navi_avatar_animator.Play(seqState.naviAnimClipName);
         */
    }

    /*
    //For extra effects
    public void PlaySecondaryAnimation() {
        Debug.Log("playing:" + seqState.addAnimClipName);
        if (seqState.navi_avatar_animator != null && seqState.addAnimClipName != null)
            seqState.additional_animator.Play(seqState.addAnimClipName);
    }
    */

    //For extra effects
    public void PlaySecondaryAnimation() {
        //Debug.Log("playing:" + seqState.addAnimClipName);
        if (extraAnimObj != null)
            extraAnimObj.GetComponent<playanim>().isThisOn = true ;
    }

    public void EndSequence() {
        ScoreManager.ScoreCounter();
    }
}
