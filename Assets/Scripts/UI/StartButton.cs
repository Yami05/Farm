using UnityEngine;

public class StartButton : ButtonBaseScript
{
	protected override void OnClick()
	{
		base.OnClick();
		ActionManager.OnWork?.Invoke();
	}
}
