using UnityEngine;
using UnityEngine.UI;

public class NewSongButton : MonoBehaviour {

    public Button button;
    public GameObject popWindow;

    // Use this for initialization
    void Start () {
        popWindow.SetActive(false);
        button.onClick.AddListener(ShowPopUp);
    }

    public void ShowPopUp()
    {
        popWindow.SetActive(true);
    }
}
