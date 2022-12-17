using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : MonoBehaviour
{
	[SerializeField] private float movementSpeed;

	[SerializeField] private int workAmount;

	private float offset = 0.15f;

	public void StartWorking(SoilGrid[] soilGrids)
	{
		StartCoroutine(IEWork(soilGrids));
	}

	private IEnumerator IEWork(SoilGrid[] grids)
	{
		WaitForFixedUpdate wait = new WaitForFixedUpdate();

		int iterator = 0;
		int workIndex = workAmount;

		SoilGrid targetGrid = grids[iterator++];

		for (int i = 0; i < workIndex; i++)
		{
			while ((targetGrid.transform.position - transform.position).magnitude > offset)
			{
				transform.position = Vector3.MoveTowards(transform.position, targetGrid.transform.position, movementSpeed * Time.fixedDeltaTime);
				yield return wait;
			}

			targetGrid = grids[iterator++];

			yield return wait;
		}
	}
}
