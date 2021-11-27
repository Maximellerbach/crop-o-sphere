using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCity : MonoBehaviour
{
    public bool placing = false;
    public bool valid = false;
    private GameObject goPlacing;
    private Collider goCol;
    public void PlaceItem(GameObject gameObject, Transform parent)
    {
        if (placing == true) { Destroy(goPlacing); valid = false; }
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
        valid = false;
    }

    void Update()
    {
        if (placing == false) { return; }

        Vector3 mouse = Input.mousePosition;
        bool mouseClick = Input.GetMouseButtonDown(0);
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.name == "Sphere")
            {
                goPlacing.transform.position = hit.point;
                goPlacing.transform.rotation = Quaternion.FromToRotation(goPlacing.transform.forward, hit.normal) * goPlacing.transform.rotation;
                valid = true;
            }
            else { valid = false; }
        }
        if (mouseClick && valid) // TODO: check whether the location is valid
        {
            DonePlacing();
        }
    }
}
