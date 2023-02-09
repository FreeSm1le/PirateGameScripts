using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController.AI;
using Invector.vCharacterController;


public class MusicSwitchBattle : MonoBehaviour
{
    [SerializeField] private v_AIController _enemyOne;
    [SerializeField] private v_AIController _enemyTwo;
    [SerializeField] private v_AIController _enemyThree;
    [SerializeField] private bool _inCombat;
    [SerializeField] private gameObject _player;

    void Update()
    {
        if (inCombat == false)
        {
            if(_enemyOne.headTarget || _enemyTwo.headTarget || _enemyThree.headTarget)
            {
                AkSoundEngine.SetSwitch(AudioGlobalTextVariables.MusicContainer, AudioGlobalTextVariables.BattleState, _player);
                inCombat = true;
            }
        }

        else
        {
            if (_enemyOne.isDead == true & _enemyTwo.isDead == true & _enemyThree.isDead == true)
            {
                inCombat = false;
                AkSoundEngine.SetState(AudioGlobalTextVariables.MusicContainer.AmbState, AudioGlobalTextVariables.MusicStateExploration);
                AkSoundEngine.SetSwitch(AudioGlobalTextVariables.MusicContainer, AudioGlobalTextVariables.AmbientSwitchExploration, _player);
            }
        }
    }
}
