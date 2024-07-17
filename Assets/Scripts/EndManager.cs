using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class EndManager : MonoBehaviour {

    public TMPro.TextMeshProUGUI barrels;
    public TMPro.TextMeshProUGUI boxes1;
    public TMPro.TextMeshProUGUI boxes2;
    public TMPro.TextMeshProUGUI tires;
    public TMPro.TextMeshProUGUI message;

    void Start() {
        barrels.SetText(StaticResults.barrelsCount.ToString());
        boxes1.SetText(StaticResults.boxes1Count.ToString());
        boxes2.SetText(StaticResults.boxes2Count.ToString());
        tires.SetText(StaticResults.tiresCount.ToString());

        var totalObjectsCollected = StaticResults.barrelsCount +
            StaticResults.boxes1Count +
            StaticResults.boxes2Count +
            StaticResults.tiresCount;
        if (totalObjectsCollected <= 0) {
            message.SetText("\tThe task remains untouched amidst the debris. Without gathering any items, the road to recovery seems daunting. Gear up and strategize for the challenges ahead.");
        }
        else if (totalObjectsCollected <= 5) {
            message.SetText("\tYou've salvaged a few items amidst the wreckage. The path to restoration is long, but every piece counts. Prepare for tougher challenges ahead.");
        }
        else if (totalObjectsCollected <= 10) {
            message.SetText("\tWith careful effort, you've gathered the essentials for recycling. The environment shows signs of recovery. Stay vigilant as you progress to the next phase.");
        }
        else if (totalObjectsCollected <= 15) {
            message.SetText("\tImpressive work! Your diligence has yielded a significant haul for recycling. The land begins to cleanse itself, signaling hope for a renewed future.");
        }
        else {
            message.SetText("\tIncredible! You've amassed an overwhelming supply of recyclables. The landscape transforms as nature begins to reclaim its domain. Your dedication brings us closer to a sustainable tomorrow.");
        }
    }

}
