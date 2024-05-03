using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCount : MonoBehaviour
{
    TMPro.TMP_Text text;
    int count;

    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }

    void OnEnable() => CollectionScript.OnCollected += OnCollectibleCollected;
    void OnDisable() => CollectionScript.OnCollected -= OnCollectibleCollected;

    void Start() => UpdateCount();

    void OnCollectibleCollected()
    {
        count++;
        UpdateCount();
    }

    void UpdateCount()
    {
        text.text = $"{count} / {CollectionScript.total}";
    }
}
