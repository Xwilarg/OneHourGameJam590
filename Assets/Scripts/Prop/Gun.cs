using UnityEngine;
using UnityEngine.InputSystem;

namespace OneHourGameJam.Prop
{
    public class Gun : MonoBehaviour
    {
        [SerializeField]
        private GameObject _bullet;

        [SerializeField]
        private float _bulletSpeed;

        private Camera _cam;

        private void Awake()
        {
            _cam = Camera.main;
        }

        private void Update()
        {
            var mousePos = Mouse.current?.position?.ReadValue();

            if (mousePos != null)
            {
                var worldMouse = _cam.ScreenToWorldPoint(mousePos.Value);
                transform.position = new Vector3(worldMouse.x, transform.position.y, 0f);
            }
        }

        public void OnClick(InputAction.CallbackContext value)
        {
            if (value.phase == InputActionPhase.Started)
            {
                var bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().linearVelocityY = _bulletSpeed;
            }
        }
    }
}
