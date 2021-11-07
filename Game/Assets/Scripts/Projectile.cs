using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 ShootDirection { get; set; }
    public GameObject Sender { get; set; }
    
    [SerializeField] private AudioClip m_dyingSound;
    [SerializeField] private AudioSource m_sfxPlayer;

    private void Awake()
    {
        Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += this.ShootDirection * Time.deltaTime * 20f;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit" + other.gameObject.name);
        if (other.GetComponent<Projectile>() != null)
            return;
        
        if (other.TryGetComponent(out HealthController playerHealthController) && this.Sender != other.gameObject)
        {
            playerHealthController.TakeDamage(1);   
        }

        if (this.m_dyingSound != null)
        {
            this.m_sfxPlayer.clip = this.m_dyingSound;
            this.m_sfxPlayer.loop = false;
            this.m_sfxPlayer.Play();    
        }
        
        
        Destroy(this.gameObject);

    }
}
