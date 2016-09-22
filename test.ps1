param(
    # Only build netcoreapp/netstandard version
    [switch] $NetCoreOnly
    )

$here = Split-Path -Parent $MyInvocation.MyCommand.Path

Write-Output "*** Executing tests"
$testExitCode=0
Get-Content "$here\build\test-order.txt" `
    | Where-Object { $_ -ne "" } `
    | ForEach-Object { 
        $temp = $_.Split("|")
        $project = $temp[0]
        $framework = $temp[1]
        Write-Output ""
        if ($NetCoreOnly){
            Write-Output "*** dotnet test --framework $project"
            dotnet test --framework $framework $project
        } else {
            Write-Output "*** dotnet test $project"
            dotnet test $project
        }
        if ($LASTEXITCODE -ne 0){
            $testExitCode = $LASTEXITCODE
        }
    }

if($testExitCode -ne 0) {
    Write-Output ""
    Write-Output "*** Tests failed"
    exit $testExitCode
}