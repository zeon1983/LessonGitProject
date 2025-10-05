using UnityEngine;

public class Bomb : MonoBehaviour
{
    //Початок - приклад 6
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.Die();
            Destroy(gameObject);
        }
    }
    //Кінець - приклад 6
}
