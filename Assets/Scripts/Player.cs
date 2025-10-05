using UnityEngine;
using UnityEngine.Events;


public class Player : MonoBehaviour
{
    //Початок - приклад 6
    public UnityEvent DieEvent = new();
    //Кінець - приклад 6

    [SerializeField] private float _speed = 5;
    [SerializeField] private CharacterController _characterController;
    //Початок - приклад 6
    private Animator _animator;
    private bool _isAlive = true;
    //Кінець - приклад 6
    // Start is called before the first frame update
    void Start()
    {
        //Початок - приклад 6
        _animator = GetComponent<Animator>();
        //Кінець - приклад 6
    }

    // Update is called once per frame
    void Update()
    {
        _characterController.Move(Vector3.right * _speed * Input.GetAxis("Horizontal") * Time.deltaTime);
    }
    //Початок - приклад 6
    public void Die()
    {
        if (_isAlive == false)
            return;

        print("Гравця не стало");
        _animator.SetTrigger("Die");
        _isAlive = false;
        DieEvent?.Invoke();
    }
    //Кінець - приклад 6
}
