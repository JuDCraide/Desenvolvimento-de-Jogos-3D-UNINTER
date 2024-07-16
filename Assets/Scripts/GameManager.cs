using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public float seconds = 0;
    public int minutes = 0;
    public TMPro.TextMeshProUGUI TimeText;

    public Overlap barrels;
    public Overlap boxes1;
    public Overlap boxes2;
    public Overlap tires;

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this);
        }
        else {
            instance = this;
        }
    }

    public void Start() {
        TimeText.SetText(minutes.ToString("00") + ":" + seconds.ToString("00"));
    }

    void FixedUpdate() {
        StaticResults.barrelsCount = barrels.containObjectsQuantity;
        StaticResults.boxes1Count = boxes1.containObjectsQuantity;
        StaticResults.boxes2Count = boxes2.containObjectsQuantity;
        StaticResults.tiresCount = tires.containObjectsQuantity;

        seconds -= Time.deltaTime;
        if (minutes <= 0 && seconds <= 0) {
            EndLevel();
        }
        else if (seconds < 0) {
            minutes--;
            seconds += 59;
        }
        TimeText.SetText(minutes.ToString("00") + ":" + seconds.ToString("00"));
    }

    public void EndLevel() {
        Debug.Log("END");
        SceneManager.LoadScene("End");
        AudioManager.instance.PlayMenuMusic();
    }

}
