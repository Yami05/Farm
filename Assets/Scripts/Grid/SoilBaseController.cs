using UnityEngine;

public class SoilBaseController : MonoBehaviour
{
	protected Grid grid;

	protected virtual void OnFinished()
	{

	}

	public virtual void Init(Grid grid)
	{
		this.grid = grid;
	}
}
