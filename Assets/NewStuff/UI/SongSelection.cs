using AudioUtilities;
using UnityEngine;
using UnityEngine.UI;

public class SongSelection : MonoBehaviour
{
    public static Song selection = null;

    [SerializeField] GameObject template;
    [SerializeField] Transform parent;
    private void Start()
    {
        if (SongImporter.Ready) SongImporter_Complete();
    }
    private void OnEnable()
    {
        SongImporter.Complete += SongImporter_Complete;
    }
    private void OnDisable()
    {
        SongImporter.Complete -= SongImporter_Complete;
    }

    private void SongImporter_Complete()
    {
        selection = SongImporter.Songs[0];
        foreach (Song song in SongImporter.Songs)
        {
            GameObject gO = Instantiate(template, parent);
            gO.GetComponent<Button>().Select(); // Because no selectable objects exists when entering the scene the script selects the last button to be selected
            gO.GetComponentInChildren<Text>().text = song.name;
            gO.GetComponent<SongSelectionButton>().song = song;
            gO.SetActive(true);
        }
    }
}
