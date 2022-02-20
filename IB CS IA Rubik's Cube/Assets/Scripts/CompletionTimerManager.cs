using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CompletionTimerManager : MonoBehaviour
{
    
    [SerializeField] bool ifSolved;
    [SerializeField] float timeElapsed = 0;
    [SerializeField] float startTime;
    [SerializeField] private UnityEngine.UI.Text timerText;
    private Face[] faces;

    private void Start() // Initialize reference to all faces on the Rubik's Cube and the start time
    {
        faces = this.GetComponentsInChildren<Face>();
        startTime = Time.time;
    }

    public void restartTimer()
    {
        startTime = Time.time;
        timeElapsed = 0;
        setTimer();
        ifSolved = false;
    }

    private void Update() // Elapsed time is updated and displayed
    {
        
        if (!ifSolved)
        { 
            timeElapsed = Time.time - startTime;
            setTimer();
            ifSolved = isCubeSolved();
        }
        else
        {
            timerText.text = "Congratulations! You took " + timeElapsed + " seconds to solve the Rubik's Cube!";
        }
    }

    public bool isCubeSolved() // Returns a boolean value corresponding to the solved state of the Rubik's Cube
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

    private void setTimer() // Sets the text field to display the elapsed time
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
