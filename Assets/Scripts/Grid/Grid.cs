using UnityEngine;

public class GridBase : MonoBehaviour
{
	[SerializeField] protected bool isAvailable;

	protected Vector2 coord;

	public bool IsAvailable { get => isAvailable; }

	public void Init(Vector2 coord)
	{
		this.coord = coord;
	}
}
