using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;

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

        buildManager.BuildTurretOn(this);

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
