using UnityEngine;

namespace Character.Rigidbody
{
    public class Rigidbody2DMover : RigidbodyBase
    {
        private CharacterSettings _characterSettings;
        private float _inputX;

        protected override void Awake()
        {
            base.Awake();
            enabled = (_characterSettings = GetComponentInParent<CharacterSettings>()) != null;
            if (rigidbodyComponent == null || enabled == false) Debug.Log("Не обнаружен/не добавлен компонент" + 
                                                                          "\nRigidBody: " + rigidbodyComponent + 
                                                                          "\nCharacterStats: " + enabled);
        }
        
        public void SetCharacterSettings(CharacterSettings settings)
        {
            _characterSettings = settings;
        }

        public void Move(float inputX)
        {
            rigidbodyComponent.velocity = new Vector2(inputX * _characterSettings.moveSpeed, rigidbodyComponent.velocity.y);
        }
    }
}   
