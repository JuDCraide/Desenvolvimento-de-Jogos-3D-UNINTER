using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour {

    public TMPro.TextMeshProUGUI barrels;
    public TMPro.TextMeshProUGUI boxes1;
    public TMPro.TextMeshProUGUI boxes2;
    public TMPro.TextMeshProUGUI tires;

    void Start() {
        barrels.SetText(StaticResults.barrelsCount.ToString());
        boxes1.SetText(StaticResults.boxes1Count.ToString());
        boxes2.SetText(StaticResults.boxes2Count.ToString());
        tires.SetText(StaticResults.tiresCount.ToString());
    }

}
