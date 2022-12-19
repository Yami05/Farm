using System;
using UnityEngine;

public class SoilGrid : GridBase
{
	[SerializeField] private SoilBaseController[] soilBaseControllers;
	[SerializeField] private SoilSettings soilSettings;
	[SerializeField] private float offset;

	private int SoilGridIndex = 0;

	public float Offset { get => soilSettings.SoilPrefs[SoilGridIndex].Offset; }

	public void ChangeType(Action<AnimType, int> action)
	{
		var currentSettings = soilSettings.SoilPrefs[SoilGridIndex];
		action(currentSettings.animType, currentSettings.animCount);
	}

	public void InitType()
	{
		soilBaseControllers[SoilGridIndex].gameObject.SetActive(false);

		SoilGridIndex = (SoilGridIndex + 1) % soilBaseControllers.Length;
		soilBaseControllers[SoilGridIndex].gameObject.SetActive(true);
	}
}
