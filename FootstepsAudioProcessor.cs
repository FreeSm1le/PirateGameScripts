using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;

public class WwiseFootsteps : MonoBehaviour
{
    [SerializeField] private gameObject _footLeft;  
    [SerializeField] private gameObject _footRight; 
    [SerializeField] private AK.Wwise.Event _footevent; 
    [SerializeField] private LayerMask _lm;

    private vThirdPersonInput _tpInput;
    private vThirdPersonController _tpController;

    private void Start()
    {
        _tpInput = GetComponent<vThirdPersonInput>();
        _tpController = GetComponent<vThirdPersonController>();
    }

    private void PlayFootstep(string side) // call by animator
    {
        if (tpInput.cc.inputMagnitude < 0.1)
            return;

        GameObject footObject = null;
        
        if (side == AudioGlobalTextVariables.Left) 
        {
            footObject = footLeft;
        }
        else if (side == AudioGlobalTextVariables.Right) 
        {
            footObject = footRight;
        }

        if (Physics.Raycast(footObject.transform.position, Vector3.down, out RaycastHit hit, 0.6f, _lm)) 
        {
            AkSoundEngine.SetSwitch(AudioGlobalTextVariables.Surface, hit.collider.tag, footObject);  

            if (_tpController.isSprinting)
            {
                AkSoundEngine.SetSwitch(AudioGlobalTextVariables.Locomotion, AudioGlobalTextVariables.Running, footObject);
            }
            else 
            {
                AkSoundEngine.SetSwitch(AudioGlobalTextVariables.Locomotion, AudioGlobalTextVariables.Walking, footObject);
            }
 
            _footevent.Post(footObject);
        }
    }
}
