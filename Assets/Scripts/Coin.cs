﻿using UnityEngine;

public class Coin : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<GameManager>().AddCoin();
        Destroy(gameObject);
    }
}
