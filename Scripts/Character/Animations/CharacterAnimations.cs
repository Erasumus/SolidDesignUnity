using Character.Collider;
using UnityEngine;
using UnityEngine.Serialization;

namespace Character.Animations
{
    public class CharacterAnimations : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody2D rigidbodyComponent;
        [FormerlySerializedAs("groundColliderCheck")] [SerializeField] private ColliderCheckGround colliderCheckGround;
        private static readonly int XVelocity = Animator.StringToHash("xVelocity"),
            YVelocity = Animator.StringToHash("yVelocity"), 
            IsGrounded = Animator.StringToHash("isGrounded");

        private float _xVelocity, _yVelocity;
        private bool _isGrounded;
        
        private void Awake()
        {
            if (animator && rigidbodyComponent && colliderCheckGround) return;
            Debug.LogError($"AnimatorHandler: Один или несколько необходимых компонентов не установлены: " +
                           $"\nanimator = {animator}," +
                           $"\nrigidbodyComponent = {rigidbodyComponent}," +
                           $"\ngroundColliderCheck = {colliderCheckGround}.");
            enabled = false;
        }

        private void FixedUpdate()
        {
            _xVelocity = Mathf.Abs(rigidbodyComponent.velocity.x);
            _yVelocity = Mathf.Abs(rigidbodyComponent.velocity.y);
            _isGrounded = colliderCheckGround.IsGround();

            animator.SetFloat(XVelocity, _xVelocity);
            animator.SetFloat(YVelocity, _yVelocity);
            animator.SetBool(IsGrounded, _isGrounded);
            
            /*Debug.Log($"AnimatorHandler: XVelocity = {xVelocity}, YVelocity = {yVelocity}, IsGrounded = {isGrounded}");*/
        }
    }
}

