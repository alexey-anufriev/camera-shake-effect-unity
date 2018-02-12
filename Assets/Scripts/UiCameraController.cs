using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class UiCameraController : MonoBehaviour
    {
        public Transform Player;
        public Transform HealthText;
        public RectTransform HealthBar;

        private PlayerController _playerController;
        private Text _healthText;

        private void Awake()
        {
            _playerController = Player.GetComponent<PlayerController>();
            _healthText = HealthText.GetComponent<Text>();
        }
    
        private void OnEnable()
        {
            _playerController.Damage += RegisterPlayerDamage;
        }
    
        private void OnDisable()
        {
            _playerController.Damage -= RegisterPlayerDamage;
        }

        private void RegisterPlayerDamage(int currentHealth)
        {
            _healthText.text = "Health: " + currentHealth;
        
            // x2 to align bar witdth, 40 - const height
            HealthBar.sizeDelta = new Vector2(currentHealth * 2, 40);
        }
    }
}