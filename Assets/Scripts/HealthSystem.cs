using UnityEngine;

public class HealthSystem : MonoBehaviour {

	private int health;

	public HealthSystem(int health) {
		this.health = health;
	}

	public int GetHealth() {
		return health;
	}

	public void Damage(int damageAmount) {
		health -= damageAmount;
	}

	public void Heal(int healAmount) {
		health += healAmount;
	}
}
