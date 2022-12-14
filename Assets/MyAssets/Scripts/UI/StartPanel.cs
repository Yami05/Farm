using UnityEngine;
using UnityEngine.EventSystems;

public class StartPanel : MonoBehaviour, IPointerDownHandler
{
	public void OnPointerDown(PointerEventData eventData)
	{
		GameEvents.Start?.Invoke();
		gameObject.SetActive(false);
	}
}
