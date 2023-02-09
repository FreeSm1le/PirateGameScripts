using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;

public class CombatAudioProcessor : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event _attackOne;
    [SerializeField] private AK.Wwise.Event _attackTwo;
    [SerializeField] private AK.Wwise.Event _attackThree;
    [SerializeField] private AK.Wwise.Event _attackOnePhrase;
    [SerializeField] private AK.Wwise.Event _takeDamage;

    vThirdPersonInput _tpInput;
    vThirdPersonController _tpController;

    void Start()
    {
        _tpInput = GetComponent<vThirdPersonInput>();
        _tpController = GetComponent<vThirdPersonController>();
    }

    private void PlayAttackSound(string NumberOfAttack)
    {
        AK.Wwise.Event wwiseEvent = null;

        if (NumberOfAttack = AudioGlobalTextVariables.AttackOne)
        {
            wwiseEvent = _attackOne;
        }
        else if (NumberOfAttack = AudioGlobalTextVariables.AttackTwo)
        {
            wwiseEvent = _attackTwo;

        else if (NumberOfAttack = AudioGlobalTextVariables.AttackThree)
            {
                wwiseEvent = _attackThree;
            }

            wwiseEvent.Post(gameObject);
            _attackOnePhrase.Post(gameObject);
        }
    }

    private void PlayTakeDamageSound()
    {
        _takeDamage.Post(gameObject);
    }
}

