//Esse codigo nao foi feito por mim
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class FisicaAgua : MonoBehaviour
{
    public Rigidbody rb;
    public float dephBefSub;
    public float displacementAmt;
    public int floaters;

    public float waterDrag;
    public float waterAngularDrang;

    public WaterSurface water;

    WaterSearchParameters waterSearchParameters;
    WaterSearchResult waterSearchResult;

    private void FixedUpdate()
    {
        rb.AddForceAtPosition(Physics.gravity / floaters, transform.position, ForceMode.Acceleration);

        waterSearchParameters.startPositionWS = transform.position;

        water.ProjectPointOnWaterSurface(waterSearchParameters, out waterSearchResult);

        if (transform.position.y < waterSearchResult.projectedPositionWS.y)
        {
            float displacementMult = Mathf.Clamp01((waterSearchResult.projectedPositionWS.y - transform.position.y) / dephBefSub) * displacementAmt;

            rb.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMult, 0f), transform.position, ForceMode.Acceleration);

            rb.AddForce(displacementMult * -rb.linearVelocity * waterDrag * Time.fixedDeltaTime, ForceMode.Acceleration);

            rb.AddTorque(displacementMult * -rb.angularVelocity * waterAngularDrang * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}
