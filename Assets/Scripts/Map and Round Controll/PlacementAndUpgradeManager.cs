using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlacementAndUpgradeManager : MonoBehaviour
{
    public GameObject RangeCirclePrefab;
    private GameObject rangeCircle;
    public UIRaycast UIRaycast;

    public ShopManager shopManager;

    public GameObject basicTowerObject;

    private GameObject dummyPlacement;

    private GameObject hoverTile;

    private GameObject currentTowerPlacing;

    private GameObject selectedTower;

    public GameObject SellButton;



    [SerializeField]
    List<GameObject> upgrades;

    public bool IsBuilding;

    public Camera cam;

    public LayerMask mask;
    public LayerMask towerMask;

    
    public void Upgrade()
    {
        if (selectedTower != null)
        {
            if (shopManager.CanBuyUpgrade(selectedTower))
            {
                shopManager.BuyUpgrade(selectedTower);
                SellButton.SetActive(false);
                upgrades[selectedTower.GetComponent<Tower>().IndexOfNextUpgrade].SetActive(false);
                selectedTower.GetComponent<Tower>().Upgrade();
                selectedTower = null;
            }
            
        }
        
    }
    public void SellTower()
    {
        shopManager.SellTower(selectedTower);
        Destroy(selectedTower);
        SellButton.SetActive(false);
        foreach (var upgrade in upgrades)
        {
            upgrade.SetActive(false);
        }
    }
    public void TriggerUpgradeUI()
    {
        if (IsBuilding != true)
        {
            
            if (Input.GetButtonDown("Fire1"))
            {
                if (CheckForTower() != null)
                {
                    SellButton.SetActive(true);
                    selectedTower = CheckForTower();
                    foreach (var upgrade in upgrades)
                    {
                        upgrade.SetActive(false);
                    }
                    int index = selectedTower.GetComponent<Tower>().IndexOfNextUpgrade;
                    if (!(index > upgrades.Count - 1))
                    {
                        if (upgrades[index].activeSelf == false)
                        {
                            upgrades[index].SetActive(true);
                        }
                    }
                }
                //Sets all open Upgrade UI Windows on Inactive when player klicks on mouse without hovering on tower AND without hovering on a button.
                else if (UIRaycast.CheckForButton()==false)
                {
                    SellButton.SetActive(false);
                    selectedTower = null;
                    foreach (var upgrade in upgrades)
                    {
                        upgrade.SetActive(false);
                    }
                }
                

            }
        }
    }
    public Vector2 GetMousePosition()
    {
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void GetCurrentHoverTile()
    {
        Vector2 mousePosition = GetMousePosition();

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, new Vector2(0, 0), 0.1f, mask, -100, 100);

        if (hit.collider != null)
        {
            //Checking if the object detected is a maptile
            if (MapGenerator.MapTiles.Contains(hit.collider.gameObject))
            {
                //Checking if the maptile detected is NOT a pathtile.
                if (!MapGenerator.PathTiles.Contains(hit.collider.gameObject))
                {
                    hoverTile = hit.collider.gameObject;
                }
            }
        }
        else
        {
            hoverTile = null;
        }

    }

    public GameObject CheckForTower()
    {
        GameObject towerOnSlot = null;
        Vector2 mousePosition = GetMousePosition();
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, new Vector2(0, 0), 0.1f, towerMask, -100, 100);

        if (hit.collider != null)
            towerOnSlot = hit.collider.gameObject;

        return towerOnSlot;
    }

    public void PlaceBuilding()
    {
        if (hoverTile != null)
        {
            if (CheckForTower() == null)
            {
                if (shopManager.CanBuyTower(currentTowerPlacing) == true)
                {
                    GameObject newTowerObject = Instantiate(currentTowerPlacing);
                    newTowerObject.layer = LayerMask.NameToLayer("Tower");
                    newTowerObject.transform.position = hoverTile.transform.position;
                    EndBuilding();
                    shopManager.BuyTower(currentTowerPlacing);
                }
                else
                {
                    Debug.Log("You don't have enough money.");
                }
            }
        }
    }
    public void StartBuilding(GameObject towerToBuild)
    {
        IsBuilding = true;
        currentTowerPlacing = towerToBuild;
        dummyPlacement = Instantiate(currentTowerPlacing);
        if (dummyPlacement.GetComponent<Tower>() != null)
        {
            Destroy(dummyPlacement.GetComponent<Tower>());
        }
        if (dummyPlacement.GetComponent<BarrelRotation>() != null)
        {
            Destroy(dummyPlacement.GetComponent<BarrelRotation>());
        }
    }
    public void EndBuilding()
    {
        IsBuilding = false;
        if (dummyPlacement != null)
            Destroy(dummyPlacement);
    }

    public void ShowRangeCircleofSelectedTower()
    {
        if(selectedTower!=null&&rangeCircle==null)
        {

            rangeCircle=Instantiate(RangeCirclePrefab, selectedTower.transform.position, selectedTower.transform.rotation);
            float range = selectedTower.GetComponent<Tower>().Range*2;
            rangeCircle.transform.localScale = new Vector3(range,range,range);
        }
        else if(rangeCircle != null&&selectedTower==null)
        {
            
            Destroy(rangeCircle);
        }
    }

    // Update is called once per frame
    private void Update()
    {

        if (IsBuilding)
        {
            if (dummyPlacement != null)
            {
                GetCurrentHoverTile();
                if (hoverTile != null)
                {

                    dummyPlacement.transform.position = hoverTile.transform.position;
                }
            }
            if (Input.GetButtonDown("Fire1"))
            {
                PlaceBuilding();
            }
        }

        TriggerUpgradeUI();
        ShowRangeCircleofSelectedTower();
    }
}
