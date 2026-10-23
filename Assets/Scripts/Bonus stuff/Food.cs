using UnityEngine;

public abstract class Food : MonoBehaviour, IBonusItems
{
    [SerializeField] protected int bonusScore;
    [SerializeField] protected float despawnTime;

    protected virtual void Start()
    {
        Debug.Log("A food magically appears somewhere");
    }

    protected virtual void Update()
    {
        Destroy(gameObject, despawnTime);
    }

    protected virtual void Behavior()
    {
        Debug.Log("A fine addition to my camp bag");
    }

    public int GetBonusScore()
    {
        return bonusScore;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(GetBonusScore());
            Destroy(gameObject);
        }
    }
}
