using UnityEngine;

public class CarController : MonoBehaviour
{
    // Ссылки на колеса
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;

    // Визуальные представления колес (опционально)
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform rearLeftWheelTransform;
    public Transform rearRightWheelTransform;

    // Настройки автомобиля
    public float motorForce = 500f; // Мощность двигателя
    public float brakeForce = 500f; // Сила тормозов
    public float maxSteerAngle = 30f; // Максимальный угол поворота руля

    private Rigidbody rb;

    void Start()
    {
        // Получаем компонент RigidBody
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Управление двигателем и тормозами
        float moveInput = Input.GetAxis("Vertical"); // W/S или стрелки вверх/вниз
        float steerInput = Input.GetAxis("Horizontal"); // A/D или стрелки влево/вправо

        // Поворот передних колес
        float steerAngle = maxSteerAngle * steerInput;
        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;

        // Применение силы двигателя или тормозов
        float currentTorque = moveInput * motorForce;
        frontLeftWheelCollider.motorTorque = currentTorque;
        frontRightWheelCollider.motorTorque = currentTorque;

        // Торможение при нажатии на клавишу "Space"
        if (Input.GetKey(KeyCode.Space))
        {
            ApplyBrakes();
        }
        else
        {
            ReleaseBrakes();
        }

        // Обновляем позицию и поворот визуальных колес
        UpdateWheelPoses();
    }

    // Применение тормозной силы
    void ApplyBrakes()
    {
        frontLeftWheelCollider.brakeTorque = brakeForce;
        frontRightWheelCollider.brakeTorque = brakeForce;
        rearLeftWheelCollider.brakeTorque = brakeForce;
        rearRightWheelCollider.brakeTorque = brakeForce;
    }

    // Отключение тормозов
    void ReleaseBrakes()
    {
        frontLeftWheelCollider.brakeTorque = 0f;
        frontRightWheelCollider.brakeTorque = 0f;
        rearLeftWheelCollider.brakeTorque = 0f;
        rearRightWheelCollider.brakeTorque = 0f;
    }

    // Обновление положения визуальных колес
    void UpdateWheelPoses()
    {
        UpdateWheelPose(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheelPose(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheelPose(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateWheelPose(rearRightWheelCollider, rearRightWheelTransform);
    }

    // Обновление положения одного колеса
    void UpdateWheelPose(WheelCollider wheelCollider, Transform wheelTransform)
    {
        if (wheelTransform == null) return;

        Vector3 position;
        Quaternion rotation;
        wheelCollider.GetWorldPose(out position, out rotation);

        wheelTransform.position = position;
        wheelTransform.rotation = rotation;
    }
}