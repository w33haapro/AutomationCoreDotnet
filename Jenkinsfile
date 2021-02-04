pipeline {
    agent any
    stages {
        stage('Tests') {
            steps {
                sh returnStatus: true, script: "dotnet test \"${workspace}/Core-DotnetCore.sln\" --logger \"nunit;LogFileName=results.xml\""
                nunit failIfNoResults: true, testResultsPattern: '**/results.xml'
            }
        }
    }
}


