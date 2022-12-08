using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LosePanel : MonoBehaviour, IPointerDownHandler
{
	private void Restart()
	{
		SceneManager.LoadScene(0);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		Restart();
	}
}
