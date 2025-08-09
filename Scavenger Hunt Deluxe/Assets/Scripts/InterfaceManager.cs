using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InterfaceManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public Image seekImage;
    public GameObject npc;
    public GameObject randomSpawn;

    [SerializeField]
    private Sprite[] collectibleSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CollectibleUpdate(int item)
    {

    }

    public void ShowBox(string dialogue, int item)
    {
        if (npc.GetComponent<DialogueOpen>().begin)
        {
            scatterCoins();
        }
    }

    public void scatterCoins()
    {
        randomSpawn.GetComponent<RandomSpawn>().DistributeCollectibles();
        npc.GetComponent<DialogueOpen>().coinsScattered();
    }
}
