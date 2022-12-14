using UnityEngine;

public class BuyButton : ButtonBaseScript
{
	protected override void OnClick()
	{
		base.OnClick();
		ActionManager.OnBuy?.Invoke();
	}
}
