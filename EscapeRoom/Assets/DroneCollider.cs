using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCollider : MonoBehaviour
{
    public int HitPoints { get; private set; }
    public GameObject GameOverPanel;
    public PlayerController Player;
    private bool Invincible;

    [SerializeField]
    private float invincibilityDurationSeconds = 2;

    // Start is called before the first frame update
    void Start()
    {
        HitPoints = 10;        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CollideWithEnemy(Enemy enemy)
    {
        if (Invincible)
            return;

        DamagePlayer(enemy);
    }

    private void DamagePlayer(Enemy enemy)
    {
        HitPoints = HitPoints - enemy.DamagePlayer;
        Debug.Log($"HP: {HitPoints}");
        if (HitPoints <= 0)
        {
            HitPoints = 0;
            GameOverPanel.SetActive(false);
            GameOverPanel.SetActive(true);
            Player.SetCanInteract(false);
        }

        StartCoroutine(BeginInvincibleFrames());
    }

    private IEnumerator BeginInvincibleFrames()
    {
        Invincible = true;
        Debug.Log("Begin I Frames");

        yield return new WaitForSeconds(invincibilityDurationSeconds);

        Invincible = false;
        Debug.Log("End I Frames");
    }
}
