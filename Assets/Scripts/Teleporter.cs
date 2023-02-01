using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
//using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Teleporter : MonoBehaviour
{
    //public XRRig xrrig;
    public Teleporter Other;
    private Transform trans;
    public float zPosCheck;
    public ActionBasedContinuousMoveProvider locomotion;
    public float time = 0.05f;
    public bool teleport = false;
    // Start is called before the first frame update
    void Start()
    {
        locomotion = FindObjectOfType<ActionBasedContinuousMoveProvider>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(xrrig.transform.position);
    }

    private void OnTriggerStay(Collider other)
    {
        float zPos = transform.worldToLocalMatrix.MultiplyPoint3x4(other.transform.position).z;
        zPosCheck = zPos;
        if (zPos < 0.32
            && !teleport)
        {
            teleport = !teleport;
            locomotion.enabled = false;
            trans = other.transform;
            TeleportRot();
            TeleportPos();
            Debug.Log("Name portal: " + gameObject.name);
        }

    }

    private void TeleportPos()
    {
        //Position
        //Debug.Log("First pos: " + obj.position);
        Vector3 localPos = transform.worldToLocalMatrix.MultiplyPoint3x4(trans.position);
        localPos = new Vector3(-localPos.x, localPos.y, -localPos.z);
        //obj.position = Vector3.up;
        Debug.Log(trans.forward);
        trans.position = Other.transform.localToWorldMatrix.MultiplyPoint3x4(localPos);
        StartCoroutine(LocomotionOn());

        //Debug.Log("Second pos: " + obj.position);
    }

    private void TeleportRot()
    {
        Quaternion difference = Other.transform.rotation * Quaternion.Inverse(transform.rotation * Quaternion.Euler(0, 180, 0));
        trans.rotation = difference * trans.rotation;
        //Rotation
        //Debug.Log("Position in end: " + obj.position);
    }

    private IEnumerator LocomotionOn()
    {
        yield return new WaitForSeconds(time);
        locomotion.enabled = true;
    }

    private void Teleport(Transform obj)
    {
        //Position
        //Debug.Log("First pos: " + obj.position);
        Vector3 localPos = transform.worldToLocalMatrix.MultiplyPoint3x4(obj.position);
        localPos = new Vector3(-localPos.x, localPos.y, -localPos.z);
        //obj.position = Vector3.up;
        obj.position = Other.transform.localToWorldMatrix.MultiplyPoint3x4(localPos);
        //Debug.Log("Second pos: " + obj.position);

        //Rotation
        Quaternion difference = Other.transform.rotation * Quaternion.Inverse(transform.rotation * Quaternion.Euler(0, 180, 0));
        obj.rotation = difference * obj.rotation;
        //Debug.Log("Position in end: " + obj.position);

    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.layer = 9;
    }

    private void OnTriggerExit(Collider other)
    {
        teleport = false;
        other.gameObject.layer = 10;
    }
}
