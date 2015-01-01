cd /d %~dp0
cd out
del /s *.txt
del /s *.bytes
cd..
for /R %%i in (*.lua) do luajit -b %%i out\%%~nxi
cd out
ren *.lua *.lua.bytes
cd..