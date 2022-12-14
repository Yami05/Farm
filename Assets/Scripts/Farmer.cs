using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : MonoBehaviour
{
	public void StartWorking(InventoryGrid[] inventoryGrids)
	{
		for (int i = 0; i < inventoryGrids.Length; i++)
		{
			Debug.Log(inventoryGrids[i].name);
		}
	}
}
