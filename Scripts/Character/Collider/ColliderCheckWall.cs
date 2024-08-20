using System;
using UnityEngine;

namespace Character.Collider
{
    public class ColliderCheckWall : MonoBehaviour
    {
        [SerializeField] private float wallCheckDistance;
        [SerializeField] private SpriteRenderer flipSprite;
        [SerializeField] private LayerMask wallLayerMask;
        private Vector2 _direction;
        
        private bool IsWallDetected(){
            _direction = flipSprite.flipX ? Vector2.left : Vector2.right;
            return Physics.Raycast(transform.position, _direction,  wallCheckDistance, wallLayerMask);
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.right * wallCheckDistance);
            Gizmos.DrawLine(transform.position, transform.position + Vector3.left * wallCheckDistance);
        }
    }
}
