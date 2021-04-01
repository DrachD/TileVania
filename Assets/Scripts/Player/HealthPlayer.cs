public class HealthPlayer : Health
{
    public override void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.SetHealth(health);

        //GameEvent.Instance.ChangeHealth(id, health);
        GameEvent.Instance.LowHealthPoint(id, health);

        if (health <= 0) Die();
    }

    protected override void Die()
    {
        countDeath++;
        GameEvent.Instance.FirstBlood(id);
        GameEvent.Instance.Death(id);
        gameObject.SetActive(false);
    }
}
