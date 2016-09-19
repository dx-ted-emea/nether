
param(
    # Skip dotnet restore   
    [switch] $NoRestore,
    # Only build netcoreapp/netstandard version
    [switch] $NetCoreOnly
    )

$here = Split-Path -Parent $MyInvocation.MyCommand.Path

dotnet --version

if ($NoRestore) {
    Write-Output "*** Skipping package restore"
} else {
    $buildExitCode=0

    Write-Output "*** Restoring packages"
    dotnet restore
    $buildExitCode = $LASTEXITCODE
    if ($buildExitCode -ne 0){
        Write-Output "*** Restore failed"
        exit $buildExitCode
    }
}

Write-Output ""
Write-Output "*** Building projects"
$buildExitCode=0
Get-Content "$here\build\build-order.txt" `
    | Where-Object { $_ -ne "" } `
    | ForEach-Object { 
        $temp = $_.Split("|")
        $project = $temp[0]
        $framework = $temp[1]
        Write-Output ""
        if ($NetCoreOnly){
            Write-Output "*** dotnet build --framework $framework $project"
            dotnet build --framework $framework $project
        } else{
            Write-Output "*** dotnet build $project"
            dotnet build $project
        }
        if ($LASTEXITCODE -ne 0){
            $buildExitCode = $LASTEXITCODE
        }
    }

if($buildExitCode -ne 0) {
    Write-Output ""
    Write-Output "*** Build failed"
    exit $buildExitCode
}
# TODO - think about how to handle this going forwards. e.g. xplat msbuild?
