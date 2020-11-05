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
          cd ./src/Server
          dotnet test
          cd ..
		""")
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
	stage('Docker Build') {
	  steps {
		powershell(script: 'docker-compose build')     
		powershell(script: 'docker images -a')
	  }
	}
	stage('Push Images') {
      when { branch 'master' }
      steps {
        script {
          docker.withRegistry('https://index.docker.io/v1/', 'Docker hub') {
            def image = docker.image("krisko95/body-sculptor-identity-service")
            image.push("1.0.${env.BUILD_ID}")
            image.push('latest')
          }
        }
      }
    }
  }
}

