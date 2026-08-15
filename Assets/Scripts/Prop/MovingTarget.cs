using System.Linq;
using UnityEngine;

namespace OneHourGameJam.Prop
{
    public class MovingTarget : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        [SerializeField]
        private Sprite _nakedSprite;

        private SpriteRenderer _sr;

        private Node _node;
        private Rigidbody2D _rb;

        private bool _isShotOnce = true;

        private void Awake()
        {
            _sr = GetComponent<SpriteRenderer>();
            _rb = GetComponent<Rigidbody2D>();
            _node = GameObject.FindObjectsByType<Node>().OrderBy(x => Vector2.Distance(transform.position, x.transform.position)).First();
        }

        private void FixedUpdate()
        {
            _rb.linearVelocity = (_node.transform.position - transform.position).normalized * _speed;
        }

        private void Update()
        {
            if (Vector2.Distance(transform.position, _node.transform.position) < .1f)
            {
                _node = _node.NextNode;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_isShotOnce) Destroy(gameObject);
            else _sr.sprite = _nakedSprite;

            Destroy(collision.gameObject);
        }
    }
}
