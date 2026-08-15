using OneHourGameJam.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OneHourGameJam.Prop
{
    public class Gun : MonoBehaviour
    {
        private int _bulletCount;

        [SerializeField]
        private TMP_Text _bulletCountDisplay;

        [SerializeField]
        private GameObject _bullet;

        [SerializeField]
        private float _bulletSpeed;

        [SerializeField]
        private Transform _outPoint;

        private Camera _cam;

        private void Awake()
        {
            _cam = Camera.main;
        }

        private void Start()
        {
            _bulletCount = GirlManager.Instance.AmmoCount;
            _bulletCountDisplay.text = $"{_bulletCount} shot{(_bulletCount > 1 ? "s" : "")} left";
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
            if (value.phase == InputActionPhase.Started && _bulletCount > 0)
            {
                var bullet = Instantiate(_bullet, _outPoint.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().linearVelocityY = _bulletSpeed;
                _bulletCount--;
                if (_bulletCount == 0) _bulletCountDisplay.text = "Thanks for playing";
                else _bulletCountDisplay.text = $"{_bulletCount} shot{(_bulletCount > 1 ? "s" : "")} left";
            }
        }
    }
}
