# using 'posh-vs' powershell module to access visual studio tools
# link: https://github.com/olegsych/posh-vs

$nasm_path = "C:\Users\Matthew\AppData\Local\bin\NASM\nasm.exe"

if (-not(Test-Path -Path .\asm\main.exe))
{
    Write-Host "Executable not found, assembling..."
    Invoke-Expression "$nasm_path -f win32 .\asm\main.asm"
    Invoke-Expression "$nasm_path -f win32 .\asm\231Lib.asm"
    link /OUT:.\asm\main.exe /ENTRY:start /SUBSYSTEM:CONSOLE .\asm\231Lib.obj .\asm\main.obj
    Write-Host "Successfully assembled and linked!"
}

$asm_start = Get-Date
.\asm\main.exe
$asm_end = Get-Date
$asm_time = ($asm_end - $asm_start)

Write-Host "Assembler: $($asm_time.TotalSeconds) seconds"

if (-not(Test-Path -Path .\cpp\main.exe))
{
    Write-Host "C++ executable not found, compiling from source..."
    cl .\cpp\main.cpp -o .\cpp\main.exe
}
.\cpp\main.exe

java .\java\Main.java

python .\python\main.py
