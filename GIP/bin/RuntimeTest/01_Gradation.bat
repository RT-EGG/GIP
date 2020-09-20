setlocal
pushd %~dp0

call 00_Common.bat

set result_dir=%dir%\Results\01_Gradation\
if not exist %result_dir% (
    mkdir %result_dir%
)

set task_file=.\WorkSpace\01_Gradiation.json

call %bin%^
 -t %task_file%^
 -l %result_dir%log.log^
 min autocls

popd
endlocal

exit /b 0