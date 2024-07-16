using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour {

    const string gameScene = "MainScene";
    public void QuitGame() {
        Application.Quit();
    }

    public void ChangeScene(string sceneName) {
        //Debug.Log(sceneName);
        SceneManager.LoadScene(sceneName);
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        if (sceneName == gameScene) {
            AudioManager.instance.PlayGameMusic();
        }
    }

    public void restartScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
