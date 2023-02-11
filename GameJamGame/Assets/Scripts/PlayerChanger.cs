using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChanger : MonoBehaviour
{
	[SerializeField] private GameObject[] playerFormat;
	[SerializeField] private Transform spawnPosition;
	private int currentFormat;
	public bool directlySpawned = false;


	private void Start()
	{
		if (GameObject.Find("Small Player")) { currentFormat = 0; }
		else { currentFormat = 1; }
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		ChangePlayer(collision);
	}

	private void ChangePlayer(Collision2D collision)
	{
		if (directlySpawned == false)
		{
			Destroy(collision.gameObject);
			var formatChooser = (currentFormat == 0 ? 1 : 0);
			currentFormat = formatChooser;
			GameObject newPlayer = Instantiate(playerFormat[formatChooser], spawnPosition.position , Quaternion.identity);
			newPlayer.name = newPlayer.name.Replace("(Clone)", "");

			newPlayer.transform.position = new Vector3(newPlayer.transform.position.x, newPlayer.transform.position.y + (formatChooser * 1), newPlayer.transform.position.z);
			directlySpawned = true;
		}
	}
}