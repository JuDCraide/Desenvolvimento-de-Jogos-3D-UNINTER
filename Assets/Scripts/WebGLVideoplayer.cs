
using UnityEngine;
using UnityEngine.Video;

public class WebGLVideoplayer : MonoBehaviour {
    VideoPlayer videoPlayer;
    public string videoName;
    void Start() {
        videoPlayer = GetComponent<VideoPlayer>();
        if (videoPlayer) {
            videoPlayer.url = Application.streamingAssetsPath + "/" + videoName;
            videoPlayer.Prepare();
            videoPlayer.Play();
        }

    }

    void Update() {

    }
}
