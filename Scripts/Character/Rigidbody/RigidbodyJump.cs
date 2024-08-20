using UnityEngine;

namespace Character.Rigidbody
{
    public class Rigidbody2DJump : RigidbodyBase
    {
        private CharacterSettings _characterSettings;
        private bool _canDoubleJump;
        private float _baseJumpForce;
        protected override void Awake()
        {
            base.Awake();
            enabled = (_characterSettings = GetComponentInParent<CharacterSettings>()) != null;
            if (enabled == false) Debug.Log("Не обнаружен/не добавлен компонент" + 
                                                                                                                       "\nCharacterStats: " + enabled);
            rigidbodyComponent.gravityScale = _characterSettings.gravityScale;
        }
            
        public void SetCharacterSettings(CharacterSettings settings)
        {
            _characterSettings = settings;
            _baseJumpForce = _characterSettings.jumpForce;
        }
        
        public void Jump()
        {
            if (!_isGround && !_canDoubleJump) return;
            rigidbodyComponent.AddForce(Vector2.up * _characterSettings.jumpForce, ForceMode2D.Impulse);
            _characterSettings.jumpForce /= 1.5f;
            if (_isGround) return;
            _canDoubleJump = false;
            _characterSettings.jumpForce = _baseJumpForce;
        }
    }
}