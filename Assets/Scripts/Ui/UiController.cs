using UnityEngine;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour {

    public void ReloadGame(){
        SceneManager.LoadScene("FirstScene");
    }

    public void QuitGame(){

        Application.Quit();

    }

}
