using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public float seconds = 0;
    public int minutes = 0;
    public TMPro.TextMeshProUGUI TimeText;

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
        seconds -= Time.deltaTime;
        if (seconds < 0) {
            minutes--;
            seconds += 59;
        }
        if (minutes <= 0 && seconds <= 0) {
            EndLevel();
        }
        TimeText.SetText(minutes.ToString("00") + ":" + seconds.ToString("00"));
    }

    public static void EndLevel() {
        Debug.Log("END");
    }

}
