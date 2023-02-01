using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CreatePortal : BaseTeleportationInteractable
{
    public GameObject[] portals;
    protected override bool GenerateTeleportRequest(IXRInteractor interactor, RaycastHit raycastHit, ref TeleportRequest teleportRequest)
    {
        if (raycastHit.collider == null)
            return false;

        var name = InteractionLayerMask.LayerToName(interactor.interactionLayers.value / 2);
        Debug.LogWarning("Layer: " + interactor.interactionLayers.value / 2);
        Debug.LogWarning("Name: " + name);
        var portal = portals.Where(p => p.name.IndexOf(name) != -1).First();

        var tempPortal = FindObjectsOfType<Portal>().Select(p => p.gameObject).Where(p => p.name == portal.name).First();
        tempPortal.transform.rotation = gameObject.transform.rotation * Quaternion.Euler(0, -90f, 0);
        raycastHit.point = raycastHit.point.y < 2.3f ? new Vector3(raycastHit.point.x, 2.3f, raycastHit.point.z) : raycastHit.point;
        tempPortal.transform.position = raycastHit.point + tempPortal.transform.forward * 0.3f;
        //Instantiate(portal, raycastHit.point, gameObject.transform.rotation);

        return false;
    }

    public void Checking()
    {
        Debug.Log("Checking");
    }
}
