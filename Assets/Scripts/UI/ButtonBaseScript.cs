using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonBaseScript : MonoBehaviour
{
	protected Button myButton;
	protected Vector3 initialScale;

	protected virtual void Awake()
	{
		myButton = GetComponent<Button>();
		myButton.onClick.AddListener(OnClick);

		ActionManager.OnWork += OnWork;
		ActionManager.OnRoundComplete += OnRoundComplete;

		initialScale = transform.localScale;
	}

	protected virtual void OnClick()
	{

	}

	protected virtual void OnWork()
	{
		transform.DOScale(0, 0.25f).SetEase(Ease.InBack);
	}

	protected virtual void OnRoundComplete()
	{
		transform.DOScale(initialScale, 0.25f).SetEase(Ease.OutBack);
	}
}
