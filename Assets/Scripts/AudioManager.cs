using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;
    public Sound bgMenuMusic;
    public Sound bgGameMusic;

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
        bgMenuMusic.InitializeSound();
        if (SceneManager.GetActiveScene().name == "MainScene") {
            PlayGameMusic();
        } else {
            PlayMenuMusic();
        }
    }

    public void Play(Sound s) {
        if (!s.WasInitialized()) {
            s.InitializeSound();
        }
        s.source.Play();
    }

    public void Stop(Sound s) {
        s.source.Stop();
    }

    public void PlayGameMusic() {
        Stop(bgMenuMusic);
        bgGameMusic.InitializeSound();
        Play(bgGameMusic);
    }

    public void PlayMenuMusic() {
        Stop(bgGameMusic);
        bgMenuMusic.InitializeSound();
        Play(bgMenuMusic);
    }
}
