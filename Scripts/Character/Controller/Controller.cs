using Character.FlipToObject;
using Character.Rigidbody;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character.Controller
{
   public class Controller : MonoBehaviour
   {
      [Header("Rigidbody ")]
      [SerializeField] private Rigidbody2DMover mover;
      [SerializeField] private Rigidbody2DJump jump;
      [Header("Sprite ")]
      [SerializeField] private SpriteFlip spriteFlipper;
      [Header("Settings ")]
      [SerializeField] private CharacterSettings characterSettings;
      private float _inputX;
      private bool _isJumping;
      
      private void Awake()
      {
         if (mover == null || jump == null)
         {
            Debug.LogError("Rigidbody2DMover или Rigidbody2DJump не установлены через инспектор.");
         }
         
         mover.SetCharacterSettings(characterSettings);
         jump.SetCharacterSettings(characterSettings);
      }
      
      private void FixedUpdate()
      {
         mover.Move(_inputX); 
      }

      public void OnMove(InputAction.CallbackContext callbackContext)
      {
         _inputX = callbackContext.ReadValue<float>();
         mover.Move(_inputX);
         spriteFlipper?.FlipToSprite(_inputX);
      }

      public void OnJump(InputAction.CallbackContext callbackContext)
      {
         if (callbackContext.performed)
         {
            jump.Jump();
         }
      }
   } 
}
