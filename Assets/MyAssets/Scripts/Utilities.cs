using UnityEngine;


public enum PoolItems
{
	Farmer = 0,
}

public enum AnimType
{
	Idle = 0,
	Walk = 1,
	semination = 2,
	Watering = 3,
	Harvesting = 4,
	Mining = 5,
}

public enum SoilTypes
{
	Obstacle = 0,
	CleanSoil = 1,
	PlantableSoil = 2,
	PlantedSoil = 3,
	HarvestedSoil = 4,
}

public class Utilities : MonoBehaviour
{
	public const string AnimState = "AnimState";
}
