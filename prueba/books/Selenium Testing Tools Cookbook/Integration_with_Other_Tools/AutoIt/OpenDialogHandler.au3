WinWaitActive("Open","","20")
If WinExists("Open") Then
   ControlSetText("Open","","Edit1",$CmdLine[1])
   ControlClick("Open","","&Open")
EndIf


   