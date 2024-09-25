using UnityEngine;

public class HitEffectAnimator : MonoBehaviour
{
    public void AnimationEnd()
    {
        Destroy(gameObject);
    }
}
