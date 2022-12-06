using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator anim;

    void Start()
    {
        GameEvents.Start += () => PlayAnim(AnimType.Run);
    }

    public void PlayAnim(AnimType type)
    {
        if (GetComponent<Animator>())
        {
            anim.SetInteger("animState", (int)type);
        }
    }
}


