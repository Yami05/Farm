using UnityEditor;
using UnityEngine;
using Sirenix.OdinInspector;
using System;
using System.Linq;
using System.Collections.Generic;

public class GridController : MonoBehaviour
{
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


	[SerializeField] private SoilGrid[] soilGrids;
	[SerializeField] private InventoryGrid[] inventoryGrids;

	[SerializeField] private List<GameObject> farmers = new List<GameObject>();

	private ObjectPool pool;

	private void Awake()
	{
		ActionManager.OnBuy += OnBuy;
		ActionManager.OnWork += OnWork;
		ActionManager.OnFarmerRunEnd += OnRunEnd;
	}

	private void Start()
	{
		pool = ObjectPool.instance;
	}

	private bool isEmpty(int i) => inventoryGrids[i].Farmer == null;
	private void OnBuy()
	{
		for (int i = 0; i < inventoryGrids.Length; i++)
		{

			if (isEmpty(i))
			{
				GameObject farmer = pool.GetFromPool(PoolItems.Farmer);
				inventoryGrids[i].Farmer = farmer.GetComponent<Farmer>();
				farmer.transform.position = inventoryGrids[i].transform.position;
				farmer.GetComponent<Farmer>().SetFirstPos(inventoryGrids[i].transform);
				farmers.Add(farmer);
				break;
			}
		}
	}

	private void OnWork()
	{
		List<InventoryGrid> invGrids = Array.FindAll(inventoryGrids, a => a.Farmer != null).ToList();
		int iterator = 0;

		for (int i = 0; i < width; i++)
		{
			var tempSoilGrids = new SoilGrid[length];

			for (int j = 0; j < length; j++)
			{
				tempSoilGrids[j] = soilGrids[iterator++];
			}

			for (int k = 0; k < invGrids.Count; k++)
			{
				if (invGrids[k].Coord.x == i)
				{
					InventoryGrid grid = invGrids[k];
					grid.Farmer.StartWorking(tempSoilGrids);

					invGrids.RemoveAt(k--);
				}
			}
		}
	}

	#region RunControl

	private int farmerIndex;
	private void OnRunEnd()
	{
		farmerIndex++;
		if (farmerIndex == farmers.Count)
		{
			farmerIndex = 0;
			ActionManager.OnRoundComplete?.Invoke();
			print("RunFinished");
		}
	}

	#endregion

#if UNITY_EDITOR
	#region GridMaker

	[Button]
	private void CreateVoxel()
	{
		for (int i = gridParent.childCount - 1; i >= 0; i--)
			DestroyImmediate(gridParent.GetChild(0).gameObject);

		for (int i = inventoryParent.childCount - 1; i >= 0; i--)
			DestroyImmediate(inventoryParent.GetChild(0).gameObject);

		soilGrids = new SoilGrid[width * length];
		inventoryGrids = new InventoryGrid[width * inventoryLenght];

		int iterator = 0;
		int iterator1 = 0;

		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < length; j++)
			{
				SoilGrid grid = (PrefabUtility.InstantiatePrefab(soilGridPrefab, gridParent) as GameObject).GetComponent<SoilGrid>();
				grid.transform.localPosition = new Vector3(i, 0, j);
				grid.Init(new Vector2(i, j));
				soilGrids[iterator1++] = grid;
			}

			for (int j = 0; j < inventoryLenght; j++)
			{
				InventoryGrid grid = (PrefabUtility.InstantiatePrefab(inventoryGridPrefab, inventoryParent) as GameObject).GetComponent<InventoryGrid>();
				grid.transform.localPosition = new Vector3(i, 0, -j - (inventoryZOffset));
				grid.Init(new Vector2(i, j));
				inventoryGrids[iterator++] = grid;
			}
		}

		transform.position = new Vector3((width * -0.5f) + 0.5f, transform.position.y, transform.position.z);

	}
	#endregion
#endif
}
