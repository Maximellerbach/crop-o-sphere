using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCity : MonoBehaviour
{
    public bool placing = false;
    private GameObject goPlacing;
    private Collider goCol;
    public void PlaceItem(GameObject gameObject, Transform parent)
    {
        if (placing == true) { return; }
        placing = true;

        goPlacing = Instantiate(gameObject);
        goPlacing.transform.SetParent(parent);
        goCol = goPlacing.GetComponentInChildren<Collider>();
        goCol.enabled = false;

    }

    public void DonePlacing()
    {
        goCol.enabled = true;
        placing = false;
    }

    void Update()
    {
        if (placing == false) { return;}

        Vector3 mouse = Input.mousePosition;
        bool mouseClick = Input.GetMouseButtonDown(0);
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.name == "Sphere")
            {
                goPlacing.transform.position = hit.point;
                goPlacing.transform.rotation = Quaternion.FromToRotation (goPlacing.transform.forward, hit.normal) * goPlacing.transform.rotation;
            }
        }
        if (mouseClick && Vector3.Distance(goPlacing.transform.position, Vector3.zero) < 200) // TODO: check whether the location is valid
        {
            DonePlacing();
        }
    }
}
