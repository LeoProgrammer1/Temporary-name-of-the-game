using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogue;
    [SerializeField] private GameObject task;
    [Space]
    [SerializeField] private Text nameText;
    [SerializeField] private Text proposalText;
    [SerializeField] private new string name;
    [TextArea(1, 3)] [SerializeField] private string[] proposal;
    [Space]
    [SerializeField] private bool heStartsTheDialogueHimself;
    [SerializeField] private bool haveTheyMet;
    [Tooltip("In Which Sentence Do We Find Out The Name Of The Character")]
    [SerializeField] private int proposal_;
    private bool startDialog;
    int i, e = 0;
    [Space]
    [SerializeField] private GameObject player;
    void Update()
    {
        if (startDialog)
        {
            if (haveTheyMet) nameText.text = name;
            else nameText.text = "...";

            if (!heStartsTheDialogueHimself)
            {
                if (Input.GetKeyDown(KeyCode.E) && e < 2)
                {
                    dialogue.SetActive(true);
                    player.GetComponent<PlayerMove>().enabled = false; e += 1;
                }
                if (Input.GetKeyDown(KeyCode.E) && e > 1) i++;
                if (i == proposal_) haveTheyMet = true;
                if (i >= proposal.Length)
                {
                    i = 0; e = 0;
                    startDialog = false;
                    task.SetActive(true);
                    dialogue.SetActive(false);
                    player.GetComponent<PlayerMove>().enabled = true;
                }
                else proposalText.text = proposal[i];
            }
            if (heStartsTheDialogueHimself)
            {
                dialogue.SetActive(true);
                player.GetComponent<PlayerMove>().enabled = false;

                if (Input.GetKeyDown(KeyCode.E)) i++;
                if (i == proposal_) haveTheyMet = true;
                if (i >= proposal.Length)
                {
                    i = 0;
                    startDialog = false;
                    task.SetActive(true);
                    dialogue.SetActive(false);
                    heStartsTheDialogueHimself = false;
                    player.GetComponent<PlayerMove>().enabled = true;
                }
                else proposalText.text = proposal[i];
            }
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            startDialog = true;
        }
    }
}