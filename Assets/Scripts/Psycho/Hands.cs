using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    private GameControls gamecontrols;

    [SerializeField] PsychoSFXController psychoSFXController;
    [SerializeField] pauseManager PM;
    [SerializeField] ParticleSystem particleSystem;

    private SpriteRenderer handReady;
    private SpriteRenderer handReady2;
    private SpriteRenderer handStab;
    private BoxCollider2D stabCollide;

    public GameObject stabHole;

    bool particlePlayed = false;

    private float speed = 5f;
    private float stuckTime = .2f;

    void Awake()
    {
        gamecontrols = new GameControls();
        handReady = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        handReady2 = this.transform.GetChild(2).GetComponent<SpriteRenderer>();
        handStab = this.transform.GetChild(1).GetComponent<SpriteRenderer>();
        stabCollide = this.transform.GetChild(1).GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        gamecontrols.Enable();
    }

    public void OnDisable()
    {
        gamecontrols.Disable();
    }

    void Update()
    {
        float stabInput = gamecontrols.Move.Select.ReadValue<float>();
        Vector2 movementInput = gamecontrols.Move.Directions.ReadValue<Vector2>();

        Vector3 currentPosition = transform.position;
        currentPosition.x += movementInput.x * speed * Time.deltaTime;
        currentPosition.y += movementInput.y * speed * Time.deltaTime;

        if (stabInput == 0)
        {
            particlePlayed = false;
            handStab.enabled = false;
            handReady.enabled = true;
            handReady2.enabled = true;
            stabCollide.enabled = false;

            transform.position = currentPosition;
        }
        else
        {
            if (PM.IsGamePaused() == false)
            {
                if (particlePlayed == false)
                {
                    particlePlayed = true;
                    PlayAndStop();
                }
                Vector3 holePos = transform.position;
                holePos.x = transform.position.x + 1.3f;
                holePos.y = transform.position.y - .5f;
                Instantiate(stabHole, holePos, Quaternion.identity);
                handStab.enabled = true;
                handReady.enabled = false;
                handReady2.enabled = false;
                stabCollide.enabled = true;
                psychoSFXController.PlayTornPaper();
            }
        }
    }

    public void PlayAndStop()
    {
        particleSystem.Play();
        Invoke("StopParticleSystem", particleSystem.main.duration);
    }

    private void StopParticleSystem()
    {
        particleSystem.Stop();
    }

    public void removeStabHoles()
    {
        Stabhole[] allStabhole = FindObjectsOfType<Stabhole>();
        foreach (Stabhole obj in allStabhole)
        {
            if (obj.name == "SC")
            {
                Destroy(obj.gameObject);
            }
        }
    }

    public void Reset()
    {
        particlePlayed = false;
        StopParticleSystem();
    }
}
