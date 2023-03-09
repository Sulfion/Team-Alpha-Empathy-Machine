using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] Button beginButton;

    // Start is called before the first frame update
    void Start()
    {
        beginButton.onClick.AddListener(BeginGame);
    }

    private void BeginGame()
    {
        ScenesManager.Instance.LoadNewGame();
    }
}
