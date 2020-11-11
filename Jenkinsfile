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
	      echo "Build Successfull You can deploy"
	    }
	    failure {
	      echo "Build Failed You will receive an e-mail"
	    }
      }
    }
    stage('Push Images') {
      when { branch 'master' } 
      steps {						
            script {
		     docker.withRegistry('https://index.docker.io/v1/', 'Docker Hub') {           
				def identityImage = docker.image("sekul/carrentalsystem_identity")
				identityImage.push('latest')
			  }
			
			  docker.withRegistry('https://index.docker.io/v1/', 'Docker Hub') {		
				def watchdogImage = docker.image("sekul/carrentalsystem_watchdog")
				watchdogImage.push('latest')
			  }
			
			  docker.withRegistry('https://index.docker.io/v1/', 'Docker Hub') {				
				def dealerImage = docker.image("sekul/carrentalsystem_dealer")
				dealerImage.push('latest')
			  }
			
			  docker.withRegistry('https://index.docker.io/v1/', 'Docker Hub') {			
				def statisticsImage = docker.image("sekul/carrentalsystem_statistics")
				statisticsImage.push('latest')
			  }	

			  docker.withRegistry('https://index.docker.io/v1/', 'Docker Hub') {			
				def notificationsImage = docker.image("sekul/carrentalsystem_notifications")
				notificationsImage.push('latest')
			  }	

			  docker.withRegistry('https://index.docker.io/v1/', 'Docker Hub') {			
				def adminImage = docker.image("sekul/carrentalsystem_admin")
				adminImage.push('latest') 
			  }
			
			  docker.withRegistry('https://index.docker.io/v1/', 'Docker Hub') {	
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
		
    }
