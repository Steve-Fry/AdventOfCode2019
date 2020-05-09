param(
	[String]
	$ProjectDir #= "D:\DEV\CSharp\Advent of Code\Advent of Code\"
	,
	[String]
	$BuildDir #= "D:\DEV\CSharp\Advent of Code\Advent of Code\bin\Debug\netcoreapp3.0\"
)

# Tricky to pass from Visual Studio PostBuild
if ($ProjectDir -match "^'(.*)'$") {
	$ProjectDir = $Matches[1]
}

if ($BuildDir -match "^'(.*)'$") {
	$BuildDir = $Matches[1]
}

Write-Output "Source: $ProjectDir"
Write-Output "Destination: $BuildDir"

# Copy the input files to the output directory
$PuzzleInputDirectory = Join-Path $BuildDir "Inputs"
New-Item -Type "Directory" -Path $PuzzleInputDirectory -ErrorAction "SilentlyContinue"
Write-Output "InputDir: $PuzzleInputDirectory"
Get-ChildItem -Path . -Recurse -Filter "*Input.txt" | 
	Where-Object {$_.DirectoryName -notmatch "^.*\\bin\\.*Inputs$"} | 
	Copy-Item -Destination $PuzzleInputDirectory -Force
