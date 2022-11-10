using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randoControllerScript : MonoBehaviour
{
    public GameObject FlashlightMaster;
    public GameObject EMFMaster;
    public GameObject VacuumMaster;
    public GameObject BSMaster;

    public GameObject FlashlightDefault;
    public GameObject FlashlightDefault2;
    public GameObject EMFDefault;
    public GameObject VacuumDefault;
    public GameObject BSDefault;

    public int FLX = 0;
    public int FLY = 0;
    public int EMFX = 0;
    public int EMFY = 0;
    public int VX = 0;
    public int VY = 0;

    public int FLX2 = 0;
    public int FLY2 = 0;

    public int BSX = 0;
    public int BSY = 0;

    void Start()
    {
        
    }

    public void randoItems(){
        Destroy(FlashlightDefault);
        Destroy(FlashlightDefault2);
        Destroy(EMFDefault);
        Destroy(VacuumDefault);
        Destroy(BSDefault);

        FLX = Random.Range(3,10);
        FLY = Random.Range(-7,-2);
        FLX2 = Random.Range(18,25);
        FLY2 = Random.Range(-14,-9);
        EMFX = Random.Range(12,16);
        EMFY = Random.Range(-13,-10);
        VX = Random.Range(12,16);
        VY = Random.Range(-6,-3);

        Instantiate(FlashlightMaster, new Vector3(FLX,FLY,0), Quaternion.identity);
        Instantiate(FlashlightMaster, new Vector3(FLX2,FLY2,0), Quaternion.identity);
        Instantiate(EMFMaster, new Vector3(EMFX,EMFY,0), Quaternion.identity);
        Instantiate(VacuumMaster, new Vector3(VX,VY,0), Quaternion.identity);
    }
}
