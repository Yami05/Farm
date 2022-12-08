using UnityEngine;


public enum PoolItems
{

}

public enum AnimType
{
	Idle = 0,
	Walk = 1,
	Watering = 2,
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
