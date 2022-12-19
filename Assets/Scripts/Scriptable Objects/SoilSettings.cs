using System;
using UnityEngine;

[Serializable]
public struct SoilPrefs
{
	public SoilTypes soilTypes;
	public AnimType animType;

	public float Offset;
	public int animCount;
}

[CreateAssetMenu(menuName = "Game/SoilSettings")]
public class SoilSettings : ScriptableObject
{
	public SoilPrefs[] SoilPrefs;
}
