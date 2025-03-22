using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public Player player;  // Si necesitas acceso a los datos del jugador
    public float hookSpeed = 15f;
    public float swingForce = 10f;
    public float maxGrappleDistance = 10f;
    public LayerMask techoLayer;
    public LineRenderer lineRenderer;

    private Rigidbody2D rb;
    private Vector2 grapplePoint;
    private DistanceJoint2D distanceJoint;
    private bool isGrappling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        distanceJoint = gameObject.AddComponent<DistanceJoint2D>();
        distanceJoint.enabled = false;
        lineRenderer.positionCount = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            LanzarGancho();
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            DesanclarGancho();
        }

        DibujarCuerda();
    }

    void LanzarGancho()
    {
        // Detecta la dirección del jugador usando el movimiento horizontal
        float direccionX = Input.GetAxis("Horizontal");

        // Si el jugador va hacia la derecha (direccionX > 0), el gancho va hacia la derecha
        // Si el jugador va hacia la izquierda (direccionX < 0), el gancho va hacia la izquierda
        Vector2 direccion;

        if (direccionX > 0)  // Movimiento hacia la derecha
        {
            direccion = (transform.up + transform.right).normalized;  // Dirección diagonal hacia la derecha
        }
        else if (direccionX < 0)  // Movimiento hacia la izquierda
        {
            direccion = (transform.up - transform.right).normalized;  // Dirección diagonal hacia la izquierda
        }
        else  // Si no hay movimiento horizontal, el gancho se lanza hacia arriba
        {
            direccion = transform.up;  // Dirección vertical hacia arriba
        }

        // Hacemos el raycast en la dirección calculada
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direccion, maxGrappleDistance, techoLayer);

        if (hit.collider != null && hit.collider.CompareTag("Techo"))
        {
            grapplePoint = hit.point;  // Guarda el punto donde se engancha el gancho
            isGrappling = true;

            // Configura el DistanceJoint para engancharse al punto
            distanceJoint.enabled = true;
            distanceJoint.connectedAnchor = grapplePoint;
            distanceJoint.autoConfigureDistance = false;
            distanceJoint.distance = Vector2.Distance(transform.position, grapplePoint);
            distanceJoint.enableCollision = true;

            lineRenderer.positionCount = 2;
        }
    }

    void DesanclarGancho()
    {
        isGrappling = false;
        distanceJoint.enabled = false;
        lineRenderer.positionCount = 0;
    }

    void DibujarCuerda()
    {
        if (isGrappling)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, grapplePoint);
        }
    }

    void FixedUpdate()
    {
        if (isGrappling)
        {
            float inputHorizontal = Input.GetAxis("Horizontal");
            rb.AddForce(Vector2.right * inputHorizontal * swingForce, ForceMode2D.Force);
        }
    }
}

