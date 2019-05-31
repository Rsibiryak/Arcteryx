set Version=3.9.1
set ServerPath=D:\WorkSpace\Github\Arcteryx\packages\selenium-server-standalone.3.9.1.1\jar
set DriverPath=D:\WorkSpace\Github\Arcteryx\Arcteryx\bin\Debug

java -jar %ServerPath%\selenium-server-standalone-%Version%.jar -role node 
     -hub http://localhost:4444/grid/register -port 5558
     -browser browserName=chrome, maxInstance=3
     -Dwebdriver.chrome.driver=%DriverPath%\chromedriver.exe 

