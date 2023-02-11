using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	string sceneName;


	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
        {
			LoadScene();
        }
	}

	public void LoadScene()
	{
		sceneName = SceneManager.GetActiveScene().name;
		if(sceneName == "Main Menu")
		{
			SceneManager.LoadScene("TutorialLevel1");
			print("TutorialScene loaded");
		}
		if(sceneName == "TutorialLevel1")
		{
			SceneManager.LoadScene("Level 1");
		}
		if(sceneName == "Level 1")
		{
			SceneManager.LoadScene("Main Menu");
		}
		print("LoadScene called");
	}

	public void ExitScene()
	{
		Application.Quit();	
	}
}
