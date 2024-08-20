using UnityEngine;

namespace Character.FlipToObject
{
    public class ObjectFlip : MonoBehaviour 
    {
        private float _inputX;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private void FlipToObject()
        { 
            transform.rotation = Quaternion.Euler(0, _inputX < 0 ? 180 : 0, 0);
        }
    }
}