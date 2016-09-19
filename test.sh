#!/bin/bash

echo
echo "*** Executing tests"

testExitCode=0

while IFS='|' read -r project framework
do
  if [ "x$project" != "x" ]
  then
    echo "*** dotnet test --framework $framework $project"
    dotnet test --framework $framework "$project"
    lastexit=$?
    if [ $lastexit -ne 0 ]
    then
      testExitCode=$lastexit
    fi
  fi
done < "build/test-order.txt"

if [ $testExitCode -ne 0 ]
then
  exit=$testExitCode
fi
