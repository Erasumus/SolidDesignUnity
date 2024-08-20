using UnityEngine;

namespace Character.FlipToObject
{
    public class SpriteFlip : MonoBehaviour 
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        public void FlipToSprite(float direction)
        {
            if (direction == 0) return;
            spriteRenderer.flipX = direction < 0;
        }
    }
}
    
