using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour {
    public void QuitGame() {
        Application.Quit();
    }

    public void ChangeScene(string sceneName) {
        //Debug.Log(sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public void restartScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
