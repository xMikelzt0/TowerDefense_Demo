using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprints turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;


    BuildManager buildManager;

    private Renderer rend;
    private Color startColor;

    

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        {
            //Debug.Log("Can't build there! - Turret or building exists.");
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
        {           
            return;
        }
        BuildTurret(buildManager.GetTurretToBuild());

        //buildManager.BuildTurretOn(this);

        //GameObject turretToBuild = buildManager.GetTurretToBuild();
        //turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

        //turret = TurretManager.instance.GetTurretToBuild();
        //if (turret != null)
        //{
        //    GameObject turretGO = (GameObject)Instantiate(turret, transform.position, Quaternion.identity);
        //    turretGO.transform.parent = transform;
        //    //Debug.Log("Turret built on node: " + gameObject.name);
        //}
    }

    void BuildTurret(TurretBlueprints blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);


        Debug.Log("Turret built!");
    }
    public void UpgradeTurret(/*TurretBlueprints blueprint*/)
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade that!");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        //// Destroy old turret
        Destroy(turret);

        // Build new turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;

        Debug.Log("Turret upgraded!");
    }
    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        Destroy(turret);
        turretBlueprint = null;

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret sold!");
    }
    void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(!buildManager.CanBuild)
        {
            return;
        }

        if(buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
        rend.material.color = hoverColor;
        
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
        
    }
}
