using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneLoader : MonoBehaviour
{
    public const string FIRST_SCENE = "GameScene";
    [SerializeField]
    private Button loadSceneButton;
    private void Start()
    {
        loadSceneButton.onClick.AddListener(LoadScene);
    }

    public void LoadScene()
    {
        Debug.Log("loading...");
        SceneManager.LoadScene(FIRST_SCENE);
    }
}