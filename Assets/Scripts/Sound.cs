using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound {

    public AudioClip clip;
    public bool loop;

    [Range(0f, 1f)]
    public float volume = 0.5f;
    //[Range(1f, 3f)]
    [Range(-3f, 3f)]
    public float pitch = 1f;

    [HideInInspector]
    public AudioSource source;
    public bool mute;

    private bool initialized = false;

    public void InitializeSound() {
        source = AudioManager.instance.gameObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
        source.loop = loop;
        source.mute = mute;
        initialized = true;
    }

    public bool WasInitialized() {
        return initialized;
    }

    public void ChangelogPitch(float pitch) {
        if(pitch > 3f || pitch< -3f) {
            return;
        }
        this.pitch = pitch;
        source.pitch = pitch;
    }
}
