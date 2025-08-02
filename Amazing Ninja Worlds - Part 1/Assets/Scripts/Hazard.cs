using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{       
    public GameObject background;
    public GameObject HealthBar;
    private void OnTriggerEnter(Collider other)
    {
        background.GetComponent<GameManager>().moveToCheckPoint();
        HealthBar.GetComponent<LifeHUD>().HurtPlayer();
    }
}
