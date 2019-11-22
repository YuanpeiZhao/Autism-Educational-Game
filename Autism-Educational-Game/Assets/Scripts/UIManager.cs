using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;


public class UIManager : MonoBehaviour
{
    public Button BtnInfo;
    public Button BtnWarning;

    public GameObject ScrollView;
    public GameObject WarningPanel;
    public GameObject IntroductionPanel;
    public GameObject BlockPanel;

    public int playTimes;

    // Start is called before the first frame update
    void Start()
    {
        playTimes = GetPlayTimes();

        if (playTimes % 2 == 1)
        {
            BlockPanel.SetActive(true);
        }
        else
        {
            BlockPanel.SetActive(false);
        }

        BtnInfo.onClick.AddListener(delegate () {
            ShowUI(ScrollView);
            IntroductionPanel.SetActive(false);
        });
        BtnWarning.onClick.AddListener(delegate ()
        {
            ShowUI(IntroductionPanel);
            ShowUI(WarningPanel);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShowUI(GameObject UI)
    {
        UI.SetActive(!UI.activeSelf);
    }

    public int GetPlayTimes()
    {
        StreamReader input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, "ConfigurationData.csv"));

        input.ReadLine();
        string values = input.ReadLine();

        input.Close();

        return int.Parse(values);
    }

    public void AddPlayTimes()
    {
        StreamWriter sc = new StreamWriter(Path.Combine(
                Application.streamingAssetsPath, "ConfigurationData.csv"), false);

        playTimes++;

        sc.WriteLine("playTimes");
        sc.WriteLine(playTimes.ToString());

        sc.Close();
    }
}
