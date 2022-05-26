using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUiHandler : MonoBehaviour
{
    public TextMeshProUGUI HighScoreLabel;
    private TMP_InputField nameInput;

    // Start is called before the first frame update
    void Start()
    {
        nameInput = GetComponentInChildren<TMP_InputField>();
        nameInput.text = PersistenceManager.Instance.playerName;

        // set the high score
        HighScoreLabel.text = $"Best Score : {PersistenceManager.Instance.highScorePlayerName} : {PersistenceManager.Instance.highScore}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        PersistenceManager.Instance.playerName = nameInput.text;
        SceneManager.LoadScene("main");
    }

    public void Exit()
    {
        PersistenceManager.Instance.SaveHighScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
