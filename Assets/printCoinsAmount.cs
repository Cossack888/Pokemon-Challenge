using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class printCoinsAmount : MonoBehaviour
{
    public Text text;
    DataStorage storage;
    // Start is called before the first frame update
    void Start()
    {
        storage = FindObjectOfType<DataStorage>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = storage.coins.ToString();
    }
}
