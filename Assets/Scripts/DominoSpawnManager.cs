using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class DominoSpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] dominoPrefabs;

    [SerializeField]
    private Transform[] spawnPoints;

    [NonSerialized]
    public FocusableDomino TheDomino;

    private int[] _order;
    private GameObject[] _dominoes;
    private GameObject _exampleDomino;

    void Awake()
    {
        var count = dominoPrefabs.Length;
        _order = Enumerable.Range(0, count).ToArray();
        _dominoes = new GameObject[count];
        ShuffleOrder();
        var r = Random.Range(0, count);
        for (int i = 0; i < count; i++)
        {
            _dominoes[i] = Instantiate(dominoPrefabs[_order[i]], spawnPoints[i]);
            if (i == r) TheDomino = _dominoes[i].GetComponent<FocusableDomino>();
        }

        _exampleDomino = Instantiate(dominoPrefabs[_order[r]], spawnPoints[count]);
        _exampleDomino.GetComponent<FocusableDomino>().highlight = false;
    }

    private void ShuffleOrder() {
        var count = _order.Length;
        for (var i = 0; i < count; ++i) {
            var r = Random.Range(0, count);
            var tmp = _order[i];
            _order[i] = _order[r];
            _order[r] = tmp;
        }
    }

    public void Shuffle()
    {
        _exampleDomino.GetComponent<Renderer>().material.SetColor("_Color", Color.magenta);
        ShuffleOrder();
        var count = dominoPrefabs.Length;
        var r = Random.Range(0, count);
        for (int i = 0; i < count; i++)
        {
            var spawnPoint = _dominoes[i].transform.parent;
            Destroy(_dominoes[i]);
            _dominoes[i] = Instantiate(dominoPrefabs[_order[i]], spawnPoint);
            if (i == r) TheDomino = _dominoes[i].GetComponent<FocusableDomino>();
            //_dominoes[i].transform.SetParent(spawnPoints[_order[i]], false);
            //if (i == r) TheDomino = _dominoes[i].GetComponent<FocusableDomino>();
        }
        Destroy(_exampleDomino);
        //Destroy(spawnPoints[count].transform.GetChild(0));
        _exampleDomino = Instantiate(dominoPrefabs[_order[r]], spawnPoints[count]);
        _exampleDomino.GetComponent<FocusableDomino>().highlight = false;
    }
    
}
