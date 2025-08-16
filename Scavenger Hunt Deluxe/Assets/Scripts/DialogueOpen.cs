using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOpen : MonoBehaviour
{

    public string dialogue;
    public GameObject interfaceManager;
    public PlayerHolding pHolding;
    public bool begin = true;
    public bool end = false;
    private string[] collectibles;
    private int clue;
    private string[] thanks;
    private string[] notit;

    private AudioSource greeting;

    // Start is called before the first frame update
    void Start()
    {
        greeting = GetComponent<AudioSource>();
        collectibles = new string[] { "film", "balloons", "life saver", "bull's eye", "pipe", "I've lost the key to my house, can you help?", "fish", "birdhouse", "red airhorn", "magic hat" };
        thanks = new string[] { "film", "balloons", "life saver", "bull's eye", "pipe", "Thank you now I can return home!", "fish", "birdhouse", "red airhorn", "magic hat" };
        notit = new string[] { "film", "balloons", "life saver", "bull's eye", "pipe", "No that's not my key but please continue looking.", "fish", "birdhouse", "red airhorn", "magic hat" };
        createClue();
    }

    public void createClue()
    {
        clue = Random.Range(0, 9);
        searchDialogue();
    }
    public void searchDialogue()
    {
        dialogue = collectibles[clue];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!begin && pHolding.Verify())
        {
            checkClue();
        }
        greeting.Play(0);
        interfaceManager.GetComponent<InterfaceManager>().ShowBox(dialogue, clue);
    }

    private void checkClue()
    {
        if (pHolding.holdValue == clue)
        {
            dialogue = thanks[clue] ;
            end = true;
        }
        else
        {
            dialogue = "No, that's not my " + notit[clue] + ".";
        }
    }

    public void coinsScattered()
    {
        begin = false;
    }

}
