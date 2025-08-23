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
        collectibles = new string[] { "I've dropped my film can you find it for me?", "My balloon has blown away can you retrieve it.", "Please help me find the life saver. They can't swim!", "Find my bull's eye please. I'm bored now!", "Find my pipe so I can smoke please.", "I've lost the key to my house, can you help?", "Please find my fish. He's out of the water", "My birdhouse fell can you find me a new one?", "I need a red airhorn to scare these birds away!", "I give you a magic hat but you need to find MY magic hat" };
        thanks = new string[] { "I can finally watch this 5 star movie! Thanks!", "Thank You so much. I now have a gift for my niece!", "Thanks to you a life was saved!", "Yay! Now we can have some fun with the bull's eye!", "Finally! I'm able to smoke with my pipe!", "Thank you now I can return home!", "Thanks for saving my fish!", "My birds now have a new birdhouse!", "The red airhorn scared those wretched creatures!", "Here's your magic hat for finding mine!" };
        notit = new string[] { "film please continue looking", "balloon. Please hurry!", "life saver. Be quick!", "bull's eye. BTW I'm still waiting!", "PIPE. I NEED TO SMOKE RIGHT NOW!", "key please continue your search", "fish. He's still out there!", "birdhouse. My birds are starting to go hungry now.", "red airhorn. they're hitting my toes!", "magic hat. You won't get yours." };
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
