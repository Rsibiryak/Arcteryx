set Version=3.9.1
REM work set ServerPath=D:\WorkSpace\Github\Arcteryx\packages\selenium-server-standalone.3.9.1.1\jar
REM work set DriverPath=D:\WorkSpace\Github\Arcteryx\packages\Selenium.Chrome.WebDriver.74.0.0\driver
         
set ServerPath=F:\Selenium\Git\Arcteryx\Arcteryx\packages\selenium-server-standalone.3.9.1.1\jar
set DriverPath=F:\Selenium\Git\Arcteryx\Arcteryx\packages\Selenium.Chrome.WebDriver.74.0.0\driver

java -Dwebdriver.chrome.driver=%DriverPath%\chromedriver.exe -jar %ServerPath%\selenium-server-standalone-%Version%.jar -role node -hub http://localhost:4444/grid/register -port 5002 -browser browserName=chrome,version=75.0.3770.80,maxInstances=3,platform=WINDOWS


