$value= "DefaultEndpointsProtocol=https;AccountName=persstingdatasa;AccountKey=lmFQG5/hsQwCsu8gUV73PkpVCa+ImlBhnx87Wv/NL6OGmX2dBAAmsLSrVqg4gWdab7Wmi3Vd5lEO+AStmLTD7g==;EndpointSuffix=core.windows.net"

$Bytes = [System.Text.Encoding]::UTF8.GetBytes($value)

$Base64 = [Convert]::ToBase64String($Bytes)

Write-Host $Base64