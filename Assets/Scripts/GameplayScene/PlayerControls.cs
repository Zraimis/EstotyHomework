using UnityEngine;
using UnityEngine.InputSystem;

namespace EstotyHomework.GameplayScene
{
    public class PlayerControls : MonoBehaviour
    {
        [SerializeField]
        private InputActionReference moveActionToUse;
        // TODO SerializeField attribute needed here?
        [SerializeField]
        private float _currentLocationX = -1000;
        private float _currentLocationZ = 0;

        public void Update()
        {
            Vector2 moveDirection = moveActionToUse.action.ReadValue<Vector2>();
            _currentLocationX += moveDirection.x;
            _currentLocationZ += moveDirection.y;
            transform.localPosition = new Vector3(_currentLocationX, 30f, _currentLocationZ);
        }
    }
}