pipeline {
    agent any
    triggers {
        githubPush()
    }
    stages {
        stage('Restore packages'){
           steps{
               sh 'dotnet restore Net5.Deployment.sln'
            }
         }
        stage('Clean'){
           steps{
               sh 'dotnet clean Net5.Deployment.sln --configuration Release'
            }
         }
        stage('Build'){
           steps{
               sh 'dotnet build Net5.Deployment.sln --configuration Release --no-restore'
            }
         }
        stage('Test: Unit Test'){
           steps {
                sh 'dotnet test XUnitTestProject/XUnitTestProject.csproj --configuration Release --no-restore'
             }
          }
        stage('Publish'){
             steps{
               sh 'dotnet publish Net5.Deployment.API/Net5.Deployment.API.csproj --configuration Release --no-restore'
             }
        }
        stage('Deploy'){
             steps{
               sh '''for pid in $(lsof -t -i:9090); do
                       kill -9 $pid
               done'''
               sh 'cd Net5.Deployment.API/bin/Release/net5.0/publish/'
               sh 'nohup dotnet Net5.Deployment.API.dll --urls="http://172.24.0.1:9095" --ip="1172.24.0.1" --port=9095 --no-restore > /dev/null 2>&1 &'
             }
        }
    }
}
