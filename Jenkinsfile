@Library('jenkins-sharedlib@feature/modularization-net-core')

import sharedlib.NetCoreJenkinsUtil

def utils = new NetCoreJenkinsUtil(this)

/* Project settings */

def project="G760"

/* Mail configuration*/

// If recipients is null the mail is sent to the person who start the job

// The mails should be separated by commas(',')

def recipients=""

def deploymentEnvironment="dev"

try {

   node {

      stage('Preparation') {

        cleanWs()

        utils.notifyByMail('START',recipients)

        checkout scm

        utils.prepare()

        //Setup parameters

        env.project="${project}"

        env.deploymentEnvironment = "${deploymentEnvironment}"

        utils.setNetCoreVersion("NETCORE_50")

        //Línea de código para habilitar la opción de obtener credenciales desde Hashicorp Vault      

        utils.setHashicorpVaultEnabled(false)

        //Línea de código para establecer el valor del ambiente de Hashicorp Vault

        utils.setHashicorpVaultEnvironment("dev")

        utils.setSonarQualityGateValidationEnabled(false)

 

      }

      stage('Build & U.Test') {

        utils.build("/p:PublishProfile=WebDeploy")

      }

      /*stage('QA Analisys') {

        utils.executeQA()

      }

               stage('SAST Analisys') {

        utils.executeSast()

      }*/

    /*  stage('Upload Artifact') {

        utils.uploadArtifact()

      }*/

      stage('Save Results') {

        utils.saveResult('zip')

      }

 


 

      stage ('Delivery to DEV'){

       

           def parameters = [

             webAppParameters : [

               resourceGroupName : "rsgreu2g760d01",

               webAppName: "wappeu2g760d01",    

             ],           

             appSettings : [

               KeyVaultName : "akvteu2g760c01"

             ]

           ]

           utils.deployWebApp(parameters)

         }

     

      stage('Post Execution') {

        utils.executePostExecutionTasks()

        utils.notifyByMail('SUCCESS',recipients)

      }

   }

}

catch(Exception e) {

   node{

      utils.executeOnErrorExecutionTasks()

      utils.notifyByMail('FAIL',recipients)

    throw e

   }

}
