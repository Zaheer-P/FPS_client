using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour   
{

    private AudioSource footstepSound;
    private PlayerMovement script;
    [SerializeField]
    private AudioClip[] audioClips;
    [HideInInspector]
    public float stepDistance;
    [HideInInspector]
    public float volume_Min, volume_Max;
    private bool Grounded;
    private Rigidbody rigidB;
    private float accumlatedDistance;
     
    


//if player grounded and movement key is pressed play sound
    void Awake()
    {
        footstepSound = GetComponent<AudioSource>();
        rigidB = gameObject.GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckToPlaySound(); 
    }

    void CheckToPlaySound()
    {
        Grounded = gameObject.GetComponentInParent<PlayerMovement>().grounded;
        if (!Grounded)
            return;
        //above code check if player is not on the ground
        //if the player is not on ground exit function

        //to see if the player has moved other then standered idle position hense > 1
        if (rigidB.velocity.sqrMagnitude > 1)
        {
            accumlatedDistance += Time.deltaTime;
            if (accumlatedDistance > stepDistance)
            {
                footstepSound.clip = audioClips[Random.Range(0, audioClips.Length)];
                footstepSound.Play();
                footstepSound.volume = Random.Range(volume_Min, volume_Max);
                accumlatedDistance = 0f;
                
            }
        }
        else
        {
            accumlatedDistance = 0f;
        }
        
    }
}
