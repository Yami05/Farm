using UnityEngine;

public class AnimationController : MonoBehaviour
{
	[SerializeField] private Animator anim;

	void Start()
	{
		GameEvents.Start += () => PlayAnim(AnimType.Idle);
	}

	public void PlayAnim(AnimType type)
	{
		anim.SetInteger(Utilities.AnimState, (int)type);
	}
}
