using UnityEngine;

namespace _Game.Scripts.Character
{
    public class PlayerInput : MonoBehaviour
    {
        private const string Horizontal = "Horizontal";
        
        public bool IsShooting => Input.GetMouseButtonDown(0);

        public bool CanUseLaser => Input.GetMouseButtonDown(1);

        public bool IsMoving => Input.GetKey(KeyCode.W);
        
        public Vector3 Direction => new Vector3(0, 0, Input.GetAxis(Horizontal));
        
    }
}