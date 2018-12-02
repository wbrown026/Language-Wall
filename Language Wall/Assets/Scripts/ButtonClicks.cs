using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClicks : MonoBehaviour {

    public GameObject howToPanel; //The How To Panel of the title scene

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /**
     * This function is called when the player clicks on the "Play" button in the title scene 
     * When the "Play" button is clicked, it's goes to the game scene
     * 
     * @param scene - The name of the next scene
     */
    public void Play_Onclick(string scene)
    {
        Application.LoadLevel(scene);
    }

    /**
     * This function is called when the player clicks on the "How to Play" button in the title scene.
     * When the "How To Play" button is clicked, a new window opened up, telling the player instructions
     * on how to play the game
     */
    public void HowToPlay_Onclick()
    {
        howToPanel.SetActive(true);
    }

    /**
     * This function is called when the player clicks on the "Back" button in the "How To Play" window in the title scene.
     * When the "Back" button is clicked, the "How To Play" window disappears
     */
    public void Back_Onclick()
    {
        howToPanel.SetActive(false);
    }
}
