//
//  GameController.cs
//  Manage control of the game state
//  Copyright 2018 Disi Studios LLC
//
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
    public Text ConsoleText;
    public GameObject ConsoleContainer;
    public GameObject MiniMap;
    public PowerSystemClass PowerSystem;
    public BatterySystemClass BatterySystem;
    public LifeSupportClass LifeSupportSystem;
    public LightingSystemClass LightingSystem;
    public DoorSystemClass DoorSystem;
    public  List<ShipSystemClass> shipSystems;

    public int maxMessages = 30;
    public Color playerMessage, info;

    public GameObject newConsolePanel, textObject, conBox, inpField;
    public InputField chatBox;
    public string userName;

    Queue<string> consoleHistory = new Queue<string>();
    bool ConsoleActive = false;

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
	

    public void AppendToConsole(string TextToAppend)
    {
        if (consoleHistory.Count > 30)
            consoleHistory.Dequeue();

        consoleHistory.Enqueue(TextToAppend);
        ConsoleText.text = string.Join("\n", consoleHistory.ToArray());
    }

    public void ToggleConsole()
    {
        ConsoleActive = !ConsoleActive;
        ConsoleContainer.SetActive(ConsoleActive);
        

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

    [SerializeField]
    List<Message> messageList = new List<Message>();

    void Update()
    {
        if (chatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToConsole(userName + ": " + chatBox.text, Message.MessageType.playerMessage);
                chatBox.text = "";
            }
        }
        else
        {
            if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
                chatBox.ActivateInputField();

        }

        if (!chatBox.isFocused)
        {
            //The idea for this if to set responses for things the player types,
            //But i don't really know how to yet
            //It should be noted that currently this is reacting to keypresses while the box is focused, so regardless of typing this will trigger...
            if (Input.GetKeyDown(KeyCode.Y))
            {
                SendMessageToConsole("Ship Exploding in 5, 4, 3 , 2, PSYCH", Message.MessageType.info);
                Debug.Log("Y");
            }
        }

    }


    public void SendMessageToConsole(string text, Message.MessageType messageType)
    {
        //sends  messages to console
        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);

        }
        Message newMessage = new Message();

        newMessage.text = text;

        GameObject newText = Instantiate(textObject, newConsolePanel.transform);

        newMessage.textObject = newText.GetComponent<Text>();

        newMessage.textObject.text = newMessage.text;
        newMessage.textObject.color = MessageTypeColor(messageType);

        messageList.Add(newMessage);
    }

    bool chatActive = false;
    public void ToggleNewConsole()
    {
        //This turns the chatbox and input field on/off
        chatActive = !chatActive;
        inpField.SetActive(chatActive);
        conBox.SetActive(chatActive);

    }

    Color MessageTypeColor(Message.MessageType messageType)
    {
        //system or player color specificity is kind of neat
        Color color = info;

        switch (messageType)
        {
            case Message.MessageType.playerMessage:
                color = playerMessage;
                break;
        }

        return color;
    }

    [System.Serializable]
    public class Message
    {
        public string text;
        public Text textObject;
        public MessageType messageType;

        public enum MessageType
        {
            playerMessage,
            info
        }
    }
}
