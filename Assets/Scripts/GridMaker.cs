using UnityEditor;
using UnityEngine;
using Sirenix.OdinInspector;

public class GridMaker : MonoBehaviour
{
	[SerializeField] private SoilGrid[,] soilGrids;
	[SerializeField] private InventoryGrid[,] inventoryGrids;



#if UNITY_EDITOR
	#region GridMaker

	[Header("GridPreferences")]
	[SerializeField] private int length;
	[SerializeField] private int width;
	[SerializeField] private int inventoryLenght;
	[SerializeField] private float inventoryZOffset;

	[Header("GridProperties")]
	[SerializeField] private Transform gridParent;
	[SerializeField] private GameObject soilGridPrefab;
	[SerializeField] private GameObject inventoryGridPrefab;
	[SerializeField] private Transform inventoryParent;

	[Button]
	private void CreateVoxel()
	{
		for (int i = gridParent.childCount - 1; i >= 0; i--)
			DestroyImmediate(gridParent.GetChild(0).gameObject);

		for (int i = inventoryParent.childCount - 1; i >= 0; i--)
			DestroyImmediate(inventoryParent.GetChild(0).gameObject);

		soilGrids = new SoilGrid[width, length];
		inventoryGrids = new InventoryGrid[width, inventoryLenght];

		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < length; j++)
			{
				SoilGrid grid = (PrefabUtility.InstantiatePrefab(soilGridPrefab, gridParent) as GameObject).GetComponent<SoilGrid>();
				grid.transform.localPosition = new Vector3(i, 0, j);
				grid.Init(new Vector2(i, j));
				soilGrids[i, j] = grid;

			}

			for (int j = 0; j < inventoryLenght; j++)
			{
				InventoryGrid grid = (PrefabUtility.InstantiatePrefab(inventoryGridPrefab, inventoryParent) as GameObject).GetComponent<InventoryGrid>();
				grid.transform.localPosition = new Vector3(i, 0, -j - (inventoryZOffset));
				grid.Init(new Vector2(i, j));
				inventoryGrids[i, j] = grid;
			}
		}

	}
	#endregion
#endif
}
