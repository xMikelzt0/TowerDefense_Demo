using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }


    //public GameObject standardTurretPrefab;
    //public GameObject missileLauncherPrefab;

    public GameObject buildEffect;

    //void Start()
    //{
    //    turretToBuild = standardTurretPrefab;
    //}

    private TurretBlueprints turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret built! Money left: " + PlayerStats.Money);
    }

    //public GameObject GetTurretToBuild()
    //{
    //    return turretToBuild;
    //}

    public void SelectTurretToBuild(TurretBlueprints turret)
    {
        turretToBuild = turret;
    }

    //public void SetTurretToBuild(GameObject turret)
    //{
    //    turretToBuild = turret;
    //}
}
