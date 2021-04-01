# “Pneumonia Auto diagnosis” web application


## Overview, Problem Description

Due to the spread of coronavirus in the world, the possibility of early diagnosis of pneumonia is becoming increasingly important. In addition, the epidemic highlighted a shortage of medical staff, so automatic pneumonia diagnostics could save specialists time and help the pandemic overcome.

## Suggested Solution / Design

As a possible solution of the pneumonia diagnostic problem, a “Pneumonia Auto diagnosis” web application can be implemented. This application will predict the positive or negative 
diagnostic result(“Status”) based on the patient's characteristics.

![image](https://user-images.githubusercontent.com/29300927/113260582-1c93bc00-92d7-11eb-9ab5-5ad0fbed0c4e.png)

## Prerequisites

* NodeJS
* .NET 5.0
* Docker
* Azure subscripton

## Installation

1. Use the package manager [npm](https://www.npmjs.com/package/npm) to install packages of React application.
```bash
cd react-client-app
npm install
```
2. Use [dotnet](https://dotnet.microsoft.com/download) command to restore packages of .Net application.
```bash
cd PneumoniaAutoDiagnosis
dotnet restore
```
## Usage

1. Run React application.
```bash
cd react-client-app
npm start
```
2. Run .Net application.
```bash
cd PneumoniaAutoDiagnosis
dotnet build
```
Navigate to http://localhost:3000/ and verify application is running.

## Deployment

1. Deploy .Net application as Azure web service.
2. Navigate to react-client-app\src\appsettings.js and change 'url' parametr to your Azure web service. Rebuild React application.
3. Run there commands in 'react-client-app' folder to create React application image and deploy it to Docker Hub: 
```bash
docker build -t pad-client .
docker tag  <your image id> <your DH login name>/pad-client
docker login --username=<your DH login name>
docker push <your DH login name>/pad-client
```
4. Navigate to Azure portal. Create a new Kubernetes cluster. Start Azure CLI and run this command: 
```bash
kubectl code create-react-client-container.yaml
```
Copy react-client-app\docker-compose.yaml to Azure CLI, change 'image' setting to your DH image name, save. 

```bash
kubectl apply -f create-react-client-container.yaml
kubectl get service
```
Navigate to External IP of created service and verify application is running.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License

Public
