using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour {

    public Button button;
    public GameObject popWindow;

    // Use this for initialization
    void Start()
    {
        button.onClick.AddListener(HidePopUp);
    }

    public void HidePopUp()
    {
        popWindow.SetActive(false);
    }
}
