using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

	public Canvas menuCanvas;
	public Canvas creditsCanvas;
	public void PlayGame()
	{
		SceneManager.LoadScene(1);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void HideCredits()
	{
		creditsCanvas.gameObject.SetActive(false);
		menuCanvas.gameObject.SetActive(true);
	}

	public void ShowCredits()
	{
		menuCanvas.gameObject.SetActive(false);
		creditsCanvas.gameObject.SetActive(true);
	}

	public void LoadMenu()
	{
		SceneManager.LoadScene(0);
	}
}
