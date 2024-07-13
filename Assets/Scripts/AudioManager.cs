using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;
    public Sound bgMusic;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

    }

    void Start() {
        bgMusic.InitializeSound();
        Play(bgMusic);
    }

    public void Play(Sound s) {
        if (!s.WasInitialized()) {
            s.InitializeSound();
        }
        s.source.Play();
    }
}
