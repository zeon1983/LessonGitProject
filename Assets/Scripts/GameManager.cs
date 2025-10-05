using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Початок Приклад 6
    [SerializeField] private Player _player;
    //Кінець Приклад 6
    //Початок Приклад 6 - Зупинка нашого генератору
    [SerializeField] private TileGenerator _tileGenerator;
    //Кінець Приклад 6
    [SerializeField] private TextMeshProUGUI _coinsText;
    //Початок Приклад 7
    [SerializeField] private float _loadDelay = 4;
    //Кінець Приклад 7

    private int _coinsCount;

    //Початок Приклад 8
    [SerializeField] private AudioClip _coinSound;
    [SerializeField] private AudioClip _explosionSound;
    [SerializeField] private AudioSource _audioSource;
    //Кінець Приклад 8

    // Start is called before the first frame update
    void Start()
    {
        //Початок Приклад 6
        _player.DieEvent.AddListener(LoseHandler); //Тут поле DieEvent создано в классе Player
        //Кінець Приклад 6
    }

    //Початок Приклад 7
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");

        }
    }
    //Кінець Приклад 7

    private void LoseHandler()
    {
        print("Кінець гри");
        //Початок Приклад 8
        SaveScore();

        _audioSource.PlayOneShot(_explosionSound);
        //Кінець Приклад 8
        //Початок Приклад 6 - Зупинка нашого генератору
        _tileGenerator.SetEnabling(false);
        //Кінець Приклад 6

        //Початок Приклад 7
        StartCoroutine(LoadDelayedMenu());
        //Кінець Приклад 7
    }

    //Початок Приклад 7
    private IEnumerator LoadDelayedMenu()
    {
        yield return new WaitForSeconds(_loadDelay);
        SceneManager.LoadScene("Menu");
    }
    //Кінець Приклад 7

    //Початок Приклад 8
    private void SaveScore()
    {
        int oldScore = PlayerPrefs.GetInt("score");
        if (oldScore < _coinsCount)
        {
            PlayerPrefs.SetInt("score", _coinsCount);
            PlayerPrefs.Save();
        }
    }
    //Кінець Приклад 8

    public void AddCoin()
    {
        //Початок Приклад 8
        _audioSource.PlayOneShot(_coinSound);
        //Кінець Приклад 8

        _coinsCount++;
        _coinsText.text = _coinsCount.ToString();
    }
}
