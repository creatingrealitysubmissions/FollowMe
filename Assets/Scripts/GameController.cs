using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public PlayerData pd;

    
    // Use this for initialization
    void Start () {
        pd = PlayerData.Instance;
        this.InvokeRepeating("PrintMsg", 3, 5);
    }


    void PrintMsg() {
        Debug.Log(pd.maximumPlayerHealth);
        Debug.Log(pd.startingLives);
    }

    // Update is called once per frame
    void Update () {
    }

    public void NextState() {

    }
}

