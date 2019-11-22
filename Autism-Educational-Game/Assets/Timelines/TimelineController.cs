using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using System.IO;
using System;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector director;
    public bool next = false;
    public float startTime;
    public float timeUsed;
    public int wrongAns;

    [SerializeField] Material unfinishedMat;
    [SerializeField] Material finishedMat;
    GameObject progressBar;

    public void Play()
    {
        director.Play();
    }
    public void Pause()
    {
        director.Pause();
    }

    private void Start()
    {
        progressBar = GameObject.FindGameObjectWithTag("ProgressBar");
        wrongAns = 0;
    }

    private void Update()
    {
        if(next)
        {
            director.Play();
            next = false;
        }
    }

    public void DestroyProgressBar()
    {
        Destroy(progressBar);
    }

    public void SetToNextStage()
    {
        float bv = progressBar.GetComponent<ProgressBar>().BarValue;
        bv += 10.0f;
        progressBar.GetComponent<ProgressBar>().BarValue = bv;
    }

    public void  StartTimer()
    {
        startTime = Time.time;
    }

    public void EndTimer()
    {
        timeUsed = Time.time - startTime;
    }

    public void EndGame()
    {
        WriteResult(timeUsed.ToString() + ',' + wrongAns.ToString());
        Application.Quit();
    }

    public void AddWrongAns()
    {
        wrongAns++;
    }

    public void WriteResult(string result)
    {
        StreamWriter sc = new StreamWriter(Path.Combine(
                Application.streamingAssetsPath, "Result.csv"), true);

        sc.WriteLine(result);

        sc.Close();
    }
}
