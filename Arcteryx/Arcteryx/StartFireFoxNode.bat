set Version=3.9.1
set ServerPath=D:\WorkSpace\Github\Arcteryx\packages\selenium-server-standalone.3.9.1.1\jar
set DriverPath=D:\WorkSpace\Github\Arcteryx\packages\Selenium.Firefox.WebDriver.0.24.0\driver

java -jar %ServerPath%\selenium-server-standalone-%Version%.jar -role node -port 5001
     -hub http://localhost:4444/grid/register 
     -browser browserName=firefox, maxInstance=3
     -Dwebdriver.firefox.driver=%DriverPath%\geckodriver.exe 
