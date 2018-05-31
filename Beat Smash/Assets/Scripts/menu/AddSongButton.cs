using UnityEngine;
using UnityEngine.UI;

public class AddSongButton : MonoBehaviour {

    public Button button;
    public UpdateBeatmaps window;

    // Use this for initialization
    void Start () {
        button.onClick.AddListener(ShowPopUp);
    }
	
    private void ShowPopUp()
    {
        window.Show();
    }



}
