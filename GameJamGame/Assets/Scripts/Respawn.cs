using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		RespawnPlayer();
	}

	public void RespawnPlayer()
	{
		var currentScene = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene(currentScene);
	}
}
