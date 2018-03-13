using UnityEngine;

// Add an entry to the Assets menu for creating an asset of this type
[CreateAssetMenu(menuName = "ScriptableObjects/AudioManagerSingleton")]
public class AudioManagerSingleton : SingletonScriptableObject<AudioManagerSingleton> {
    public AudioClip audioClip;
    public AudioSource audioSource;

    public void SetClip(AudioClip ac) {
        audioClip = ac;
        audioSource.clip = audioClip;
    }

    public void Stop() {
        audioSource.Stop();
    }

    public void Play() {
        audioSource.Play();
    }

    public GameObject PlayClipAt(AudioClip clip, Vector3 pos) {
        GameObject tempGO = new GameObject("TempAudio"); // create the temp object
        tempGO.transform.position = pos; // set its position
        AudioSource aSource = tempGO.AddComponent<AudioSource>(); // add an audio source
        aSource.clip = clip; // define the clip
                             // set other aSource properties here, if desired
        aSource.Play(); // start the sound
        Destroy(tempGO, clip.length); // destroy object after clip duration
        return tempGO; // return the AudioSource reference
    }
}