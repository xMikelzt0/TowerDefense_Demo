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
    public GameObject sellEffect;

    //void Start()
    //{
    //    turretToBuild = standardTurretPrefab;
    //}

    private TurretBlueprints turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);

        //UIManager.instance.SelectNode(node);
    }
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    //public GameObject GetTurretToBuild()
    //{
    //    return turretToBuild;
    //}

    public void SelectTurretToBuild(TurretBlueprints turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }
    public TurretBlueprints GetTurretToBuild()
    {
        return turretToBuild;
    }

}
