using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameObject gemGreen;
    public GameObject background;
    public string teleportDestination;

    private void OnTriggerEnter(Collider other)
    {
        if (gemGreen.activeInHierarchy == false)
        {
            background.GetComponent<GameManager>().TeleportOpen(teleportDestination);
        }
    }
}
