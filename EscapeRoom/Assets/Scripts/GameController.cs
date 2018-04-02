//
//  GameController.cs
//  Manage control of the game state
//  Copyright 2018 Disi Studios LLC
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public BatterySystemClass BatterySystem;
    public LifeSupportClass LifeSupportSystem;
    public LightingSystemClass LightingSystem;
    public DoorSystemClass DoorSystem;
    public  List<ShipSystemClass> shipSystems;

    public GameController()
    {
        CurrentState = GameStateEnum.Running;           // TODO: Have this start at PreGame JPR

        shipSystems = new List<ShipSystemClass>();
        Time = 0;
    }

    // Use this for initialization
    void Start () {

        InvokeRepeating("TimeUpdate", 1, 1);
        Valve.VR.InteractionSystem.Teleport.instance.CancelTeleportHint();

        shipSystems.AddRange(new ShipSystemClass[] { PowerSystem, BatterySystem, LifeSupportSystem, LightingSystem, DoorSystem });
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void TimeUpdate()
    {
        if (CurrentState == GameStateEnum.Running)
        { 
            // Increment time
            Time++;

            int i = 0;
            double PowerRequested = 0;
            // Use power from ship's generator first
            for (; i < shipSystems.Count; i++)
            {
                PowerRequested = shipSystems[i].PowerRequested();
                if(!PowerSystem.UseCharge(PowerRequested))
                {
                    // This means that the power usage of the ship has exceeded the power created by the generator in the 
                    // power system. At this point the logic will transition to using the batteries for power.
                    // Break out of the loop keeping i the same
                    break;
                }
            }

            // Anything leftover in the generator will credit or debit battery charge as necessary
            for (; i < shipSystems.Count; i++)
            {
                PowerRequested = shipSystems[i].PowerRequested();
                if (BatterySystem.UseCharge(PowerRequested))
                {
                    // At this point the battery system can no longer supply power to anything
                    // Should put a trigger here to alert players that they are FUCKED
                    shipSystems[i].ChargeFailed();
                }
            }

            // Update the ship systems
            for (i = 0; i < shipSystems.Count; i++)
            {
                shipSystems[i].TimeUpdate(Time);
            }

            // Update the players
        }
    }

    public void SetupLevel(int LevelNumber)
    {
        // Load the level info for the level
        // Maybe dynamically create the level with prefabs
        // Add all the light objects to the lighting system
        // Add all the doors to the door system
    }
}
