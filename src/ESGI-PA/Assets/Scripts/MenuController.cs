using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
	public RectTransform mainMenu;
	public RectTransform gameConfigMenu;
	public RectTransform optionsMenu;
	public RawImage[] playerImages;

	public bool canEditPlayers;
	
	private void Start()
	{
		canEditPlayers = false;
		foreach (var image in playerImages)
		{
			image.color = Color.gray;
		}
	}

	public void ToMainMenu()
	{
		canEditPlayers = false;
		gameConfigMenu.gameObject.SetActive(false);
		mainMenu.gameObject.SetActive(true);
	}

	public void ToOptions()
	{
		mainMenu.gameObject.SetActive(false);
		optionsMenu.gameObject.SetActive(true);
	}

	public void ExitOptions()
	{
		optionsMenu.gameObject.SetActive(false);
		mainMenu.gameObject.SetActive(true);
	}
	public void PrepareGame()
	{
		canEditPlayers = true;
		mainMenu.gameObject.SetActive(false);
		gameConfigMenu.gameObject.SetActive(true);
	}
	
      public void RestartGame()
    {
		Debug.Log("Restart");
        SceneManager.LoadScene("Menuprincipal");
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
