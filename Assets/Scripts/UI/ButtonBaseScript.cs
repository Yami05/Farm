using UnityEngine;
using UnityEngine.UI;

public class ButtonBaseScript : MonoBehaviour
{
	private Button myButton;

	private void Awake()
	{
		myButton = GetComponent<Button>();
		myButton.onClick.AddListener(OnClick);
	}

	protected virtual void OnClick()
	{

	}
}
