using UnityEngine;
using UnityEngine.SceneManagement;

namespace OneHourGameJam.Manager
{
    public class MenuManager : MonoBehaviour
    {
        public void Play()
        {
            SceneManager.LoadScene("Main");
        }
    }
}
