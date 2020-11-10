$count = 0

$arrayApis = @("http://localhost", "http://localhost:5000/", "http://localhost:5001/Identity/Login", "http://localhost:5002/dealers/1", "http://localhost:5003/Statistics")

do {
    $count++
	
      Write-Output "[$env:STAGE_NAME] Starting container [Attempt: $count]"
	
	for($i = 0; $i -lt $arrayApis.length; $i++){ 
  
		$testStart = Invoke-WebRequest -Uri $arrayApis[$i] -UseBasicParsing
    
		if ($testStart.statuscode -eq '200' -Or $testStart.statuscode -eq '401') {
		  $started = $true
		} 
		else {
		  Start-Sleep -Seconds 5 
		}
		
	}
	
} until ($started -or ($count -eq 3))

if (!$started) {
    exit 1
}
