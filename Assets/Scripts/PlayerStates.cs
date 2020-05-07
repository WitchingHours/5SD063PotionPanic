using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerInput
{
    JoyCon1,
    JoyCon2,
    Mouse,
    Keyboard_WASD,
    Keyboard_IJKL
}

class Player
{
    public PlayerInput input = PlayerInput.Keyboard_WASD;
}
public class PlayerStates : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
