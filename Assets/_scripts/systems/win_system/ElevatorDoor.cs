﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private AudioClip openDoorClip;
    [SerializeField] private AudioClip closeDoorClip;

    [SerializeField] private string startLevelTrigger = "startLevel";
    [SerializeField] private string closingBool = "isClosed";

    private void Start()
    {
        EventManager.SubscribeToEvent(Constants.ON_PLAYER_CLEARED_FLOOR, this.OpenDoor);
        EventManager.SubscribeToEvent(Constants.ON_PLAYER_LEFT_ELEVATOR, this.CloseDoor);

        m_animator.SetTrigger(startLevelTrigger);
        OpenDoor();
    }

    private void OpenDoor(params object[] vs)
    {
        this.m_animator.SetBool("isClosed", false);
        if (openDoorClip != null)
            SoundManager.instance.PlayAmbient(openDoorClip);
    }
    private void CloseDoor(params object[] vs)
    {
        this.m_animator.SetBool("isClosed", true);

        if (closeDoorClip != null)
            SoundManager.instance.PlayMusic(closeDoorClip);
    }
}
