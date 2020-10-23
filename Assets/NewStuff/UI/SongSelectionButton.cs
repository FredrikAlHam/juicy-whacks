using AudioUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SongSelectionButton : Button
{
    public Song song = null;
    protected override void Start()
    {
        onClick.AddListener(new UnityEngine.Events.UnityAction(OnClick));
    }

    private void OnClick()
    {
        SongSelection.selection = song;
        Debug.Log($"{song.name} is selected");
        Play();
    }
    public void Play()
    {
        SceneManager.LoadSceneAsync("game");
    }
}
