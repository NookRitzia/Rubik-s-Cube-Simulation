using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObjectAfterInterval : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float intervalUntilDeletion = 5f;
    private float startTime;
    public void setInterval(float t)
    {
        intervalUntilDeletion = t;
    }

    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > intervalUntilDeletion)
            GameObject.Destroy(this.gameObject);
    }
}
