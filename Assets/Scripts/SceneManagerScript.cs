using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private string sceneName; 
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
