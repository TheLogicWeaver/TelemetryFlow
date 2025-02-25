📡 Azure IoT Data Ingestion Pipeline
🧠 Project Overview
This project simulates IoT devices sending telemetry data (temperature & humidity) to Azure IoT Hub, processes and stores it in Azure Data Explorer (ADX), and visualizes insights using Power BI. It showcases an end-to-end real-time data ingestion pipeline suitable for MedTech, Manufacturing, and Supply Chain industries.

🎯 Purpose
To demonstrate the implementation of a scalable IoT architecture that handles real-time data streams, supports anomaly detection, and offers actionable insights via dashboards.

🏗️ Architecture
[C# IoT Simulator] → [Azure IoT Hub] → [Azure Stream Analytics] → [Azure Data Explorer (ADX)]

IoT Device Simulator → Sends real-time telemetry data.
Azure IoT Hub → Acts as the central message broker.
Azure Stream Analytics → Processes incoming data (optional but recommended).
Azure Data Explorer (ADX) → Stores data for complex time-series queries.

💻 Tech Stack
Languages: C#, KQL (Kusto Query Language)
Cloud Services: Azure IoT Hub, Azure Data Explorer, Power BI

📁 Project Structure
TelemetryFlow/
│
├── Program.cs                 # App entry point
├── Models/
│   └── TelemetryData.cs        # Telemetry data model
│
├── Services/
│   ├── IMessageSender.cs       # Abstraction for sending messages
│   ├── IDeviceSimulator.cs     # Abstraction for device simulation
│   ├── IoTHubMessageSender.cs  # Communicates with Azure IoT Hub
│   └── DeviceSimulator.cs      # Simulates sensor data
|   └── StartupService.cs       # Service startup class
│
├── Utils/
│   └── RandomTelemetryGenerator.cs # Generates random data

💡 Potential Extensions
Add Anomaly Detection using Azure Machine Learning.
Trigger Azure Functions for real-time alerts.
Extend telemetry to include more sensors (CO2, pressure, etc.).
Power BI Integration showing real-time temperature/humidity trends
