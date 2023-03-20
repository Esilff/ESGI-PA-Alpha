using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
      public void RestartGame()
    {
		Debug.Log("Restart");
        SceneManager.LoadScene("CircuitTest");
    }

    public void QuitGame()
    {
		Debug.Log("Quit");
        Application.Quit();
    }
}
