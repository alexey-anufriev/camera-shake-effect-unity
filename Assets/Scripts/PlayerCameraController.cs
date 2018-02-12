using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerCameraController : MonoBehaviour
    {
        public Transform Player;
        private PlayerController _playerController;

        private CameraShaker _cameraShaker;
    
        private void Awake()
        {
            _playerController = Player.GetComponent<PlayerController>();
            _cameraShaker = GetComponent<CameraShaker>();
        }
    
        private void OnEnable()
        {
            _playerController.Damage += HandlePlayerDamage;
        }
    
        private void OnDisable()
        {
            _playerController.Damage -= HandlePlayerDamage;
        }

        private void HandlePlayerDamage(int currentHealth)
        {
            _cameraShaker.Shake();
        }
    }
}