using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

public void PlayGame(){
    SceneManager.LoadSceneAsync(1);
}
public void Level2(){
    SceneManager.LoadSceneAsync(2);
}
public void Level3 (){
    SceneManager.LoadSceneAsync(3);
}



public void QuitGame(){
    Application.Quit();
}

}
