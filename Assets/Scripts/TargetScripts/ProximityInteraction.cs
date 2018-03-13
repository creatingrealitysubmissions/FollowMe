using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityInteraction : MonoBehaviour, ITargetInteraction {
    private BoxCollider boxCol;
    public Renderer[] renderers;
    public SequenceState seqState;
    public AudioManagerSingleton audioManager;

	// Use this for initialization
	void Start () {
        boxCol = GetComponent<BoxCollider>();
        renderers = GetComponentsInChildren<Renderer>();
        audioManager = AudioManagerSingleton.Instance;
	}

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Triggered");
        Success();
    }

    public void PlayAudio() {
        //audioManager.SetClip(seqState.successClip);
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
