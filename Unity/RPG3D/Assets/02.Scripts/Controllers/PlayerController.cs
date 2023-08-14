using RPG.FSM;
using RPG.GameElements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Controllers
{
    [RequireComponent(typeof(MachineManager))]
    public class PlayerController : ControllerBase
    {
        private MachineManager _machineManager;

        protected override void Awake()
        {
            base.Awake();
            _machineManager = GetComponent<MachineManager>();
        }
        private void Update()
        {
            _machineManager.horizontal = Input.GetAxis("Horizontal");
            _machineManager.vertical = Input.GetAxis("Vertical");
            _machineManager.moveGain = Input.GetKey(KeyCode.LeftShift) ? 2.0f : 1.0f;
            

            if (Input.GetMouseButtonDown(0))
            {
                _machineManager.ChagneState(StateType.Attack);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_machineManager.isGrounded)
                {
                    if (_machineManager.hasJumped == false)
                    {
                        _machineManager.ChagneState(StateType.Jump);
                    }
                }
                else
                {
                    if (_machineManager.hasSomersaulted == false)
                    {
                        _machineManager.ChagneState(StateType.Somesault);
                    }
                }
            }
        }


        private void OnTriggerStay(Collider other)
        {
            if (Input.GetKey(KeyCode.F) &&
               ((1 << other.gameObject.layer) & (1<<LayerMask.NameToLayer("ItemDropped"))) >0)
            {
                if (other.TryGetComponent(out ItemDropped itemDropped))
                {
                    itemDropped.PickUp();
                }
            }
        }
    }
}
