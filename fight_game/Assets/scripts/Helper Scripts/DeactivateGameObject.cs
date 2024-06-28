using UnityEngine;

public class DeactivateGameObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float timer = 2f;
    void Start()
    {
        Invoke("DeactivateAfterTime", timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DeactivateAfterTime()
    {
        gameObject.SetActive(false);    
    }
}
