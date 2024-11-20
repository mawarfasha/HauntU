using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [Header("Stage Picture")]
    [SerializeField] private Sprite theBarn;
    [SerializeField] private Sprite gasStation;
    [SerializeField] private Sprite hotel;
    [SerializeField] private Sprite unknown;

    [Header("Reference")]
    [SerializeField] private GameObject didntChoose;
    [SerializeField] private Image preview;
    [SerializeField] private Text description;

    private int sceneIndex;

    public void BarnChoice()
    {
        preview.sprite = theBarn;
        description.text = "A desolate farmstead shrouded in gloom, with decaying buildings and barren trees." +
            "Graves dot the area, and eerie figures like pocong and pontianak lurk in the shadows." +
            "A haunting setting for survival horror.";
        sceneIndex = 1;
    }

    public void GasStationChoice()
    {
        preview.sprite = gasStation;
        description.text = "A rundown gas station surrounded by barren land and broken vehicles." +
            "The area is eerily silent, with toyol and pontianak lurking nearby, creating a haunting and oppressive atmosphere.";
        sceneIndex = 2;
    }

    public void HotelChoice()
    {
        preview.sprite = hotel;
        description.text = "An abandoned housing complex surrounded by barren paths and twisted trees." +
            "Blocked roads and eerie silence set the stage for pocong and toyol to haunt the shadows," +
            "creating a tense and foreboding atmosphere.";
        sceneIndex = 3;
    }

    public void Unknown()
    {
        preview.sprite = unknown;
        description.text = "???";
        sceneIndex = 0;
    }

    public void SelectedStage()
    {
        if (sceneIndex == 0)
        {
            StartCoroutine(PopUp());
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
        }
    }

    private IEnumerator PopUp()
    {
        didntChoose.SetActive(true);
        yield return new WaitForSeconds(3);
        didntChoose.SetActive(false);
    }

    public void ExtGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
