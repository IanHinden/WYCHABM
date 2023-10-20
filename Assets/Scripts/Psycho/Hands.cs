using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    private GameControls gamecontrols;

    private SpriteRenderer handReady;
    private SpriteRenderer handReady2;
    private SpriteRenderer handStab;
    private BoxCollider2D stabCollide;

    public GameObject stabHole;

    private float speed = 5f;
    // Start is called before the first frame update
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

    private void OnDisable()
    {
        gamecontrols.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        float stabInput = gamecontrols.Move.Select.ReadValue<float>();
        Vector2 movementInput = gamecontrols.Move.Directions.ReadValue<Vector2>();

        Vector3 currentPosition = transform.position;
        currentPosition.x += movementInput.x * speed * Time.deltaTime;
        currentPosition.y += movementInput.y * speed * Time.deltaTime;

        if (stabInput == 0)
        {
            handStab.enabled = false;
            handReady.enabled = true;
            handReady2.enabled = true;
            stabCollide.enabled = false;

            transform.position = currentPosition;
        } else
        {
            Vector3 holePos = transform.position;
            holePos.x = transform.position.x + .75f;
            holePos.y = transform.position.y - 1.9f;
            Instantiate(stabHole, holePos, Quaternion.identity);
            handStab.enabled = true;
            handReady.enabled = false;
            handReady2.enabled = false;
            stabCollide.enabled = true;
        }
    }

    public void removeStabHoles()
    {
        Stabhole[] allStabhole = FindObjectsOfType<Stabhole>();
        foreach (Stabhole obj in allStabhole)
        {
            Destroy(obj.gameObject);
        }
    }
}
