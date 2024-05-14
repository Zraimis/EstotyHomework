using UnityEngine;
using UnityEngine.SceneManagement;

namespace EstotyHomework.Managers
{
    public class SceneManagerScript : MonoBehaviour
    {
        [SerializeField]
        private string sceneName;
        public void LoadScene()
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }
        public void UnloadScene()
        {
            SceneManager.UnloadSceneAsync(2);
        }
    }
}