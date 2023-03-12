using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public const string SECOND_SCENE = "MainMenuScene";
    [SerializeField]
    private Button loadSceneButton;
    private void Start()
    {
        loadSceneButton.onClick.AddListener(LoadScene);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SECOND_SCENE);
    }
}
