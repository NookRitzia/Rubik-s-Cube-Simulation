using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFallingBackground : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject objectCenter;
    [SerializeField] private Vector3 offset = Vector3.zero;
    [SerializeField] private Vector3 maxOffset = Vector3.zero;

    [SerializeField] private GameObject spawnedObject;
    [SerializeField] private float timeUntilDeletion = 5f;
    void Start()
    {
        if (objectCenter == null)
            objectCenter = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 randomOffset = new Vector3(Random.Range(-1 * maxOffset.x, maxOffset.x), Random.Range(-1 * maxOffset.x, maxOffset.x), Random.Range(-1 * maxOffset.x, maxOffset.x));
        GameObject spawned =  GameObject.Instantiate(spawnedObject, objectCenter.transform.position + offset + randomOffset, new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
        spawned.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(-360, 360), Random.Range(-360, 360), Random.Range(-360, 360));
        DeleteObjectAfterInterval delObject = spawned.AddComponent<DeleteObjectAfterInterval>();
        delObject.setInterval(timeUntilDeletion);
    }
}
