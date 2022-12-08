using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class WinPanel : MonoBehaviour, IPointerDownHandler
{
	private void NextLevel()
	{
		SceneManager.LoadScene(0);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		NextLevel();
	}
}
