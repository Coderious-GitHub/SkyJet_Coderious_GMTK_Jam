using UnityEngine;
using Pathfinding;

public class EnemyGraphics : MonoBehaviour
{
    public AIPath aiPath;
    public Animator animator;

    GameManager manager;

    int maxHealth = 100;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        manager = FindObjectOfType<GameManager>();
    }

    public void TakeDamage(int dmg)
    { 
        if(manager.c && manager.t && manager.r && manager.l)
        {
            currentHealth -= dmg;
        }


        if (currentHealth < 0)
        {
            gameObject.transform.parent.gameObject.SetActive(false);
            Time.timeScale = 0;
            manager.victoryPanel.SetActive(true);
        }
    }

    public void Die()
    {

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("xSpeed", aiPath.desiredVelocity.x);
        animator.SetFloat("ySpeed", aiPath.desiredVelocity.y);

        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);

        } else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
