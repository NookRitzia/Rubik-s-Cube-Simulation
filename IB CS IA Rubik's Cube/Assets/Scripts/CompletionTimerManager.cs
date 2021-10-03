using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CompletionTimerManager : MonoBehaviour
{
    [SerializeField] private Face[] faces;
    [SerializeField] bool ifSolved;
    [SerializeField] float timeElapsed = 0;
    [SerializeField] float startTime;
    [SerializeField] UnityEngine.UI.Text timerText;

    private void Start()
    {
        faces = this.GetComponentsInChildren<Face>();
        startTime = Time.time;
    }

    private void Update()
    {
        timeElapsed = Time.time - startTime;
        ifSolved = isCubeSolved();
        Debug.Log(ifSolved);
        setTimer();
    }

    public bool isCubeSolved()
    {
        foreach(Face f in faces)
        {
            string orientation = f.getOrientation();
            foreach(Tile t in f.getTiles())
                if (!t.getColorOrientation().Equals(orientation))
                    return false;

        }
        return true;
    }

    private void setTimer()
    {
        if (timerText != null)
        {
            string minutes = Mathf.FloorToInt(timeElapsed / 60) + "";
            string seconds = Mathf.FloorToInt(timeElapsed % 60) + "";
            string ms = Mathf.FloorToInt((timeElapsed % 1f) * 1000) + "";
            if (minutes.Length <= 1)
                minutes = "0" + minutes;
            if (seconds.Length <= 1)
                seconds = "0" + seconds;
            if (ms.Length <= 1)
                ms = "0" + ms;
            ms = ms.Substring(0, 2);
            timerText.text = minutes + ":" + seconds + ":" + ms;
        }
    }
}
