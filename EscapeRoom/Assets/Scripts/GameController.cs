﻿//
//  GameController.cs
//  Manage control of the game state
//  Copyright 2018 Disi Studios LLC
//
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    #region Singleton Scene Persistent Nonsense
    private static GameController instance;
    public static GameController Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            DestroyImmediate(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public enum GameStateEnum
    {
        PreGame,
        Running,
        Paused,
        Lost
    }

    public int Time {get; private set; }
    public GameStateEnum CurrentState;
    public PowerSystemClass PowerSystem;
    public RechargeSystemClass RechargeSystem;
    public BatterySystemClass BatterySystem;
    public LifeSupportClass LifeSupportSystem;
    public LightingSystemClass LightingSystem;
    public DoorSystemClass DoorSystem;
    public List<ShipSystemClass> shipSystems;
    public GameObject VRWatch;
    public Tutorial CurrentStory;

    public int maxMessages = 30;
    public Color playerMessage, info;

    public string userName;

    Queue<string> consoleHistory = new Queue<string>();
    bool ConsoleActive = false;

    private List<IndependentPowerSystem> IndependentSystems;

    public GameController()
    {
        CurrentState = GameStateEnum.Running;           // TODO: Have this start at PreGame JPR
        
        IndependentSystems = new List<IndependentPowerSystem>();
        shipSystems = new List<ShipSystemClass>();
        Time = 0;
    }

    // Use this for initialization
    void Start () {

        InvokeRepeating("TimeUpdate", 1, 1);
        Valve.VR.InteractionSystem.Teleport.instance.CancelTeleportHint();

        shipSystems.AddRange(new ShipSystemClass[] { PowerSystem, RechargeSystem, BatterySystem, LifeSupportSystem, LightingSystem, DoorSystem });

        var foundObjects = FindObjectsOfType<Rigidbody>();

        foreach (Rigidbody r in foundObjects)
        {
            if (r.collisionDetectionMode == CollisionDetectionMode.Continuous)
            {
                Debug.Log(r.gameObject.name);
            }
        }
    }

    void TimeUpdate()
    {
        if (CurrentState == GameStateEnum.Running)
        {
            // Increment time
            Time++;

            // Story Time!
            CurrentStory.TimeUpdate();
            
            UpdateSystemPower();
            UpdateIndependentPowerSystems();

            // Update the ship systems
            for (int i = 0; i < shipSystems.Count; i++)
            {
                shipSystems[i].TimeUpdate(Time);
            }

            // Update the players
        }

    }

    private void UpdateSystemPower()
    {
        double PowerRequested = 0;
        double TotalPowerRequested = 0;
        // Use power from ship's generator first
        for (int i = 0; i < shipSystems.Count; i++)
        {
            PowerRequested = shipSystems[i].PowerRequested();
            if (!PowerSystem.UseCharge(PowerRequested))
            {
                // At this point the battery system can no longer supply power to anything
                // Should put a trigger here to alert players that they are FUCKED
                shipSystems[i].ChargeFailed();
            }
            TotalPowerRequested += PowerRequested;
        }

        PowerSystem.UpdateTotalDraw(TotalPowerRequested);
    }

    private void UpdateIndependentPowerSystems()
    {
        foreach(IndependentPowerSystem system in IndependentSystems)
        {
            system.SystemUpdate();
        }
    }

    public void SetupLevel(int LevelNumber)
    {
        // Load the level info for the level
        // Maybe dynamically create the level with prefabs
        // Add all the light objects to the lighting system
        // Add all the doors to the door system
    }

    void Update()
    {

    }

    public static float StepValue(float CurrentValue, float IntendedValue, float Step)
    {
        float retVal = CurrentValue;

        float Diff = CurrentValue - IntendedValue;
        if (Diff != 0)
        {
            if (Mathf.Abs(Diff) <= Step)
            {
                retVal = IntendedValue;
            }
            else if(Diff < 0)
            {
                retVal = CurrentValue + Step;
            }
            else
            {
                retVal = CurrentValue - Step;
            }
        }

        return retVal;
    }

    public void AddRechargePoint(RechargePoint rechargePoint)
    {
        
    }

    public void AddIndependentPowerSystem(IndependentPowerSystem independentPowerSystem)
    {
        IndependentSystems.Add(independentPowerSystem);
    }

    public void RemoveIndependentPowerSystem(IndependentPowerSystem independentPowerSystem)
    {
        IndependentSystems.Remove(independentPowerSystem);
    }
}
