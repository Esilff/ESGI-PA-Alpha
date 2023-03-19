using UnityEngine;
using UnityEngine.SceneManagement;

public class menufin : MonoBehaviour
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
