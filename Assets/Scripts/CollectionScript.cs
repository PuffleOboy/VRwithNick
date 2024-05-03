using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CollectionScript : MonoBehaviour
{
    public static event Action OnCollected;
    public static int total;

    private void Awake() => total++;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}
