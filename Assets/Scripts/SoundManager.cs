using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [SerializeField] private AudioClip shootSound;

    [SerializeField] private AudioClip enemyHitSound;

    [SerializeField] private AudioClip enemyDeathSound;

    [SerializeField] private AudioClip playerHurtSound;

    [SerializeField] private AudioClip gameOverSound;

    [SerializeField] private AudioClip victorySound;

    [SerializeField] private AudioClip backgroundMusic;



    public void PlaySound(Vector3 position, string soundType)
    {
        AudioClip clipToPlay = null;

        if (soundType == "Shoot")
        {
            clipToPlay = shootSound;
        }
        else if (soundType == "EnemyHit")
        {
            clipToPlay = enemyHitSound;
        }
        else if (soundType == "EnemyDeath")
        {
            clipToPlay = enemyDeathSound;
        }
        else if (soundType == "PlayerHurt")
        {
            clipToPlay = playerHurtSound;
        }
        else if (soundType == "GameOver")
        {
            clipToPlay = enemyDeathSound;
        }
        else if (soundType == "Victory")
        {
            clipToPlay = victorySound;

        }
        else if (soundType == "Music")
        {
            clipToPlay = backgroundMusic;

        } else
        {
            Debug.LogError("Invalid Sound Type: " + soundType);
        }
        AudioSource.PlayClipAtPoint(clipToPlay, position);
    }
}
