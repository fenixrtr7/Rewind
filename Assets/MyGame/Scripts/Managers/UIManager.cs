using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Manager<UIManager>
{
    [SerializeField] Button reset;
    [SerializeField] Button play;
    [SerializeField] GameObject panelWin;
    // Start is called before the first frame update
    void Start()
    {
        if (play != null)
        {
            play.onClick.AddListener(delegate() { GameManager.Instance.StarGame(); });
        }else
        {
            Debug.Log("I don't have button play");
        }

        if (reset != null)
        {
            reset.onClick.AddListener(delegate() { GameManager.Instance.ResetLevel(); });
        }else
        {
            Debug.Log("I don't have button reset");
        }
    }

    public void WinPanel()
    {
        panelWin.SetActive(true);
    }
}
