using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        public delegate void OnDamage(int currentHealth);
        public event OnDamage Damage;
    
        private int _health { get; set; }
    
        public void HandleAttack(int damage)
        {
            _health -= damage;

            if (Damage != null)
            {
                Damage(_health);
            }
        }

        private void Awake()
        {
            _health = 100;
        }

        private void Update()
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
            transform.Translate(x, 0, z);
        
            var y = Input.GetAxis("Mouse X") * Time.deltaTime * 50.0f;
            transform.Rotate(0, y, 0);
        }
    }
}