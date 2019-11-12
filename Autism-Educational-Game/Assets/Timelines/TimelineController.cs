using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

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
}
