using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

public void PlayGame(){
    SceneManager.LoadSceneAsync(1);
}

}
