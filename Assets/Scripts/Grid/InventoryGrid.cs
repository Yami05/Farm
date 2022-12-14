using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGrid : GridBase
{
	[SerializeField] private Farmer farmer;

	public Farmer Farmer { get => farmer; }
}
