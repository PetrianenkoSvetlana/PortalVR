using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Teleporter : MonoBehaviour
{
    public Quaternion diff;
    public Teleporter other;

    private int countTel = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider person)
    {
        float zPos = transform.worldToLocalMatrix.MultiplyPoint3x4(person.transform.position).z;
        if (zPos < 0 && countTel == 0)
        {
            Debug.Log(zPos);
            countTel++;
            Teleport(person.transform);
        }
    }

    private void Teleport(Transform obj)
    {
        //Position
        Debug.Log("First pos: " + obj.position);
        Vector3 localPos = transform.worldToLocalMatrix.MultiplyPoint3x4(obj.position);
        localPos = new Vector3(-localPos.x, localPos.y, -localPos.z);
        obj.position = other.transform.localToWorldMatrix.MultiplyPoint3x4(localPos);
        Debug.Log("Second pos: " + obj.position);

        //Rotation
        Quaternion difference = other.transform.rotation * Quaternion.Inverse(transform.rotation * Quaternion.Euler(0, 180, 0));
        obj.rotation = difference * obj.rotation;
        //Debug.Log("Position in end: " + obj.position);

    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.layer = 9;
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.layer = 10;
        countTel = 0;
    }
}
