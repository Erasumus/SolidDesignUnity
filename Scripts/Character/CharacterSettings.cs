using UnityEngine;

namespace Character
{
    public class CharacterSettings : MonoBehaviour
    {
        [Header("Character Stats")]
        public float moveSpeed;
        public float jumpForce;
        
        [Header("Character Physics")]
        public float gravityScale;
        
        private void Awake() {
            moveSpeed = Mathf.Max(moveSpeed, 5f);
            jumpForce = Mathf.Max(jumpForce, 5f);
            gravityScale = Mathf.Max(gravityScale, 2f);
        }
    }
}
