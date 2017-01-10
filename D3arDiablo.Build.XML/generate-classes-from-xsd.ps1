# This script imports the BuildExample.xsd and generates C# classes into the project source
$xsd = 'Resources/BuildSchema.xsd'

& "C:\Program Files (x86)\Microsoft SDKs\Windows\v8.1A\bin\NETFX 4.5.1 Tools\xsd.exe" /classes /namespace:D3arDiablo.Build.XML $xsd