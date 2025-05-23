using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprints standardTurret;
    public TurretBlueprints missileLauncher;
    public TurretBlueprints laserBeamer;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Standard turret selected!");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher selected!");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer selected!");
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}
