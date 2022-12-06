using UnityEditor;
using UnityEngine;
using Sirenix.OdinInspector;

public class GridMaker : MonoBehaviour
{
	[SerializeField] private int length;
	[SerializeField] private int width;
	[SerializeField] private GameObject gridPrefab;
	[SerializeField] private Transform gridParent;

#if UNITY_EDITOR

	[Button]
	private void CreateVoxel()
	{
		int forAmount = gridParent.childCount;

		for (int i = 0; i < forAmount; i++)
		{
			DestroyImmediate(gridParent.GetChild(0).gameObject);
		}

		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < length; j++)
			{
				Grid grid = (PrefabUtility.InstantiatePrefab(gridPrefab, gridParent) as GameObject).GetComponent<Grid>();
				grid.transform.position = new Vector3(i, 0, j);
				grid.Init(new Vector2(j, i));
			}
		}
	}

#endif
}
