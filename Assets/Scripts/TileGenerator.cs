using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private float _speed;
    [SerializeField] private int _maxCount;
    [SerializeField] private List<Tile> _tiles = new List<Tile>();
    [SerializeField] private Transform _tileHolder;

    //Приклад 5 початок
    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject _bomb;
    [SerializeField] private float _startSpawnBomb = 3;

    private float _timer;
    //Приклад 5 кінець
    //Приклад 6 початок
    private bool _isEnabling = true; //По замовченню наші панелі движутся і генератор працює
    //Приклад 6 кінець
    // Start is called before the first frame update
    void Start()
    {
        //Приклад 6 початок - Зупинка нашого генератору
        _tiles.First().SetSpeed(_speed); //Тут було із іншиш прикладів так: _tiles.First().speed = speed;
        //Приклад 6 кінець

        for (int i = 0; i < _maxCount; i++)
        {
            GenerateTile();
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Приклад 6 початок - Зупинка нашого генератору
        if (_isEnabling == false)
            return;
        //Приклад 6 кінець

        //Приклад 5 початок
        _timer += Time.deltaTime;
        //Приклад 5 кінець

        if (_tiles.Count < _maxCount)
        {

            GenerateTile();

        }

    }

    //Приклад 6 початок - Зупинка нашого генератору
    public void SetEnabling(bool state)
    {
        _isEnabling = state;

        foreach (Tile tile in _tiles)
        {
            tile.SetMoving(state);
        }
    }
    //Приклад 6 кінець


    private void GenerateTile()
    {
        GameObject newTileObject = Instantiate(_tilePrefab, _tiles.Last().transform.position + Vector3.forward * _tilePrefab.transform.localScale.z, Quaternion.identity);
        Tile newTile = newTileObject.GetComponent<Tile>();
        //Приклад 5 початок
        newTile.Initialize(_coin, _bomb, _startSpawnBomb, _timer);
        //Приклад 5 кінець
        //Приклад 6 початок - Зупинка нашого генератору
        newTile.SetSpeed(_speed);   //Було newTile.speed = speed;
                                    //Приклад 6 кінець

        _tiles.Add(newTile);
        newTileObject.transform.SetParent(_tileHolder);
    }

    private void OnTriggerEnter(Collider other)
    {
        _tiles.Remove(other.GetComponent<Tile>());
        Destroy(other.gameObject);
    }

}
