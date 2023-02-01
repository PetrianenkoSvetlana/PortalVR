using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal other;
    public Camera portalView;
    // Start is called before the first frame update
    void Start()
    {
        other.portalView.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        GetComponentInChildren<MeshRenderer>().sharedMaterial.mainTexture = other.portalView.targetTexture;
    }

    // Update is called once per frame
    void Update()
    {
        //Position
        Vector3 lookerPosition = other.transform.worldToLocalMatrix.MultiplyPoint3x4(Camera.main.transform.position);
        lookerPosition = new Vector3(-lookerPosition.x, lookerPosition.y, -lookerPosition.z);
        portalView.transform.localPosition = lookerPosition;

        //Rotation
        Quaternion difference = transform.rotation * Quaternion.Inverse(other.transform.rotation * Quaternion.Euler(0, 180, 0));
        portalView.transform.rotation = difference * Camera.main.transform.rotation;

        //Clipping
        portalView.nearClipPlane = lookerPosition.magnitude;
    }
}
