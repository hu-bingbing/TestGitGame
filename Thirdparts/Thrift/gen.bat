@ECHO OFF
set des=..\..\Assets\Scripts\Realm

rd /s /q gen-csharp

FOR %%e IN (*.thrift) DO (
  echo gen c# %%e
  call thrift-0.10.0.exe --gen csharp %%e
  call thrift-0.10.0.exe --gen cpp %%e
)

rd /s /q %des%
md %des%

xcopy /s gen-csharp\*.* %des%

pause