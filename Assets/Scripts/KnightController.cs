using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class KnightController : MonoBehaviour
    {
        public Transform Target;

        private PlayerController _playerController;

        private Animator _animator;
        private float _speed;

        private Dictionary<String, int> _stateMovementSpeed = new Dictionary<string, int>
        {
            {"run", 2},
            {"walk", 1},
            {"attack", 0}
        };
    
        private void Awake()
        {
            _speed = 0;
            _animator = GetComponent<Animator>();

            _playerController = Target.GetComponent<PlayerController>();
        }

        private void Update()
        {
            transform.LookAt(new Vector3(Target.position.x, 0, Target.position.z));
        
            if (Vector3.Distance(transform.position, Target.position) > 4)
            {
                TriggerTransition("run");
            }
            else if (Vector3.Distance(transform.position, Target.position) > 2.5
                     && Vector3.Distance(transform.position, Target.position) <= 4)
            {
                TriggerTransition("walk");
            }
            else if (Vector3.Distance(transform.position, Target.position) <= 2.5)
            {
                TriggerTransition("attack");
            }
        
            transform.Translate(0, 0, Time.deltaTime * _speed);
        }

        private void TriggerTransition(string transitionName)
        {
            _stateMovementSpeed.Keys.ToList().ForEach(state =>
            {
                if (!state.Equals(transitionName))
                {
                    _animator.ResetTrigger(state);
                }
            });
            
            _animator.SetTrigger(transitionName);
            
            _speed = _stateMovementSpeed[transitionName];
        }
    
        // triggered by animation event
        private void Attack()
        {
            _playerController.HandleAttack(10);
        }
    }
}
