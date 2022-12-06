using UnityEngine;

public class Grid : MonoBehaviour
{
	[SerializeField] private bool isAvailable;
	[SerializeField] private SoilBaseController[] soilBaseControllers;

	private Vector2 coord;

	public bool IsAvailable { get => isAvailable; }

	public void Init(Vector2 coord)
	{
		this.coord = coord;
	}
}
