using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    [RequireComponent(typeof(Renderer))]
    public class Keywords : MonoBehaviour, ISpeechHandler
    {
        MeshRenderer render;

        public void Awake()
        {
            render = gameObject.GetComponent<MeshRenderer>();
        }

        public void success(string command)
        {
            
            switch (command)
            {
                case "alarm":
                    render.enabled = false;
                    break;
                case "safe":
                    render.enabled = false;
                    break;
                case "exit":
                    render.enabled = false;
                    break;
            }
        }

        public void OnSpeechKeywordRecognized(SpeechEventData eventData)
        {
            success(eventData.RecognizedText);
        }
    }
}

