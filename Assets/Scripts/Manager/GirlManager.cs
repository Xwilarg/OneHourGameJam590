using UnityEngine;
using UnityEngine.UI;

namespace OneHourGameJam.Manager
{
    public class GirlManager : MonoBehaviour
    {
        public static GirlManager Instance;

        [SerializeField]
        private Image _image;

        [SerializeField]
        private Sprite _nakedSprite;

        public int AmmoCount;
        private int _validShot;

        private void Awake()
        {
            Instance = this;
        }

        public void HitTarget()
        {
            _validShot++;
            if (_validShot == AmmoCount)
            {
                _image.sprite = _nakedSprite;
            }
        }
    }
}
