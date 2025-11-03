using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 3f;

    [SerializeField] private float _timer;


    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _lifeTime )
        {
            Destroy(gameObject);
        }
    }
}
