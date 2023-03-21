using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
	public RectTransform mainMenu;
	public RectTransform gameConfigMenu;


	public void ToMainMenu()
	{
		gameConfigMenu.gameObject.SetActive(false);
		mainMenu.gameObject.SetActive(true);
	}
	public void PrepareGame()
	{
		mainMenu.gameObject.SetActive(false);
		gameConfigMenu.gameObject.SetActive(true);
	}
	
      public void RestartGame()
    {
		Debug.Log("Restart");
        SceneManager.LoadScene("CircuitTest");
    }

    public void QuitGame()
    {
		Debug.Log("Quit");
        Application.Quit();
		//quit the game in the editor
	    #if UNITY_EDITOR	
		        UnityEditor.EditorApplication.isPlaying = false;
	    #endif
    }
}
