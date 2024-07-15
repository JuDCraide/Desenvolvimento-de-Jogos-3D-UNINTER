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

    public int barrelsCount;
    public int boxes1Count;
    public int boxes2Count;
    public int tiresCount;

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
        if (minutes <= 0 && seconds <= 0) {
            EndLevel();
        }
        else if (seconds < 0) {
            minutes--;
            seconds += 59;
        }
        TimeText.SetText(minutes.ToString("00") + ":" + seconds.ToString("00"));

        barrelsCount = barrels.containObjectsQuantity;
        boxes1Count = boxes1.containObjectsQuantity;
        boxes2Count = boxes2.containObjectsQuantity;
        tiresCount = tires.containObjectsQuantity;
    }

    public void EndLevel() {
        Debug.Log("END");
        SceneManager.LoadScene("End");
    }

}
