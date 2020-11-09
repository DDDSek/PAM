pipeline {
  agent any
  stages {
    // stage('Verify Branch') {
    //   steps {
    //     echo "$GIT_BRANCH"
    //   }
    // }
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
      when { branch 'main' }
      steps {
        script {
          docker.withRegistry('https://index.docker.io/v1/', 'DockerHub') {
            
			def identityImage = docker.image("sekul/carrentalsystem_identity")
            identityImage.push('latest')
			
			def watchdogImage = docker.image("sekul/carrentalsystem_watchdog")
            watchdogImage.push('latest')
			
			def dealerImage = docker.image("sekul/carrentalsystem_dealer")
            dealerImage.push('latest')
			
			def statisticsImage = docker.image("sekul/carrentalsystem_statistics")
            statisticsImage.push('latest')
			
			def notificationsImage = docker.image("sekul/carrentalsystem_notifications")
            notificationsImage.push('latest')
			
			def adminImage = docker.image("sekul/carrentalsystem_admin")
            adminImage.push('latest') 
			
			def clientImage = docker.image("sekul/angular-client")
            clientImage.push('latest') 
          }
        }
      }
    }
  }
}
