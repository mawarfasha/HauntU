using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartEvent : MonoBehaviour
{
    public Flock blueFlock;
    public Flock orangeBlock;

    public GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        blueFlock.enabled = false;
        orangeBlock.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(StartPrograme());
    }

    IEnumerator StartPrograme()
    {
        yield return new WaitForSeconds(3);
        background.SetActive(false);
        yield return new WaitForSeconds(1);
        blueFlock.enabled = true;
        orangeBlock.enabled = true;
    }
}
