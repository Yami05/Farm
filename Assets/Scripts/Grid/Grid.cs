using Sirenix.OdinInspector;
using UnityEngine;

public class GridBase : MonoBehaviour
{
	[SerializeField] protected bool isAvailable;

	[SerializeField, ReadOnly] private Vector2 coord;

	public bool IsAvailable { get => isAvailable; }	
	public Vector2 Coord { get => coord; }

	public void Init(Vector2 coord)
	{
		this.coord = coord;
	}
}
