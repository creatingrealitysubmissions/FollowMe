using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AudioTriggerInteraction : MonoBehaviour, ITargetInteraction {
    private BoxCollider boxCol;
    public Renderer[] renderers;
    public SequenceState seqState;
    public AudioManagerSingleton audioManager;

    public string keyword;
    public string targetkeyword = "yes";
    bool isKeywordSaid = false;

    // Use this for initialization
    void Start() {
        boxCol = GetComponent<BoxCollider>();
        renderers = GetComponentsInChildren<Renderer>();
        audioManager = AudioManagerSingleton.Instance;

        if(GetComponentInChildren<TextMeshProUGUI>() != null) {
            TextMeshProUGUI textMesh =GetComponentInChildren<TextMeshProUGUI>();
            textMesh.text = targetkeyword;
        }
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
        audioManager.PlayClipAt(seqState.successClip, this.transform.position);
    }

    public void RenderSuccessColor() {
        foreach (Renderer renderer in renderers) {
            renderer.material.color = Color.green;
        }
    }

    public void MessageGameController() {
        Debug.Log("Tell GM trigger entered");
    }

    public void Success() {
        MessageGameController();
        RenderSuccessColor();
        PlayAudio();
    }
}
