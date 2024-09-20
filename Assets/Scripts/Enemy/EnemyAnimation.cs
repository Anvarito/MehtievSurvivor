using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Transform _target;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void SetTargetToMove(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        _spriteRenderer.flipX = _target.transform.position.x < transform.position.x;
    }
}
