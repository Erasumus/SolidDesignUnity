using UnityEngine;

namespace Character.Rigidbody
{
    public abstract class RigidbodyBase : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D rigidbodyComponent;

        protected virtual void Awake()
        {
            if (rigidbodyComponent == null)
            {
                rigidbodyComponent = GetComponent<Rigidbody2D>();
            }
        }
    }
}