using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviours : MonoBehaviour
{

    [SerializeField] List<GameObject> foodList;
    public List<int> spawnTime;
    [SerializeField] List<int> foodAmount;
    [SerializeField] List<float> frequency;
    [SerializeField] Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = new Timer(spawnTime[1]);
        timer.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(spawnFood(Random.Range(0, frequency.Count)));
    }
    IEnumerator spawnFood(float spawnTime)
    {
        Debug.Log(spawnTime);
        yield return new WaitForSeconds(spawnTime);
    }
}
