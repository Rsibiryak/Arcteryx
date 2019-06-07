set Version=3.9.1
set ServerPath=D:\WorkSpace\Github\Arcteryx\packages\selenium-server-standalone.3.9.1.1\jar
set DriverPath=D:\WorkSpace\Github\Arcteryx\packages\Selenium.Chrome.WebDriver.74.0.0\driver

java -jar %ServerPath%\selenium-server-standalone-%Version%.jar -role node -hub http://localhost:4444/grid/register -port 5002   
     -Dwebdriver.chrome.driver=%DriverPath%\chromedriver.exe
REM     -browser browserName=сhrome,maxInstance=3,platform=WINDOWS

REM Попробовать путь к хром драйверу. без ключа browser


