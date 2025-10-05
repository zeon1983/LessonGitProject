using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreTextView;
    [SerializeField] private GameObject _exitButton;
    void Start()
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        _exitButton.SetActive(true);
#elif UNITY_WEBGL
        _exitButton.SetActive(false);
#endif

        //Початок Приклад 8
        LoadScore();
        //Кінець Приклад 8
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    //Початок Приклад 8
    private void LoadScore()
    {
        int score = PlayerPrefs.GetInt("score");
        _scoreTextView.text = score.ToString();
    }
    //Кінець Приклад 8
}
