﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EventCardUpdate : MonoBehaviour {

    public GameObject eventCard;
    private GameManager gameM;
    private Event curEvent;

	// Use this for initialization
	void Start () {
        gameM = GameManager.Instance;
    }
	
	// Update is called once per frame
	void Update () {
        NewEvent();
	}

    void NewEvent ()
    {
        curEvent = gameM.GetCurrentEvent();
        if (gameM.newT)
        {
            if (curEvent.id != -1) {
                GameObject patateobject = Instantiate(eventCard, new Vector3(-1, 3, 0), Quaternion.identity) as GameObject;
                Text[] textM = patateobject.GetComponentsInChildren<Text>();
                textM[0].text = curEvent.FlavorText + "\n ";
                textM[1].text = "Art: ";
                textM[1].text += definitionEvent((int)(curEvent.teamArtEffect*100)) + "\n";
                textM[1].text += "Programming: ";
                textM[1].text += definitionEvent((int)(curEvent.teamProgEffect * 100)) + "\n";
                textM[1].text += "Hack: ";
                textM[1].text += definitionEvent((int)(curEvent.teamSaltEffect * 100)) + "\n";
                textM[1].text += "Sleeping: ";
                textM[1].text += definitionEvent((int)(curEvent.teamSleepEffect * 100));
                Destroy(patateobject, 5);
            }
            gameM.newT = false;
            Debug.Log(curEvent.id);
        }
    }

    string definitionEvent(int impact) {
        Debug.Log(impact);
        switch (impact)
        {
            case 1: return "Enough";
            case 25: return "A lot";
            case 50: return "fair";
            case  75: return "A bit";
            case 100: return "No bonus";
            case 125: if (curEvent.teamSaltEffect == 1.25)
                    return "A lot";
                else
                    return "Enough";
            default: return "A bit";
        }
    }
}
