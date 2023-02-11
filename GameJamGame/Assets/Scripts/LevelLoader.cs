using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
        {
			LoadScene();
        }
	}

	public void LoadScene()
	{
		SceneManager.LoadScene("Level 1");
	}
}
