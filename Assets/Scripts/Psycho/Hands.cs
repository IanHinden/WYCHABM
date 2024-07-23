using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    private GameControls gamecontrols;

    [SerializeField] PsychoSFXController psychoSFXController;
    [SerializeField] pauseManager PM;

    private SpriteRenderer handReady;
    private SpriteRenderer handReady2;
    private SpriteRenderer handStab;
    private BoxCollider2D stabCollide;

    public GameObject stabHole;

    private Coroutine wobbleCo;

    private float speed = 5f;
    private float stuckTime = .2f;
    private bool inRoutine = false;
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

    public void OnDisable()
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

        if (inRoutine == false)
        {
            if (stabInput == 0)
            {
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
                    Vector3 holePos = transform.position;
                    holePos.x = transform.position.x + 1.3f;
                    holePos.y = transform.position.y - .5f;
                    GameObject stabholeCopy = Instantiate(stabHole, holePos, Quaternion.identity);
                    stabholeCopy.name = "SC";
                    wobbleCo = StartCoroutine(stabRoutine());
                    psychoSFXController.PlayTornPaper();
                }
            }
        }
    }

    public void StopWobbleCo()
    {
        StopCoroutine(wobbleCo);
        inRoutine = false;
    }

    private IEnumerator stabRoutine()
    {
        inRoutine = true;
        Vector3 initialPosition = this.gameObject.transform.position;
        float shakeSpeed = 100f;
        float shakeDistance = 0.08f;

        gamecontrols.Disable();
        handStab.enabled = true;
        handReady.enabled = false;
        handReady2.enabled = false;
        stabCollide.enabled = true;
        yield return new WaitForSeconds(stuckTime);

        float elapsedTime = 0;
        while (elapsedTime < stuckTime)
        {
            float offset = Mathf.Sin(elapsedTime * shakeSpeed) * shakeDistance;
            transform.position = initialPosition + new Vector3(offset, 0, 0);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = initialPosition;

        psychoSFXController.PlayPop();
        handStab.enabled = false;
        handReady.enabled = true;
        handReady2.enabled = true;
        stabCollide.enabled = false;
        inRoutine = false;
        gamecontrols.Enable();
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
        inRoutine = false;
    }
}
