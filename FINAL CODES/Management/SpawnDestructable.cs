using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDestructable : MonoBehaviour
{
    [SerializeField] private GameObject barrel;

    private float timerCount = 500;

    [Header("Coordinates Boundaries")]
    [SerializeField] private float maxX;
    [SerializeField] private float minX;
    [SerializeField] private float maxY;
    [SerializeField] private float minY;

    // Update is called once per frame
    void Update()
    {
        if (timerCount == 0)
        {
            StartCoroutine(Spawning());
            timerCount = 500;
        }
        else
        {
            timerCount -= 0.1f;
        }
    }

    private IEnumerator Spawning()
    {
        Vector2 ramPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Instantiate(barrel, ramPos, Quaternion.identity);
        yield return new WaitForSeconds(20);
    }
}
