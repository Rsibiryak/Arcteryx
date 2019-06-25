set Version=3.9.1
REM work 
set ServerPath=D:\WorkSpace\Github\Arcteryx\packages\selenium-server-standalone.3.9.1.1\jar
set DriverPath=D:\WorkSpace\Github\Arcteryx\packages\Selenium.Firefox.WebDriver.0.24.0\driver

REM home
REM set ServerPath=F:\Selenium\Git\Arcteryx\Arcteryx\packages\selenium-server-standalone.3.9.1.1\jar
REM set DriverPath=F:\Selenium\Git\Arcteryx\Arcteryx\packages\Selenium.Firefox.WebDriver.0.24.0\driver

java -Dwebdriver.gecko.driver=%DriverPath%\geckodriver.exe -jar %ServerPath%\selenium-server-standalone-%Version%.jar -role node -hub http://localhost:4444/grid/register -port 5001 -browser browserName=firefox,version=67.0.1,maxInstance=1,platform=WINDOWS 
