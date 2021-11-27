using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFarm : MonoBehaviour
{
    GameObject tractor;
    Inventory inventory;

    private bool placing = false;
    private bool valid = false;
    private GameObject goPlacing;
    private string goFoodType;
    private Collider goCol;

    void Start()
    {
        tractor = GameObject.FindGameObjectWithTag("tractor");
        inventory = tractor.GetComponent<Inventory>();
    }

    public void PlaceItem(string foodType, GameObject gameObject, Transform parent)
    {
        if (!inventory.HasEnoughRessources(foodType)) {return; }
        if (placing == true && valid == false) { Destroy(goPlacing); valid = false; }
        placing = true;

        goFoodType = foodType;
        goPlacing = Instantiate(gameObject);
        goPlacing.transform.SetParent(parent);
        goCol = goPlacing.GetComponentInChildren<Collider>();
        goCol.enabled = false;

    }

    public void DonePlacing()
    {
        inventory.ApplyTile(goFoodType);
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
        else { valid = false; }

        if (mouseClick && valid) // TODO: check whether the location is valid
        {
            DonePlacing();
        }
    }
}
