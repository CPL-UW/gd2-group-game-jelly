using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randoControllerScript : MonoBehaviour
{
    public GameObject FlashlightMaster;
    public GameObject EMFMaster;
    public GameObject VacuumMaster;
    public GameObject BSMaster;

    public GameObject RockMaster;
    public GameObject PaperMaster;
    public GameObject ScissorsMaster;

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

    public int Card = 0;
    public int CardQuadrant = 0; //which corner to spawn the card in
    public int CardX = 0;
    public int CardY = 0;

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

    public void spawnCard(){
        CardQuadrant = Random.Range(1,5);
        switch (CardQuadrant)
        {
            case 1: //top left
                CardX = Random.Range(3,10);
                CardY = Random.Range(-7,-2);
                break;
            case 2: //top right
                CardX = Random.Range(12,25);
                CardY = Random.Range(-7,-2);
                break;
            case 3: //bottom left
                CardX = Random.Range(3,16);
                CardY = Random.Range(-13,-9);
                break;
            case 4: //bottom right
                CardX = Random.Range(18,25);
                CardY = Random.Range(-13,-9);
                break;
            default:
                Debug.Log("Huh?");
                break;
        }
        Card = Random.Range(1,4);
        switch (Card)
        {
            case 1: //rock
                Instantiate(RockMaster, new Vector3(CardX,CardY,0), Quaternion.identity);
                break;
            case 2: //paper
                Instantiate(PaperMaster, new Vector3(CardX,CardY,0), Quaternion.identity);
                break;
            case 3: //scissors
                Instantiate(ScissorsMaster, new Vector3(CardX,CardY,0), Quaternion.identity);
                break;
            default:
                Debug.Log("Uh oh");
                break;
        }
    }
}
