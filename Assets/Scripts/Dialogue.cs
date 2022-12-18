using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject player;
    public GameObject dialogue;
    public GameObject task;
    public bool startDialog;

    public Text nameText;
    public Text proposalText;
    public new string name;
    [TextArea(1, 3)] public string[] proposal;
    int i = 0;

    private void Start()
    {
        nameText.text = "...";
        proposalText.text = " ";
    }
    private void Update()
    {
        if (startDialog)
        {
            if (Input.GetKeyDown(KeyCode.E)) { i++; }
            if (i == 6) { nameText.text = name; }
            if (i >= proposal.Length)
            {
                i = 0;
                startDialog = false;
                task.SetActive(true);
                dialogue.SetActive(false);
                player.GetComponent<PlayerMove>().enabled = true;
            }
            else { proposalText.text = proposal[i]; player.GetComponent<PlayerMove>().enabled = false; }
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            dialogue.SetActive(true);
            startDialog = true;
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            dialogue.SetActive(false);
            startDialog = false;
        }
    }
}