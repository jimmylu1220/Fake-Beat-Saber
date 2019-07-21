using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardSpawner : MonoBehaviour
{
    public GameObject[] cubes;
    public GameObject MeunButton;
    public Transform[] points;
    public float beat;
    public int direction = 8;
    public int angle = 45;
    private float timer;
    public int SongTime;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SongTimer", 1, 1);
        MeunButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > beat && SongTime > 0)
        {
            GameObject cube = Instantiate(cubes[Random.Range(0, 2)], points[Random.Range(0, 4)]);
            cube.transform.localPosition = Vector3.zero;
            cube.transform.Rotate(transform.forward, angle * Random.Range(0, direction));
            timer -= beat;
        }
        else if (SongTime <= 0)
        {
            MeunButton.SetActive(true);
        }
        timer += Time.deltaTime;
    }

    private void SongTimer()
    {
        SongTime -= 1;
        if (SongTime == 0)
            CancelInvoke("SongTimer");
    }
}
