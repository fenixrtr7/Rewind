using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Manager<UIManager>
{
    [SerializeField] Button reset;
    // Start is called before the first frame update
    void Start()
    {
        reset.onClick.AddListener(delegate() { GameManager.Instance.ChangeScene("Level1"); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
