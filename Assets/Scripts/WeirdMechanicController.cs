using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeirdMechanicController : MonoBehaviour
{
    public Player1_Controller[] CharactersArray;
    public int CurrentPLayer;
    // Start is called before the first frame update
    void Start()
    {
        CurrentPLayer = 0;
        for (int i = 0; i < CharactersArray.Length; i++)
        {
            CharactersArray[i].GetComponent<PlayerInput>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangePlayer()
    {
        for(int i = 0; i < CharactersArray.Length; i++)
        {
            print("ENABLE");
            if (i == CurrentPLayer)
            {
                CharactersArray[i].GetComponent<PlayerInput>().enabled = true;
            }else
            {
                CharactersArray[i].GetComponent<PlayerInput>().enabled = false;
            }
        }
    }
    public void SetNextPlayer(InputAction.CallbackContext context)
    {
        if(CurrentPLayer < CharactersArray.Length - 1)
        {
            if (context.performed)
            {
                CurrentPLayer++;
                ChangePlayer();
            }
        }
    }
    public void SetPreviousPlayer(InputAction.CallbackContext context)
    {
        if(CurrentPLayer > 0)
        {
            if (context.performed)
            {
                CurrentPLayer--;
                ChangePlayer();
            }
        }
    }
}
