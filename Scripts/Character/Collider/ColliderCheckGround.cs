using UnityEngine;

namespace Character.Collider
{
    public class ColliderCheckGround : MonoBehaviour
    {
        [SerializeField] private LayerMask groundLayerMask;
        [SerializeField] private float groundCheckDistance;

        public bool IsGround() => 
            Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayerMask);
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
        }
    }
}
