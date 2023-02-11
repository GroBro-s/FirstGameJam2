using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoSpawnArea : MonoBehaviour
{
//Dit script kan weg als ik een radius om de checkpoint gooi en deze check doe als de player buiten die radius is gewandeld
//maar dan moet ik daar nog wel een manier voor vinden.
	[SerializeField] private GameObject checkpoint;
	private PlayerChanger playerChanger;


	private void Awake()
	{
		playerChanger = checkpoint.GetComponent<PlayerChanger>();
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			playerChanger.directlySpawned = false;
		}
	}
}