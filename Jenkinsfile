pipeline {
  agent any
  stages {    
     stage('Verify Branch') {
       steps {
         echo "$GIT_BRANCH"
       }
     }
    stage('Run Unit Tests') {
      steps {
        powershell(script: """ 
          cd Server
          dotnet test
          cd ..
        """)
      }
    }
    stage('Docker Build') {
      steps {
        powershell(script: 'docker-compose build')     
        powershell(script: 'docker images -a')
      }
    }
    stage('Run Test Application') {
      steps {
        powershell(script: 'docker-compose up -d')    
      }
    }
    stage('Run Integration Tests') {
      steps {
        powershell(script: './Tests/ContainerTests.ps1') 
      }
    }
    stage('Stop Test Application') {
      steps {
        powershell(script: 'docker-compose down') 
        // powershell(script: 'docker volumes prune -f')   		
      }
      post {
	    success {
	      echo "Build successfull! You should deploy! :)"
	    }
	    failure {
	      echo "Build failed! You should receive an e-mail! :("
	    }
      }
    }
    stage('Push Images') {
      when { branch 'master' } 
      steps {
			script {
			  docker.withRegistry('https://index.docker.io/v1/', 'DockerHub') {           
				def identityImage = docker.image("sekul/carrentalsystem_identity")
				identityImage.push('latest')
			  }
			}

			script {
			  docker.withRegistry('https://index.docker.io/v1/', 'DockerHub') {		
				def watchdogImage = docker.image("sekul/carrentalsystem_watchdog")
				watchdogImage.push('latest')
			  }
			}

			script {
			  docker.withRegistry('https://index.docker.io/v1/', 'DockerHub') {				
				def dealerImage = docker.image("sekul/carrentalsystem_dealer")
				dealerImage.push('latest')
			  }
			}
			script {
			  docker.withRegistry('https://index.docker.io/v1/', 'DockerHub') {			
				def statisticsImage = docker.image("sekul/carrentalsystem_statistics")
				statisticsImage.push('latest')
			  }
			}	

			script {
			  docker.withRegistry('https://index.docker.io/v1/', 'DockerHub') {			
				def notificationsImage = docker.image("sekul/carrentalsystem_notifications")
				notificationsImage.push('latest')
			  }
			}	

			script {
			  docker.withRegistry('https://index.docker.io/v1/', 'DockerHub') {			
				def adminImage = docker.image("sekul/carrentalsystem_admin")
				adminImage.push('latest') 
			  }
			}	
			
			script {
			  docker.withRegistry('https://index.docker.io/v1/', 'DockerHub') {	
				def clientImage = docker.image("sekul/angular-client")
				clientImage.push('latest') 
			  }
			}
          }
        }  	  
	  
      }
	
	
	
	
post {
    failure {
        mail to: 'telerikcsharp1@gmail.com',
             subject: "Failed Pipeline: ${currentBuild.fullDisplayName}",
             body: "Something is wrong with ${env.BUILD_URL}"
    }
     success {
        mail to: 'telerikcsharp1@gmail.com',
             subject: "Success Pipeline: ${currentBuild.fullDisplayName}",
             body: "Build with ${env.BUILD_URL} succeeded"
    }
  }  
	
	
    post {
        always {
            echo 'I will always say Hello again!'
            
            emailext body: "${currentBuild.currentResult}: Job ${env.JOB_NAME} build ${env.BUILD_NUMBER}\n More info at: ${env.BUILD_URL}",
                recipientProviders: [[$class: 'DevelopersRecipientProvider'], [$class: 'RequesterRecipientProvider']],
                subject: "Jenkins Build ${currentBuild.currentResult}: Job ${env.JOB_NAME}"
            
        }
    }	
	
	
	
    }
