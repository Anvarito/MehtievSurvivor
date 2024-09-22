using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Transform _target;
    private bool _isDeadAnim = false;
    private SpriteRenderer _spriteRenderer;

    public void SetTargetToSearch(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        if(_isDeadAnim)
            transform.Rotate(Vector3.forward * 10, Space.World);
    }

    public void DeadAnimation()
    {
        _isDeadAnim = true;
    }
}
