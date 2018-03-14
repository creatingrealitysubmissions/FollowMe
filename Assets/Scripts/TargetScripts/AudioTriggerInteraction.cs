using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;
public class AudioTriggerInteraction : MonoBehaviour, ITargetInteraction {
    private BoxCollider boxCol;
    public Renderer[] renderers;
    public SequenceState seqState;
    public AudioManagerSingleton audioManager;

    public string keyword;
    public string targetkeyword = "yes";
    bool isKeywordSaid = false;

    public GameObject naviGameObject;


    // Use this for initialization
    void Start() {
        boxCol = GetComponent<BoxCollider>();
        renderers = GetComponentsInChildren<Renderer>();
        audioManager = AudioManagerSingleton.Instance;
        /*
        if(GetComponentInChildren<TextMeshProUGUI>() != null) {
            TextMeshProUGUI textMesh =GetComponentInChildren<TextMeshProUGUI>();
            textMesh.text = targetkeyword;
        }
    */
    }


    private void OnTriggerEnter(Collider other) {
        Debug.Log("Triggered");
        
    }

    public void Update() {
        if (CheckKeyword()) {
            Success();
        }
    }

    public bool CheckKeyword() {
        if (keyword == targetkeyword ) {
            isKeywordSaid = true;
            keyword = "";
            return true;
        } else {
            isKeywordSaid = true;
            return false;
        }     
    }

    public void PlayAudio() {
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
        PlayAudio();

        PlayAnimation();
        PlaySecondaryAnimation();
    }

    //For main navi
    public void PlayAnimation() {
        if (naviGameObject != null)
            naviGameObject.GetComponent<naviAnimation>().MoveToNextAnim();
       // Debug.Log("playing:" + seqState.naviAnimClipName);

        //if (seqState.navi_avatar_animator != null && seqState.naviAnimClipName != null)
        //    seqState.navi_avatar_animator.Play(seqState.naviAnimClipName);
    }

    //For extra effects
    public void PlaySecondaryAnimation() {
        Debug.Log("playing:" + seqState.addAnimClipName);
        if (seqState.navi_avatar_animator != null && seqState.addAnimClipName != null)
            seqState.additional_animator.Play(seqState.addAnimClipName);
    }
}
