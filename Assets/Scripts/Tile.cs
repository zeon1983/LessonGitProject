using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private float _speed;
    [SerializeField] private List<Transform> _points = new List<Transform>();
    //[SerializeField] private GameObject _coin;
    //Приклад 5 початок
    private GameObject _coin;
    private GameObject _bomb;
    private float _startSpawnBomb;
    private float _timer;
    //Приклад 5 кінець

    //Приклад 6 початок - Зупинка нашого генератору
    private bool _isMove = true; //По замовченню наші панелі движутся і генератор працює
    //Приклад 6 кінець
    // Start is called before the first frame update
    void Start()
    {
        int randomPoinIndex = Random.Range(0, _points.Count);
        // GameObject newCoin = Instantiate(_coin, _points[randomPoinIndex].position, Quaternion.identity);
        // newCoin.transform.SetParent(transform);

        //Приклад 5 початок
        if (_coin == null || _bomb == null) //Перевірка для виключення із першої платформи із коду на створення монет і бомб (перевірка якщо ми нічого не передали у монетку або бомбу)
        {
            return; //Метод Start() завершиться досрочно
        }


        if (_timer < _startSpawnBomb) //_startSpawnBomb починається з 3-ї секунди гри, а у нас в умовах, якщо меньше 3-х секунд триває гра
        {
            CreateObject(randomPoinIndex, _coin); //Створення об'єкту - передаєм модельку монетки
        }
        else //Тут створюються бомби, та вирогідність створення бомб повинна бути менша ніж монеток 
        {
            float chanceSpawnBomb = 20 + (_timer / 2);
            chanceSpawnBomb = Mathf.Clamp(chanceSpawnBomb, 0, 50);

            if (Random.Range(0, 100) < chanceSpawnBomb)
            {
                CreateObject(randomPoinIndex, _bomb); //створення бомб менше
            }
            else
            {
                CreateObject(randomPoinIndex, _coin); //створення монеток більше
            }
        }
        //Приклад 5 кінець
    }

    private void CreateObject(int randomPoinIndex, GameObject createdObject)
    {
        GameObject newCoin = Instantiate(createdObject, _points[randomPoinIndex].position, Quaternion.identity);
        newCoin.transform.SetParent(transform);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Приклад 6 початок - Зупинка нашого генератору
        if (_isMove == false)
            return;
        //Приклад 6 кінець
        transform.Translate(Vector3.back * _speed * Time.fixedDeltaTime);
    }

    //Приклад 5 початок
    public void Initialize(GameObject coin, GameObject bomb, float startSpawnBomb, float timer)
    {
        _coin = coin;
        _bomb = bomb;
        _timer = timer;
        _startSpawnBomb = startSpawnBomb;
    }
    //Приклад 5 кінець

    //Приклад 6 початок - Зупинка нашого генератору
    public void SetSpeed(float speed)
    {
        if (speed < 0)
        {
            Debug.LogError("Швидкість для тайла меньша за 0");
            return;
        }

        _speed = speed;
    }

    public void SetMoving(bool state)
    {
        _isMove = state;
    }

    //Приклад 6 кінець
}
