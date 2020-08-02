using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Manager<LevelManager>
{
    [SerializeField] GameObject[] keys;
    // Start is called before the first frame update
    void Start()
    {
        keys = GameObject.FindGameObjectsWithTag("key");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
