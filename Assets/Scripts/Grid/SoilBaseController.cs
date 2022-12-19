using UnityEngine;

public class SoilBaseController : MonoBehaviour
{
	protected GridBase grid;

	protected virtual void OnFinished()
	{
		
	}

	public virtual void Init(GridBase grid)
	{
		this.grid = grid;
	}
}
