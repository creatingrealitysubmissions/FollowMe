using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterAnimScript : MonoBehaviour {

    private static MasterAnimScript _instance;
    public Animator m_Animator;

    public static MasterAnimScript Instance {
        get {
            if (_instance == null) {
                GameObject obj = new GameObject("Game Manager");
                MasterAnimScript anim = obj.AddComponent<MasterAnimScript>();
                _instance = anim;
            }

            return _instance;
        }
    }

    void Awake() {
        _instance = this;
        m_Animator = GetComponent<Animator>();
    }


    public void PlayClip(string clip_name) {
        //m_Animator.SetBool(clip_name, true);
        m_Animator.Play(clip_name);
    }
}
