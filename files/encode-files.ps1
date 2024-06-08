$inputFile = "file2.txt"
$outputFile = "file2_base64.txt"
[Convert]::ToBase64String([System.IO.File]::ReadAllBytes($inputFile)) > $outputFile
