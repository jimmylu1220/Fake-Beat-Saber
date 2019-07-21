using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SameSideSpawner : MonoBehaviour
{
    public GameObject[] cubes;
    public GameObject MeunButton;
    private GameObject Red_cube, Blue_cube;
    public Transform[] points;
    public float beat;
    public int direction = 4;
    public int angle = 90;
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
        
            Red_cube = Instantiate(cubes[0], points[Random.Range(0, 2)]);
            Blue_cube = Instantiate(cubes[1], points[Random.Range(2, 4)]);
            Red_cube.transform.localPosition = Vector3.zero;
            Red_cube.transform.Rotate(transform.forward, angle * Random.Range(0, direction));
            Blue_cube.transform.localPosition = Vector3.zero;
            Blue_cube.transform.Rotate(transform.forward, angle * Random.Range(0, direction));
            timer -= beat;
            Destroy(Red_cube, 9.0f);
            Destroy(Blue_cube, 5.0f);

        }
        
        else if(SongTime <= 0)
        {
            MeunButton.SetActive(true);
        }
        timer += Time.deltaTime;
        
    }

    private void SongTimer() {
        SongTime -= 1;
        if (SongTime == 0) 
            CancelInvoke("SongTimer");
    }
}
